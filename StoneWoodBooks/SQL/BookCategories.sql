USE [C:\USERS\DEVIN\SOURCE\REPOS\STONEWOODBOOKS\STONEWOODBOOKS\APP_DATA\STONEWOODDATA.MDF];

CREATE TABLE [dbo].[BookCategories](
    [CategoryID] INT IDENTITY(1,1) NOT NULL,
    [CategoryDescription] varchar(50) NOT NULL,
    PRIMARY KEY CLUSTERED ([CategoryID] ASC));


INSERT INTO BookCategories(CategoryDescription)
VALUES
	('Action/Adventure'),
	('Classic'),
	('Fantasy'),
	('Historical Fiction'),
	('Horror'),
	('Literary Fiction'),
	('Romance'),
	('Science Fiction'),
	('Short Story'),
	('Thriller'),
	('Drama'),
	('Crime/Mystery'),
	('Poetry'),
	('History'),
	('Biography');