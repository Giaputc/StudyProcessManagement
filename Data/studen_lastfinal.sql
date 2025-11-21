
-- ============================================
-- DATABASE: StudyProcess - PHIÊN BẢN CUỐI CÙNG
-- Đã sửa tất cả lỗi và hoàn thiện
-- Date: November 20, 2025
-- ============================================

-- Tạo database
CREATE DATABASE [StudyProcess];
GO

USE [StudyProcess];
GO

/* ======================
   BẢNG TÀI KHOẢN & NGƯỜI DÙNG
   ====================== */

CREATE TABLE Accounts (
    AccountID   VARCHAR(50)  NOT NULL PRIMARY KEY,
    Username    NVARCHAR(50) NOT NULL UNIQUE,
    Password    NVARCHAR(255) NOT NULL,
    Role        NVARCHAR(20) NOT NULL, -- Admin / Teacher / Student
    Status      NVARCHAR(20) NOT NULL DEFAULT N'Active', -- Active / Locked
    CreatedDate DATETIME      NOT NULL DEFAULT GETDATE()
);
GO

CREATE TABLE Users (
    UserID      INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    AccountID   VARCHAR(50)  NOT NULL UNIQUE,
    FullName    NVARCHAR(100) NOT NULL,
    Email       NVARCHAR(100) NOT NULL UNIQUE,
    Phone       NVARCHAR(20) NULL,
    DateOfBirth DATE         NULL,
    Gender      NVARCHAR(10) NULL,
    AvatarPath  NVARCHAR(255) NULL,

    CONSTRAINT FK_Users_Accounts
        FOREIGN KEY (AccountID) REFERENCES Accounts(AccountID)
);
GO

/* ======================
   BẢNG KHOÁ HỌC & NỘI DUNG
   ====================== */

CREATE TABLE Courses (
    CourseID      INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    CourseCode    NVARCHAR(50)  NOT NULL UNIQUE,
    Title         NVARCHAR(200) NOT NULL,
    Description   NVARCHAR(MAX) NULL,
    Level         NVARCHAR(50)  NULL, -- Beginner / Intermediate / Advanced
    Category      NVARCHAR(100) NULL,
    ThumbnailPath NVARCHAR(255) NULL,
    Status        NVARCHAR(20)  NOT NULL DEFAULT N'Active', -- Active / Hidden / Archived
    CreatedDate   DATETIME      NOT NULL DEFAULT GETDATE()
);
GO

CREATE TABLE CourseTeachers (
    CourseTeacherID INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    CourseID        INT NOT NULL,
    TeacherID       INT NOT NULL, -- Users.UserID (role = Teacher),
    AssignedDate    DATETIME NOT NULL DEFAULT GETDATE(),

    CONSTRAINT FK_CourseTeachers_Courses
        FOREIGN KEY (CourseID) REFERENCES Courses(CourseID),
    CONSTRAINT FK_CourseTeachers_Users
        FOREIGN KEY (TeacherID) REFERENCES Users(UserID)
);
GO

CREATE TABLE Lessons (
    LessonID      INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    CourseID      INT          NOT NULL,
    Title         NVARCHAR(200) NOT NULL,
    Content       NVARCHAR(MAX) NULL,
    VideoUrl      NVARCHAR(255) NULL,
    OrderIndex    INT           NOT NULL,
    IsPreview     BIT           NOT NULL DEFAULT 0,
    Status        NVARCHAR(20)  NOT NULL DEFAULT N'Active', -- Active / Hidden
    CreatedDate   DATETIME      NOT NULL DEFAULT GETDATE(),

    CONSTRAINT FK_Lessons_Courses
        FOREIGN KEY (CourseID) REFERENCES Courses(CourseID)
);
GO

-- Bài tập
CREATE TABLE Assignments (
    AssignmentID  INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    CourseID      INT           NOT NULL,
    Title         NVARCHAR(200) NOT NULL,
    Description   NVARCHAR(MAX) NULL,
    AssignedDate  DATETIME      NULL,
    DueDate       DATETIME      NULL,
    MaxScore      DECIMAL(5,2)  NULL,
    AttachmentPath NVARCHAR(500) NULL,

    CONSTRAINT FK_Assignments_Courses
        FOREIGN KEY (CourseID) REFERENCES Courses(CourseID)
);
GO

CREATE TABLE Enrollments (
    EnrollmentID     INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    StudentID        INT           NOT NULL,          -- Users.UserID (role = Student)
    CourseID         INT           NOT NULL,
    EnrollmentDate   DATETIME      NOT NULL DEFAULT GETDATE(),
    ProgressPercent  INT           NULL,
    CompletedLessons INT           NULL,
    Status           NVARCHAR(50)  NULL,
    AverageScore     DECIMAL(5,2)  NULL,

    CONSTRAINT FK_Enrollments_Users
        FOREIGN KEY (StudentID) REFERENCES Users(UserID),
    CONSTRAINT FK_Enrollments_Courses
        FOREIGN KEY (CourseID)  REFERENCES Courses(CourseID)
);
GO

CREATE TABLE Submissions (
    SubmissionID    INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    AssignmentID    INT           NOT NULL,
    StudentID       INT           NOT NULL,
    SubmissionDate  DATETIME      NOT NULL DEFAULT GETDATE(),
    Content         NVARCHAR(MAX) NULL,
    AttachmentPath  NVARCHAR(500) NULL,
    Score           DECIMAL(5,2)  NULL,
    Feedback        NVARCHAR(MAX) NULL,
    Status          NVARCHAR(50)  NULL,   -- NotSubmitted / Submitted / Late / Graded
    GradedDate      DATETIME      NULL,
    GradedBy        INT           NULL,   -- Users.UserID (teacher)

    CONSTRAINT FK_Submissions_Assignments
        FOREIGN KEY (AssignmentID) REFERENCES Assignments(AssignmentID),
    CONSTRAINT FK_Submissions_Users_Student
        FOREIGN KEY (StudentID) REFERENCES Users(UserID),
    CONSTRAINT FK_Submissions_Users_Teacher
        FOREIGN KEY (GradedBy)   REFERENCES Users(UserID)
);
GO
/* ======================
   CẬP NHẬT RÀNG BUỘC KHÓA NGOẠI
   ====================== */
-- 1. Xóa cái ràng buộc khóa ngoại cũ đang gây lỗi
ALTER TABLE Users DROP CONSTRAINT FK_Users_Accounts;
GO

-- 2. Tạo lại ràng buộc mới có thêm tính năng "ON DELETE CASCADE"
ALTER TABLE Users ADD CONSTRAINT FK_Users_Accounts
FOREIGN KEY (AccountID) REFERENCES Accounts(AccountID)
ON DELETE CASCADE;

ALTER TABLE Enrollments DROP CONSTRAINT FK_Enrollments_Users;
ALTER TABLE Enrollments ADD CONSTRAINT FK_Enrollments_Users
    FOREIGN KEY (StudentID) REFERENCES Users(UserID) ON DELETE CASCADE;
GO

-- 2. Cho phép xóa User -> tự động xóa Submissions (Bài nộp)
ALTER TABLE Submissions DROP CONSTRAINT FK_Submissions_Users;
ALTER TABLE Submissions ADD CONSTRAINT FK_Submissions_Users
    FOREIGN KEY (StudentID) REFERENCES Users(UserID) ON DELETE CASCADE;
GO

-- 3. Cho phép xóa User -> tự động xóa ActivityLogs (Nhật ký)
ALTER TABLE ActivityLogs DROP CONSTRAINT FK_ActivityLogs_Users;
ALTER TABLE ActivityLogs ADD CONSTRAINT FK_ActivityLogs_Users
    FOREIGN KEY (UserID) REFERENCES Users(UserID) ON DELETE CASCADE;
GO
/* ======================
   THÊM DỮ LIỆU MẪU
   ====================== */

-- 1. TÀI KHOẢN QUẢN TRỊ
INSERT INTO Accounts (AccountID, Username, Password, Role, Status)
VALUES 
    ('ADM001', 'admin',  'admin123', 'Admin',   N'Active'),
    ('TEA001', 'teacher1','teacher123','Teacher',N'Active'),
    ('TEA002', 'teacher2','teacher123','Teacher',N'Active');
GO

-- 2. TÀI KHOẢN SINH VIÊN
INSERT INTO Accounts (AccountID, Username, Password, Role, Status)
SELECT 
    CONCAT('STU', RIGHT('000' + CAST(ROW_NUMBER() OVER (ORDER BY (SELECT NULL)) AS VARCHAR(3))), '') AS AccountID,
    CONCAT('student', ROW_NUMBER() OVER (ORDER BY (SELECT NULL))) AS Username,
    '123456' AS Password,
    'Student' AS Role,
    N'Active' AS Status
FROM (SELECT 1 AS n UNION ALL SELECT 2 UNION ALL SELECT 3 UNION ALL SELECT 4 UNION ALL SELECT 5
      UNION ALL SELECT 6 UNION ALL SELECT 7 UNION ALL SELECT 8 UNION ALL SELECT 9 UNION ALL SELECT 10
      UNION ALL SELECT 11 UNION ALL SELECT 12 UNION ALL SELECT 13 UNION ALL SELECT 14 UNION ALL SELECT 15
      UNION ALL SELECT 16 UNION ALL SELECT 17 UNION ALL SELECT 18 UNION ALL SELECT 19 UNION ALL SELECT 20) AS t;
GO

-- 3. THÊM NGƯỜI DÙNG (ADMIN + TEACHER)
INSERT INTO Users (AccountID, FullName, Email, Phone, DateOfBirth, Gender, AvatarPath)
VALUES
    ('ADM001', N'Quản trị viên hệ thống', 'admin@lms.com', '0123456789', '1990-01-01', N'Nam',  NULL),
    ('TEA001', N'Nguyễn Văn Giáo', 'teacher1@lms.com', '0987654321', '1985-05-20', N'Nam', NULL),
    ('TEA002', N'Trần Thị Hồng',   'teacher2@lms.com', '0978123456', '1988-09-15', N'Nữ', NULL);
GO

-- 4. THÊM NGƯỜI DÙNG (STUDENT)
INSERT INTO Users (AccountID, FullName, Email, Phone, DateOfBirth, Gender, AvatarPath)
SELECT 
    a.AccountID,
    N'Student ' + RIGHT(a.AccountID, 3),
    CONCAT(a.AccountID, '@lms.com'),
    CONCAT('09', RIGHT('0000000' + CAST(ROW_NUMBER() OVER (ORDER BY a.AccountID) AS VARCHAR(7)), 7)),
    DATEADD(YEAR, -20, GETDATE()),
    CASE WHEN (ROW_NUMBER() OVER (ORDER BY a.AccountID)) % 2 = 0 THEN N'Nam' ELSE N'Nữ' END,
    NULL
FROM Accounts a
WHERE a.Role = 'Student';
GO

-- 5. TẠO KHOÁ HỌC
INSERT INTO Courses (CourseCode, Title, Description, Level, Category, ThumbnailPath, Status)
VALUES 
    ('C001', N'Lập trình C# cơ bản', N'Khoá học nhập môn lập trình C# cho người mới bắt đầu', N'Beginner', N'Lập trình', NULL, N'Active'),
    ('C002', N'Lập trình Web với ASP.NET Core', N'Xây dựng ứng dụng web với ASP.NET Core MVC', N'Intermediate', N'Web', NULL, N'Active'),
    ('C003', N'Thiết kế UI/UX cơ bản', N'Giới thiệu quy trình thiết kế giao diện người dùng', N'Beginner', N'Thiết kế', NULL, N'Active');
GO

-- 6. PHÂN CÔNG GIẢNG VIÊN CHO KHOÁ HỌC
INSERT INTO CourseTeachers (CourseID, TeacherID, AssignedDate)
SELECT c.CourseID, u.UserID, GETDATE()
FROM Courses c
JOIN Users u ON u.AccountID IN ('TEA001','TEA002')
WHERE (c.CourseCode = 'C001' AND u.AccountID = 'TEA001')
   OR (c.CourseCode = 'C002' AND u.AccountID = 'TEA001')
   OR (c.CourseCode = 'C003' AND u.AccountID = 'TEA002');
GO

-- 7. TẠO ENROLLMENTS
INSERT INTO Enrollments (StudentID, CourseID, EnrollmentDate, ProgressPercent, Status)
SELECT UserID, 1, DATEADD(DAY, -ABS(CHECKSUM(NEWID()) % 50), GETDATE()), 
       (ABS(CHECKSUM(NEWID()) % 100)), N'Active'
FROM Users 
WHERE AccountID IN ('STU001','STU002','STU003','STU004','STU005','STU006','STU007','STU008','STU009','STU010',
                    'STU011','STU012','STU013','STU014','STU015','STU016','STU017','STU018','STU019','STU020');

INSERT INTO Enrollments (StudentID, CourseID, EnrollmentDate, ProgressPercent, Status)
SELECT UserID, 2, DATEADD(DAY, -ABS(CHECKSUM(NEWID()) % 40), GETDATE()), 
       (ABS(CHECKSUM(NEWID()) % 100)), N'Active'
FROM Users 
WHERE AccountID IN ('STU005','STU006','STU007','STU008','STU009','STU010','STU011','STU012','STU013','STU014',
                    'STU015','STU016','STU017','STU018','STU019','STU020');

INSERT INTO Enrollments (StudentID, CourseID, EnrollmentDate, ProgressPercent, Status)
SELECT UserID, 3, DATEADD(DAY, -ABS(CHECKSUM(NEWID()) % 30), GETDATE()), 
       (ABS(CHECKSUM(NEWID()) % 100)), N'Active'
FROM Users 
WHERE AccountID IN ('STU001','STU003','STU005','STU007','STU009','STU011','STU013','STU015','STU017','STU019');
GO

-- CẬP NHẬT TRẠNG THÁI ENROLLMENTS THEO TIẾN ĐỘ
-- B1: mặc định tất cả là Learning (đang học) nếu đang Active hoặc NULL
UPDATE Enrollments
SET Status = N'Learning'
WHERE Status IS NULL OR Status = N'Active';

-- B2: những học viên đã hoàn thành (tiến độ >= 80%)
UPDATE Enrollments
SET Status = N'Completed'
WHERE ProgressPercent >= 80;

-- B3: những học viên tạm dừng (tiến độ <= 20% và đăng ký đã lâu hơn 30 ngày)
UPDATE Enrollments
SET Status = N'Suspended'
WHERE ProgressPercent <= 20
  AND DATEDIFF(DAY, EnrollmentDate, GETDATE()) > 30;
GO

-- 8. TẠO ASSIGNMENTS
INSERT INTO Assignments (CourseID, Title, Description, AssignedDate, DueDate, MaxScore)
VALUES 
    (1, N'Bài tập 1: Hello World', N'Viết chương trình in ra "Hello World"', DATEADD(DAY, -50, GETDATE()), DATEADD(DAY, -43, GETDATE()), 10.00),
    (1, N'Bài tập 2: Tính toán cơ bản', N'Viết chương trình tính toán với 2 số', DATEADD(DAY, -40, GETDATE()), DATEADD(DAY, -33, GETDATE()), 15.00),
    (1, N'Bài tập 3: Vòng lặp', N'In ra các số từ 1 đến 100 sử dụng vòng lặp', DATEADD(DAY, -30, GETDATE()), DATEADD(DAY, -23, GETDATE()), 20.00),
    (1, N'Bài tập 4: Class và Object', N'Tạo class Student với các thuộc tính cơ bản', DATEADD(DAY, -20, GETDATE()), DATEADD(DAY, -13, GETDATE()), 25.00),
    (1, N'Bài tập 5: LINQ', N'Sử dụng LINQ để truy vấn danh sách sinh viên', DATEADD(DAY, -10, GETDATE()), DATEADD(DAY, -3, GETDATE()), 30.00),
    (2, N'Bài tập 1: Tạo Controller', N'Tạo HomeController với các action cơ bản', DATEADD(DAY, -35, GETDATE()), DATEADD(DAY, -28, GETDATE()), 20.00),
    (2, N'Bài tập 2: Razor Views', N'Tạo View hiển thị danh sách sản phẩm', DATEADD(DAY, -25, GETDATE()), DATEADD(DAY, -18, GETDATE()), 25.00),
    (2, N'Bài tập 3: Entity Framework', N'Tạo Model và DbContext kết nối SQL Server', DATEADD(DAY, -15, GETDATE()), DATEADD(DAY, -8, GETDATE()), 30.00),
    (2, N'Bài tập 4: CRUD Operations', N'Xây dựng chức năng CRUD đầy đủ', DATEADD(DAY, -5, GETDATE()), DATEADD(DAY, 2, GETDATE()), 35.00),
    (3, N'Bài tập 1: User Persona', N'Tạo 3 user persona cho một sản phẩm bất kỳ', DATEADD(DAY, -20, GETDATE()), DATEADD(DAY, -13, GETDATE()), 20.00),
    (3, N'Bài tập 2: Wireframe', N'Thiết kế wireframe cho trang chủ ứng dụng', DATEADD(DAY, -10, GETDATE()), DATEADD(DAY, -3, GETDATE()), 25.00);
GO

-- 9. GIẢ LẬP SUBMISSIONS (BÀI NỘP)

INSERT INTO Submissions (AssignmentID, StudentID, SubmissionDate, Content, Score, Feedback, Status, GradedDate, GradedBy)
SELECT TOP 7 
    a.AssignmentID,
    u.UserID,
    DATEADD(DAY, -ABS(CHECKSUM(NEWID()) % 10), GETDATE()),
    N'Bài làm của ' + u.FullName + N' cho ' + a.Title,
    CAST(ABS(CHECKSUM(NEWID()) % 40) + 60 AS DECIMAL(5,2)),
    N'Bài làm tốt, cần chú ý thêm một số chi tiết.',
    N'Đã chấm',
    GETDATE(),
    (SELECT TOP 1 UserID FROM Users WHERE AccountID = 'TEA001')
FROM Assignments a
JOIN Enrollments e ON e.CourseID = a.CourseID
JOIN Users u ON u.UserID = e.StudentID
WHERE a.CourseID IN (1,2);
GO

INSERT INTO Submissions (AssignmentID, StudentID, SubmissionDate, Content, Score, Feedback, Status, GradedDate, GradedBy)
SELECT TOP 3 
    a.AssignmentID,
    u.UserID,
    DATEADD(DAY, -ABS(CHECKSUM(NEWID()) % 5), GETDATE()),
    N'Bài làm của ' + u.FullName + N' (chưa chấm)',
    NULL,
    NULL,
    N'Chưa chấm',
    NULL,
    NULL
FROM Assignments a
JOIN Enrollments e ON e.CourseID = a.CourseID
JOIN Users u ON u.UserID = e.StudentID
WHERE a.CourseID IN (1,2)
  AND NOT EXISTS (SELECT 1 FROM Submissions s WHERE s.AssignmentID = a.AssignmentID AND s.StudentID = u.UserID);
GO

/* ======================
   CÁC VIEW / PROC HỖ TRỢ CHO ỨNG DỤNG
   ====================== */

IF OBJECT_ID('vw_TeacherCourses', 'V') IS NOT NULL
    DROP VIEW vw_TeacherCourses;
GO

CREATE VIEW vw_TeacherCourses
AS
SELECT 
    ct.TeacherID,
    u.FullName AS TeacherName,
    c.CourseID,
    c.CourseCode,
    c.Title AS CourseTitle,
    c.Level,
    c.Category,
    c.Status,
    c.CreatedDate
FROM CourseTeachers ct
JOIN Users u ON u.UserID = ct.TeacherID
JOIN Courses c ON c.CourseID = ct.CourseID;
GO

IF OBJECT_ID('sp_GetTeacherCourses', 'P') IS NOT NULL
    DROP PROCEDURE sp_GetTeacherCourses;
GO

CREATE PROCEDURE sp_GetTeacherCourses
    @TeacherID VARCHAR(50)
AS
BEGIN
    SET NOCOUNT ON;

    SELECT 
        c.CourseID,
        c.Title AS CourseName
    FROM Courses c
    JOIN CourseTeachers ct ON ct.CourseID = c.CourseID
    JOIN Users u ON u.UserID = ct.TeacherID
    WHERE u.AccountID = @TeacherID
    ORDER BY c.Title;
END
GO

IF OBJECT_ID('sp_GetStudentsByFilter', 'P') IS NOT NULL
    DROP PROCEDURE sp_GetStudentsByFilter;
GO

CREATE PROCEDURE sp_GetStudentsByFilter
    @TeacherID VARCHAR(50),
    @CourseID INT = NULL,
    @Status NVARCHAR(50) = N'Tất cả trạng thái',
    @SearchKeyword NVARCHAR(100) = N''
AS
BEGIN
    SET NOCOUNT ON;

    SELECT 
        e.StudentID,
        u.FullName,
        u.Email,
        c.Title AS CourseName,
        e.EnrollmentDate,
        ISNULL(e.ProgressPercent, 0) AS ProgressPercent,
        ISNULL(e.Status, N'Learning') AS Status
    FROM Enrollments e
    JOIN Users u ON u.UserID = e.StudentID
    JOIN Courses c ON c.CourseID = e.CourseID
    JOIN CourseTeachers ct ON ct.CourseID = c.CourseID
    JOIN Users t ON t.UserID = ct.TeacherID
    WHERE t.AccountID = @TeacherID
      AND (@CourseID IS NULL OR e.CourseID = @CourseID)
      AND (@Status = N'Tất cả trạng thái' OR e.Status = @Status)
      AND (
            @SearchKeyword = N'' 
         OR u.FullName LIKE '%' + @SearchKeyword + '%'
         OR u.Email LIKE '%' + @SearchKeyword + '%'
      )
    ORDER BY e.EnrollmentDate DESC;
END
GO

IF OBJECT_ID('sp_GetStudentSummaryByTeacher', 'P') IS NOT NULL
    DROP PROCEDURE sp_GetStudentSummaryByTeacher;
GO

CREATE PROCEDURE sp_GetStudentSummaryByTeacher
    @TeacherID VARCHAR(50),
    @CourseID INT = NULL
AS
BEGIN
    SET NOCOUNT ON;

    SELECT 
        COUNT(*) AS Total,
        SUM(CASE WHEN e.Status = 'Learning'  THEN 1 ELSE 0 END) AS Active,
        SUM(CASE WHEN e.Status = 'Completed' THEN 1 ELSE 0 END) AS Completed
    FROM Enrollments e
    JOIN Courses c ON c.CourseID = e.CourseID
    JOIN CourseTeachers ct ON ct.CourseID = c.CourseID
    JOIN Users t ON t.UserID = ct.TeacherID
    WHERE t.AccountID = @TeacherID
      AND (@CourseID IS NULL OR e.CourseID = @CourseID);
END
GO

IF OBJECT_ID('sp_GetAllSubmissions', 'P') IS NOT NULL
    DROP PROCEDURE sp_GetAllSubmissions
GO

CREATE PROCEDURE sp_GetAllSubmissions
    @TeacherID VARCHAR(50),  -- ✅ Đã sửa
    @CourseID INT = NULL,
    @StatusFilter NVARCHAR(50) = NULL
AS
BEGIN
    SET NOCOUNT ON;
    
    SELECT 
        s.SubmissionID,
        u.FullName AS StudentName,
        a.Title AS AssignmentTitle,
        c.Title AS CourseName,
        s.SubmissionDate,
        a.DueDate,
        s.Status,
        s.Score
    FROM Submissions s
    JOIN Assignments a ON a.AssignmentID = s.AssignmentID
    JOIN Courses c ON c.CourseID = a.CourseID
    JOIN Enrollments e ON e.StudentID = s.StudentID AND e.CourseID = c.CourseID
    JOIN CourseTeachers ct ON ct.CourseID = c.CourseID
    JOIN Users t ON t.UserID = ct.TeacherID
    JOIN Users u ON u.UserID = s.StudentID
    WHERE t.AccountID = @TeacherID
      AND (@CourseID IS NULL OR c.CourseID = @CourseID)
      AND (@StatusFilter IS NULL OR s.Status = @StatusFilter)
    ORDER BY s.SubmissionDate DESC;
END
GO
