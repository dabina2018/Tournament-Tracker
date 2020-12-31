-- ========================================================================================
-- Create User as DBO template for Azure SQL Database and Azure SQL Data Warehouse Database
-- ========================================================================================
-- For login <login_name, sysname, login_name>, create a user in the database

--create a Login
CREATE LOGIN DbUser
		WITH PASSWORD = 'p@ssw0rd';
	
--creatE a user
CREATE USER DbUser FOR LOGIN DbUser
	WITH DEFAULT_SCHEMA = Tournaments
GO

--Check if user is created
SELECT* FROM Sys.database_principals

--create a role
CREATE ROLE sp_executor AUTHORIZATION db_securityadmin
-- Add user to the created role
EXEC sp_addrolemember sp_executor, DbUser

--remove all permissons for that role
DENY INSERT, UPDATE, SELECT, DELETE ON Tournaments TO sp_executor
DENY INSERT, UPDATE, SELECT, DELETE ON TournamentPrizes TO sp_executor
DENY INSERT, UPDATE, SELECT, DELETE ON TournamentEntries TO sp_executor
DENY INSERT, UPDATE, SELECT, DELETE ON Teams TO sp_executor
DENY INSERT, UPDATE, SELECT, DELETE ON Prizes TO sp_executor
DENY INSERT, UPDATE, SELECT, DELETE ON People TO sp_executor
DENY INSERT, UPDATE, SELECT, DELETE ON Matchups TO sp_executor
DENY INSERT, UPDATE, SELECT, DELETE ON MatchupEntries TO sp_executor

--grant permisson for staroed procedure for that role
GRANT EXECUTE ON dbo.spPrizes_Insert TO sp_executor


--READ ONly can only execute Select statements
EXEC sp_addrolemember db_datareader, NONE
-- has write access
EXEC sp_addrolemember db_datawriter, NONE
EXEC sp_addrolemember Production, NONE
GO
