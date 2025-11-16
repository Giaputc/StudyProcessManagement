-- Tạo database
CREATE DATABASE QuanLyHocTap;
GO

-- Sử dụng database vừa tạo
USE QuanLyHocTap;
GO

-- Tạo bảng Monhoc
CREATE TABLE Monhoc
(
  Mamonhoc INT NOT NULL PRIMARY KEY,
  Tenmonhoc NVARCHAR(100) NOT NULL,
  Thoigianhoc INT NOT NULL
);

-- Tạo bảng Tainguyen
CREATE TABLE Tainguyen
(
  Matainguyen INT NOT NULL PRIMARY KEY,
  Loaitainguyen NVARCHAR(50) NOT NULL,
  Tientrinh NVARCHAR(50),
  Mamonhoc INT NOT NULL,
  FOREIGN KEY (Mamonhoc) REFERENCES Monhoc(Mamonhoc)
);

-- Tạo bảng Baitap
CREATE TABLE Baitap
(
  Mabaitap INT NOT NULL PRIMARY KEY,
  Tientrinhbaitap NVARCHAR(50),
  Thoigian INT NOT NULL,
  Loai NVARCHAR(50),
  Mamonhoc INT NOT NULL,
  FOREIGN KEY (Mamonhoc) REFERENCES Monhoc(Mamonhoc)
);

-- Tạo bảng Giangvien
CREATE TABLE Giangvien
(
  Magv INT NOT NULL PRIMARY KEY,
  Ho NVARCHAR(50) NOT NULL,
  Ten NVARCHAR(50) NOT NULL,
  Sdt NVARCHAR(15),
  Email NVARCHAR(100)
);

-- Tạo bảng Nganh
CREATE TABLE Nganh
(
  Manganh INT NOT NULL PRIMARY KEY,
  Tennganh NVARCHAR(100) NOT NULL
);

-- Tạo bảng Giangday
CREATE TABLE Giangday
(
  Magv INT NOT NULL,
  Mamonhoc INT NOT NULL,
  PRIMARY KEY (Magv, Mamonhoc),
  FOREIGN KEY (Magv) REFERENCES Giangvien(Magv),
  FOREIGN KEY (Mamonhoc) REFERENCES Monhoc(Mamonhoc)
);

-- Tạo bảng Lop
CREATE TABLE Lop
(
  Malophoc INT NOT NULL PRIMARY KEY,
  Tenlophoc NVARCHAR(50) NOT NULL,
  Siso INT,
  Manganh INT NOT NULL,
  FOREIGN KEY (Manganh) REFERENCES Nganh(Manganh)
);

-- Tạo bảng Sinhvien
CREATE TABLE Sinhvien
(
  Masinhvien INT NOT NULL PRIMARY KEY,
  Ho NVARCHAR(50) NOT NULL,
  Ten NVARCHAR(50) NOT NULL,
  Nienkhoa NVARCHAR(20),
  Sdt NVARCHAR(15),
  Email NVARCHAR(100),
  Malophoc INT NOT NULL,
  FOREIGN KEY (Malophoc) REFERENCES Lop(Malophoc)
);

-- Tạo bảng Phutrach
CREATE TABLE Phutrach
(
  Malophoc INT NOT NULL,
  Magv INT NOT NULL,
  PRIMARY KEY (Malophoc, Magv),
  FOREIGN KEY (Malophoc) REFERENCES Lop(Malophoc),
  FOREIGN KEY (Magv) REFERENCES Giangvien(Magv)
);

-- Tạo bảng KetQuaHoc
CREATE TABLE KetQuaHoc
(
  Masinhvien INT NOT NULL,
  Mamonhoc INT NOT NULL,
  Diem FLOAT,
  Hocky NVARCHAR(20),
  PRIMARY KEY (Masinhvien, Mamonhoc),
  FOREIGN KEY (Masinhvien) REFERENCES Sinhvien(Masinhvien),
  FOREIGN KEY (Mamonhoc) REFERENCES Monhoc(Mamonhoc)
);