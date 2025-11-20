using System;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using StudyProcessManagement.Business.Teacher;

namespace StudyProcessManagement.Views.Teacher.Forms
{
    public partial class GradeSubmissionForm : Form
    {
        private string submissionID;
        private bool isViewOnly;
        private string attachmentPath = "";
        private GradeSubmissionFormService service;

        public GradeSubmissionForm(string submissionID, bool isViewOnly = false)
        {
            InitializeComponent();
            this.submissionID = submissionID;
            this.isViewOnly = isViewOnly;
            this.service = new GradeSubmissionFormService();

            LoadSubmissionData();

            if (isViewOnly)
            {
                SetReadOnlyMode();
            }
        }

        private void LoadSubmissionData()
        {
            try
            {
                DataTable dt = service.GetSubmissionDetails(submissionID);

                if (dt.Rows.Count > 0)
                {
                    DataRow row = dt.Rows[0];

                    // ✅ Load thông tin - Đọc đúng tên cột trong DB
                    lblStudentValue.Text = row["StudentName"].ToString();
                    lblAssignmentValue.Text = row["AssignmentTitle"].ToString();
                    lblCourseValue.Text = row["CourseName"].ToString();

                    // Load thông tin bài nộp
                    lblSubmitDateValue.Text = Convert.ToDateTime(row["SubmissionDate"]).ToString("dd/MM/yyyy HH:mm");
                    lblDueDateValue.Text = Convert.ToDateTime(row["DueDate"]).ToString("dd/MM/yyyy");

                    // ✅ Đọc StudentNote (không phải SubmissionText)
                    txtSubmissionText.Text = row["StudentNote"]?.ToString() ?? "";

                    // Load mô tả bài tập
                    txtAssignmentDescription.Text = row["AssignmentDescription"]?.ToString() ?? "";

                    // ✅ Load file đính kèm - Đọc FileUrl (không phải AttachmentUrl)
                    attachmentPath = row["FileUrl"]?.ToString() ?? "";
                    lblAttachmentValue.Text = string.IsNullOrEmpty(attachmentPath)
                        ? "Không có file đính kèm"
                        : Path.GetFileName(attachmentPath);

                    // Load điểm và phản hồi (nếu đã chấm)
                    if (row["Score"] != DBNull.Value)
                    {
                        numScore.Value = Convert.ToDecimal(row["Score"]);
                    }

                    // ✅ Đọc TeacherFeedback (không phải Feedback)
                    if (row["TeacherFeedback"] != DBNull.Value)
                    {
                        txtFeedback.Text = row["TeacherFeedback"].ToString();
                    }

                    // Hiển thị điểm tối đa
                    lblMaxScoreValue.Text = "/ " + row["MaxScore"].ToString();
                }
                else
                {
                    MessageBox.Show("Không tìm thấy thông tin bài nộp!", "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // Validate điểm
            if (numScore.Value < 0 || numScore.Value > 10)
            {
                MessageBox.Show("Điểm số phải từ 0 đến 10!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                numScore.Focus();
                return;
            }

            // Validate ID
            if (string.IsNullOrEmpty(submissionID))
            {
                MessageBox.Show("Lỗi: Không tìm thấy ID bài nộp!", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                // Gọi service để lưu
                bool success = service.GradeSubmission(submissionID, numScore.Value, txtFeedback.Text.Trim());

                if (success)
                {
                    MessageBox.Show("Chấm điểm thành công!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Không thể cập nhật bài nộp!", "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lưu: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnOpenFile_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(attachmentPath))
            {
                try
                {
                    if (File.Exists(attachmentPath))
                    {
                        Process.Start(new ProcessStartInfo
                        {
                            FileName = attachmentPath,
                            UseShellExecute = true
                        });
                    }
                    else
                    {
                        MessageBox.Show("File không tồn tại: " + attachmentPath, "Lỗi",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Không thể mở file: " + ex.Message, "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Không có file đính kèm.", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
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
