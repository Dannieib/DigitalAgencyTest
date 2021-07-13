CREATE PROCEDURE [dbo].[spDeleteSaleById]
	@id int
AS
	begin
		update dbo.Master_Sales set
			UpdatedDate = GETDATE(),
			IsDeleted = 1
		where Id = @id

	end
