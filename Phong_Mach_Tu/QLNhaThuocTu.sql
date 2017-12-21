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
Go
create table DonKham
(
	ma_don_kham nchar(10),
	so_benh_nhan_toi_da int,
	ngay_kham datetime,
	doanh_thu_ngay int,
	primary key(ma_don_kham)
)
Go
create table CT_DonKham
( 
	ma_don_kham nchar(10),
	stt int,
	ma_benh_nhan nchar(10),
	ngay_kham datetime
	primary key(ma_don_kham, ma_benh_nhan)
)
go
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
	ma_don_vi nchar(10),
	ten_don_vi nvarchar(10)
	primary key(ma_don_vi)
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
	don_vi nchar(10),
	cach_dung nchar(10),
	so_luong int,
	gia_thuoc nchar(10)
	primary key(ma_thuoc)
)
Go
create table HoaDon
(
	ma_hoa_don nchar(10),
	ma_phieu_kham_benh nchar(10),
	ten_benh_nhan nvarchar(30),
	ngay_lap datetime,
	ma_tien_kham nchar(10),
	tinh_trang nvarchar(30),
	tong_tien int
	primary key(ma_hoa_don)		
)
Go
create table CT_HoaDon
(	
	hoa_don nchar(10),
	thuoc nchar(10),
	so_luong int,
	don_gia int
	primary key(hoa_don,thuoc)
)
Go

create table TienKham
(
	ma_tien_kham nchar(10),
	tien_kham int
	primary key(ma_tien_kham)	
)
-------------------------------------------------------------------------------------------------
go
--CT_HoaDon-HoaDon
Alter table CT_HoaDon
Add constraint FK_CT_HoaDon_HoaDon
foreign key (hoa_don)
references HoaDon(ma_hoa_don)
--CT_HoaDon - Thuoc
Alter table CT_HoaDon
Add constraint FK_CT_HoaDon_Thuoc
foreign key (thuoc)
references Thuoc(ma_thuoc)
-- HoaDon- PhieuKhamBenh
Alter table HoaDon
Add constraint FK_HoaDon_PhieuKhamBenh
foreign key (ma_phieu_kham_benh)
references PhieuKhamBenh(ma_phieu_kham_benh)
-- CT_DonKham- DonKham
Alter table CT_DonKham
Add constraint FK_CTDonKham_DonKham
foreign key (ma_don_kham)
references DonKham(ma_don_kham)
-- CT_DOnKham - BenhNhan
Alter table CT_DonKham
Add constraint FK_CTDonKham_BenhNhan
foreign key (ma_benh_nhan)
references BenhNhan(ma_benh_nhan)
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
references DonVi(ma_don_vi)

-- HoaDon - TienKham
Alter table HoaDon
Add constraint FK_HoaDon_TienKham
Foreign key (tien_kham)
references TienKham(ma_tien_kham)

