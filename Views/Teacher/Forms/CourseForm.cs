using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace StudyProcessManagement.Views.Teacher.Forms
{
    public partial class CourseForm : Form
    {
        // ============================================
        // PRIVATE FIELDS
        // ============================================
        private string connectionString = "Server=DESKTOP-FO9OMBO;Database=StudyProcess;Integrated Security=true;";
        private string currentTeacherID = "USR002";
        private string courseID;
        private bool isEditMode = false;

        // ============================================
        // CONSTRUCTORS
        // ============================================
        public CourseForm()
        {
            InitializeComponent();
            this.Text = "Thêm khóa học mới";
            lblFormTitle.Text = "THÊM KHÓA HỌC MỚI";
            isEditMode = false;
            LoadCategories();
        }

        public CourseForm(string courseID)
        {
            InitializeComponent();
            this.courseID = courseID;
            this.Text = "Chỉnh sửa khóa học";
            lblFormTitle.Text = "CHỈNH SỬA KHÓA HỌC";
            isEditMode = true;
            LoadCategories();
            LoadCourseData();
        }

        // ============================================
        // PRIVATE METHODS
        // ============================================

        private void LoadCategories()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT CategoryID, CategoryName FROM Categories ORDER BY CategoryName";
                    SqlCommand cmd = new SqlCommand(query, conn);

                    cboCategory.Items.Clear();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        cboCategory.Items.Add(new CategoryItem
                        {
                            CategoryID = reader["CategoryID"].ToString(),
                            CategoryName = reader["CategoryName"].ToString()
                        });
                    }

                    if (cboCategory.Items.Count > 0)
                    {
                        cboCategory.DisplayMember = "CategoryName";
                        cboCategory.ValueMember = "CategoryID";
                        cboCategory.SelectedIndex = 0;
                    }
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
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT CourseName, Description, CategoryID, ImageCover, Status FROM Courses WHERE CourseID = @CourseID";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@CourseID", courseID);

                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        txtCourseName.Text = reader["CourseName"].ToString();
                        txtDescription.Text = reader["Description"].ToString();
                        txtImageCover.Text = reader["ImageCover"] != DBNull.Value ? reader["ImageCover"].ToString() : "";

                        string categoryID = reader["CategoryID"].ToString();
                        for (int i = 0; i < cboCategory.Items.Count; i++)
                        {
                            CategoryItem item = (CategoryItem)cboCategory.Items[i];
                            if (item.CategoryID == categoryID)
                            {
                                cboCategory.SelectedIndex = i;
                                break;
                            }
                        }

                        string status = reader["Status"] != DBNull.Value ? reader["Status"].ToString() : "Active";
                        cboStatus.SelectedItem = status;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải thông tin khóa học: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ============================================
        // EVENT HANDLERS
        // ============================================

        private void btnBrowseImage_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Chức năng upload ảnh đang được phát triển!\nHiện tại vui lòng nhập URL ảnh.",
                "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // Validation
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

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query;

                    if (isEditMode)
                    {
                        query = @"UPDATE Courses SET 
                                CourseName = @CourseName,
                                Description = @Description,
                                CategoryID = @CategoryID,
                                ImageCover = @ImageCover,
                                Status = @Status
                                WHERE CourseID = @CourseID AND TeacherID = @TeacherID";
                    }
                    else
                    {
                        courseID = "CRS" + DateTime.Now.ToString("yyyyMMddHHmmss");
                        query = @"INSERT INTO Courses 
                                (CourseID, CourseName, Description, CategoryID, TeacherID, ImageCover, Status, TotalLessons, CreatedAt) 
                                VALUES (@CourseID, @CourseName, @Description, @CategoryID, @TeacherID, @ImageCover, @Status, 0, GETDATE())";
                    }

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@CourseID", courseID);
                    cmd.Parameters.AddWithValue("@CourseName", txtCourseName.Text.Trim());
                    cmd.Parameters.AddWithValue("@Description", txtDescription.Text.Trim());
                    cmd.Parameters.AddWithValue("@CategoryID", selectedCategory.CategoryID);
                    cmd.Parameters.AddWithValue("@TeacherID", currentTeacherID);
                    cmd.Parameters.AddWithValue("@ImageCover", string.IsNullOrWhiteSpace(txtImageCover.Text) ? (object)DBNull.Value : txtImageCover.Text.Trim());
                    cmd.Parameters.AddWithValue("@Status", cboStatus.SelectedItem.ToString());

                    cmd.ExecuteNonQuery();

                    MessageBox.Show(
                        isEditMode ? "Cập nhật khóa học thành công!" : "Thêm khóa học mới thành công!",
                        "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lưu khóa học: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ============================================
        // NESTED CLASSES
        // ============================================

        private class CategoryItem
        {
            public string CategoryID { get; set; }
            public string CategoryName { get; set; }
        }
    }
}
