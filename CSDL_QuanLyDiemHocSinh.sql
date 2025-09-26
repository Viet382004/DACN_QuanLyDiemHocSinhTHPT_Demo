USE master
CREATE DATABASE QLDHSTHPT
GO
USE QLDHSTHPT
GO

CREATE TABLE HOC_SINH (
    MaHS INT PRIMARY KEY,
    HoTenHS NVARCHAR(100) NOT NULL,
    GioiTinh NVARCHAR(10),
    NgaySinh DATE,
    DiaChi NVARCHAR(200),
	MaLop INT,
);
GO
ALTER TABLE HOC_SINH
ADD CONSTRAINT FK_HOC_SINH_LOP FOREIGN KEY (MaLop) REFERENCES Lop(MaLop);
GO

--Do bên dưới tạo có 10 mã lớp mà trong bảng HOC_SINH có tận 12 nên lỗi , chạy dòng này để tạo khóa ngoại MaLop cho bảng HOC_SINH
UPDATE HOC_SINH
SET MaLop = 1
WHERE MaLop NOT IN (SELECT MaLop FROM LOP);






CREATE TABLE GIAO_VIEN (
    MaGV INT PRIMARY KEY,
    HoTenGV NVARCHAR(100) NOT NULL,
    GioiTinh NVARCHAR(10),
    NgaySinh DATE,
    SDT VARCHAR(15),
    Email VARCHAR(100)
);
GO


CREATE TABLE LOP (
    MaLop INT PRIMARY KEY,
    TenLop NVARCHAR(50) NOT NULL,
    Khoi INT,
    MaGV INT
);
GO


ALTER TABLE LOP
ADD CONSTRAINT FK_LOP_GVCN FOREIGN KEY (MaGV) REFERENCES GIAO_VIEN(MaGV);
GO



CREATE TABLE MON_HOC (
    MaMon INT PRIMARY KEY,
    TenMon NVARCHAR(100) NOT NULL,
    SoTiet INT
);
GO


CREATE TABLE DIEM (
    MaHS INT not null,
    MaMon INT not null,
    HocKy TINYINT NOT NULL,
    NamHoc VARCHAR(9) NOT NULL,
    DiemKT FLOAT,
    DiemGK FLOAT,
    DiemThi FLOAT
);
GO
ALTER TABLE DIEM
ADD CONSTRAINT PK_DIEM PRIMARY KEY (MaHS,MaMon);

ALTER TABLE DIEM
ADD CONSTRAINT FK_DIEM_HS FOREIGN KEY (MaHS) REFERENCES HOC_SINH(MaHS);

ALTER TABLE DIEM
ADD CONSTRAINT FK_DIEM_MON FOREIGN KEY (MaMon) REFERENCES MON_HOC(MaMon);
GO
CREATE TABLE GIANG_DAY (
    MaLop INT NOT NULL,
    MaGV INT NOT NULL,
    MaMon INT NOT NULL,
	NgayBatDau Date,
	NgayKetThuc Date,
	PhongHoc INT,
);
GO
ALTER TABLE GIANG_DAY
ADD CONSTRAINT PK_GIANGDAY PRIMARY KEY (MaLop, MaGV, MaMon);

ALTER TABLE GIANG_DAY
ADD CONSTRAINT FK_GIANGDAY_LOP FOREIGN KEY (MaLop) REFERENCES LOP(MaLop);

ALTER TABLE GIANG_DAY
ADD CONSTRAINT FK_GIANGDAY_GV FOREIGN KEY (MaGV) REFERENCES GIAO_VIEN(MaGV);

ALTER TABLE GIANG_DAY
ADD CONSTRAINT FK_GIANGDAY_MON FOREIGN KEY (MaMon) REFERENCES MON_HOC(MaMon);
GO

CREATE TABLE TAI_KHOAN (
    MaTK INT PRIMARY KEY,
    TenDangNhap VARCHAR(50) UNIQUE NOT NULL,
    MatKhau VARCHAR(255) NOT NULL,
    VaiTro NVARCHAR(20) NOT NULL,
    MaHS INT NULL,
    MaGV INT NULL
);
GO
ALTER TABLE TAI_KHOAN
ADD CONSTRAINT FK_TK_HS FOREIGN KEY (MaHS) REFERENCES HOC_SINH(MaHS);

ALTER TABLE TAI_KHOAN
ADD CONSTRAINT FK_TK_GV FOREIGN KEY (MaGV) REFERENCES GIAO_VIEN(MaGV);
GO


-- Tạo bảng tạm chứa các họ và tên phổ biến
CREATE TABLE #TempNames (
    ID INT IDENTITY(1,1),
    Ho NVARCHAR(50),
    DemNam NVARCHAR(50),
    TenNam NVARCHAR(50),
    DemNu NVARCHAR(50),
    TenNu NVARCHAR(50)
);

INSERT INTO #TempNames (Ho, DemNam, TenNam, DemNu, TenNu)
VALUES
(N'Nguyễn', N'Văn', N'An', N'Thị', N'Anh'),
(N'Trần', N'Văn', N'Bình', N'Thị', N'Bích'),
(N'Lê', N'Văn', N'Cường', N'Thị', N'Châu'),
(N'Phạm', N'Văn', N'Dũng', N'Thị', N'Dung'),
(N'Hoàng', N'Văn', N'Đạt', N'Thị', N'Đào'),
(N'Phan', N'Văn', N'Giang', N'Thị', N'Giang'),
(N'Vũ', N'Văn', N'Hải', N'Thị', N'Hà'),
(N'Đặng', N'Văn', N'Hùng', N'Thị', N'Hằng'),
(N'Bùi', N'Văn', N'Khoa', N'Thị', N'Hoa'),
(N'Đỗ', N'Văn', N'Long', N'Thị', N'Hồng'),
(N'Ngô', N'Văn', N'Mạnh', N'Thị', N'Huệ'),
(N'Dương', N'Văn', N'Nam', N'Thị', N'Hương'),
(N'Lý', N'Văn', N'Phong', N'Thị', N'Lan'),
(N'Đinh', N'Văn', N'Quang', N'Thị', N'Liên'),
(N'Lâm', N'Văn', N'Quân', N'Thị', N'Linh'),
(N'Mai', N'Văn', N'Sơn', N'Thị', N'Loan'),
(N'Võ', N'Văn', N'Thắng', N'Thị', N'Mai'),
(N'Trịnh', N'Văn', N'Tiến', N'Thị', N'My'),
(N'Đoàn', N'Văn', N'Trung', N'Thị', N'Nga'),
(N'Lưu', N'Văn', N'Tú', N'Thị', N'Ngọc'),
(N'Lương', N'Văn', N'Tùng', N'Thị', N'Nhung'),
(N'Phùng', N'Văn', N'Việt', N'Thị', N'Oanh'),
(N'Hồ', N'Văn', N'Vũ', N'Thị', N'Phương'),
(N'Trương', N'Văn', N'Xuân', N'Thị', N'Quỳnh'),
(N'Chu', N'Văn', N'Yến', N'Thị', N'Thảo');

-- Tạo dữ liệu cho 300 học sinh
DECLARE @i INT = 1;
DECLARE @MaLop INT;
DECLARE @Ho NVARCHAR(50), @Dem NVARCHAR(50), @Ten NVARCHAR(50);
DECLARE @GioiTinh NVARCHAR(10);

WHILE @i <= 300
BEGIN
    SET @MaLop = CAST(RAND() * 12 + 1 AS INT); -- Giả sử có 12 lớp (từ 1 đến 12)
    SET @GioiTinh = CASE WHEN @i % 2 = 0 THEN N'Nam' ELSE N'Nữ' END;
    
    -- Chọn ngẫu nhiên một tên từ bảng tạm
    DECLARE @NameID INT = CAST(RAND() * 25 + 1 AS INT);
    SELECT @Ho = Ho, 
           @Dem = CASE WHEN @GioiTinh = N'Nam' THEN DemNam ELSE DemNu END,
           @Ten = CASE WHEN @GioiTinh = N'Nam' THEN TenNam ELSE TenNu END
    FROM #TempNames
    WHERE ID = @NameID;
    
    INSERT INTO HOC_SINH (MaHS, HoTenHS, GioiTinh, NgaySinh, DiaChi, MaLop)
    VALUES (
        @i,
        @Ho + ' ' + @Dem + ' ' + @Ten,
        @GioiTinh,
        DATEADD(DAY, -CAST(RAND() * 1000 AS INT), '2007-01-01'),
        N'Đường ' + CAST(@i AS NVARCHAR(10)) + N', Quận ' + CAST(@i % 12 + 1 AS NVARCHAR(2)) + N', TP.HCM',
        @MaLop
    );
    
    SET @i = @i + 1;
END;

SELECT * 
FROM INFORMATION_SCHEMA.COLUMNS
WHERE TABLE_NAME = 'HOC_SINH';


-- Xóa bảng tạm
DROP TABLE #TempNames;
GO


-- Tạo dữ liệu mẫu cho 30 giáo viên
INSERT INTO GIAO_VIEN (MaGV, HoTenGV, GioiTinh, NgaySinh, SDT, Email)
VALUES
(1, N'Nguyễn Văn Anh', N'Nam', '1980-05-15', '0909123456', 'nguyenvananh@school.edu.vn'),
(2, N'Trần Thị Bích', N'Nữ', '1982-08-22', '0909123457', 'tranthibich@school.edu.vn'),
(3, N'Lê Hoàng Cường', N'Nam', '1978-03-10', '0909123458', 'lehoangcuong@school.edu.vn'),
(4, N'Phạm Thị Dung', N'Nữ', '1985-11-28', '0909123459', 'phamthidung@school.edu.vn'),
(5, N'Hoàng Văn Đức', N'Nam', '1975-12-03', '0909123460', 'hoangvanduc@school.edu.vn'),
(6, N'Vũ Thị Hương', N'Nữ', '1983-07-19', '0909123461', 'vuthihuong@school.edu.vn'),
(7, N'Đặng Văn Hải', N'Nam', '1979-09-25', '0909123462', 'dangvanhai@school.edu.vn'),
(8, N'Bùi Thị Lan', N'Nữ', '1981-04-30', '0909123463', 'buithilan@school.edu.vn'),
(9, N'Đỗ Văn Minh', N'Nam', '1977-06-14', '0909123464', 'dovanminh@school.edu.vn'),
(10, N'Ngô Thị Nga', N'Nữ', '1984-02-08', '0909123465', 'ngothinga@school.edu.vn'),
(11, N'Phan Văn Phong', N'Nam', '1980-10-12', '0909123466', 'phanvanphong@school.edu.vn'),
(12, N'Trịnh Thị Quỳnh', N'Nữ', '1982-01-17', '0909123467', 'trinhthiquynh@school.edu.vn'),
(13, N'Lý Văn Sơn', N'Nam', '1976-08-23', '0909123468', 'lyvanson@school.edu.vn'),
(14, N'Mai Thị Tâm', N'Nữ', '1983-03-07', '0909123469', 'maithitam@school.edu.vn'),
(15, N'Võ Văn Thành', N'Nam', '1978-05-21', '0909123470', 'vovanthanh@school.edu.vn'),
(16, N'Đinh Thị Uyên', N'Nữ', '1985-07-11', '0909123471', 'dinhthiuyen@school.edu.vn'),
(17, N'Lâm Văn Việt', N'Nam', '1979-12-29', '0909123472', 'lamvanviet@school.edu.vn'),
(18, N'Chu Thị Xuân', N'Nữ', '1981-09-04', '0909123473', 'chuthixuan@school.edu.vn'),
(19, N'Phùng Văn Yên', N'Nam', '1977-02-16', '0909123474', 'phungvanyen@school.edu.vn'),
(20, N'Hồ Thị Ánh', N'Nữ', '1984-06-09', '0909123475', 'hothianh@school.edu.vn'),
(21, N'Đoàn Văn Bảo', N'Nam', '1980-11-26', '0909123476', 'doanvanbao@school.edu.vn'),
(22, N'Lưu Thị Châu', N'Nữ', '1982-04-13', '0909123477', 'luuthichau@school.edu.vn'),
(23, N'Trương Văn Đạt', N'Nam', '1978-10-08', '0909123478', 'truongvandat@school.edu.vn'),
(24, N'Nguyễn Thị Hạnh', N'Nữ', '1983-01-31', '0909123479', 'nguyenthihanh@school.edu.vn'),
(25, N'Trần Văn Khôi', N'Nam', '1976-07-22', '0909123480', 'tranvankhoi@school.edu.vn'),
(26, N'Lê Thị Liên', N'Nữ', '1985-05-18', '0909123481', 'lethilien@school.edu.vn'),
(27, N'Phạm Văn Mạnh', N'Nam', '1979-08-05', '0909123482', 'phamvanmanh@school.edu.vn'),
(28, N'Hoàng Thị Ngọc', N'Nữ', '1981-03-27', '0909123483', 'hoathingoc@school.edu.vn'),
(29, N'Vũ Văn Phú', N'Nam', '1977-12-14', '0909123484', 'vuvanphu@school.edu.vn'),
(30, N'Đặng Thị Quyên', N'Nữ', '1984-09-02', '0909123485', 'dangthiquyen@school.edu.vn');
GO

USE QLDHSTHPT;
GO

-- Tạo tài khoản cho 300 học sinh
INSERT INTO TAI_KHOAN (MaTK, TenDangNhap, MatKhau, VaiTro, MaHS, MaGV)
SELECT 
    ROW_NUMBER() OVER (ORDER BY MaHS) + 1000 AS MaTK, -- Bắt đầu từ 1001 để tránh trùng với giáo viên
    'hs' + RIGHT('000' + CAST(MaHS AS VARCHAR(3)), 3) AS TenDangNhap,
    '123456' AS MatKhau, -- Mật khẩu mặc định
    N'Học sinh' AS VaiTro,
    MaHS,
    NULL AS MaGV
FROM HOC_SINH;
GO

USE QLDHSTHPT;
GO

-- Tạo tài khoản cho 30 giáo viên
INSERT INTO TAI_KHOAN (MaTK, TenDangNhap, MatKhau, VaiTro, MaHS, MaGV)
SELECT 
    (SELECT ISNULL(MAX(MaTK), 0) FROM TAI_KHOAN) + ROW_NUMBER() OVER (ORDER BY MaGV) AS MaTK,
    'gv' + RIGHT('00' + CAST(MaGV AS VARCHAR(2)), 2) AS TenDangNhap,
    CONVERT(VARCHAR(255), HASHBYTES('SHA2_256', '123456'), 2) AS MatKhau,
    N'Giáo viên' AS VaiTro,
    NULL AS MaHS,
    MaGV
FROM GIAO_VIEN
WHERE NOT EXISTS (
    SELECT 1 FROM TAI_KHOAN 
    WHERE TenDangNhap = 'gv' + RIGHT('00' + CAST(GIAO_VIEN.MaGV AS VARCHAR(2)), 2)
);
GO
USE QLDHSTHPT;
GO

-- Tạo thông tin cho 10 lớp học
INSERT INTO LOP (MaLop, TenLop, Khoi, MaGV)
VALUES
(1, N'10A1', 10, 1),
(2, N'10A2', 10, 2),
(3, N'10A3', 10, 3),
(4, N'10A4', 10, 4),
(5, N'10A5', 10, 5),
(6, N'10A6', 10, 6),
(7, N'10A7', 10, 7),
(8, N'10A8', 10, 8),
(9, N'10A9', 10, 9),
(10, N'10A10', 10, 10);
GO


-- Kiểm tra kết quả
SELECT * FROM LOP ORDER BY MaLop;
GO

USE QLDHSTHPT;
GO

-- Tạo thông tin cho 12 môn học cơ bản
INSERT INTO MON_HOC (MaMon, TenMon, SoTiet)
VALUES
(1, N'Toán', 45),
(2, N'Ngữ Văn', 45),
(3, N'Tiếng Anh', 45),
(4, N'Vật Lý', 45),
(5, N'Hóa Học', 45),
(6, N'Sinh Học', 45),
(7, N'Lịch Sử', 45),
(8, N'Địa Lý', 45),
(9, N'Giáo Dục Công Dân', 45),
(10, N'Tin Học', 45),
(11, N'Công Nghệ', 45),
(12, N'Thể Dục', 45);
GO

-- Kiểm tra kết quả
SELECT * FROM MON_HOC ORDER BY MaMon;
GO


-- Xóa dữ liệu điểm cũ của 10 học sinh này (nếu có)
DELETE FROM DIEM 
WHERE MaHS IN (1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31, 32, 33, 34, 35, 36, 37, 38, 39, 40, 41, 42, 43, 44, 45, 46, 47, 48, 49, 50, 51, 52, 53, 54, 55, 56, 57, 58, 59, 60, 61, 62, 63, 64, 65, 66, 67, 68, 69, 70, 71, 72, 73, 74, 75, 76, 77, 78, 79, 80, 81, 82, 83, 84, 85, 86, 87, 88, 89, 90, 91, 92, 93, 94, 95, 96, 97, 98, 99, 100, 101, 102, 103, 104, 105, 106, 107, 108, 109, 110, 111, 112, 113, 114, 115, 116, 117, 118, 119, 120, 121, 122, 123, 124, 125, 126, 127, 128, 129, 130, 131, 132, 133, 134, 135, 136, 137, 138, 139, 140, 141, 142, 143, 144, 145, 146, 147, 148, 149, 150, 151, 152, 153, 154, 155, 156, 157, 158, 159, 160, 161, 162, 163, 164, 165, 166, 167, 168, 169, 170, 171, 172, 173, 174, 175, 176, 177, 178, 179, 180, 181, 182, 183, 184, 185, 186, 187, 188, 189, 190, 191, 192, 193, 194, 195, 196, 197, 198, 199, 200, 201, 202, 203, 204, 205, 206, 207, 208, 209, 210, 211, 212, 213, 214, 215, 216, 217, 218, 219, 220, 221, 222, 223, 224, 225, 226, 227, 228, 229, 230, 231, 232, 233, 234, 235, 236, 237, 238, 239, 240, 241, 242, 243, 244, 245, 246, 247, 248, 249, 250, 251, 252, 253, 254, 255, 256, 257, 258, 259, 260, 261, 262, 263, 264, 265, 266, 267, 268, 269, 270, 271, 272, 273, 274, 275, 276, 277, 278, 279, 280, 281, 282, 283, 284, 285, 286, 287, 288, 289, 290, 291, 292, 293, 294, 295, 296, 297, 298, 299, 300);
GO

-- Tạo dữ liệu điểm cho 10 học sinh đầu tiên
DECLARE @MaHS VARCHAR(10);
DECLARE @MaMon INT;
DECLARE @HocKy TINYINT;
DECLARE @NamHoc VARCHAR(9) = '2023-2024';
DECLARE @DiemKT FLOAT, @DiemGK FLOAT, @DiemThi FLOAT;

-- Duyệt qua 10 học sinh đầu tiên
DECLARE @i INT = 1;
WHILE @i <= 300
BEGIN
    SET @MaHS =  RIGHT(  CAST(@i AS VARCHAR(3)), 3);
    
    -- Duyệt qua tất cả môn học (12 môn)
    SET @MaMon = 1;
    WHILE @MaMon <= 12
    BEGIN
        -- Duyệt qua 2 học kỳ
        SET @HocKy = 1;
        WHILE @HocKy <= 2
        BEGIN
            -- Tạo điểm ngẫu nhiên với phân phối thực tế
            -- Học sinh có mã số thấp hơn thường có điểm cao hơn (giả định)
            DECLARE @baseScore FLOAT = CASE 
                WHEN @i <= 3 THEN 7.0  -- HS001-HS003: học sinh giỏi
                WHEN @i <= 7 THEN 5.5  -- HS004-HS007: học sinh khá
                ELSE 4.0               -- HS008-HS010: học sinh trung bình
            END;
            
            -- Tạo điểm ngẫu nhiên xung quanh baseScore
            SET @DiemKT = CAST((RAND() * 3 + @baseScore - 1.5) AS DECIMAL(4,1));
            SET @DiemGK = CAST((RAND() * 3 + @baseScore - 1.5) AS DECIMAL(4,1));
            SET @DiemThi = CAST((RAND() * 3 + @baseScore - 1.5) AS DECIMAL(4,1));
            
            -- Đảm bảo điểm trong khoảng 0-10
            IF @DiemKT < 0 SET @DiemKT = 0;
            IF @DiemKT > 10 SET @DiemKT = 10;
            
            IF @DiemGK < 0 SET @DiemGK = 0;
            IF @DiemGK > 10 SET @DiemGK = 10;
            
            IF @DiemThi < 0 SET @DiemThi = 0;
            IF @DiemThi > 10 SET @DiemThi = 10;
            
            -- Chèn dữ liệu điểm
            INSERT INTO DIEM (MaHS, MaMon, HocKy, NamHoc, DiemKT, DiemGK, DiemThi)
            VALUES (@MaHS, @MaMon, @HocKy, @NamHoc, @DiemKT, @DiemGK, @DiemThi);
            
            SET @HocKy = @HocKy + 1;
        END
        
        SET @MaMon = @MaMon + 1;
    END
    
    PRINT 'Đã tạo điểm cho học sinh: ' + @MaHS;
    SET @i = @i + 1;
END
GO

-- Hiển thị thông báo hoàn thành
PRINT 'Đã hoàn thành tạo điểm cho 10 học sinh đầu tiên';
GO

-- Kiểm tra dữ liệu điểm
SELECT COUNT(*) AS 'Số bản ghi điểm đã tạo' 
FROM DIEM 
WHERE MaHS IN (1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31, 32, 33, 34, 35, 36, 37, 38, 39, 40, 41, 42, 43, 44, 45, 46, 47, 48, 49, 50, 51, 52, 53, 54, 55, 56, 57, 58, 59, 60, 61, 62, 63, 64, 65, 66, 67, 68, 69, 70, 71, 72, 73, 74, 75, 76, 77, 78, 79, 80, 81, 82, 83, 84, 85, 86, 87, 88, 89, 90, 91, 92, 93, 94, 95, 96, 97, 98, 99, 100, 101, 102, 103, 104, 105, 106, 107, 108, 109, 110, 111, 112, 113, 114, 115, 116, 117, 118, 119, 120, 121, 122, 123, 124, 125, 126, 127, 128, 129, 130, 131, 132, 133, 134, 135, 136, 137, 138, 139, 140, 141, 142, 143, 144, 145, 146, 147, 148, 149, 150, 151, 152, 153, 154, 155, 156, 157, 158, 159, 160, 161, 162, 163, 164, 165, 166, 167, 168, 169, 170, 171, 172, 173, 174, 175, 176, 177, 178, 179, 180, 181, 182, 183, 184, 185, 186, 187, 188, 189, 190, 191, 192, 193, 194, 195, 196, 197, 198, 199, 200, 201, 202, 203, 204, 205, 206, 207, 208, 209, 210, 211, 212, 213, 214, 215, 216, 217, 218, 219, 220, 221, 222, 223, 224, 225, 226, 227, 228, 229, 230, 231, 232, 233, 234, 235, 236, 237, 238, 239, 240, 241, 242, 243, 244, 245, 246, 247, 248, 249, 250, 251, 252, 253, 254, 255, 256, 257, 258, 259, 260, 261, 262, 263, 264, 265, 266, 267, 268, 269, 270, 271, 272, 273, 274, 275, 276, 277, 278, 279, 280, 281, 282, 283, 284, 285, 286, 287, 288, 289, 290, 291, 292, 293, 294, 295, 296, 297, 298, 299, 300);
GO

-- Xem điểm chi tiết của 10 học sinh này
SELECT 
    HS.MaHS,
    HS.HoTenHS,
    M.TenMon,
    D.HocKy,
    D.DiemKT,
    D.DiemGK,
    D.DiemThi,
    CAST((D.DiemKT * 0.2 + D.DiemGK * 0.3 + D.DiemThi * 0.5) AS DECIMAL(4,2)) AS DiemTB
FROM DIEM D
INNER JOIN HOC_SINH HS ON D.MaHS = HS.MaHS
INNER JOIN MON_HOC M ON D.MaMon = M.MaMon
WHERE HS.MaHS IN (1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31, 32, 33, 34, 35, 36, 37, 38, 39, 40, 41, 42, 43, 44, 45, 46, 47, 48, 49, 50, 51, 52, 53, 54, 55, 56, 57, 58, 59, 60, 61, 62, 63, 64, 65, 66, 67, 68, 69, 70, 71, 72, 73, 74, 75, 76, 77, 78, 79, 80, 81, 82, 83, 84, 85, 86, 87, 88, 89, 90, 91, 92, 93, 94, 95, 96, 97, 98, 99, 100, 101, 102, 103, 104, 105, 106, 107, 108, 109, 110, 111, 112, 113, 114, 115, 116, 117, 118, 119, 120, 121, 122, 123, 124, 125, 126, 127, 128, 129, 130, 131, 132, 133, 134, 135, 136, 137, 138, 139, 140, 141, 142, 143, 144, 145, 146, 147, 148, 149, 150, 151, 152, 153, 154, 155, 156, 157, 158, 159, 160, 161, 162, 163, 164, 165, 166, 167, 168, 169, 170, 171, 172, 173, 174, 175, 176, 177, 178, 179, 180, 181, 182, 183, 184, 185, 186, 187, 188, 189, 190, 191, 192, 193, 194, 195, 196, 197, 198, 199, 200, 201, 202, 203, 204, 205, 206, 207, 208, 209, 210, 211, 212, 213, 214, 215, 216, 217, 218, 219, 220, 221, 222, 223, 224, 225, 226, 227, 228, 229, 230, 231, 232, 233, 234, 235, 236, 237, 238, 239, 240, 241, 242, 243, 244, 245, 246, 247, 248, 249, 250, 251, 252, 253, 254, 255, 256, 257, 258, 259, 260, 261, 262, 263, 264, 265, 266, 267, 268, 269, 270, 271, 272, 273, 274, 275, 276, 277, 278, 279, 280, 281, 282, 283, 284, 285, 286, 287, 288, 289, 290, 291, 292, 293, 294, 295, 296, 297, 298, 299, 300)
ORDER BY HS.MaHS, M.MaMon, D.HocKy;
GO

-- Thống kê điểm trung bình của 10 học sinh này
SELECT 
    HS.MaHS,
    HS.HoTenHS,
    COUNT(*) AS SoMonHoc,
    AVG(CAST((D.DiemKT * 0.2 + D.DiemGK * 0.3 + D.DiemThi * 0.5) AS DECIMAL(4,2))) AS DiemTBChung
FROM DIEM D
INNER JOIN HOC_SINH HS ON D.MaHS = HS.MaHS
WHERE HS.MaHS IN (1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31, 32, 33, 34, 35, 36, 37, 38, 39, 40, 41, 42, 43, 44, 45, 46, 47, 48, 49, 50, 51, 52, 53, 54, 55, 56, 57, 58, 59, 60, 61, 62, 63, 64, 65, 66, 67, 68, 69, 70, 71, 72, 73, 74, 75, 76, 77, 78, 79, 80, 81, 82, 83, 84, 85, 86, 87, 88, 89, 90, 91, 92, 93, 94, 95, 96, 97, 98, 99, 100, 101, 102, 103, 104, 105, 106, 107, 108, 109, 110, 111, 112, 113, 114, 115, 116, 117, 118, 119, 120, 121, 122, 123, 124, 125, 126, 127, 128, 129, 130, 131, 132, 133, 134, 135, 136, 137, 138, 139, 140, 141, 142, 143, 144, 145, 146, 147, 148, 149, 150, 151, 152, 153, 154, 155, 156, 157, 158, 159, 160, 161, 162, 163, 164, 165, 166, 167, 168, 169, 170, 171, 172, 173, 174, 175, 176, 177, 178, 179, 180, 181, 182, 183, 184, 185, 186, 187, 188, 189, 190, 191, 192, 193, 194, 195, 196, 197, 198, 199, 200, 201, 202, 203, 204, 205, 206, 207, 208, 209, 210, 211, 212, 213, 214, 215, 216, 217, 218, 219, 220, 221, 222, 223, 224, 225, 226, 227, 228, 229, 230, 231, 232, 233, 234, 235, 236, 237, 238, 239, 240, 241, 242, 243, 244, 245, 246, 247, 248, 249, 250, 251, 252, 253, 254, 255, 256, 257, 258, 259, 260, 261, 262, 263, 264, 265, 266, 267, 268, 269, 270, 271, 272, 273, 274, 275, 276, 277, 278, 279, 280, 281, 282, 283, 284, 285, 286, 287, 288, 289, 290, 291, 292, 293, 294, 295, 296, 297, 298, 299, 300)
GROUP BY HS.MaHS, HS.HoTenHS
ORDER BY HS.MaHS;
GO


USE QLDHSTHPT;
GO

-- Xóa dữ liệu cũ của 10 giáo viên này trong bảng GIANG_DAY (nếu có)
DELETE FROM GIANG_DAY 
WHERE MaGV BETWEEN 1 AND 10;
GO

-- Tạo dữ liệu giảng dạy cho 10 giáo viên đầu tiên
DECLARE @MaGV INT = 1;
DECLARE @MaMon INT;
DECLARE @MaLop INT;
DECLARE @NgayBatDau DATE;
DECLARE @NgayKetThuc DATE;
DECLARE @PhongHoc INT;

WHILE @MaGV <= 30
BEGIN
    -- Mỗi giáo viên dạy từ 2-4 môn
    DECLARE @SoMonDay INT = CAST(RAND() * 3 + 2 AS INT);
    DECLARE @monCount INT = 1;
    
    WHILE @monCount <= @SoMonDay
    BEGIN
        -- Chọn ngẫu nhiên một môn học (từ 1 đến 12)
        SET @MaMon = CAST(RAND() * 12 + 1 AS INT);
        
        -- Mỗi môn dạy ở 1-3 lớp
        DECLARE @lopCount INT = 1;
        DECLARE @soLopDay INT = CAST(RAND() * 3 + 1 AS INT);
        
        WHILE @lopCount <= @soLopDay
        BEGIN
            -- Chọn ngẫu nhiên một lớp (từ 1 đến 10)
            SET @MaLop = CAST(RAND() * 10 + 1 AS INT);
            
            -- Kiểm tra xem giáo viên đã được phân công dạy môn này ở lớp này chưa
            IF NOT EXISTS (
                SELECT 1 FROM GIANG_DAY 
                WHERE MaGV = @MaGV AND MaMon = @MaMon AND MaLop = @MaLop
            )
            BEGIN
                -- Thiết lập ngày bắt đầu và kết thúc (trong năm học 2023-2024)
                SET @NgayBatDau = DATEADD(DAY, CAST(RAND() * 60 AS INT), '2023-09-05');
                SET @NgayKetThuc = DATEADD(DAY, CAST(RAND() * 120 + 60 AS INT), @NgayBatDau);
                
                -- Đảm bảo ngày kết thúc không vượt quá 31/05/2024
                IF @NgayKetThuc > '2024-05-31'
                    SET @NgayKetThuc = '2024-05-31';
                
                -- Tạo phòng học ngẫu nhiên (từ 1 đến 20)
                SET @PhongHoc = CAST(RAND() * 20 + 1 AS INT);
                
                -- Chèn dữ liệu giảng dạy
                INSERT INTO GIANG_DAY (MaLop, MaGV, MaMon, NgayBatDau, NgayKetThuc, PhongHoc)
                VALUES (@MaLop, @MaGV, @MaMon, @NgayBatDau, @NgayKetThuc, @PhongHoc);
            END
            
            SET @lopCount = @lopCount + 1;
        END
        
        SET @monCount = @monCount + 1;
    END
    
    PRINT 'Đã phân công giảng dạy cho giáo viên: ' + CAST(@MaGV AS VARCHAR(10));
    SET @MaGV = @MaGV + 1;
END
GO

-- Hiển thị thông báo hoàn thành
PRINT 'Đã hoàn thành phân công giảng dạy cho 10 giáo viên đầu tiên';
GO

-- Kiểm tra dữ liệu giảng dạy
SELECT COUNT(*) AS 'Số bản ghi phân công' 
FROM GIANG_DAY 
WHERE MaGV BETWEEN 1 AND 10;
GO

-- Xem thông tin giảng dạy chi tiết
SELECT 
    GD.MaLop,
    L.TenLop,
    GD.MaGV,
    GV.HoTenGV,
    GD.MaMon,
    M.TenMon,
    GD.NgayBatDau,
    GD.NgayKetThuc,
    GD.PhongHoc,
    DATEDIFF(WEEK, GD.NgayBatDau, GD.NgayKetThuc) AS SoTuanGiangDay
FROM GIANG_DAY GD
INNER JOIN LOP L ON GD.MaLop = L.MaLop
INNER JOIN GIAO_VIEN GV ON GD.MaGV = GV.MaGV
INNER JOIN MON_HOC M ON GD.MaMon = M.MaMon
WHERE GD.MaGV BETWEEN 1 AND 10
ORDER BY GD.MaGV, GD.MaLop, GD.MaMon;
GO

-- Thống kê số môn mỗi giáo viên dạy
SELECT 
    GV.MaGV,
    GV.HoTenGV,
    COUNT(DISTINCT GD.MaMon) AS SoMonDay,
    COUNT(DISTINCT GD.MaLop) AS SoLopDay
FROM GIAO_VIEN GV
LEFT JOIN GIANG_DAY GD ON GV.MaGV = GD.MaGV
WHERE GV.MaGV BETWEEN 1 AND 10
GROUP BY GV.MaGV, GV.HoTenGV
ORDER BY GV.MaGV;
GO

SELECT * FROM HOC_SINH;
SELECT * FROM GIAO_VIEN;
SELECT * FROM TAI_KHOAN;
SELECT * FROM LOP;
SELECT * FROM MON_HOC;
SELECT * FROM DIEM;
SELECT * FROM GIANG_DAY;


