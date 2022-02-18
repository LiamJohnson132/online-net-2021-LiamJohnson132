-- Clean Creation
USE [master];
GO

IF exists (select * from sys.databases where name = N'GuildCarsTest')
begin
	EXEC msdb.dbo.sp_delete_database_backuphistory @database_name = N'GuildCarsTest';
	ALTER DATABASE GuildCarsTest SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
	DROP DATABASE GuildCarsTest;
end

CREATE DATABASE GuildCarsTest;
GO