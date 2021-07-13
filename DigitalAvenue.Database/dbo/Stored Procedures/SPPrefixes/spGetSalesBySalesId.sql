CREATE PROCEDURE [dbo].[spGetSalesBySalesId]
	@id int
AS
begin
	SELECT * from dbo.Master_Sales

	where 1=1 and Id = @id

end