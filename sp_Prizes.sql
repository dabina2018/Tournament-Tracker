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
CREATE PROCEDURE dbo.spPrizes_Insert
(
    -- Add the parameters for the stored procedure here
    @PlaceNumber int, @PlaceName nvarchar(50), @PrizeAmount money, @PrizePercentage float,
	@id int = 0 output
)
AS
BEGIN
    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON

    -- Insert statements for procedure here
    INSERT INTO dbo.Prizes (PlaceNumber, PlaceName, PrizeAmount, PrizePercentage)
	values(@PlaceNumber, @PlaceName, @PrizeAmount, @PrizePercentage);

	select @id = SCOPE_IDENTITY();
END
GO
-- ===========================================================
CREATE PROCEDURE dbo.spPrizes_GetBy_Tournament
(
    @PlaceNumber int, @PlaceName nvarchar(50), @PrizeAmount money, @PrizePercentage float,
	@id int = 0 output
)
AS
BEGIN
    SET NOCOUNT ON
    INSERT INTO dbo.Prizes (PlaceNumber, PlaceName, PrizeAmount, PrizePercentage)
	values(@PlaceNumber, @PlaceName, @PrizeAmount, @PrizePercentage);
	select @id = SCOPE_IDENTITY();
END
GO
-- =============================================================================================
drop procedure dbo.spPrizes;
