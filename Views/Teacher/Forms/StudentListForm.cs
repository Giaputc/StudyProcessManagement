using System;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using StudyProcessManagement.Business.Teacher;

namespace StudyProcessManagement.Views.Teacher.Forms
{
    public partial class StudentListForm : Form
    {
        // ============================================
        // PRIVATE FIELDS
        // ============================================

        // ✅ Dùng Service riêng cho Form
        private StudentListFormService studentListFormService;
        private string courseID;
        private string courseName;

        // ============================================
        // CONSTRUCTOR
        // ============================================

        public StudentListForm(string courseID, string courseName)
        {
            this.courseID = courseID;
            this.courseName = courseName;

            InitializeComponent();

            // ✅ Khởi tạo Service
            studentListFormService = new StudentListFormService();

            // Set course info
            lblCourseInfo.Text = $"Khóa học: {courseName}";

            LoadStudents();
        }

        // ============================================
        // ✅ LOAD DATA - GỌI SERVICE
        // ============================================

        private void LoadStudents()
        {
            try
            {
                // ✅ Gọi Service
                DataTable dt = studentListFormService.GetEnrolledStudents(courseID);

                dgvStudents.Rows.Clear();

                if (dt.Rows.Count == 0)
                {
                    lblTitle.Text = "📊 Danh sách học viên (Chưa có học viên)";
                }
                else
                {
                    lblTitle.Text = $"📊 Danh sách học viên ({dt.Rows.Count} học viên)";

                    foreach (DataRow row in dt.Rows)
                    {
                        int progress = Convert.ToInt32(row["ProgressPercent"]);

                        dgvStudents.Rows.Add(
                            row["STT"],
                            row["StudentID"],
                            row["FullName"],
                            row["Email"],
                            Convert.ToDateTime(row["EnrollmentDate"]).ToString("dd/MM/yyyy"),
                            progress + "%",
                            row["Status"]
                        );
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải danh sách học viên: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ============================================
        // DATAGRIDVIEW CUSTOM PAINTING
        // ============================================

        private void dgvStudents_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex < 0) return;

            // Paint Progress column with progress bar
            if (e.ColumnIndex == dgvStudents.Columns["colProgress"].Index)
            {
                e.Handled = true;
                e.PaintBackground(e.CellBounds, true);

                string progressText = dgvStudents.Rows[e.RowIndex].Cells["colProgress"].Value?.ToString();
                if (!string.IsNullOrEmpty(progressText))
                {
                    int progress = int.Parse(progressText.Replace("%", ""));

                    // Color based on progress
                    Color progressColor = progress >= 80 ? Color.FromArgb(76, 175, 80) :
                                         progress >= 50 ? Color.FromArgb(255, 193, 7) :
                                         Color.FromArgb(244, 67, 54);

                    Rectangle barRect = new Rectangle(
                        e.CellBounds.X + 5,
                        e.CellBounds.Y + (e.CellBounds.Height - 18) / 2,
                        e.CellBounds.Width - 10, 18);

                    // Background
                    using (SolidBrush bgBrush = new SolidBrush(Color.FromArgb(230, 230, 230)))
                        e.Graphics.FillRectangle(bgBrush, barRect);

                    // Fill
                    int fillWidth = (int)(barRect.Width * progress / 100.0);
                    using (SolidBrush fillBrush = new SolidBrush(progressColor))
                        e.Graphics.FillRectangle(fillBrush, new Rectangle(barRect.X, barRect.Y, fillWidth, barRect.Height));

                    // Text
                    using (Font font = new Font("Segoe UI", 7F, FontStyle.Bold))
                    using (SolidBrush textBrush = new SolidBrush(Color.White))
                    {
                        StringFormat sf = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center };
                        e.Graphics.DrawString(progressText, font, textBrush, barRect, sf);
                    }
                }
            }

            // Paint Status column with badge
            if (e.ColumnIndex == dgvStudents.Columns["colStatus"].Index)
            {
                e.Handled = true;
                e.PaintBackground(e.CellBounds, true);

                string status = dgvStudents.Rows[e.RowIndex].Cells["colStatus"].Value?.ToString();
                if (!string.IsNullOrEmpty(status))
                {
                    Color badgeColor = status == "Learning" ? Color.FromArgb(33, 150, 243) :
                                      status == "Completed" ? Color.FromArgb(76, 175, 80) :
                                      Color.FromArgb(255, 152, 0);

                    Rectangle badgeRect = new Rectangle(
                        e.CellBounds.X + 5,
                        e.CellBounds.Y + (e.CellBounds.Height - 24) / 2,
                        e.CellBounds.Width - 10, 24);

                    using (GraphicsPath path = GetRoundedRectPath(badgeRect, 12))
                    using (SolidBrush brush = new SolidBrush(badgeColor))
                        e.Graphics.FillPath(brush, path);

                    using (Font font = new Font("Segoe UI", 7F, FontStyle.Bold))
                    using (SolidBrush textBrush = new SolidBrush(Color.White))
                    {
                        StringFormat sf = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center };
                        e.Graphics.DrawString(status, font, textBrush, badgeRect, sf);
                    }
                }
            }
        }

        // ============================================
        // HELPER METHODS
        // ============================================

        private GraphicsPath GetRoundedRectPath(Rectangle rect, int radius)
        {
            GraphicsPath path = new GraphicsPath();
            path.AddArc(rect.X, rect.Y, radius, radius, 180, 90);
            path.AddArc(rect.Right - radius, rect.Y, radius, radius, 270, 90);
            path.AddArc(rect.Right - radius, rect.Bottom - radius, radius, radius, 0, 90);
            path.AddArc(rect.X, rect.Bottom - radius, radius, radius, 90, 90);
            path.CloseFigure();
            return path;
        }
    }
}
