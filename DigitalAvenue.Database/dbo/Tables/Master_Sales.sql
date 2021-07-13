CREATE TABLE [dbo].[Master_Sales]
(
	[Id]  INT         IDENTITY (1, 1) NOT NULL,
    [CustomerName]         NVARCHAR (MAX) NOT NULL,
    [Country] NVARCHAR (MAX) NOT NULL,
    [Region]           NVARCHAR (MAX) NOT NULL,
    [City]           NVARCHAR (MAX) NOT NULL,
    [DateOfSale]         DATETIME       NOT NULL,
    [UpdatedDate]         DATETIME       NULL,
    [productId] INT Not Null,
    [Quantity] int not null,
    [IsDeleted] BIT NULL, 
    PRIMARY KEY CLUSTERED ([Id] ASC)
)
