-- =======================================================
-- Create Stored Procedure Template for Azure SQL Database
-- =======================================================
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =======================================================
-- Author:      <Author, , Name>
-- Create Date: <Create Date, , >
-- Description: <Description, , >
-- =======================================================
CREATE PROCEDURE dbo.sp_Teams_Insert
@TeamName nvarchar(50), @id int=0 output
AS
BEGIN
    SET NOCOUNT ON
	INSERT INTO dbo.Teams (TeamName)
	values (@TeamName);
    -- Insert statements for procedure here
    SELECT @id = SCOPE_IDENTITY();
END
GO
-- =========================================================
CREATE PROCEDURE dbo.sp_Team_GetBy_Tournament
@TournamentId
AS
BEGIN
    SET NOCOUNT ON;
	
    SELECT @TeamName FROM Teams
	WHERE Tourn
END
GO