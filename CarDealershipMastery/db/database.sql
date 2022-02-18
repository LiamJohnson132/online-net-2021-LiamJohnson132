-- Clean Creation
USE [master];
GO

IF exists (select * from sys.databases where name = N'GuildCars')
begin
	EXEC msdb.dbo.sp_delete_database_backuphistory @database_name = N'GuildCars';
	ALTER DATABASE GuildCars SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
	DROP DATABASE GuildCars;
end

CREATE DATABASE GuildCars;
GO