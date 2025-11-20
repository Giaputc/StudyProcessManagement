using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace StudyProcessManagement.Views.Teacher.Forms
{
    public partial class AssignmentForm : Form
    {
        // ============================================
        // PRIVATE FIELDS
        // ============================================
        private string connectionString = "Server=DESKTOP-FO9OMBO;Database=StudyProcess;Integrated Security=true;";
        private string currentTeacherID = "USR002";
        private string assignmentID;
        private bool isEditMode = false;
        private string attachmentFilePath = "";

        // ============================================
        // CONSTRUCTORS
        // ============================================
        public AssignmentForm()
        {
            InitializeComponent();
            this.Text = "Tạo bài tập mới";
            isEditMode = false;
            LoadCourses();
        }

        public AssignmentForm(string assignmentID)
        {
            InitializeComponent();
            this.assignmentID = assignmentID;
            this.Text = "Chỉnh sửa bài tập";
            isEditMode = true;
            LoadCourses();
            LoadAssignmentData();
        }

        // ============================================
        // PRIVATE METHODS
        // ============================================
        private void LoadCourses()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("sp_GetTeacherCourses", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@TeacherID", currentTeacherID);

                    SqlDataReader reader = cmd.ExecuteReader();
                    cboCourse.Items.Clear();

                    while (reader.Read())
                    {
                        cboCourse.Items.Add(new CourseItem
                        {
                            CourseID = reader["CourseID"].ToString(),
                            CourseName = reader["CourseName"].ToString()
                        });
                    }

                    if (cboCourse.Items.Count > 0)
                    {
                        cboCourse.DisplayMember = "CourseName";
                        cboCourse.ValueMember = "CourseID";
                        cboCourse.SelectedIndex = 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải khóa học: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadAssignmentData()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = @"SELECT CourseID, Title, Description, AssignedDate, 
                                    DueDate, MaxScore, AttachmentPath FROM Assignments 
                                    WHERE AssignmentID = @ID";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@ID", assignmentID);

                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        string courseID = reader["CourseID"].ToString();
                        for (int i = 0; i < cboCourse.Items.Count; i++)
                        {
                            CourseItem item = (CourseItem)cboCourse.Items[i];
                            if (item.CourseID == courseID)
                            {
                                cboCourse.SelectedIndex = i;
                                break;
                            }
                        }

                        txtTitle.Text = reader["Title"].ToString();
                        txtDescription.Text = reader["Description"].ToString();
                        dtpAssignedDate.Value = Convert.ToDateTime(reader["AssignedDate"]);
                        dtpDueDate.Value = Convert.ToDateTime(reader["DueDate"]);
                        numMaxScore.Value = Convert.ToDecimal(reader["MaxScore"]);

                        if (reader["AttachmentPath"] != DBNull.Value)
                        {
                            attachmentFilePath = reader["AttachmentPath"].ToString();
                            txtAttachment.Text = System.IO.Path.GetFileName(attachmentFilePath);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải thông tin bài tập: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ============================================
        // EVENT HANDLERS
        // ============================================
        private void btnBrowse_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Word Documents (*.docx)|*.docx|Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
                openFileDialog.FilterIndex = 1;
                openFileDialog.Title = "Chọn file đính kèm cho bài tập";
                openFileDialog.Multiselect = false;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    attachmentFilePath = openFileDialog.FileName;
                    txtAttachment.Text = System.IO.Path.GetFileName(attachmentFilePath);

                    MessageBox.Show($"Đã chọn file: {txtAttachment.Text}",
                        "Thông tin", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (cboCourse.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng chọn khóa học!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboCourse.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtTitle.Text))
            {
                MessageBox.Show("Vui lòng nhập tên bài tập!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTitle.Focus();
                return;
            }

            if (dtpDueDate.Value <= dtpAssignedDate.Value)
            {
                MessageBox.Show("Hạn nộp phải sau ngày giao bài!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dtpDueDate.Focus();
                return;
            }

            try
            {
                CourseItem selectedCourse = (CourseItem)cboCourse.SelectedItem;

                string savedFilePath = null;
                if (!string.IsNullOrEmpty(attachmentFilePath) && System.IO.File.Exists(attachmentFilePath))
                {
                    string attachmentFolder = System.IO.Path.Combine(
                        Application.StartupPath, "Attachments", "Assignments");

                    if (!System.IO.Directory.Exists(attachmentFolder))
                    {
                        System.IO.Directory.CreateDirectory(attachmentFolder);
                    }

                    string tempAssignmentID = assignmentID ?? ("ASM" + DateTime.Now.ToString("yyyyMMddHHmmss"));
                    string fileName = $"{tempAssignmentID}_{System.IO.Path.GetFileName(attachmentFilePath)}";
                    savedFilePath = System.IO.Path.Combine(attachmentFolder, fileName);

                    System.IO.File.Copy(attachmentFilePath, savedFilePath, true);
                }

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query;

                    if (isEditMode)
                    {
                        query = @"UPDATE Assignments SET 
                                CourseID = @CourseID,
                                Title = @Title,
                                Description = @Description,
                                AssignedDate = @AssignedDate,
                                DueDate = @DueDate,
                                MaxScore = @MaxScore,
                                AttachmentPath = @AttachmentPath
                                WHERE AssignmentID = @AssignmentID";
                    }
                    else
                    {
                        query = @"INSERT INTO Assignments 
                                (AssignmentID, CourseID, Title, Description, AssignedDate, DueDate, MaxScore, AttachmentPath) 
                                VALUES (@AssignmentID, @CourseID, @Title, @Description, @AssignedDate, @DueDate, @MaxScore, @AttachmentPath)";

                        assignmentID = "ASM" + DateTime.Now.ToString("yyyyMMddHHmmss");
                    }

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@AssignmentID", assignmentID);
                    cmd.Parameters.AddWithValue("@CourseID", selectedCourse.CourseID);
                    cmd.Parameters.AddWithValue("@Title", txtTitle.Text.Trim());
                    cmd.Parameters.AddWithValue("@Description", txtDescription.Text.Trim());
                    cmd.Parameters.AddWithValue("@AssignedDate", dtpAssignedDate.Value.Date);
                    cmd.Parameters.AddWithValue("@DueDate", dtpDueDate.Value.Date);
                    cmd.Parameters.AddWithValue("@MaxScore", numMaxScore.Value);
                    cmd.Parameters.AddWithValue("@AttachmentPath",
                        string.IsNullOrEmpty(savedFilePath) ? (object)DBNull.Value : savedFilePath);

                    cmd.ExecuteNonQuery();

                    MessageBox.Show(
                        isEditMode ? "Cập nhật bài tập thành công!" : "Tạo bài tập mới thành công!",
                        "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lưu bài tập: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ============================================
        // NESTED CLASSES
        // ============================================
        private class CourseItem
        {
            public string CourseID { get; set; }
            public string CourseName { get; set; }
        }
    }
}
