using System;
using System.Data;
using System.Windows.Forms;
using StudyProcessManagement.Business.Admin;

namespace StudyProcessManagement.Views.Admin.Course
{
    public partial class CourseVerificationForm : Form
    {
        private ContentService contentService;
        private string _courseId;

        // ✅ CONSTRUCTOR MẶC ĐỊNH CHO DESIGNER (BẮT BUỘC)
        public CourseVerificationForm()
        {
            InitializeComponent();

            // CHẶN DESIGNER - Không làm gì thêm
            if (this.DesignMode) return;
        }

        // ✅ CONSTRUCTOR THỰC SỰ (Dùng khi gọi từ code)
        public CourseVerificationForm(string courseId, string courseName) : this()
        {
            // CHẶN nếu đang trong Design Mode
            if (this.DesignMode) return;

            // Khởi tạo Service
            contentService = new ContentService();
            _courseId = courseId;

            // Cập nhật tiêu đề
            if (!string.IsNullOrEmpty(courseName))
            {
                lblTitle.Text = $"DUYỆT: {courseName.ToUpper()}";
            }

            // Load dữ liệu
            if (!string.IsNullOrEmpty(_courseId))
            {
                LoadTreeData();
            }

            // Gán sự kiện (nếu chưa gán trong Designer)
            btnApprove.Click += BtnApprove_Click;
            tvContent.AfterSelect += TvContent_AfterSelect;
        }

        private void LoadTreeData()
        {
            try
            {
                tvContent.Nodes.Clear();
                DataTable dtSections = contentService.GetSections(_courseId);

                foreach (DataRow secRow in dtSections.Rows)
                {
                    string secId = secRow["SectionID"].ToString();
                    TreeNode secNode = new TreeNode($"📂 {secRow["SectionTitle"]}");
                    secNode.Tag = "SECTION";

                    DataTable dtLessons = contentService.GetLessons(secId);
                    foreach (DataRow lesRow in dtLessons.Rows)
                    {
                        TreeNode lesNode = new TreeNode($"📄 {lesRow["LessonTitle"]}");
                        lesNode.Tag = lesRow["LessonID"].ToString();
                        secNode.Nodes.Add(lesNode);
                    }
                    tvContent.Nodes.Add(secNode);
                }
                tvContent.ExpandAll();
            }
            catch (Exception ex)
            {
                if (!this.DesignMode)
                {
                    MessageBox.Show("Lỗi tải dữ liệu: " + ex.Message);
                }
            }
        }

        private void TvContent_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Tag == null) return;

            if (e.Node.Tag.ToString() == "SECTION")
            {
                ClearDetail();
                return;
            }

            string lessonId = e.Node.Tag.ToString();
            DataRow lesson = contentService.GetLessonDetail(lessonId);

            if (lesson != null)
            {
                txtLessonName.Text = lesson["LessonTitle"].ToString();
                txtContent.Text = lesson["Content"].ToString();
                txtVideo.Text = lesson["VideoUrl"].ToString();
            }
        }

        private void ClearDetail()
        {
            txtLessonName.Clear();
            txtContent.Clear();
            txtVideo.Clear();
        }

        private void BtnApprove_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_courseId)) return;

            if (MessageBox.Show("Xác nhận DUYỆT khóa học này?", "Xác nhận",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (contentService.ApproveCourse(_courseId))
                {
                    MessageBox.Show("Đã duyệt thành công!");
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Lỗi khi duyệt!");
                }
            }
        }
    }
}