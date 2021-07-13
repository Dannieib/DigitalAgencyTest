CREATE PROCEDURE [dbo].[spInsertNewSales]

	@customerName nvarchar(max),
	@country char(3),
	@region char(3),
	@city char(5),
	@productId int,
	@quantity int

AS
	begin
		insert into dbo.Master_Sales
		(CustomerName, Country, Region, City, DateOfSale, productId, Quantity)
		output inserted.Id
		values		
		(@customerName, @country,@region,@city,getdate(),@productId,@quantity)
	end