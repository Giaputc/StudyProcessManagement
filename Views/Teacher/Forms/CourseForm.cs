using System;
using System.Data;
using System.Windows.Forms;
using StudyProcessManagement.Business.Teacher;

namespace StudyProcessManagement.Views.Teacher.Forms
{
    public partial class CourseForm : Form
    {
        private CourseFormService courseFormService;
        private string currentTeacherID = "USR002";
        private int courseID;
        private bool isEditMode = false;

        public CourseForm()
        {
            InitializeComponent();
            courseFormService = new CourseFormService();
            this.Text = "Thêm khóa học mới";
            lblFormTitle.Text = "THÊM KHÓA HỌC MỚI";
            isEditMode = false;

            if (cboStatus.Items.Count > 0)
                cboStatus.SelectedIndex = 0;

            LoadCategories();
        }

        public CourseForm(int courseID)
        {
            InitializeComponent();
            courseFormService = new CourseFormService();
            this.courseID = courseID;
            this.Text = "Chỉnh sửa khóa học";
            lblFormTitle.Text = "CHỈNH SỬA KHÓA HỌC";
            isEditMode = true;

            LoadCategories();
            LoadCourseData();
        }

        private void LoadCategories()
        {
            try
            {
                DataTable dt = courseFormService.GetAllCategories();

                cboCategory.Items.Clear();
                foreach (DataRow row in dt.Rows)
                {
                    cboCategory.Items.Add(new CategoryItem
                    {
                        CategoryID = row["CategoryID"].ToString(),  // ✅ STRING
                        CategoryName = row["CategoryName"].ToString()
                    });
                }

                if (cboCategory.Items.Count > 0)
                {
                    cboCategory.DisplayMember = "CategoryName";
                    cboCategory.ValueMember = "CategoryID";
                    cboCategory.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải danh mục: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadCourseData()
        {
            try
            {
                DataTable dt = courseFormService.GetCourseDetails(courseID);

                if (dt.Rows.Count > 0)
                {
                    DataRow row = dt.Rows[0];

                    txtCourseName.Text = row["CourseName"].ToString();
                    txtDescription.Text = row["Description"].ToString();
                    txtImageCover.Text = row["ImageCover"] != DBNull.Value ? row["ImageCover"].ToString() : "";

                    // Select category
                    string categoryID = row["CategoryID"].ToString();  // ✅ STRING
                    for (int i = 0; i < cboCategory.Items.Count; i++)
                    {
                        CategoryItem item = (CategoryItem)cboCategory.Items[i];
                        if (item.CategoryID == categoryID)
                        {
                            cboCategory.SelectedIndex = i;
                            break;
                        }
                    }

                    string status = row["Status"] != DBNull.Value ? row["Status"].ToString() : "Active";
                    cboStatus.SelectedItem = status;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải thông tin khóa học: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBrowseImage_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Chức năng upload ảnh đang được phát triển!\nHiện tại vui lòng nhập URL ảnh.",
                "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCourseName.Text))
            {
                MessageBox.Show("Vui lòng nhập tên khóa học!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCourseName.Focus();
                return;
            }

            if (cboCategory.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng chọn danh mục!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboCategory.Focus();
                return;
            }

            try
            {
                CategoryItem selectedCategory = (CategoryItem)cboCategory.SelectedItem;

                if (isEditMode)
                {
                    bool success = courseFormService.UpdateCourse(
                        courseID,                          // ✅ INT
                        selectedCategory.CategoryID,       // ✅ STRING
                        txtCourseName.Text.Trim(),
                        txtDescription.Text.Trim(),
                        currentTeacherID,                  // ✅ STRING
                        txtImageCover.Text.Trim(),
                        cboStatus.SelectedItem.ToString()
                    );

                    if (success)
                    {
                        MessageBox.Show("Cập nhật khóa học thành công!", "Thành công",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                }
                else
                {
                    int newCourseID = courseFormService.CreateCourse(
                        selectedCategory.CategoryID,       // ✅ STRING
                        txtCourseName.Text.Trim(),
                        txtDescription.Text.Trim(),
                        currentTeacherID,                  // ✅ STRING
                        txtImageCover.Text.Trim(),
                        cboStatus.SelectedItem.ToString()
                    );

                    if (newCourseID > 0)
                    {
                        MessageBox.Show($"Thêm khóa học mới thành công! ID: {newCourseID}", "Thành công",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lưu khóa học: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private class CategoryItem
        {
            public string CategoryID { get; set; }      // ✅ STRING
            public string CategoryName { get; set; }
        }
    }
}
