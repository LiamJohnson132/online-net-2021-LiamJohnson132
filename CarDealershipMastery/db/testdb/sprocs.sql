use [GuildCarsTest]
go

-- Select Featured Cars
if exists(select * from INFORMATION_SCHEMA.ROUTINES
	where ROUTINE_NAME = 'CarSelectFeatured')
		drop procedure [CarSelectFeatured]
go

create procedure [CarSelectFeatured] as
begin
	select [CarId], [VIN], [Year], k.[Name] as Make, m.[Name] as Model, [ImgFileName], [Price]
	from Car c
	inner join Model m on c.ModelId = m.ModelId
	inner join Make k on m.MakeId = k.MakeId
	where c.IsFeatured = 1 and c.IsSold = 0
end
go

-- Search New Cars
if exists(select * from INFORMATION_SCHEMA.ROUTINES
	where ROUTINE_NAME = 'CarNewSearch')
		drop procedure [CarNewSearch]
go

create procedure [CarNewSearch] (
	@Parameter varchar(50),
	@YearParameter int,
	@PriceMin decimal(8,2),
	@PriceMax decimal(8,2),
	@YearMin int,
	@YearMax int
) as
begin
	-- CarId, Year, Make, Model, Img, BodyStyle, Interior, Price, Transmission, Mileage, MSRP, Color, VIN
	select top 20 [CarId], [Year], k.[Name] as Make, m.[Name] as Model, [ImgFileName], b.[Name] as BodyStyle, i.[Name] as Interior, [Price], t.[Name] as Transmission, [Mileage], [MSRP], o.[Name] as Color, [VIN]
	from Car c
	inner join Model m on c.ModelId = m.ModelId
	inner join Make k on m.MakeId = k.MakeId
	inner join Interior i on c.InteriorId = i.InteriorId
	inner join Color o on c.ColorId = o.ColorId
	inner join BodyStyle b on c.BodyStyleId = b.BodyStyleId
	inner join Transmission t on c.TransmissionId = t.TransmissionId
	where (k.[Name] like '%' + @Parameter + '%' or m.[Name] like '%' + @Parameter + '%' or [Year] = @YearParameter) and 
		([Price] between @PriceMin and @PriceMax) and 
		([Year] between @YearMin and @YearMax) and 
		([IsSold] = 0) and 
		([TypeId] = 0)
	order by c.[MSRP] desc
end
go

-- Search Used Cars
if exists(select * from INFORMATION_SCHEMA.ROUTINES
	where ROUTINE_NAME = 'CarUsedSearch')
		drop procedure [CarUsedSearch]
go

create procedure [CarUsedSearch] (
	@Parameter varchar(50),
	@YearParameter int,
	@PriceMin decimal(8,2),
	@PriceMax decimal(8,2),
	@YearMin int,
	@YearMax int
) as
begin
	-- CarId, Year, Make, Model, Img, BodyStyle, Interior, Price, Transmission, Mileage, MSRP, Color, VIN
	select top 20 [CarId], [Year], k.[Name] as Make, m.[Name] as Model, [ImgFileName], b.[Name] as BodyStyle, i.[Name] as Interior, [Price], t.[Name] as Transmission, [Mileage], [MSRP], o.[Name] as Color, [VIN]
	from Car c
	inner join Model m on c.ModelId = m.ModelId
	inner join Make k on m.MakeId = k.MakeId
	inner join Interior i on c.InteriorId = i.InteriorId
	inner join Color o on c.ColorId = o.ColorId
	inner join BodyStyle b on c.BodyStyleId = b.BodyStyleId
	inner join Transmission t on c.TransmissionId = t.TransmissionId
	where (k.[Name] like '%' + @Parameter + '%' or m.[Name] like '%' + @Parameter + '%' or [Year] = @YearParameter) and 
		([Price] between @PriceMin and @PriceMax) and 
		([Year] between @YearMin and @YearMax) and 
		([IsSold] = 0) and 
		([TypeId] = 1)
	order by c.[MSRP] desc
end
go

-- Get Car Details
if exists(select * from INFORMATION_SCHEMA.ROUTINES
	where ROUTINE_NAME = 'CarGetDetails')
		drop procedure [CarGetDetails]
go

create procedure [CarGetDetails] (
	@CarId int
) as
begin
	select [CarId], [Year], k.[Name] as Make, m.[Name] as Model, b.[Name] as BodyStyle, i.[Name] as Interior, [Price], t.[Name] as Transmission, [Mileage], [MSRP], o.[Name] as Color, [VIN], [Description], [ImgFileName], [IsSold]
	from Car c
	inner join Model m on c.ModelId = m.ModelId
	inner join Make k on m.MakeId = k.MakeId
	inner join BodyStyle b on c.BodyStyleId = b.BodyStyleId
	inner join Interior i on c.InteriorId = i.InteriorId
	inner join Transmission t on c.TransmissionId = t.TransmissionId
	inner join Color o on c.ColorId = o.ColorId
	where c.[CarId] = @CarId
end
go

-- Get Car Full By Id
if exists(select * from INFORMATION_SCHEMA.ROUTINES
	where ROUTINE_NAME = 'CarGetById')
		drop procedure [CarGetById]
go

create procedure [CarGetById] (
	@CarId int
) as
begin
	select [CarId], m.[MakeId], c.[ModelId], [TypeId], [BodyStyleId], [Year], [TransmissionId], [ColorId], [InteriorId], [Mileage], [VIN], [MSRP], [Price], [Description], [ImgFileName], [IsSold], [IsFeatured]
	from Car c
	inner join [Model] m on c.ModelId = m.ModelId
	where c.[CarId] = @CarId
end
go


-- Get Specials
if exists(select * from INFORMATION_SCHEMA.ROUTINES
	where ROUTINE_NAME = 'SpecialGetAll')
		drop procedure [SpecialGetAll]
go

create procedure [SpecialGetAll] as
begin
	select *
	from Special
end
go

-- Post Contact
if exists(select * from INFORMATION_SCHEMA.ROUTINES
	where ROUTINE_NAME = 'ContactInsert')
		drop procedure [ContactInsert]
go

create procedure [ContactInsert] (
	@Name varchar(50),
	@Email varchar(50),
	@Phone char(10),
	@Message varchar(500)
) as
begin
	insert into Contact ([Name], [Email], [Phone], [Message])
	values (@Name, @Email, @Phone, @Message)
end
go

-- Post Order
if exists(select * from INFORMATION_SCHEMA.ROUTINES
	where ROUTINE_NAME = 'OrderInsert')
		drop procedure [OrderInsert]
go

create procedure [OrderInsert] (
	@OrderId int output,
	@Name varchar(50),
	@Email varchar(50),
	@Phone char(10),
	@StreetOne varchar(100),
	@StreetTwo varchar(100),
	@City varchar(50),
	@Zipcode char(5),
	@ZipcodeExtension char(4),
	@PurchasePrice decimal(8,2),
	@UserEmail varchar(256),
	@CarId int,
	@PurchaseTypeId int,
	@StateId char(2)
) as
begin
	insert into [Order] ([Name], [Email], [Phone], [StreetOne], [StreetTwo], [City], [Zipcode], [ZipcodeExtension], [PurchasePrice], [UserEmail], [CarId], [PurchaseTypeId], [StateId], [DateAdded])
	values (@Name, @Email, @Phone, @StreetOne, @StreetTwo, @City, @Zipcode, @ZipcodeExtension, @PurchasePrice, @UserEmail, @CarId, @PurchaseTypeId, @StateId, GETDATE())

	set @OrderId = SCOPE_IDENTITY();
end
go

-- Get All States
if exists(select * from INFORMATION_SCHEMA.ROUTINES
	where ROUTINE_NAME = 'StateGetAll')
		drop procedure [StateGetAll]
go

create procedure [StateGetAll] as
begin
	select *
	from [State]
end
go

-- Search All Cars
if exists(select * from INFORMATION_SCHEMA.ROUTINES
	where ROUTINE_NAME = 'CarAllSearch')
		drop procedure [CarAllSearch]
go

create procedure [CarAllSearch] (
	@Parameter varchar(50),
	@YearParameter int,
	@PriceMin decimal(8,2),
	@PriceMax decimal(8,2),
	@YearMin int,
	@YearMax int
) as
begin
	-- CarId, Year, Make, Model, Img, BodyStyle, Interior, Price, Transmission, Mileage, MSRP, Color, VIN
	select top 20 [CarId], [Year], k.[Name] as Make, m.[Name] as Model, [ImgFileName], b.[Name] as BodyStyle, i.[Name] as Interior, [Price], t.[Name] as Transmission, [Mileage], [MSRP], o.[Name] as Color, [VIN]
	from Car c
	inner join Model m on c.ModelId = m.ModelId
	inner join Make k on m.MakeId = k.MakeId
	inner join Interior i on c.InteriorId = i.InteriorId
	inner join Color o on c.ColorId = o.ColorId
	inner join BodyStyle b on c.BodyStyleId = b.BodyStyleId
	inner join Transmission t on c.TransmissionId = t.TransmissionId
	where (k.[Name] like '%' + @Parameter + '%' or m.[Name] like '%' + @Parameter + '%' or [Year] = @YearParameter) and 
		([Price] between @PriceMin and @PriceMax) and 
		([Year] between @YearMin and @YearMax) and 
		([IsSold] = 0)
	order by c.[MSRP] desc
end
go

-- Get All Makes
if exists(select * from INFORMATION_SCHEMA.ROUTINES
	where ROUTINE_NAME = 'MakeGetAll')
		drop procedure [MakeGetAll]
go

create procedure [MakeGetAll] as
begin
	select *
	from [Make]
end
go

-- Get All Models by Make
if exists(select * from INFORMATION_SCHEMA.ROUTINES
	where ROUTINE_NAME = 'ModelSelectAllByMake')
		drop procedure [ModelSelectAllByMake]
go

create procedure [ModelSelectAllByMake] (
	@MakeId int
) as
begin
	select *
	from [Model]
	where Model.MakeId = @MakeId
end
go

-- Get All Types
if exists(select * from INFORMATION_SCHEMA.ROUTINES
	where ROUTINE_NAME = 'TypeGetAll')
		drop procedure [TypeGetAll]
go

create procedure [TypeGetAll] as
begin
	select *
	from [Type]
end
go

-- Get All Body Styles
if exists(select * from INFORMATION_SCHEMA.ROUTINES
	where ROUTINE_NAME = 'BodyStyleGetAll')
		drop procedure [BodyStyleGetAll]
go

create procedure [BodyStyleGetAll] as
begin
	select *
	from [BodyStyle]
end
go

-- Get All Transmissions
if exists(select * from INFORMATION_SCHEMA.ROUTINES
	where ROUTINE_NAME = 'TransmissionGetAll')
		drop procedure [TransmissionGetAll]
go

create procedure [TransmissionGetAll] as
begin
	select *
	from [Transmission]
end
go

-- Get All Colors
if exists(select * from INFORMATION_SCHEMA.ROUTINES
	where ROUTINE_NAME = 'ColorGetAll')
		drop procedure [ColorGetAll]
go

create procedure [ColorGetAll] as
begin
	select *
	from [Color]
end
go

-- Get All Interiors
if exists(select * from INFORMATION_SCHEMA.ROUTINES
	where ROUTINE_NAME = 'InteriorGetAll')
		drop procedure [InteriorGetAll]
go

create procedure [InteriorGetAll] as
begin
	select *
	from [Interior]
end
go
-- Post Car
if exists(select * from INFORMATION_SCHEMA.ROUTINES
	where ROUTINE_NAME = 'CarInsert')
		drop procedure [CarInsert]
go

create procedure [CarInsert] (
	@CarId int output,
	@ModelId int,
	@TypeId int,
	@BodyStyleId int,
	@Year int,
	@TransmissionId int,
	@ColorId int,
	@InteriorId int,
	@Mileage int,
	@VIN char(17),
	@MSRP decimal(8,2),
	@Price decimal(8,2),
	@Description varchar(500),
	@ImgFileName varchar(50)
) as
begin
	insert into [Car] ([ModelId], [TypeId], [BodyStyleId], [Year], [TransmissionId], [ColorId], [InteriorId], [Mileage], [VIN], [MSRP], [Price], [Description], [ImgFileName], [IsSold], [IsFeatured])
	values (@ModelId, @TypeId, @BodyStyleId, @Year, @TransmissionId, @ColorId, @InteriorId, @Mileage, @VIN, @MSRP, @Price, @Description, @ImgFileName, 0, 0)

	set @CarId = SCOPE_IDENTITY();
end
go

-- Edit Car
if exists(select * from INFORMATION_SCHEMA.ROUTINES
	where ROUTINE_NAME = 'CarUpdate')
		drop procedure [CarUpdate]
go

create procedure [CarUpdate] (
	@CarId int,
	@ModelId int,
	@TypeId int,
	@BodyStyleId int,
	@Year int,
	@TransmissionId int,
	@ColorId int,
	@InteriorId int,
	@Mileage int,
	@VIN char(17),
	@MSRP decimal(8,2),
	@Price decimal(8,2),
	@Description varchar(500),
	@ImgFileName varchar(50),
	@IsSold bit,
	@IsFeatured bit
) as
begin
	update Car set
		[ModelId] = @ModelId,
		[TypeId] = @TypeId,
		[BodyStyleId] = @BodyStyleId,
		[Year] = @Year,
		[TransmissionId] = @TransmissionId,
		[ColorId] = @ColorId,
		[InteriorId] = @InteriorId,
		[Mileage] = @Mileage,
		[VIN] = @VIN,
		[MSRP] = @MSRP,
		[Price] = @Price,
		[Description] = @Description,
		[ImgFileName] = @ImgFileName,
		[IsSold] = @IsSold,
		[IsFeatured] = @IsFeatured
	where [CarId] = @CarId
end
go

-- Delete Car
if exists(select * from INFORMATION_SCHEMA.ROUTINES
	where ROUTINE_NAME = 'CarDelete')
		drop procedure [CarDelete]
go

create procedure [CarDelete] (
	@CarId int
) as
begin
	delete from Car
	where [CarId] = @CarId
end
go

-- Get All Users
if exists(select * from INFORMATION_SCHEMA.ROUTINES
	where ROUTINE_NAME = 'UserGetAll')
		drop procedure [UserGetAll]
go

create procedure [UserGetAll] 
as
begin
	select u.[Id] as UserId, [LastName], [FirstName], [Email], r.[Name] as Role, CONCAT([FirstName], ' ', [LastName]) as FullName
	from [AspNetUserRoles] ur
	left outer join [AspNetUsers] u on ur.[UserId] = u.[Id]
	inner join [AspNetRoles] r on ur.[RoleId] = r.[Id]
	
end
go



-- Get All Roles
if exists(select * from INFORMATION_SCHEMA.ROUTINES
	where ROUTINE_NAME = 'RoleGetAll')
		drop procedure [RoleGetAll]
go

create procedure [RoleGetAll] 
as
begin
	select [Id] as [RoleId], [Name]
	from [AspNetRoles]
end
go



-- Post Make
if exists(select * from INFORMATION_SCHEMA.ROUTINES
	where ROUTINE_NAME = 'MakeInsert')
		drop procedure [MakeInsert]
go

create procedure [MakeInsert] (
	@MakeId int output,
	@Name varchar(50),
	@UserEmail varchar(256)
) as
begin
	insert into [Make] ([Name], [UserEmail], [DateAdded])
	values (@Name, @UserEmail, GETDATE())

	set @MakeId = SCOPE_IDENTITY();
end
go

-- Get Models
if exists(select * from INFORMATION_SCHEMA.ROUTINES
	where ROUTINE_NAME = 'ModelGetAll')
		drop procedure [ModelGetAll]
go

create procedure [ModelGetAll] 
as
begin
	select [ModelId], m.[Name] as Name, m.[DateAdded], m.[UserEmail], k.[Name] as Make
	from [Model] m
	inner join [Make] k on m.[MakeId] = k.[MakeId]
end
go

-- Post Model
if exists(select * from INFORMATION_SCHEMA.ROUTINES
	where ROUTINE_NAME = 'ModelInsert')
		drop procedure [ModelInsert]
go

create procedure [ModelInsert] (
	@ModelId int output,
	@MakeId int,
	@Name varchar(50),
	@UserEmail varchar(256)
) as
begin
	insert into [Model] ([Name], [UserEmail], [DateAdded], [MakeId])
	values (@Name, @UserEmail, GETDATE(), @MakeId)

	set @ModelId = SCOPE_IDENTITY();
end
go

-- Post Special
if exists(select * from INFORMATION_SCHEMA.ROUTINES
	where ROUTINE_NAME = 'SpecialInsert')
		drop procedure [SpecialInsert]
go

create procedure [SpecialInsert] (
	@SpecialId int output,
	@Title varchar(50),
	@Description varchar(500)
) as
begin
	insert into [Special] ([Title], [Description])
	values (@Title, @Description)

	set @SpecialId = SCOPE_IDENTITY();
end
go

-- Delete Special
if exists(select * from INFORMATION_SCHEMA.ROUTINES
	where ROUTINE_NAME = 'SpecialDelete')
		drop procedure [SpecialDelete]
go

create procedure [SpecialDelete] (
	@SpecialId int
) as
begin
	delete from [Special]
	where [SpecialId] = @SpecialId
end
go

-- Get Sales Report By User
if exists(select * from INFORMATION_SCHEMA.ROUTINES
	where ROUTINE_NAME = 'SalesReportGetByUser')
		drop procedure [SalesReportGetByUser]
go

create procedure [SalesReportGetByUser] (
	@UserId nvarchar(128),
	@DateMin datetime,
	@DateMax datetime
) as
begin
	select u.[FirstName], u.[LastName], count(o.[OrderId]) as TotalVehicles, sum(o.[PurchasePrice]) as TotalSales
	from [AspNetUsers] u
	left outer join [Order] o on u.[Email] = o.[UserEmail]
	where u.[Id] = @UserId and o.[DateAdded] between @DateMin and @DateMax
	group by LastName, FirstName
end
go

-- Get Sales Report
if exists(select * from INFORMATION_SCHEMA.ROUTINES
	where ROUTINE_NAME = 'SalesReportGet')
		drop procedure [SalesReportGet]
go

create procedure [SalesReportGet] (
	@DateMin datetime,
	@DateMax datetime
) as
begin
	select CONCAT(u.[FirstName], ' ', u.[LastName]) as FullName, count(o.[OrderId]) as TotalVehicles, sum(o.[PurchasePrice]) as TotalSales
	from [AspNetUsers] u
	inner join [Order] o on u.[Email] = o.[UserEmail]
	where o.[DateAdded] between @DateMin and @DateMax
	group by LastName, FirstName
end
go

-- Get Used Inventory Report
if exists(select * from INFORMATION_SCHEMA.ROUTINES
	where ROUTINE_NAME = 'InventoryReportUsedGet')
		drop procedure [InventoryReportUsedGet]
go

create procedure [InventoryReportUsedGet] 
as
begin
	select c.[Year], k.[Name] as Make, m.[Name] as Model, count(c.[VIN]) as [Count], sum(c.MSRP) as StockValue
	from [Car] c
	inner join [Model] m on c.[ModelId] = m.[ModelId]
	inner join [Make] k on m.[MakeId] = k.[MakeId]
	inner join [Type] t on c.[TypeId] = t.[TypeId]
	where t.Name = 'Used'
	group by c.[Year], k.[Name], m.[Name]
end
go

-- Get Used Inventory Report
if exists(select * from INFORMATION_SCHEMA.ROUTINES
	where ROUTINE_NAME = 'InventoryReportNewGet')
		drop procedure [InventoryReportNewGet]
go

create procedure [InventoryReportNewGet] 
as
begin
	select c.[Year], k.[Name] as Make, m.[Name] as Model, count(c.[VIN]) as [Count], sum(c.MSRP) as StockValue
	from [Car] c
	inner join [Model] m on c.[ModelId] = m.[ModelId]
	inner join [Make] k on m.[MakeId] = k.[MakeId]
	inner join [Type] t on c.[TypeId] = t.[TypeId]
	where t.Name = 'New'
	group by c.[Year], k.[Name], m.[Name]
end
go

-- Get All Purchase Types
if exists(select * from INFORMATION_SCHEMA.ROUTINES
	where ROUTINE_NAME = 'PurchaseTypeGetAll')
		drop procedure [PurchaseTypeGetAll]
go

create procedure [PurchaseTypeGetAll] as
begin
	select *
	from [PurchaseType]
end
go

-- Get Next CarId
if exists(select * from INFORMATION_SCHEMA.ROUTINES
	where ROUTINE_NAME = 'CarGetNextId')
		drop procedure [CarGetNextId]
go

create procedure [CarGetNextId] as
begin
	select MAX([CarId]) + 1 as result
	from [Car]
end
go

-- (For Testing) Get Order by ID
if exists(select * from INFORMATION_SCHEMA.ROUTINES
	where ROUTINE_NAME = 'OrderGetById')
		drop procedure [OrderGetById]
go

create procedure [OrderGetById] (@OrderId int)
as
begin
	select [OrderId], [Name]
	from [Order]
	where [OrderId] = @OrderId
end
go

-- (For Testing) Get Contact by ID
if exists(select * from INFORMATION_SCHEMA.ROUTINES
	where ROUTINE_NAME = 'ContactGetById')
		drop procedure [ContactGetById]
go

create procedure [ContactGetById] (@ContactId int)
as
begin
	select [ContactId], [Name]
	from [Contact]
	where [ContactId] = @ContactId
end
go