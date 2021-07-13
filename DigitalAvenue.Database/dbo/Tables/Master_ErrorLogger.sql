CREATE TABLE [dbo].[Master_ErrorLogger]
(
	[Id] INT NOT NULL PRIMARY KEY,
	ErrorMessage nvarchar(max) not null,
	ErrorStackTrace nvarchar(max) null,
	ErrorType nvarchar(max) null

	 PRIMARY KEY CLUSTERED ([Id] ASC), 
    [DateTimeLogged] DATETIME NOT NULL
)
