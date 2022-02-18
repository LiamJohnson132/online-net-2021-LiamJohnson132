USE [master]
GO
CREATE LOGIN [GuildCarsSprocExec] WITH PASSWORD=N'password123', DEFAULT_DATABASE=[master], CHECK_EXPIRATION=OFF, CHECK_POLICY=OFF
GO
USE [GuildCars]
GO
CREATE USER [GuildCarsSprocExec] FOR LOGIN [GuildCarsSprocExec]
GO
USE [GuildCarsTest]
GO
CREATE USER [GuildCarsSprocExec] FOR LOGIN [GuildCarsSprocExec]
GO
-- Login: GuildCarsSprocExec Pass: password123
use [GuildCars]
go

grant execute on object::[dbo].[BodyStyleGetAll]
	to [GuildCarsSprocExec]
go

grant execute on object::[dbo].[CarAllSearch]
	to [GuildCarsSprocExec]
go

grant execute on object::[dbo].[CarDelete]
	to [GuildCarsSprocExec]
go

grant execute on object::[dbo].[CarGetById]
	to [GuildCarsSprocExec]
go

grant execute on object::[dbo].[CarGetDetails]
	to [GuildCarsSprocExec]
go

grant execute on object::[dbo].[CarGetNextId]
	to [GuildCarsSprocExec]
go

grant execute on object::[dbo].[CarInsert]
	to [GuildCarsSprocExec]
go

grant execute on object::[dbo].[CarNewSearch]
	to [GuildCarsSprocExec]
go

grant execute on object::[dbo].[CarSelectFeatured]
	to [GuildCarsSprocExec]
go

grant execute on object::[dbo].[CarUpdate]
	to [GuildCarsSprocExec]
go

grant execute on object::[dbo].[CarUsedSearch]
	to [GuildCarsSprocExec]
go

grant execute on object::[dbo].[ColorGetAll]
	to [GuildCarsSprocExec]
go

grant execute on object::[dbo].[ContactInsert]
	to [GuildCarsSprocExec]
go

grant execute on object::[dbo].[InteriorGetAll]
	to [GuildCarsSprocExec]
go

grant execute on object::[dbo].[InventoryReportNewGet]
	to [GuildCarsSprocExec]
go

grant execute on object::[dbo].[InventoryReportUsedGet]
	to [GuildCarsSprocExec]
go

grant execute on object::[dbo].[MakeGetAll]
	to [GuildCarsSprocExec]
go

grant execute on object::[dbo].[MakeInsert]
	to [GuildCarsSprocExec]
go

grant execute on object::[dbo].[ModelGetAll]
	to [GuildCarsSprocExec]
go

grant execute on object::[dbo].[ModelInsert]
	to [GuildCarsSprocExec]
go

grant execute on object::[dbo].[ModelSelectAllByMake]
	to [GuildCarsSprocExec]
go

grant execute on object::[dbo].[OrderInsert]
	to [GuildCarsSprocExec]
go

grant execute on object::[dbo].[PurchaseTypeGetAll]
	to [GuildCarsSprocExec]
go

grant execute on object::[dbo].[RoleGetAll]
	to [GuildCarsSprocExec]
go

grant execute on object::[dbo].[SalesReportGet]
	to [GuildCarsSprocExec]
go

grant execute on object::[dbo].[SalesReportGetByUser]
	to [GuildCarsSprocExec]
go

grant execute on object::[dbo].[SpecialDelete]
	to [GuildCarsSprocExec]
go

grant execute on object::[dbo].[SpecialGetAll]
	to [GuildCarsSprocExec]
go

grant execute on object::[dbo].[SpecialInsert]
	to [GuildCarsSprocExec]
go

grant execute on object::[dbo].[StateGetAll]
	to [GuildCarsSprocExec]
go

grant execute on object::[dbo].[TransmissionGetAll]
	to [GuildCarsSprocExec]
go

grant execute on object::[dbo].[TypeGetAll]
	to [GuildCarsSprocExec]
go

grant execute on object::[dbo].[UserGetAll]
	to [GuildCarsSprocExec]
go

grant select on object::[dbo].[__MigrationHistory]
	to [GuildCarsSprocExec]
go

grant select on object::[dbo].[AspNetUsers]
	to [GuildCarsSprocExec]
go

grant select on object::[dbo].[AspNetUserClaims]
	to [GuildCarsSprocExec]
go

grant select on object::[dbo].[AspNetUserLogins]
	to [GuildCarsSprocExec]
go

grant select on object::[dbo].[AspNetUserRoles]
	to [GuildCarsSprocExec]
go

grant select on object::[dbo].[AspNetRoles]
	to [GuildCarsSprocExec]
go