CREATE TABLE [dbo].[ProductColor] (
    [ColorID] INT           IDENTITY (1, 1) NOT NULL,
    [Color]   NVARCHAR (50) NOT NULL,
    [Comment] TEXT          NULL,
    CONSTRAINT [PK_ProductColor] PRIMARY KEY CLUSTERED ([ColorID] ASC)
);

