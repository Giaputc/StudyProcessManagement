using System;
using System.Data;
using System.Drawing;
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

        // =============================================
        // CONSTRUCTOR: CHẾ ĐỘ THÊM MỚI
        // =============================================
        public CourseForm()
        {
            InitializeComponent();
            courseFormService = new CourseFormService();
            this.Text = "Thêm khóa học mới";
            lblFormTitle.Text = "THÊM KHÓA HỌC MỚI";
            isEditMode = false;

            // ✅ ẨN PHẦN STATUS KHI THÊM MỚI
            lblStatus.Visible = false;
            cboStatus.Visible = false;

            LoadCategories();
        }

        // =============================================
        // CONSTRUCTOR: CHẾ ĐỘ CHỈNH SỬA
        // =============================================
        public CourseForm(int courseID)
        {
            InitializeComponent();
            courseFormService = new CourseFormService();
            this.courseID = courseID;
            this.Text = "Chỉnh sửa khóa học";
            lblFormTitle.Text = "CHỈNH SỬA KHÓA HỌC";
            isEditMode = true;

            // ✅ HIỂN THỊ STATUS NHƯNG DISABLED (CHỈ ĐỌC)
            lblStatus.Text = "Trạng thái (chỉ Admin được sửa)";
            lblStatus.ForeColor = Color.FromArgb(100, 100, 100);
            cboStatus.Enabled = false;
            cboStatus.BackColor = Color.WhiteSmoke;
            cboStatus.ForeColor = Color.FromArgb(60, 60, 60);

            LoadCategories();
            LoadCourseData();
        }

        // =============================================
        // LOAD CATEGORIES
        // =============================================
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
                        CategoryID = row["CategoryID"].ToString(),
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

        // =============================================
        // LOAD COURSE DATA (CHẾ ĐỘ CHỈNH SỬA)
        // =============================================
        private void LoadCourseData()
        {
            try
            {
                DataTable dt = courseFormService.GetCourseDetails(courseID);

                if (dt.Rows.Count > 0)
                {
                    DataRow row = dt.Rows[0];

                    // Load thông tin cơ bản
                    txtCourseName.Text = row["CourseName"].ToString();
                    txtDescription.Text = row["Description"].ToString();
                    txtImageCover.Text = row["ImageCover"] != DBNull.Value ? row["ImageCover"].ToString() : "";

                    // Select category
                    string categoryID = row["CategoryID"].ToString();
                    for (int i = 0; i < cboCategory.Items.Count; i++)
                    {
                        CategoryItem item = (CategoryItem)cboCategory.Items[i];
                        if (item.CategoryID == categoryID)
                        {
                            cboCategory.SelectedIndex = i;
                            break;
                        }
                    }

                    // ✅ MAPPING STATUS: DATABASE (TIẾNG ANH) → UI (TIẾNG VIỆT)
                    string statusInDB = row["Status"] != DBNull.Value ? row["Status"].ToString() : "Pending";
                    string displayStatus = MapStatusToVietnamese(statusInDB);
                    Color statusColor = GetStatusColor(statusInDB);

                    // Hiển thị trạng thái với màu sắc
                    cboStatus.Items.Clear();
                    cboStatus.Items.Add(displayStatus);
                    cboStatus.SelectedIndex = 0;
                    cboStatus.ForeColor = statusColor;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải thông tin khóa học: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // =============================================
        // MAPPING: TIẾNG ANH → TIẾNG VIỆT
        // =============================================
        /// <summary>
        /// Chuyển đổi trạng thái từ tiếng Anh (database) sang tiếng Việt (UI)
        /// </summary>
        private string MapStatusToVietnamese(string statusInDB)
        {
            if (string.IsNullOrEmpty(statusInDB))
                return "⏳ Chờ duyệt";

            switch (statusInDB.Trim().ToLower())
            {
                case "pending":
                    return "⏳ Chờ duyệt";

                case "approved":
                    return "✅ Đã duyệt";

                case "active":
                    return "✅ Đang hoạt động";

                case "inactive":
                    return "⏸️ Tạm dừng";

                case "draft":
                    return "📝 Nháp";

                case "suspended":
                    return "🚫 Đã đình chỉ";

                default:
                    // Nếu không khớp case nào, trả về nguyên văn với emoji mặc định
                    return "❓ " + statusInDB;
            }
        }

        // =============================================
        // LẤY MÀU SẮC THEO TRẠNG THÁI
        // =============================================
        /// <summary>
        /// Lấy màu sắc hiển thị cho từng trạng thái
        /// </summary>
        private Color GetStatusColor(string statusInDB)
        {
            if (string.IsNullOrEmpty(statusInDB))
                return Color.Orange;

            switch (statusInDB.Trim().ToLower())
            {
                case "pending":
                    return Color.FromArgb(230, 126, 34);  // Cam

                case "approved":
                case "active":
                    return Color.FromArgb(39, 174, 96);   // Xanh lá

                case "inactive":
                    return Color.FromArgb(127, 140, 141); // Xám

                case "draft":
                    return Color.FromArgb(52, 152, 219);  // Xanh dương

                case "suspended":
                    return Color.FromArgb(192, 57, 43);   // Đỏ

                default:
                    return Color.Black;
            }
        }

        // =============================================
        // BROWSE IMAGE
        // =============================================
        private void btnBrowseImage_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
                "Chức năng upload ảnh đang được phát triển!\n" +
                "Hiện tại vui lòng nhập URL ảnh.",
                "Thông báo",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        // =============================================
        // LƯU KHÓA HỌC
        // =============================================
        private void btnSave_Click(object sender, EventArgs e)
        {
            // ===== VALIDATION =====
            if (string.IsNullOrWhiteSpace(txtCourseName.Text))
            {
                MessageBox.Show(
                    "Vui lòng nhập tên khóa học!",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                txtCourseName.Focus();
                return;
            }

            if (cboCategory.SelectedItem == null)
            {
                MessageBox.Show(
                    "Vui lòng chọn danh mục!",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                cboCategory.Focus();
                return;
            }

            try
            {
                CategoryItem selectedCategory = (CategoryItem)cboCategory.SelectedItem;

                if (isEditMode)
                {
                    // ===== CHẾ ĐỘ CHỈNH SỬA =====
                    // ✅ KHÔNG GỬI STATUS - Giữ nguyên trạng thái hiện tại
                    bool success = courseFormService.UpdateCourse(
                        courseID,
                        selectedCategory.CategoryID,
                        txtCourseName.Text.Trim(),
                        txtDescription.Text.Trim(),
                        currentTeacherID,
                        txtImageCover.Text.Trim()
                    );

                    if (success)
                    {
                        MessageBox.Show(
                            "Cập nhật khóa học thành công!",
                            "Thành công",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);

                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show(
                            "Không thể cập nhật khóa học!\n" +
                            "Vui lòng kiểm tra lại thông tin.",
                            "Lỗi",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                    }
                }
                else
                {
                    // ===== CHẾ ĐỘ THÊM MỚI =====
                    // ✅ TỰ ĐỘNG SET Status = "Pending" Ở SERVICE
                    int newCourseID = courseFormService.CreateCourse(
                        selectedCategory.CategoryID,
                        txtCourseName.Text.Trim(),
                        txtDescription.Text.Trim(),
                        currentTeacherID,
                        txtImageCover.Text.Trim()
                    );

                    if (newCourseID > 0)
                    {
                        MessageBox.Show(
                            "🎉 Thêm khóa học mới thành công!\n\n" +
                            "📌 Trạng thái: Chờ duyệt\n" +
                            "👉 Khóa học của bạn đang chờ Admin xét duyệt\n" +
                            "⏰ Admin sẽ xem xét và duyệt sớm nhất có thể\n\n" +
                            $"🆔 Mã khóa học: {newCourseID}",
                            "Thành công",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);

                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show(
                            "Không thể tạo khóa học!\n" +
                            "Vui lòng kiểm tra lại thông tin.",
                            "Lỗi",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Lỗi khi lưu khóa học:\n" + ex.Message,
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // =============================================
        // INNER CLASS: CATEGORY ITEM
        // =============================================
        private class CategoryItem
        {
            public string CategoryID { get; set; }
            public string CategoryName { get; set; }

            public override string ToString()
            {
                return CategoryName;
            }
        }
    }
}