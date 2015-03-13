CREATE TABLE [dbo].[ProductSize] (
    [SizeID]  INT           IDENTITY (1, 1) NOT NULL,
    [Size]    NVARCHAR (50) NOT NULL,
    [Comment] TEXT          NULL,
    CONSTRAINT [PK_ProductSize] PRIMARY KEY CLUSTERED ([SizeID] ASC)
);

