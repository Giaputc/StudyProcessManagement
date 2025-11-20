using System;
using System.Data;
using System.Windows.Forms;
using StudyProcessManagement.Business.Teacher;

namespace StudyProcessManagement.Views.Teacher.Forms
{
    public partial class AssignmentForm : Form
    {
        private AssignmentFormService assignmentFormService;
        private string currentTeacherID = "USR002";
        private int assignmentID;
        private bool isEditMode = false;

        public AssignmentForm()
        {
            InitializeComponent();
            assignmentFormService = new AssignmentFormService();
            this.Text = "Tạo bài tập mới";
            isEditMode = false;
            dtpAssignedDate.Value = DateTime.Now;
            dtpDueDate.Value = DateTime.Now.AddDays(7);
            LoadCourses();
        }

        public AssignmentForm(int assignmentID)
        {
            InitializeComponent();
            assignmentFormService = new AssignmentFormService();
            this.assignmentID = assignmentID;
            this.Text = "Chỉnh sửa bài tập";
            isEditMode = true;
            LoadCourses();
            LoadAssignment(assignmentID);
        }

        private void LoadCourses()
        {
            DataTable dt = assignmentFormService.GetTeacherCourses(currentTeacherID);
            cboCourse.DataSource = dt;
            cboCourse.DisplayMember = "CourseName";
            cboCourse.ValueMember = "CourseID";
        }

        private void LoadAssignment(int id)
        {
            DataTable dt = assignmentFormService.GetAssignmentDetails(id);
            if (dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0];
                cboCourse.SelectedValue = Convert.ToInt32(row["CourseID"]);
                txtTitle.Text = row["Title"].ToString();
                txtDescription.Text = row["Description"].ToString();
                dtpAssignedDate.Value = Convert.ToDateTime(row["AssignedDate"]);
                dtpDueDate.Value = Convert.ToDateTime(row["DueDate"]);
                numMaxScore.Value = Convert.ToDecimal(row["MaxScore"]);
                txtAttachment.Text = row["AttachmentPath"]?.ToString() ?? "";
            }
            else
            {
                MessageBox.Show("Không tìm thấy thông tin bài tập!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }

        // Đúng tên hàm dựa theo Designer.cs !
        private void btnBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog { Filter = "Tất cả các tệp|*.*" };
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                txtAttachment.Text = ofd.FileName;
            }
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            int courseID = Convert.ToInt32(cboCourse.SelectedValue);
            string title = txtTitle.Text.Trim();
            string description = txtDescription.Text.Trim();
            DateTime assignedDate = dtpAssignedDate.Value;
            DateTime dueDate = dtpDueDate.Value;
            decimal maxScore = numMaxScore.Value;
            string attachmentPath = txtAttachment.Text.Trim();

            if (string.IsNullOrEmpty(title))
            {
                MessageBox.Show("Tên bài tập không được để trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                bool result = false;
                if (isEditMode)
                {
                    result = assignmentFormService.UpdateAssignment(
                        assignmentID, courseID, title, description, assignedDate, dueDate, maxScore, attachmentPath
                    );
                }
                else
                {
                    assignmentFormService.CreateAssignment(
                        courseID, title, description, assignedDate, dueDate, maxScore, attachmentPath
                    );
                    result = true;
                }

                if (result)
                {
                    MessageBox.Show("Lưu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Lưu thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
