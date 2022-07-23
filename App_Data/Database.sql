use master
go

if exists (
  select name
  from sys.databases
  where name = 'AppleWatch'
) begin
  drop database AppleWatch
end
go

---------------------------------------------------------

use master
go

create database AppleWatch
go

use AppleWatch
go

create table Genuine(
  Id          int           not null  identity(1, 1),
  Code        varchar(10)   not null,
  DisplayName nvarchar(100) not null,

  constraint  PK_Genuine      primary key (Id),
  constraint  AK_GenuineCode  unique      (Code)
)
go

create table Strap (
  Id          int           not null  identity(1, 1),
  Code        varchar(10)   not null,
  DisplayName nvarchar(100) not null,

  constraint  PK_Strap      primary key (Id),
  constraint  AK_StrapCode  unique      (Code)
)
go

create table Series (
  Id          int           not null  identity(1, 1),
  Code        varchar(10)   not null,
  DisplayName nvarchar(100) not null,

  constraint  PK_Series     primary key (Id),
  constraint  AK_SeriesCode unique      (Code)
)
go

create table Watch (
  Id                    int         not null  identity(1, 1),
  Code                  varchar(10) not null,
  SeriesId              int         not null,
  StrapId               int         not null,
  GenuineId             int,
  IsAuthorisedReseller  bit         not null,
  Price                 money,

  constraint  PK_Watch        primary key (Id),
  constraint  AK_WatchCode    unique      (Code),
  constraint  FK_WatchSeries  foreign key (SeriesId)  references Series(Id),
  constraint  FK_WatchStrap   foreign key (StrapId)   references Strap(Id),
  constraint  FK_WatchGenuine foreign key (GenuineId) references Genuine(Id)
)
go

create table Promotion (
  Id          int           not null  identity(1, 1),
  Code        varchar(10)   not null,
  DisplayName nvarchar(100) not null,
  Description ntext,

  constraint  PK_Promotion      primary key (Id),
  constraint  AK_PromotionCode  unique      (Code),
)
go

create table PromotionApplication (
  Id          int   not null  identity(1, 1),
  WatchId     int   not null,
  PromotionId int   not null,
  FromDate    date  not null,
  ToDate      date,

  constraint  PK_PromotionApplication primary key (Id),
  constraint  FK_PromotionalWatch     foreign key (WatchId)     references Watch(Id),
  constraint  FK_AppliedPromotion     foreign key (PromotionId) references Promotion(Id)
)
go

create table SaleOff (
  Id            int   not null  identity(1, 1),
  WatchId       int   not null,
  SaleOffPrice  money not null,
  FromDate      date  not null,
  ToDate        date,
  
  constraint  PK_SaleOff      primary key (Id),
  constraint  FK_SaleOffWatch foreign key (WatchId) references Watch(Id)
)
go

---------------------------------------------------------

insert into Genuine
values  ('GEN-1266', N'Chính hãng VN/A')
go

insert into Strap
values  ('STR-1643', N'Viền thép dây thép'),
        ('STR-9432', N'Viền nhôm dây cao su'),
        ('STR-1284', N'Viền thép dây cao su'),
        ('STR-7484', N'Viền nhôm dây vải')
go

insert into Series
values  ('SER-1325', N'Apple Watch Series 7 4G, 45mm'),
        ('SER-7420', N'Apple Watch Series 7 4G, 41mm'),
        ('SER-3497', N'Apple Watch Series 7 GPS, 41mm'),
        ('SER-4897', N'Apple Watch Series 7 GPS, 45mm'),
        ('SER-8756', N'Apple Watch Series 7 (4G) 45mm'),
        ('SER-0324', N'Apple Watch Series 7 (4G) 41mm'),
        ('SER-5761', N'Apple Watch SE (4G) 40mm'),
        ('SER-9823', N'Apple Watch SE (4G) 44mm')
go

insert into Watch
values  ('WAT-3508', 1, 1, 1, 1, 19990000),
        ('WAT-9830', 2, 1, 1, 1, 18990000),
        ('WAT-7414', 1, 2, 1, 1, 13490000),
        ('WAT-8497', 3, 2, 1, 1, 9590000),
        ('WAT-3721', 2, 2, 1, 1, 12990000),
        ('WAT-2398', 4, 2, 1, 1, 10890000),
        ('WAT-7834', 5, 3, 1, 0, null),
        ('WAT-3997', 6, 3, 1, 0, null),
        ('WAT-0120', 7, 2, 1, 1, 10990000),
        ('WAT-2854', 8, 4, 1, 1, 8490000)
go

insert into Promotion
values  ('PRO-6660', N'Thanh toan qua VNPAY: Giảm 50.000đ. Ưu đãi liền tay, quét VNPAY-QR nhận ngay 50K.', N'Cụ thể, khách hàng lần đầu tiên thanh toán thành công bằng tính năng QR Pay trên ứng dụng Agribank E-Mobile Banking sẽ được giảm ngay 50.000đ cho mỗi giao dịch có giá trị từ 100.000đ trở lên. Chương trình được áp dụng tại tất cả các điểm chấp nhận thanh toán mã VNPAY-QR.'),
        ('SER-6902', N'Giảm ngay 30% tối đa 600.000đ khi mở thẻ đồng thương hiệu TPBANK EVO (Áp dụng cùng VNPAY/ MOCA)', N'Khách hàng được phê duyệt thành công Thẻ tín dụng TPBank EVO sẽ nhận được Mã giảm giá 30% tối đa 600.000đ và được hoàn tiền 10% tối đa 500.000đ(*) khi khách hàng sử dụng Thẻ TPBank EVO mua hàng tại Apple Watch.')
go

insert into PromotionApplication
values  (1, 1, GETDATE(), DATEADD(month, 6, GETDATE())),
        (2, 1, GETDATE(), DATEADD(month, 3, GETDATE())),
        (3, 1, GETDATE(), DATEADD(month, 6, GETDATE())),
        (4, 1, GETDATE(), DATEADD(month, 2, GETDATE())),
        (5, 1, GETDATE(), DATEADD(month, 8, GETDATE())),
        (6, 1, GETDATE(), DATEADD(month, 9, GETDATE())),
        (7, 1, GETDATE(), DATEADD(month, 12, GETDATE())),
        (8, 1, GETDATE(), DATEADD(month, 3, GETDATE())),
        (9, 1, GETDATE(), DATEADD(month, 6, GETDATE())),
        (9, 2, GETDATE(), DATEADD(month, 6, GETDATE())),
        (10, 1, GETDATE(), DATEADD(month, 1, GETDATE()))
go

insert into SaleOff
values  (9, 3500000, GETDATE(), DATEADD(month, 12, GETDATE()))
go
