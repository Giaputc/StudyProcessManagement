using System;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace StudyProcessManagement.Views.Teacher.Forms
{
    public partial class GradeSubmissionForm : Form
    {
        // ============================================
        // PRIVATE FIELDS
        // ============================================
        private string connectionString = "Data Source=DESKTOP-FO9OMBO;Initial Catalog=StudyProcess;Integrated Security=True";
        private string submissionID;
        private bool isViewOnly;
        private string attachmentPath = "";

        // ============================================
        // CONSTRUCTORS
        // ============================================
        public GradeSubmissionForm(string submissionID, bool isViewOnly = false)
        {
            InitializeComponent();
            this.submissionID = submissionID;
            this.isViewOnly = isViewOnly;
            LoadSubmissionData();

            if (isViewOnly)
            {
                SetReadOnlyMode();
            }
        }

        // ============================================
        // EVENT HANDLERS
        // ============================================
        private void btnOpenFile_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(attachmentPath))
            {
                try
                {
                    Process.Start(new ProcessStartInfo
                    {
                        FileName = attachmentPath,
                        UseShellExecute = true
                    });
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Không thể mở file: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Không có file đính kèm.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // 1. Validate điểm
            if (numScore.Value < 0 || numScore.Value > 10)
            {
                MessageBox.Show("Điểm số phải từ 0 đến 10!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                numScore.Focus();
                return;
            }

            // 2. Validate ID
            if (string.IsNullOrEmpty(submissionID))
            {
                MessageBox.Show("Lỗi: Không tìm thấy ID bài nộp!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // 3. Validate phản hồi (optional warning)
            if (string.IsNullOrWhiteSpace(txtFeedback.Text))
            {
                if (MessageBox.Show("Bạn chưa nhập phản hồi. Tiếp tục lưu?", "Xác nhận",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    txtFeedback.Focus();
                    return;
                }
            }

            // 4. DEBUG: Hiển thị thông tin trước khi lưu
            string debugInfo = $"SubmissionID: {submissionID}\n" +
                               $"Score: {numScore.Value}\n" +
                               $"Feedback length: {txtFeedback.Text.Length}";

            System.Diagnostics.Debug.WriteLine(debugInfo);

            // 5. Kiểm tra xem bài nộp có tồn tại không TRƯỚC KHI UPDATE
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    // Kiểm tra bài nộp có tồn tại không
                    string checkQuery = "SELECT COUNT(*) FROM Submissions WHERE SubmissionID = @SubmissionID";
                    using (SqlCommand checkCmd = new SqlCommand(checkQuery, conn))
                    {
                        checkCmd.Parameters.Add("@SubmissionID", SqlDbType.Int).Value = Convert.ToInt32(submissionID);
                        int count = (int)checkCmd.ExecuteScalar();

                        if (count == 0)
                        {
                            MessageBox.Show($"Không tìm thấy bài nộp với ID: {submissionID}\n\n" +
                                            "Vui lòng kiểm tra lại dữ liệu!",
                                            "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }

                    // Thực hiện UPDATE
                    using (SqlCommand cmd = new SqlCommand("spGradeSubmission", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.Add("@SubmissionID", SqlDbType.Int).Value = Convert.ToInt32(submissionID);
                        cmd.Parameters.Add("@Score", SqlDbType.Decimal).Value = numScore.Value;
                        cmd.Parameters.Add("@TeacherFeedback", SqlDbType.NVarChar).Value = txtFeedback.Text.Trim();

                        // Debug: In ra các parameters
                        System.Diagnostics.Debug.WriteLine("=== PARAMETERS ===");
                        foreach (SqlParameter param in cmd.Parameters)
                        {
                            System.Diagnostics.Debug.WriteLine($"{param.ParameterName} = {param.Value} ({param.SqlDbType})");
                        }

                        int rows = cmd.ExecuteNonQuery();

                        System.Diagnostics.Debug.WriteLine($"Rows affected: {rows}");

                        if (rows > 0)
                        {
                            MessageBox.Show("Chấm điểm thành công!", "Thông báo",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.DialogResult = DialogResult.OK;
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show($"Không thể cập nhật bài nộp!\n\n" +
                                            $"SubmissionID: {submissionID}\n" +
                                            $"Rows affected: {rows}\n\n" +
                                            "Vui lòng kiểm tra stored procedure hoặc dữ liệu!",
                                            "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
            }
            catch (SqlException sqlEx)
            {
                MessageBox.Show($"Lỗi database: {sqlEx.Message}\n\n" +
                                $"Error Number: {sqlEx.Number}\n" +
                                $"Line Number: {sqlEx.LineNumber}\n\n" +
                                $"Chi tiết: {sqlEx.ToString()}",
                                "Lỗi SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi lưu: {ex.Message}\n\n" +
                                $"Chi tiết: {ex.ToString()}",
                                "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        // ============================================
        // PRIVATE METHODS
        // ============================================
        private void LoadSubmissionData()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    string query = @"
                        SELECT 
                            s.SubmissionID,
                            s.SubmissionDate,
                            s.StudentNote,
                            s.FileUrl,
                            s.Score,
                            s.TeacherFeedback,
                            u.FullName AS StudentName,
                            a.Title AS AssignmentTitle,
                            a.Description AS AssignmentDescription,
                            a.MaxScore,
                            a.DueDate,
                            c.CourseName
                        FROM Submissions s
                        INNER JOIN Users u ON s.StudentID = u.UserID
                        INNER JOIN Assignments a ON s.AssignmentID = a.AssignmentID
                        INNER JOIN Courses c ON a.CourseID = c.CourseID
                        WHERE s.SubmissionID = @SubmissionID";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        // ✅ SỬA: Đổi kiểu parameter từ VarChar sang Int
                        cmd.Parameters.Add("@SubmissionID", SqlDbType.Int).Value = Convert.ToInt32(submissionID);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // ✅ SỬA: Đổi tên controls theo Designer
                                // Load thông tin sinh viên và bài tập
                                lblStudentValue.Text = reader["StudentName"].ToString();
                                lblAssignmentValue.Text = reader["AssignmentTitle"].ToString();
                                lblCourseValue.Text = reader["CourseName"].ToString();

                                // Load thông tin bài nộp
                                lblSubmitDateValue.Text = Convert.ToDateTime(reader["SubmissionDate"]).ToString("dd/MM/yyyy HH:mm");
                                lblDueDateValue.Text = Convert.ToDateTime(reader["DueDate"]).ToString("dd/MM/yyyy");

                                // ✅ SỬA: Đổi tên từ txtStudentNote sang txtSubmissionText
                                txtSubmissionText.Text = reader["StudentNote"]?.ToString() ?? "";

                                // ✅ SỬA: Mô tả bài tập
                                txtAssignmentDescription.Text = reader["AssignmentDescription"]?.ToString() ?? "";

                                // Load file đính kèm
                                attachmentPath = reader["FileUrl"]?.ToString() ?? "";
                                // ✅ SỬA: Đổi tên từ lblFileName sang lblAttachmentValue
                                lblAttachmentValue.Text = string.IsNullOrEmpty(attachmentPath)
                                    ? "Không có file đính kèm"
                                    : Path.GetFileName(attachmentPath);

                                // Load điểm và phản hồi (nếu đã chấm)
                                if (!reader.IsDBNull(reader.GetOrdinal("Score")))
                                {
                                    numScore.Value = Convert.ToDecimal(reader["Score"]);
                                }

                                if (!reader.IsDBNull(reader.GetOrdinal("TeacherFeedback")))
                                {
                                    txtFeedback.Text = reader["TeacherFeedback"].ToString();
                                }

                                // Hiển thị điểm tối đa
                                // ✅ SỬA: Đổi tên từ lblMaxScore sang lblMaxScoreValue
                                lblMaxScoreValue.Text = "/ " + reader["MaxScore"].ToString();
                            }
                            else
                            {
                                MessageBox.Show("Không tìm thấy thông tin bài nộp!", "Lỗi",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                                this.Close();
                            }
                        }
                    }
                }
            }
            catch (SqlException sqlEx)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu: " + sqlEx.Message, "Lỗi SQL",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }

        private void SetReadOnlyMode()
        {
            numScore.Enabled = false;
            txtFeedback.ReadOnly = true;
            btnSave.Visible = false;
            btnCancel.Text = "Đóng";
        }
    }
}
