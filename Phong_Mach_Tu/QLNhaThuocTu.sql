use master
if DB_ID ('QLNhaThuocTu') is not null
drop database QLNhaThuocTu
go
create database QLNhaThuocTu
go
use QLNhaThuocTu
go

create table BenhNhan
(
	ma_benh_nhan nchar(10),
	ho_ten nvarchar(30),
	gioi_tinh nchar(4),
	nam_sinh datetime,
	dia_chi nvarchar(30)
	primary key(ma_benh_nhan)
)
--Go
--create table DonKham
--(
--	ma_don_kham nchar(10),
--	so_benh_nhan_toi_da int,
--	ngay_kham datetime,
--	doanh_thu_ngay int,
--	primary key(ma_don_kham)
--)
--Go
--create table CT_DonKham
--( 
--	ma_don_kham nchar(10),
--	stt int,
--	ma_benh_nhan nchar(10),
--	ngay_kham datetime
--	primary key(ma_don_kham, ma_benh_nhan)
--)
--go
----------------------------------------------------------------------------------------------------
create table PhieuKhamBenh
(
	ma_phieu_kham_benh nchar(10),
	benh_nhan nchar(10),
	ngay_lap_phieu datetime,
	trieu_chung nvarchar(20),
	du_doan_loai_benh nchar(10),
	primary key(ma_phieu_kham_benh)
)
Go
create table LoaiBenh
(
	ma_loai_benh nchar(10),
	ten_loai_benh nvarchar(30)
	primary key(ma_loai_benh)
)
create table DonVi
(
	ten_don_vi nvarchar(10),
	
	primary key(ten_don_vi)
)
create table CachDung
(
	ma_cach_dung nchar(10),
	cach_su_dung nvarchar(30)
	primary key(ma_cach_dung)
)
Go
create table Thuoc
(
	ma_thuoc nchar(10),
	ten_thuoc nvarchar(30),
	don_vi nvarchar(10),
	cach_dung nchar(10),
	so_luong int,
	gia_thuoc int,
	mo_ta nvarchar(255)
	primary key(ma_thuoc)
)
Go
create table HoaDon
(
	ma_hoa_don nchar(10),
	ma_phieu_kham_benh nchar(10),
	ten_benh_nhan nvarchar(30),
	ngay_lap datetime,
	tien_kham int,
	tinh_trang nvarchar(30),
	tong_tien int
	primary key(ma_hoa_don)		
)
Go
create table CT_PhieuKhamBenh
(	
	ma_phieu_kham_benh nchar(10),
	thuoc nchar(10),
	so_luong int,
	don_gia int
	primary key(ma_phieu_kham_benh,thuoc)
)
Go

create table TienKham
(
	
	tien_kham int
	primary key(tien_kham)	
)
-------------------------------------------------------------------------------------------------
go
--CT_HoaDon-PhieuKhamBenh
Alter table CT_PhieuKhamBenh
Add constraint FK_CT_HoaDon_PhieuKhamBenh
foreign key (ma_phieu_kham_benh)
references PhieuKhamBenh(ma_phieu_kham_benh)
--CT_HoaDon - Thuoc
Alter table CT_PhieuKhamBenh
Add constraint FK_CT_HoaDon_Thuoc
foreign key (thuoc)
references Thuoc(ma_thuoc)
-- HoaDon- PhieuKhamBenh
Alter table HoaDon
Add constraint FK_HoaDon_PhieuKhamBenh
foreign key (ma_phieu_kham_benh)
references PhieuKhamBenh(ma_phieu_kham_benh)
-- CT_DonKham- DonKham
--Alter table CT_DonKham
--Add constraint FK_CTDonKham_DonKham
--foreign key (ma_don_kham)
--references DonKham(ma_don_kham)
---- CT_DOnKham - BenhNhan
--Alter table CT_DonKham
--Add constraint FK_CTDonKham_BenhNhan
--foreign key (ma_benh_nhan)
--references BenhNhan(ma_benh_nhan)
-- PhieuKhamBenh- BenhNhan
Alter table PhieuKhamBenh
Add constraint FK_PhieuKhamBenh_BenhNhan
Foreign key (benh_nhan)
References BenhNhan(ma_benh_nhan)
--  PhieuKhamBenh -LoaiBenh
Alter table PhieuKhamBenh
Add constraint FK_PhieuKhamBenh_LoaiBenh
Foreign key (du_doan_loai_benh)
References LoaiBenh(ma_loai_benh)
-- Thuoc - CachDung
Alter table Thuoc
Add constraint FK_Thuoc_CachDung
Foreign key (cach_dung)
References CachDung(ma_cach_dung)
-- Thuoc - DonVi
Alter table Thuoc	
Add constraint FK_Thuoc_DonVi
foreign key (don_vi)
references DonVi(ten_don_vi)

-- HoaDon - TienKham
Alter table HoaDon
Add constraint FK_HoaDon_TienKham
Foreign key (tien_kham)
references TienKham(tien_kham)




INSERT [dbo].[LoaiBenh] ([ma_loai_benh], [ten_loai_benh]) VALUES (N'BC0004', N'Cảm cúm')
INSERT [dbo].[LoaiBenh] ([ma_loai_benh], [ten_loai_benh]) VALUES (N'BD0001', N'Da liễu')
INSERT [dbo].[LoaiBenh] ([ma_loai_benh], [ten_loai_benh]) VALUES (N'BH0005', N'Ho')
INSERT [dbo].[LoaiBenh] ([ma_loai_benh], [ten_loai_benh]) VALUES (N'BS0003', N'Sổ mũi')
INSERT [dbo].[LoaiBenh] ([ma_loai_benh], [ten_loai_benh]) VALUES (N'BV0002', N'Viêm họng')

INSERT [dbo].[TienKham] ([tien_kham]) VALUES (30000)

INSERT [dbo].[CachDung] ([ma_cach_dung], [cach_su_dung]) VALUES (N'1         ', N'Thoa ngoài da')
INSERT [dbo].[CachDung] ([ma_cach_dung], [cach_su_dung]) VALUES (N'2         ', N'Uống')
INSERT [dbo].[CachDung] ([ma_cach_dung], [cach_su_dung]) VALUES (N'3         ', N'Tiêm')
INSERT [dbo].[CachDung] ([ma_cach_dung], [cach_su_dung]) VALUES (N'4         ', N'Ngậm')

INSERT [dbo].[DonVi] ( [ten_don_vi]) VALUES ( N'chai')
INSERT [dbo].[DonVi] ( [ten_don_vi]) VALUES ( N'vien')

INSERT [dbo].[Thuoc] ([ma_thuoc], [ten_thuoc], [don_vi], [cach_dung], [so_luong], [gia_thuoc], [mo_ta]) VALUES (N'TB00001   ', N'Eumovate cream', N'chai', N'1         ', 20, N'150000    ', NULL)
INSERT [dbo].[Thuoc] ([ma_thuoc], [ten_thuoc], [don_vi], [cach_dung], [so_luong], [gia_thuoc], [mo_ta]) VALUES (N'TB00002   ', N'Contractubex', N'chai', N'1         ', 15, N'200000    ', NULL)
INSERT [dbo].[Thuoc] ([ma_thuoc], [ten_thuoc], [don_vi], [cach_dung], [so_luong], [gia_thuoc], [mo_ta]) VALUES (N'TB00003   ', N'Bepanthen 30g', N'chai', N'1         ', 20, N'120000    ', NULL)
INSERT [dbo].[Thuoc] ([ma_thuoc], [ten_thuoc], [don_vi], [cach_dung], [so_luong], [gia_thuoc], [mo_ta]) VALUES (N'TB00004   ', N'Bividerm 5g', N'chai', N'1         ', 18, N'25000     ', NULL)
INSERT [dbo].[Thuoc] ([ma_thuoc], [ten_thuoc], [don_vi], [cach_dung], [so_luong], [gia_thuoc], [mo_ta]) VALUES (N'TB00005   ', N'Crotamiton 10%-10g', N'chai', N'1         ', 22, N'50000     ', NULL)
INSERT [dbo].[Thuoc] ([ma_thuoc], [ten_thuoc], [don_vi], [cach_dung], [so_luong], [gia_thuoc], [mo_ta]) VALUES (N'TB00006   ', N'Dibetalic 15g', N'chai', N'1         ', 10, N'30000     ', NULL)
INSERT [dbo].[Thuoc] ([ma_thuoc], [ten_thuoc], [don_vi], [cach_dung], [so_luong], [gia_thuoc], [mo_ta]) VALUES (N'TN00001   ', N'Eugica', N'vien', N'4         ', 123, N'4000      ', NULL)
INSERT [dbo].[Thuoc] ([ma_thuoc], [ten_thuoc], [don_vi], [cach_dung], [so_luong], [gia_thuoc], [mo_ta]) VALUES (N'TN00002   ', N'Strepsils', N'vien', N'4         ', 69, N'5000      ', NULL)
INSERT [dbo].[Thuoc] ([ma_thuoc], [ten_thuoc], [don_vi], [cach_dung], [so_luong], [gia_thuoc], [mo_ta]) VALUES (N'TN00003   ', N'Cephalexin', N'vien', N'4         ', 90, N'2500      ', NULL)
INSERT [dbo].[Thuoc] ([ma_thuoc], [ten_thuoc], [don_vi], [cach_dung], [so_luong], [gia_thuoc], [mo_ta]) VALUES (N'TN00004   ', N'Viên ngậm Bảo Thanh', N'vien', N'4         ', 139, N'3000      ', N'Kẹo ngậm Bảo Thanh trị các chứng bệnh về viêm họng')
INSERT [dbo].[Thuoc] ([ma_thuoc], [ten_thuoc], [don_vi], [cach_dung], [so_luong], [gia_thuoc], [mo_ta]) VALUES (N'TN00005   ', N'Penicillin', N'vien', N'4         ', 200, N'2000      ', NULL)
INSERT [dbo].[Thuoc] ([ma_thuoc], [ten_thuoc], [don_vi], [cach_dung], [so_luong], [gia_thuoc], [mo_ta]) VALUES (N'TN00006   ', N'Amoxicillin', N'vien', N'4         ', 189, N'1500      ', NULL)
INSERT [dbo].[Thuoc] ([ma_thuoc], [ten_thuoc], [don_vi], [cach_dung], [so_luong], [gia_thuoc], [mo_ta]) VALUES (N'TT00001   ', N'CEFAZOLIN 1G', N'chai', N'3         ', 20, N'32000     ', N'Thuốc dùng để tiêm')
INSERT [dbo].[Thuoc] ([ma_thuoc], [ten_thuoc], [don_vi], [cach_dung], [so_luong], [gia_thuoc], [mo_ta]) VALUES (N'TT00002   ', N'ANAXATE', N'chai', N'3         ', 30, N'2100000   ', N'Thuốc dùng để tiêm')
INSERT [dbo].[Thuoc] ([ma_thuoc], [ten_thuoc], [don_vi], [cach_dung], [so_luong], [gia_thuoc], [mo_ta]) VALUES (N'TT00003   ', N'Lincomycin Injection', N'chai', N'3         ', 40, N'500000    ', N'Thuốc dùng để tiêm')
INSERT [dbo].[Thuoc] ([ma_thuoc], [ten_thuoc], [don_vi], [cach_dung], [so_luong], [gia_thuoc], [mo_ta]) VALUES (N'TT00004   ', N'Adrenalin 1 mg/ 1ml', N'chai', N'3         ', 34, N'250000    ', N'Thuốc dùng để tiêm')
INSERT [dbo].[Thuoc] ([ma_thuoc], [ten_thuoc], [don_vi], [cach_dung], [so_luong], [gia_thuoc], [mo_ta]) VALUES (N'TT00005   ', N'Vitamin B6 25 mg/1ml', N'chai', N'3         ', 24, N'100000    ', N'Thuốc dùng để tiêm')
INSERT [dbo].[Thuoc] ([ma_thuoc], [ten_thuoc], [don_vi], [cach_dung], [so_luong], [gia_thuoc], [mo_ta]) VALUES (N'TT00006   ', N'Vitamin B1 100 mg/1ml', N'chai', N'3         ', 43, N'150000    ', N'Thuốc dùng để tiêm')
INSERT [dbo].[Thuoc] ([ma_thuoc], [ten_thuoc], [don_vi], [cach_dung], [so_luong], [gia_thuoc], [mo_ta]) VALUES (N'TU00001   ', N'Diphenhydramin', N'vien', N'2         ', 50, N'1500      ', NULL)
INSERT [dbo].[Thuoc] ([ma_thuoc], [ten_thuoc], [don_vi], [cach_dung], [so_luong], [gia_thuoc], [mo_ta]) VALUES (N'TU00002   ', N'Alimemazin', N'vien', N'2         ', 80, N'2000      ', NULL)
INSERT [dbo].[Thuoc] ([ma_thuoc], [ten_thuoc], [don_vi], [cach_dung], [so_luong], [gia_thuoc], [mo_ta]) VALUES (N'TU00003   ', N'Paracetamol', N'vien', N'2         ', 100, N'3000      ', NULL)
INSERT [dbo].[Thuoc] ([ma_thuoc], [ten_thuoc], [don_vi], [cach_dung], [so_luong], [gia_thuoc], [mo_ta]) VALUES (N'TU00004   ', N'Nifedipin', N'vien', N'2         ', 120, N'1000      ', NULL)
INSERT [dbo].[Thuoc] ([ma_thuoc], [ten_thuoc], [don_vi], [cach_dung], [so_luong], [gia_thuoc], [mo_ta]) VALUES (N'TU00005   ', N'Aspirin', N'vien', N'2         ', 100, N'2500      ', NULL)
INSERT [dbo].[Thuoc] ([ma_thuoc], [ten_thuoc], [don_vi], [cach_dung], [so_luong], [gia_thuoc], [mo_ta]) VALUES (N'TU00006   ', N'Terpin Codein', N'vien', N'2         ', 75, N'2500      ', NULL)