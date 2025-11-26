-- =============================================
-- 1. TẠO DATABASE (Nếu chưa có)

CREATE DATABASE StudyProcess;
GO
USE StudyProcess;
GO

-- =============================================
-- 2. TẠO CÁC BẢNG (TABLES)
-- =============================================

-- Bảng 1: Accounts (Quản lý đăng nhập & Phân quyền)
CREATE TABLE Accounts (
    AccountID VARCHAR(50) PRIMARY KEY,       -- Mã tài khoản (VD: ACC001)
    Email VARCHAR(100) UNIQUE NOT NULL,      -- Email đăng nhập (Duy nhất)
    PasswordHash VARCHAR(255) NOT NULL,      -- Mật khẩu
    Role NVARCHAR(20) CHECK (Role IN ('Admin', 'Teacher', 'Student')), -- Vai trò
    IsActive BIT DEFAULT 1,                  -- 1: Hoạt động, 0: Khóa
    CreatedAt DATETIME DEFAULT GETDATE()     -- Ngày tạo
);

-- Bảng 2: Users (Hồ sơ cá nhân - Profile)
CREATE TABLE Users (
    UserID VARCHAR(50) PRIMARY KEY,          -- Mã người dùng (VD: USR001)
    AccountID VARCHAR(50) UNIQUE NOT NULL,   -- Liên kết 1-1 với bảng Accounts
    FullName NVARCHAR(100) NOT NULL,         -- Họ tên hiển thị
    PhoneNumber VARCHAR(20),                 -- Số điện thoại
    AvatarUrl NVARCHAR(255),                 -- Link ảnh đại diện
    DateOfBirth DATE,                        -- Ngày sinh
    Address NVARCHAR(255),                   -- Địa chỉ
    FOREIGN KEY (AccountID) REFERENCES Accounts(AccountID) ON DELETE CASCADE
);

-- Bảng 3: Categories (Danh mục khóa học)
CREATE TABLE Categories (
    CategoryID VARCHAR(50) PRIMARY KEY,      -- Mã danh mục (VD: CAT001)
    CategoryName NVARCHAR(100) NOT NULL,     -- Tên danh mục (CNTT, Ngoại ngữ...)
    Description NVARCHAR(255)                -- Mô tả ngắn
);

-- Bảng 4: Courses (Khóa học - Đã bỏ cột Price)
CREATE TABLE Courses (
    CourseID VARCHAR(50) PRIMARY KEY,        -- Mã khóa học (VD: CRS001)
    CourseName NVARCHAR(200) NOT NULL,       -- Tên khóa học
    Description NVARCHAR(MAX),               -- Mô tả chi tiết
    ImageCover NVARCHAR(255),                -- Link ảnh bìa
    TotalLessons INT DEFAULT 0,              -- Tổng số bài học
    CategoryID VARCHAR(50),                  -- Thuộc danh mục nào
    TeacherID VARCHAR(50),                   -- Giảng viên phụ trách
    CreatedAt DATETIME DEFAULT GETDATE(),    -- Ngày tạo
    Status NVARCHAR(50) DEFAULT 'Pending',   -- Trạng thái: Pending (Chờ duyệt), Approved (Đã duyệt)
    
    FOREIGN KEY (CategoryID) REFERENCES Categories(CategoryID),
    FOREIGN KEY (TeacherID) REFERENCES Users(UserID)
);

-- Bảng 5: Lessons (Bài học trong khóa học)
CREATE TABLE Lessons (
    LessonID VARCHAR(50) PRIMARY KEY,        -- Mã bài học (VD: LES001)
    CourseID VARCHAR(50),                    -- Thuộc khóa nào
    LessonTitle NVARCHAR(200) NOT NULL,      -- Tiêu đề bài học
    LessonOrder INT,                         -- Thứ tự bài (1, 2, 3...)
    Content NVARCHAR(MAX),                   -- Nội dung (Text/HTML)
    VideoUrl NVARCHAR(255),                  -- Link video
    AttachmentUrl NVARCHAR(255),             -- Link tài liệu
    
    FOREIGN KEY (CourseID) REFERENCES Courses(CourseID)
);

-- Bảng 6: Enrollments (Đăng ký học & Tiến độ)
CREATE TABLE Enrollments (
    EnrollmentID VARCHAR(50) PRIMARY KEY,    -- Mã đăng ký (VD: ENR001)
    StudentID VARCHAR(50),                   -- Học viên
    CourseID VARCHAR(50),                    -- Khóa học
    EnrollmentDate DATETIME DEFAULT GETDATE(),-- Ngày tham gia
    ProgressPercent INT DEFAULT 0,           -- Tiến độ (%)
    CompletedLessons INT DEFAULT 0,          -- Số bài đã học
    Status NVARCHAR(50) DEFAULT 'Learning',  -- Learning (Đang học), Completed (Hoàn thành)
    
    FOREIGN KEY (StudentID) REFERENCES Users(UserID),
    FOREIGN KEY (CourseID) REFERENCES Courses(CourseID)
);

-- Bảng 7: Assignments (Bài tập giáo viên giao)
CREATE TABLE Assignments (
    AssignmentID VARCHAR(50) PRIMARY KEY,    -- Mã bài tập (VD: ASM001)
    CourseID VARCHAR(50),                    -- Thuộc khóa nào
    Title NVARCHAR(200) NOT NULL,            -- Tiêu đề bài tập
    Description NVARCHAR(MAX),               -- Đề bài
    AssignedDate DATETIME DEFAULT GETDATE(), -- Ngày giao
    DueDate DATETIME,                        -- Hạn nộp
    MaxScore DECIMAL(4, 2) DEFAULT 10.0,     -- Điểm tối đa
    
    FOREIGN KEY (CourseID) REFERENCES Courses(CourseID)
);

-- Bảng 8: Submissions (Bài nộp & Chấm điểm)
CREATE TABLE Submissions (
    SubmissionID VARCHAR(50) PRIMARY KEY,    -- Mã bài nộp (VD: SUB001)
    AssignmentID VARCHAR(50),                -- Nộp cho bài tập nào
    StudentID VARCHAR(50),                   -- Ai nộp
    SubmissionDate DATETIME DEFAULT GETDATE(),-- Ngày nộp
    FileUrl NVARCHAR(255),                   -- File bài làm
    StudentNote NVARCHAR(MAX),               -- Ghi chú của trò
    Score DECIMAL(4, 2),                     -- Điểm số (NULL = Chưa chấm)
    TeacherFeedback NVARCHAR(MAX),           -- Nhận xét của thầy
    Status NVARCHAR(50) DEFAULT 'Submitted', -- Submitted (Đã nộp), Graded (Đã chấm)
    
    FOREIGN KEY (AssignmentID) REFERENCES Assignments(AssignmentID),
    FOREIGN KEY (StudentID) REFERENCES Users(UserID)
);
GO

-- =============================================
-- 3. THÊM DỮ LIỆU MẪU (SEED DATA)
-- =============================================

-- 1. Tài khoản
INSERT INTO Accounts (AccountID, Email, PasswordHash, Role) VALUES 
('ACC001', 'admin@lms.com', '123', 'Admin'),
('ACC002', 'longnv@lms.com', '123', 'Teacher'),
('ACC003', 'hoatt@lms.com', '123', 'Teacher'),
('ACC004', 'annguyen@lms.com', '123', 'Student');

-- 2. Thông tin người dùng
INSERT INTO Users (UserID, AccountID, FullName, PhoneNumber, AvatarUrl) VALUES 
('USR001', 'ACC001', N'Quản trị viên', '0900000000', 'admin.png'),
('USR002', 'ACC002', N'TS. Nguyễn Văn Long', '0912345678', 'teacher1.png'),
('USR003', 'ACC003', N'ThS. Trần Thị Hoa', '0987654321', 'teacher2.png'),
('USR004', 'ACC004', N'Nguyễn Văn An', '0999888777', 'student.png');

-- 3. Danh mục
INSERT INTO Categories (CategoryID, CategoryName) VALUES 
('CAT001', N'Công nghệ thông tin'),
('CAT002', N'Ngoại ngữ'),
('CAT003', N'Thiết kế đồ họa');

-- 4. Khóa học (Không có giá)
INSERT INTO Courses (CourseID, CourseName, Description, TotalLessons, CategoryID, TeacherID, Status) VALUES
('CRS001', N'Lập trình Web với React', N'Học ReactJS từ cơ bản', 12, 'CAT001', 'USR002', 'Approved'),
('CRS002', N'Python cơ bản', N'Nhập môn Python', 20, 'CAT001', 'USR003', 'Approved'),
('CRS003', N'Tiếng Anh Giao Tiếp', N'Tự tin giao tiếp', 30, 'CAT002', 'USR002', 'Approved');

-- 5. Đăng ký học
INSERT INTO Enrollments (EnrollmentID, StudentID, CourseID, ProgressPercent, CompletedLessons, Status) VALUES
('ENR001', 'USR004', 'CRS001', 75, 9, 'Learning'),
('ENR002', 'USR004', 'CRS002', 50, 10, 'Learning');

-- 6. Bài tập
INSERT INTO Assignments (AssignmentID, CourseID, Title, DueDate) VALUES
('ASM001', 'CRS001', N'Tạo Component trong React', '2025-11-20'),
('ASM002', 'CRS002', N'Viết hàm xử lý chuỗi', '2025-11-25');

-- 7. Bài nộp (Có nhận xét)
INSERT INTO Submissions (SubmissionID, AssignmentID, StudentID, FileUrl, Score, TeacherFeedback, Status) VALUES
('SUB001', 'ASM001', 'USR004', 'react_bai1.zip', 9.5, N'Code sạch, cấu trúc tốt.', 'Graded');
