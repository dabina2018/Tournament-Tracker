CREATE PROCEDURE [dbo].[spTestPerson_GetByLastName]
	@LastName varchar(50)
	AS
	BEGIN
		SET NOCOUNT ON;

	SELECT *
	from dbo.People
	where LastName = @LastName;
	end
	go
