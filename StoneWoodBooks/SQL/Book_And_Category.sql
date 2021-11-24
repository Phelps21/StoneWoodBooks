CREATE TABLE [dbo].[Book_And_Category] (
    [ISBN]       INT NOT NULL,
    [CategoryID] INT NOT NULL,
    CONSTRAINT [Pk_Book_And_Category] PRIMARY KEY CLUSTERED ([ISBN] ASC, [CategoryID] ASC),
    FOREIGN KEY ([ISBN]) REFERENCES [dbo].[Books] ([ISBN]),
    FOREIGN KEY ([CategoryID]) REFERENCES [dbo].[BookCategories] ([CategoryID])
);

INSERT INTO Book_And_Category(ISBN, CategoryID)
VALUES
(439064872, 3),
(446364193, 10),
(446364193, 12),
(684801221, 6);