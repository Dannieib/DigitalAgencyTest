CREATE PROCEDURE [dbo].[spLogErrorToDB]

	@errorMessage nvarchar(max),
	@errorStackTrace nvarchar(max),
	@ErrorType nvarchar(max)
AS
	begin
		insert into dbo.Master_ErrorLogger
		(ErrorMessage, ErrorStackTrace, ErrorType, DateTimeLogged)
		output inserted.Id
		values
		(@errorMessage, @errorStackTrace, @ErrorType, GETDATE())
end
