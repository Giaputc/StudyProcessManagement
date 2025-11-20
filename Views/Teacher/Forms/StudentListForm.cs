using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace StudyProcessManagement.Views.Teacher.Forms
{
    public partial class StudentListForm : Form
    {
        private string connectionString = "Server=DESKTOP-FO9OMBO;Database=StudyProcess;Integrated Security=true;";
        private string courseID;
        private string courseName;

        public StudentListForm(string courseID, string courseName)
        {
            this.courseID = courseID;
            this.courseName = courseName;
            InitializeComponent();
            LoadStudents();
        }

        private void LoadStudents()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    string query = @"
                        SELECT 
                            ROW_NUMBER() OVER (ORDER BY e.EnrollmentDate DESC) AS STT,
                            e.StudentID,
                            u.FullName,
                            a.Email,
                            e.EnrollmentDate,
                            ISNULL(e.ProgressPercent, 0) AS ProgressPercent,
                            ISNULL(e.Status, N'Learning') AS Status
                        FROM Enrollments e
                        INNER JOIN Users u ON e.StudentID = u.UserID
                        INNER JOIN Accounts a ON u.AccountID = a.AccountID
                        WHERE e.CourseID = @CourseID
                        ORDER BY e.EnrollmentDate DESC";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@CourseID", courseID);

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

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
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải danh sách học viên: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvStudents_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex < 0) return;

            // Progress column
            if (e.ColumnIndex == dgvStudents.Columns["colProgress"].Index)
            {
                e.Handled = true;
                e.PaintBackground(e.CellBounds, true);

                string progressText = dgvStudents.Rows[e.RowIndex].Cells["colProgress"].Value?.ToString();
                if (!string.IsNullOrEmpty(progressText))
                {
                    int progress = int.Parse(progressText.Replace("%", ""));

                    Color progressColor = progress >= 80 ? Color.FromArgb(76, 175, 80) :
                                         progress >= 50 ? Color.FromArgb(255, 193, 7) :
                                         Color.FromArgb(244, 67, 54);

                    Rectangle barRect = new Rectangle(
                        e.CellBounds.X + 5,
                        e.CellBounds.Y + (e.CellBounds.Height - 18) / 2,
                        e.CellBounds.Width - 10, 18);

                    using (SolidBrush bgBrush = new SolidBrush(Color.FromArgb(230, 230, 230)))
                        e.Graphics.FillRectangle(bgBrush, barRect);

                    int fillWidth = (int)(barRect.Width * progress / 100.0);
                    using (SolidBrush fillBrush = new SolidBrush(progressColor))
                        e.Graphics.FillRectangle(fillBrush, new Rectangle(barRect.X, barRect.Y, fillWidth, barRect.Height));

                    using (Font font = new Font("Segoe UI", 7F, FontStyle.Bold))
                    using (SolidBrush textBrush = new SolidBrush(Color.White))
                    {
                        StringFormat sf = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center };
                        e.Graphics.DrawString(progressText, font, textBrush, barRect, sf);
                    }
                }
            }

            // Status column
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

                    using (System.Drawing.Drawing2D.GraphicsPath path = GetRoundedRectPath(badgeRect, 12))
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

        private System.Drawing.Drawing2D.GraphicsPath GetRoundedRectPath(Rectangle rect, int radius)
        {
            System.Drawing.Drawing2D.GraphicsPath path = new System.Drawing.Drawing2D.GraphicsPath();
            path.AddArc(rect.X, rect.Y, radius, radius, 180, 90);
            path.AddArc(rect.Right - radius, rect.Y, radius, radius, 270, 90);
            path.AddArc(rect.Right - radius, rect.Bottom - radius, radius, radius, 0, 90);
            path.AddArc(rect.X, rect.Bottom - radius, radius, radius, 90, 90);
            path.CloseFigure();
            return path;
        }
    }
}
