use [GuildCars]
go

-- delete tables in proper order
if exists (select * from sys.tables where name='Order')
	drop table [Order]
go

if exists (select * from sys.tables where name='Car')
	drop table [Car]
go

if exists (select * from sys.tables where name='PurchaseType')
	drop table [PurchaseType]
go

if exists (select * from sys.tables where name='State')
	drop table [State]
go

if exists (select * from sys.tables where name='Interior')
	drop table [Interior]
go

if exists (select * from sys.tables where name='Color')
	drop table [Color]
go

if exists (select * from sys.tables where name='Type')
	drop table [Type]
go

if exists (select * from sys.tables where name='Transmission')
	drop table [Transmission]
go

if exists (select * from sys.tables where name='BodyStyle')
	drop table [BodyStyle]
go

if exists (select * from sys.tables where name='Model')
	drop table [Model]
go

if exists (select * from sys.tables where name='Make')
	drop table [Make]
go

if exists (select * from sys.tables where name='Special')
	drop table [Special]
go

if exists (select * from sys.tables where name='Contact')
	drop table [Contact]
go

-- create tables in proper order
create table [Make] (
	[MakeId] int identity(1,1) primary key not null,
	[Name] varchar(50) not null,
	[DateAdded] datetime not null,
	[UserEmail] varchar(256) not null
)

create table [Model] (
	[ModelId] int identity(1,1) primary key not null,
	[Name] varchar(50) not null,
	[DateAdded] datetime not null,
	[UserEmail] varchar(256) not null,
	[MakeId] int foreign key references Make(MakeId) not null
)

create table [BodyStyle] (
	[BodyStyleId] int identity(1,1) primary key not null,
	[Name] varchar(50) not null
)

create table [Transmission] (
	[TransmissionId] int identity(1,1) primary key not null,
	[Name] varchar(50) not null
)

create table [Type] (
	[TypeId] int identity(1,1) primary key not null,
	[Name] varchar(50) not null
)

create table [Color] (
	[ColorId] int identity(1,1) primary key not null,
	[Name] varchar(50) not null
)

create table [Interior] (
	[InteriorId] int identity(1,1) primary key not null,
	[Name] varchar(50) not null
)

create table [State] (
	[StateId] char(2) primary key not null,
	[Name] varchar(50) not null
)

create table [PurchaseType] (
	[PurchaseTypeId] int identity(1,1) primary key not null,
	[Name] varchar(25) not null
)

create table [Car] (
	[CarId] int identity(1,1) primary key not null,
	[VIN] char(17) not null,
	[ImgFileName] varchar(50) not null,
	[Year] int not null,
	[Mileage] int not null,
	[Price] decimal(8,2) not null,
	[MSRP] decimal(8,2) not null,
	[Description] varchar(500) not null,
	[IsSold] bit not null,
	[IsFeatured] bit not null,
	[ModelId] int foreign key references Model(ModelId) not null,
	[InteriorId] int foreign key references Interior(InteriorId) not null,
	[ColorId] int foreign key references Color(ColorId) not null,
	[TypeId] int foreign key references Type(TypeId) not null,
	[TransmissionId] int foreign key references Transmission(TransmissionId) not null,
	[BodyStyleId] int foreign key references BodyStyle(BodyStyleId) not null
)

create table [Order] (
	[OrderId] int identity(1,1) primary key not null,
	[Name] varchar(50) not null,
	[Email] varchar(50) null,
	[Phone] char(10) null,
	[StreetOne] varchar(100) not null,
	[StreetTwo] varchar(100) null,
	[City] varchar(50) not null,
	[Zipcode] char(5) not null,
	[ZipcodeExtension] char(4) null,
	[PurchasePrice] decimal(8,2) not null,
	[UserEmail] varchar(256) not null,
	[CarId] int foreign key references Car(CarId) not null,
	[PurchaseTypeId] int foreign key references PurchaseType(PurchaseTypeId) not null,
	[StateId] char(2) foreign key references State(StateId) not null,
	[DateAdded] datetime not null
)

create table [Special] (
	[SpecialId] int identity(1,1) primary key not null,
	[Title] varchar(50) not null,
	[Description] varchar(500) not null
)

create table [Contact] (
	[ContactId] int identity(1,1) primary key not null,
	[Name] varchar(50) not null,
	[Email] varchar(50) null,
	[Phone] char(10) null,
	[Message] varchar(500) not null
)