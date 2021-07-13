CREATE PROCEDURE [dbo].[spFilterSalesinformation]
	@dateFrom datetime,
	@dateTo datetime,
	@Search NVARCHAR(512) = NULL,
	@StartIndex INT = 0,
	@Count INT = 2147483647
AS
	begin
		DECLARE @FilteredCount INT = 0
		DECLARE @TotalCount INT = 0	

			select * from dbo.Master_Sales
			WHERE 1 = 1
			AND ((@Search IS NULL OR Country LIKE '%' + @Search + '%')
					OR (@Search IS NULL OR City LIKE '%' + @Search + '%')
					OR (@Search IS NULL OR Region LIKE '%' + @Search + '%')
					OR (DateOfSale >= @dateFrom	)
					OR (DateOfSale <= @dateTo))

	SELECT @FilteredCount = ISNULL(COUNT(Id),0) FROM dbo.Master_Sales

	SELECT @TotalCount = ISNULL(COUNT(Id),0) FROM dbo.Master_Sales

	SELECT * FROM dbo.Master_Sales
	ORDER BY DateOfSale DESC
	OFFSET @StartIndex ROWS
	FETCH NEXT @Count ROWS ONLY

	SELECT @FilteredCount AS FilteredCount, @TotalCount AS TotalCount

	end