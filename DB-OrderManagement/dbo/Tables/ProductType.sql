CREATE TABLE [dbo].[ProductType] (
    [ProductTypeID] INT           IDENTITY (1, 1) NOT NULL,
    [Name]          NVARCHAR (50) NOT NULL,
    [Code]          VARCHAR (50)  NULL,
    [Comment]       TEXT          NULL,
    CONSTRAINT [PK_ProductType] PRIMARY KEY CLUSTERED ([ProductTypeID] ASC)
);

