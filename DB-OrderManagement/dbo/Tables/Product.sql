CREATE TABLE [dbo].[Product] (
    [ProductID]     INT           IDENTITY (1, 1) NOT NULL,
    [Name]          NVARCHAR (50) NOT NULL,
    [Code]          VARCHAR (50)  NOT NULL,
    [StandardPrice] MONEY         NOT NULL,
    [Comment]       TEXT          NULL,
    [OnlineFlag]    BIT           CONSTRAINT [DF_Product_OnlineFlag] DEFAULT ((0)) NOT NULL,
    [ColorID]       INT           NULL,
    [SizeID]        INT           NULL,
    [ProductTypeID] INT           NULL,
    CONSTRAINT [PK_Product] PRIMARY KEY CLUSTERED ([ProductID] ASC),
    CONSTRAINT [FK_Product_ProductColor] FOREIGN KEY ([ColorID]) REFERENCES [dbo].[ProductColor] ([ColorID]),
    CONSTRAINT [FK_Product_ProductSize] FOREIGN KEY ([SizeID]) REFERENCES [dbo].[ProductSize] ([SizeID]),
    CONSTRAINT [FK_Product_ProductType] FOREIGN KEY ([ProductTypeID]) REFERENCES [dbo].[ProductType] ([ProductTypeID])
);

