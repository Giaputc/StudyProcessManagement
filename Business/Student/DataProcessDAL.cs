using StudyProcessManagement.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static StudyProcessManagement.Data.StudentSession;
using System.Configuration;
namespace StudyProcessManagement.Business
{
    internal class DataProcess
    {
        //string strCon = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=StudyProcess;Integrated Security=True";
        string strCon = ConfigurationManager.ConnectionStrings["StudyProcessConnection"].ConnectionString;
        SqlConnection sqlCon = null;
        List<string> thongTinCaNhanSV = new List<string>();

        // =============================================
        // PHƯƠNG THỨC KẾT NỐI (Giữ nguyên theo code bạn cung cấp)
        // =============================================
        private void OpenConnection()
        {
            if (sqlCon == null)
            {
                sqlCon = new SqlConnection(strCon);
            }
            if (sqlCon.State == ConnectionState.Closed)
            {
                sqlCon.Open();
            }
        }

        private void CloseConnection()
        {
            if (sqlCon != null && sqlCon.State == ConnectionState.Open)
            {
                sqlCon.Close();
                // Tùy chọn: sqlCon.Dispose(); sqlCon = null; nếu bạn muốn quản lý tài nguyên chặt chẽ hơn
            }
        }


        // =============================================
        // PHƯƠNG THỨC TRUY CẬP DỮ LIỆU CHUNG (GENERIC DAL)
        // =============================================

        /// <summary>
        /// Thực thi truy vấn SELECT và trả về DataTable (Cần cho DashboardService)
        /// </summary>
        public DataTable ReadData(string query, Dictionary<string, object> parameters)
        {
            DataTable dt = new DataTable();
            try
            {
                OpenConnection();

                using (SqlCommand sqlCmd = new SqlCommand(query, sqlCon))
                {
                    // Thêm tham số
                    if (parameters != null)
                    {
                        foreach (var param in parameters)
                        {
                            sqlCmd.Parameters.AddWithValue(param.Key, param.Value ?? DBNull.Value);
                        }
                    }

                    using (SqlDataAdapter da = new SqlDataAdapter(sqlCmd))
                    {
                        da.Fill(dt);
                    }
                }
            }
            catch (Exception ex)
            {
                // Thường nên ném lỗi lên tầng Business/Service để xử lý hoặc ghi log
                throw new Exception("Lỗi đọc dữ liệu trong ReadData: " + ex.Message);
            }
            finally
            {
                CloseConnection();
            }
            return dt;
        }

        /// <summary>
        /// Thực thi truy vấn SELECT không tham số.
        /// </summary>
        public DataTable ReadData(string query)
        {
            // Tái sử dụng hàm ReadData có tham số, truyền Dictionary rỗng/null
            return ReadData(query, null);
        }

        /// <summary>
        /// Thực thi lệnh INSERT, UPDATE, DELETE (ChangeData)
        /// </summary>
        public bool ChangeData(string query, Dictionary<string, object> parameters)
        {
            try
            {
                OpenConnection();
                using (SqlCommand sqlCmd = new SqlCommand(query, sqlCon))
                {
                    if (parameters != null)
                    {
                        foreach (var param in parameters)
                        {
                            sqlCmd.Parameters.AddWithValue(param.Key, param.Value ?? DBNull.Value);
                        }
                    }
                    sqlCmd.ExecuteNonQuery();
                }
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi thực thi lệnh ChangeData: " + ex.Message);
            }
            finally
            {
                CloseConnection();
            }
        }

        // Tạo alias cho UpdateData (Thường thấy trong các dự án cũ)
        public bool UpdateData(string query, Dictionary<string, object> parameters)
        {
            return ChangeData(query, parameters);
        }

        /// <summary>
        /// Thực thi Stored Procedure và trả về DataTable (Tương tự ReadData)
        /// </summary>
        public DataTable ExecuteStoredProcedure(string spName, Dictionary<string, object> parameters)
        {
            DataTable dt = new DataTable();
            try
            {
                OpenConnection();
                using (SqlCommand cmd = new SqlCommand(spName, sqlCon))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    if (parameters != null)
                    {
                        foreach (var param in parameters)
                        {
                            cmd.Parameters.AddWithValue(param.Key, param.Value ?? DBNull.Value);
                        }
                    }
                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        adapter.Fill(dt);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi thực thi stored procedure: " + ex.Message);
            }
            finally
            {
                CloseConnection();
            }
            return dt;
        }
        public StudentInfoModel LoginAndGetStudentInfo(string email, string passwordHash)
        {

            StudentInfoModel studentInfo = null;
            string sqlQuery = @"
        SELECT 
            u.UserID, u.FullName, acc.Email, u.PhoneNumber, 
            u.AvatarUrl, u.DateOfBirth, u.Address
        FROM Accounts acc
        INNER JOIN Users u ON acc.AccountID = u.AccountID
        WHERE acc.Email = @Email          -- Tham số cho Email
          AND acc.PasswordHash = @PasswordHash -- Tham số cho Mật khẩu đã Hash
          AND acc.Role = 'Student';";//

            try
            {
                OpenConnection();

                using (SqlCommand sqlCmd = new SqlCommand(sqlQuery, sqlCon))
                {
                    sqlCmd.Parameters.AddWithValue("@Email", email);
                    sqlCmd.Parameters.AddWithValue("@PasswordHash", passwordHash);
                    using (SqlDataReader reader = sqlCmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {

                            studentInfo = new StudentInfoModel
                            {
                                UserID = reader["UserID"].ToString(),
                                FullName = reader["FullName"].ToString(),
                                Email = reader["Email"].ToString(),
                                PhoneNumber = reader["PhoneNumber"].ToString(),

                                AvatarUrl = reader["AvatarUrl"] == DBNull.Value ? null : reader["AvatarUrl"].ToString(),
                                DateOfBirth = reader["DateOfBirth"] == DBNull.Value
                                    ? (DateTime?)null
                                    : (DateTime)reader["DateOfBirth"],
                                Address = reader["Address"].ToString()
                            };
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Lỗi truy vấn SQL: " + ex.Message);
            }
            finally
            {
                if (sqlCon != null && sqlCon.State == ConnectionState.Open)
                {
                    sqlCon.Close();
                }
            }
            return studentInfo;
        }
        public List<StudentContent> GetAllResources(string studentId)
        {
            List<StudentContent> resources = new List<StudentContent>();
            string spName = "sp_GetAllResourcesForStudent";

            try
            {
                OpenConnection(); // Mở kết nối

                using (SqlCommand cmd = new SqlCommand(spName, sqlCon))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@StudentID", studentId);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            resources.Add(new StudentContent
                            {
                                // === Thông tin Tài nguyên Cơ bản ===
                                LoaiTaiNguyen = reader["LoaiTaiNguyen"].ToString(),
                                ResourceID = Convert.ToInt32(reader["ResourceID"]), // Giả định không NULL
                                TenTaiNguyen = reader["TenTaiNguyen"].ToString(),
                                MoTa = reader["MoTa"] == DBNull.Value ? null : reader["MoTa"].ToString(),

                                // === Thông tin Liên kết (Links) ===
                                LinkVideo = reader["LinkVideo"] == DBNull.Value ? null : reader["LinkVideo"].ToString(),
                                LinkTaiLieu = reader["LinkTaiLieu"] == DBNull.Value ? null : reader["LinkTaiLieu"].ToString(),
                                LoaiChiTiet = reader["LoaiChiTiet"].ToString(),

                                // === Thông tin Khóa học và Chương ===
                                CourseID = Convert.ToInt32(reader["CourseID"]), // Giả định không NULL
                                TenKhoaHoc = reader["TenKhoaHoc"].ToString(),
                                AnhKhoaHoc = reader["AnhKhoaHoc"] == DBNull.Value ? null : reader["AnhKhoaHoc"].ToString(),

                                // SectionID là kiểu int? (Nullable int)
                                SectionID = reader["SectionID"] == DBNull.Value ? (int?)null : Convert.ToInt32(reader["SectionID"]),

                                TenChuong = reader["TenChuong"].ToString(),
                                TenGiangVien = reader["TenGiangVien"].ToString(),

                                // === Trạng thái và Sắp xếp ===
                                TrangThai = reader["TrangThai"].ToString(),

                                // NgayDang là kiểu DateTime? (Nullable DateTime)
                                NgayDang = reader["NgayDang"] == DBNull.Value ? (DateTime?)null : (DateTime)reader["NgayDang"],

                                ThuTuChuong = Convert.ToInt32(reader["ThuTuChuong"]), // Giả định không NULL
                                ThuTu = Convert.ToInt32(reader["ThuTu"])             // Giả định không NULL
                            });
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Lỗi truy vấn SQL khi lấy tài nguyên: " + ex.Message);
                // Bạn nên cân nhắc ghi log chi tiết ex.ToString()
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi Ép Kiểu Dữ liệu hoặc Lỗi khác: " + ex.Message);
            }
            finally
            {
                // Đảm bảo đóng kết nối theo phong cách hiện tại của bạn
                if (sqlCon != null && sqlCon.State == ConnectionState.Open)
                {
                    sqlCon.Close();
                }
            }

            return resources;
        }
        public List<AssignmentViewModel> GetStudentAssignments(string studentId)
        {
            if (!int.TryParse(studentId, out int studentIntId))
            {
                MessageBox.Show("ID sinh viên không hợp lệ.");
                return new List<AssignmentViewModel>();
            }

            List<AssignmentViewModel> assignments = new List<AssignmentViewModel>();

            // SỬA: Dùng SP đã thiết kế để lấy danh sách bài tập đầy đủ
            string spName = "sp_GetStudentAssignments";

            try
            {
                OpenConnection();

                using (SqlCommand sqlCmd = new SqlCommand(spName, sqlCon))
                {
                    sqlCmd.CommandType = CommandType.StoredProcedure;
                    sqlCmd.Parameters.AddWithValue("@StudentID", studentIntId);

                    using (SqlDataReader reader = sqlCmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            assignments.Add(new AssignmentViewModel
                            {
                                // === Thông tin Bài tập ===
                                // Đã sửa: AssignmentID và CourseID
                                AssignmentID = reader["AssignmentID"] is DBNull ? -1 : Convert.ToInt32(reader["AssignmentID"]),

                                // ⭐ ĐÃ SỬA: ToString() không an toàn khi gặp DBNull
                                TenBaiTap = reader["TenBaiTap"] is DBNull ? "" : reader["TenBaiTap"].ToString(),
                                MoTa = reader["MoTa"] is DBNull ? "" : reader["MoTa"].ToString(),

                                // ⭐ ĐÃ SỬA: Ép kiểu DateTime trực tiếp
                                NgayGiao = reader["NgayGiao"] is DBNull ? DateTime.MinValue : (DateTime)reader["NgayGiao"],
                                HanNop = reader["HanNop"] is DBNull ? DateTime.MaxValue : (DateTime)reader["HanNop"],

                                // ⭐ ĐÃ SỬA: Convert.ToDecimal trực tiếp
                                DiemToiDa = reader["DiemToiDa"] is DBNull ? 0m : Convert.ToDecimal(reader["DiemToiDa"]),

                                TaiLieuDinhKem = reader["TaiLieuDinhKem"] is DBNull ? null : reader["TaiLieuDinhKem"].ToString(),

                                // === Thông tin Khóa học & Giảng viên ===
                                CourseID = reader["CourseID"] is DBNull ? -1 : Convert.ToInt32(reader["CourseID"]),
                                TenKhoaHoc = reader["TenKhoaHoc"] is DBNull ? "" : reader["TenKhoaHoc"].ToString(),
                                TenGiangVien = reader["TenGiangVien"] is DBNull ? "" : reader["TenGiangVien"].ToString(),

                                // === Thông tin Bài nộp (Đã an toàn) ===
                                SubmissionID = reader["SubmissionID"] is DBNull ? (int?)null : Convert.ToInt32(reader["SubmissionID"]),
                                DiemDat = reader["DiemDat"] is DBNull ? (decimal?)null : Convert.ToDecimal(reader["DiemDat"]),
                                NgayNop = reader["NgayNop"] is DBNull ? (DateTime?)null : (DateTime)reader["NgayNop"],
                                FileBaiNop = reader["FileBaiNop"] is DBNull ? null : reader["FileBaiNop"].ToString(),
                                GhiChuSinhVien = reader["GhiChuSinhVien"] is DBNull ? null : reader["GhiChuSinhVien"].ToString(),
                                NhanXetGiaoVien = reader["NhanXetGiaoVien"] is DBNull ? null : reader["NhanXetGiaoVien"].ToString(),

                                // === Trạng thái & Thời gian ===
                                TrangThai = reader["TrangThai"] is DBNull ? "" : reader["TrangThai"].ToString(),
                                StatusColor = reader["StatusColor"] is DBNull ? "" : reader["StatusColor"].ToString(),
                                ThoiGianConLai = reader["ThoiGianConLai"] is DBNull ? "" : reader["ThoiGianConLai"].ToString(),

                                // ⭐ ĐÃ SỬA: Convert.ToInt32 trực tiếp
                                SoNgayConLai = reader["SoNgayConLai"] is DBNull ? 0 : Convert.ToInt32(reader["SoNgayConLai"]),
                                SoGioConLai = reader["SoGioConLai"] is DBNull ? 0 : Convert.ToInt32(reader["SoGioConLai"]),

                                // === Cờ Boolean & Điểm ===
                                // ⭐ ĐÃ SỬA: Convert.ToInt32 trực tiếp
                                DaNopTre = reader["DaNopTre"] is DBNull ? false : Convert.ToInt32(reader["DaNopTre"]) == 1,
                                DaHoanThanh = reader["DaHoanThanh"] is DBNull ? false : Convert.ToInt32(reader["DaHoanThanh"]) == 1,
                                PhanTramDiem = reader["PhanTramDiem"] is DBNull ? (decimal?)null : Convert.ToDecimal(reader["PhanTramDiem"]),

                                // === Ngày tháng Format ===
                                NgayGiaoFormat = reader["NgayGiaoFormat"] is DBNull ? "" : reader["NgayGiaoFormat"].ToString(),
                                HanNopFormat = reader["HanNopFormat"] is DBNull ? "" : reader["HanNopFormat"].ToString(),
                                NgayNopFormat = reader["NgayNopFormat"] is DBNull ? null : reader["NgayNopFormat"].ToString(),
                            });
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Lỗi truy vấn SQL khi lấy danh sách bài tập: " + ex.Message);
                return assignments; // Trả về danh sách rỗng
            }
            catch (Exception ex)
            {
                // Bắt InvalidCastException và các lỗi khác
                MessageBox.Show("Lỗi Ép Kiểu Dữ liệu hoặc Lỗi khác trong Assignment: " + ex.Message);
                MessageBox.Show("Lỗi nghiêm trọng khi đọc dữ liệu bài tập: " + ex.Message, "Lỗi Ánh Xạ C#", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return assignments; // Trả về danh sách rỗng
            }
            finally
            {
                if (sqlCon != null && sqlCon.State == ConnectionState.Open)
                {
                    sqlCon.Close();
                }
            }
            return assignments;
        }
        private const string SQL_COURSE_SUMMARY_FN =
     "SELECT CourseID, KhoaHoc, SoBaiDaCham, DiemTB, DiemCaoNhat, DiemThapNhat " +
     "FROM dbo.fn_StudentCourseScoreSummary(@StudentID)"; // Bỏ alias AS Summary và tiền tố cột
        public List<CourseSummary> GetCourseSummary(string studentId)
        {
            // 1. CHUYỂN ĐỔI VÀ KIỂM TRA ID (String -> Int)
            if (!int.TryParse(studentId, out int studentIntId))
            {
                return new List<CourseSummary>();
            }

            List<CourseSummary> summaries = new List<CourseSummary>();

            try
            {
                OpenConnection();
                using (SqlCommand sqlCmd = new SqlCommand(SQL_COURSE_SUMMARY_FN, sqlCon))
                {
                    sqlCmd.Parameters.AddWithValue("@StudentID", studentIntId);

                    using (SqlDataReader reader = sqlCmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            // 2. XỬ LÝ DBNull AN TOÀN CHO TỪNG CỘT
                            summaries.Add(new CourseSummary
                            {
                                // Giả định CourseID và KhoaHoc không null
                                CourseID = reader["CourseID"].ToString(),
                                KhoaHoc = reader["KhoaHoc"].ToString(),

                                // Cột số lượng (Integer)
                                SoBaiDaCham = reader["SoBaiDaCham"] == DBNull.Value ? 0 : Convert.ToInt32(reader["SoBaiDaCham"]),

                                // Cột điểm số (Decimal)
                                DiemTB = reader["DiemTB"] == DBNull.Value ? 0m : Convert.ToDecimal(reader["DiemTB"]),
                                DiemCaoNhat = reader["DiemCaoNhat"] == DBNull.Value ? 0m : Convert.ToDecimal(reader["DiemCaoNhat"]),
                                DiemThapNhat = reader["DiemThapNhat"] == DBNull.Value ? 0m : Convert.ToDecimal(reader["DiemThapNhat"])
                            });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lấy dữ liệu tổng kết khóa học. Vui lòng kiểm tra tên cột SQL: " + ex.Message, "Lỗi DAL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (sqlCon != null && sqlCon.State == ConnectionState.Open) sqlCon.Close();
            }
            return summaries;
        }
        // Trong file DataProcess.cs

        public List<StudentCourseViewModel> GetMyCourses(string studentId)
        {
            // 1. Chuyển đổi ID sang INT
            if (!int.TryParse(studentId, out int studentIntId))
            {
                MessageBox.Show("ID sinh viên không hợp lệ.");
                return new List<StudentCourseViewModel>();
            }

            List<StudentCourseViewModel> courses = new List<StudentCourseViewModel>();
            string spName = "sp_GetMyCoursesWithProgress";

            try
            {
                OpenConnection();

                using (SqlCommand sqlCmd = new SqlCommand(spName, sqlCon))
                {
                    sqlCmd.CommandType = CommandType.StoredProcedure;
                    sqlCmd.Parameters.AddWithValue("@StudentID", studentIntId);

                    using (SqlDataReader reader = sqlCmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            courses.Add(new StudentCourseViewModel
                            {
                                // THÔNG TIN KHÓA HỌC
                                CourseID = reader["CourseID"].ToString(),
                                TenKhoaHoc = reader["TenKhoaHoc"].ToString(),

                                // **SỬA LỖI STRING NULL CHECK**
                                AnhBia = reader["AnhBia"] == DBNull.Value ? null : reader["AnhBia"].ToString(),
                                MoTa = reader["MoTa"] == DBNull.Value ? null : reader["MoTa"].ToString(),

                                // DANH MỤC (Giả định không NULL)
                                DanhMuc = reader["DanhMuc"].ToString(),
                                CategoryID = reader["CategoryID"].ToString(),

                                // GIẢNG VIÊN
                                TenGiangVien = reader["TenGiangVien"].ToString(),
                                // **SỬA LỖI STRING NULL CHECK**
                                AnhGiangVien = reader["AnhGiangVien"] == DBNull.Value ? null : reader["AnhGiangVien"].ToString(),

                                // TIẾN ĐỘ (ĐÃ AN TOÀN nhờ ISNULL(..., 0) trong SP)
                                TienDoHoc = Convert.ToInt32(reader["TienDoHoc"]),
                                SoBaiHoanThanh = Convert.ToInt32(reader["SoBaiHoanThanh"]),
                                TongSoBaiHoc = Convert.ToInt32(reader["TongSoBaiHoc"]),
                                SoBaiConLai = Convert.ToInt32(reader["SoBaiConLai"]),

                                // TIẾN ĐỘ TEXT (ĐÃ AN TOÀN nhờ CONCAT và ISNULL trong SP)
                                TienDoText = reader["TienDoText"].ToString(),
                                PhanTramText = reader["PhanTramText"].ToString(),
                                ProgressColor = reader["ProgressColor"].ToString(),

                                // TRẠNG THÁI & ĐIỂM
                                TrangThai = reader["TrangThai"] == DBNull.Value ? null : reader["TrangThai"].ToString(),
                                TrangThaiText = reader["TrangThaiText"].ToString(),

                                // **SỬA LỖI DATETIME NULL CHECK**
                                NgayDangKy = reader["NgayDangKy"] == DBNull.Value
                                             ? (DateTime?)null
                                             : (DateTime)reader["NgayDangKy"],

                                // DiemTrungBinh (ĐÃ AN TOÀN nhờ ISNULL(..., 0) trong SP)
                                DiemTrungBinh = Convert.ToDecimal(reader["DiemTrungBinh"])
                            });
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Lỗi truy vấn SQL khi lấy danh sách khóa học: " + ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
            finally
            {
                if (sqlCon != null && sqlCon.State == ConnectionState.Open)
                {
                    sqlCon.Close();
                }
            }
            return courses;
        }
        // Trong file DataProcess.cs, bên trong class DataProcess
        public int InsertSubmission(int assignmentId, string studentId, string fileUrl, string studentNote)
        {
            // 1. Chuyển đổi và kiểm tra ID (String -> Int)
            if (!int.TryParse(studentId, out int studentIntId))
            {
                MessageBox.Show("ID sinh viên không hợp lệ. (Phải là số nguyên)", "Lỗi Dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }

            int submissionId = 0;
            string spName = "sp_InsertStudentSubmission"; // Tên Stored Procedure

            try
            {
                OpenConnection();

                using (SqlCommand sqlCmd = new SqlCommand(spName, sqlCon))
                {
                    sqlCmd.CommandType = CommandType.StoredProcedure;
                    sqlCmd.Parameters.AddWithValue("@AssignmentID", assignmentId);

                    // SỬ DỤNG ID ĐÃ CHUYỂN ĐỔI
                    sqlCmd.Parameters.AddWithValue("@StudentID", studentIntId);

                    // FileUrl (Giả định không NULL)
                    sqlCmd.Parameters.AddWithValue("@FileUrl", fileUrl);

                    // Xử lý giá trị NULL an toàn cho StudentNote
                    sqlCmd.Parameters.AddWithValue("@StudentNote", string.IsNullOrEmpty(studentNote) ? (object)DBNull.Value : studentNote);

                    // Stored Procedure trả về ID (int), dùng ExecuteScalar để lấy giá trị đầu tiên
                    object result = sqlCmd.ExecuteScalar();

                    if (result != null && result != DBNull.Value)
                    {
                        submissionId = Convert.ToInt32(result);
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Lỗi truy vấn SQL khi nộp bài: " + ex.Message, "Lỗi Nộp bài", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi hệ thống khi nộp bài: " + ex.Message, "Lỗi Nộp bài", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (sqlCon != null && sqlCon.State == ConnectionState.Open)
                {
                    sqlCon.Close();
                }
            }

            // Trả về SubmissionID: > 0 nếu thành công, 0 nếu thất bại
            return submissionId;
        }
        public StudentOverallStats GetOverallStats(string studentId)
        {
            // 1. CHUYỂN ĐỔI VÀ KIỂM TRA ID (String -> Int)
            if (!int.TryParse(studentId, out int studentIntId))
            {
                MessageBox.Show("Lỗi: ID sinh viên không hợp lệ. (Phải là số nguyên)", "Lỗi Dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new StudentOverallStats(); // Trả về đối tượng rỗng
            }

            StudentOverallStats stats = new StudentOverallStats();
            string spName = "sp_GetStudentScoreSummary"; // Giả định tên Stored Procedure

            try
            {
                OpenConnection();
                using (SqlCommand sqlCmd = new SqlCommand(spName, sqlCon))
                {
                    sqlCmd.CommandType = CommandType.StoredProcedure;
                    sqlCmd.Parameters.AddWithValue("@StudentID", studentIntId);

                    using (SqlDataReader reader = sqlCmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            // 2. XỬ LÝ DBNull AN TOÀN CHO TỪNG CỘT
                            stats.DiemTBTong = reader["DiemTBTong"] == DBNull.Value ? 0m : Convert.ToDecimal(reader["DiemTBTong"]);
                            stats.DiemCaoNhat = reader["DiemCaoNhat"] == DBNull.Value ? 0m : Convert.ToDecimal(reader["DiemCaoNhat"]);

                            // Cột số bài đã chấm (Integer)
                            stats.SoBaiDaCham = reader["SoBaiDaCham"] == DBNull.Value ? 0 : Convert.ToInt32(reader["SoBaiDaCham"]);
                            // Cột xếp loại (String)
                            stats.XepLoai = reader["XepLoai"] == DBNull.Value ? "N/A" : reader["XepLoai"].ToString();

                            // Nếu có cột TongSoBaiNop (như trong code trước):
                            // stats.TongSoBaiNop = reader["TongSoBaiNop"] == DBNull.Value ? 0 : Convert.ToInt32(reader["TongSoBaiNop"]);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lấy dữ liệu tổng quan điểm số. Vui lòng kiểm tra tên cột SQL: " + ex.Message, "Lỗi DAL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new StudentOverallStats();
            }
            finally
            {
                if (sqlCon != null && sqlCon.State == ConnectionState.Open) sqlCon.Close();
            }

            return stats;

        }

    }
}

