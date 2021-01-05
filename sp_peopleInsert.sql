-- =======================================================
-- Create Stored Procedure Template for Azure SQL Database
-- =======================================================
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:      <Author, , Name>
-- Create Date: <Create Date, , >
-- Description: <Description, , >
-- =============================================
CREATE PROCEDURE dbo.spPeople_Insert
(
    -- Add the parameters for the stored procedure here
    @FirstName varchar(50), @LastName varchar(50), @EmailAddress varchar(50), @CellphoneNumber varchar(50), @id int =0 OUTPUT
   
)
AS
BEGIN
    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON;
	insert into dbo.People (FirstName, LastName, EmailAddress, CellphoneNumber)
	values(@FirstName, @LastName, @EmailAddress, @CellphoneNumber);
	select @id = SCOPE_IDENTITY();
	end
	--======================================================================================

CREATE PROCEDURE sp_People_GetAll

AS
BEGIN
    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON

    -- Insert statements for procedure here
    SELECT* FROM dbo.People
END

