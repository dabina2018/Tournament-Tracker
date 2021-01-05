CREATE PROCEDURE dbo.sp_MatchupEntries_GetByMatchup
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
--=========================================================
CREATE PROCEDURE dbo.sp_Matchups_GetBy_Tournament
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
--==========================================================

