CREATE PROCEDURE [dbo].[spUpdateSaleInfo]
	@id int,
	@customerName nvarchar(max),
	@country char(3),
	@region char(3),
	@city char(5),
	@product int,
	@quantity int

AS
	begin
		
		update dbo.Master_Sales set
		CustomerName = @customerName,
		Country = @country,
		Region = @region,
		City = @city,
		productId = @product,
		Quantity = @quantity,
		UpdatedDate = GETDATE()

		where Id = @id
	end
