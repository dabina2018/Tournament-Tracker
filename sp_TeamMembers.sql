CREATE PROCEDURE dbo.sp_TeamMembers_Insert
@TeamId int, @PersonId int, @id int=0 output
AS
BEGIN
    SET NOCOUNT ON;
	INSERT INTO dbo.TeamMembers(TeamId, PersonId)
	values (@TeamId, @PersonId);
    -- Insert statements for procedure here
    SELECT @id = SCOPE_IDENTITY();
END
GO
--======================================================
CREATE PROCEDURE dbo.sp_TeamMembers_GetByTy_Team
--@TeamId int, @PersonId int, @id int=0 output
AS
BEGIN
    SET NOCOUNT ON;
	
    SELECT --@id = SCOPE_IDENTITY();
END
GO
