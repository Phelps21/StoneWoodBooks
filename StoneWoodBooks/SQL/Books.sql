USE [C:\USERS\DEVIN\SOURCE\REPOS\STONEWOODBOOKS\STONEWOODBOOKS\APP_DATA\STONEWOODDATA.MDF];

CREATE TABLE [dbo].Books(
[ISBN] int NOT NULL,
[Title] varchar(75) NOT NULL,
[Price] DECIMAL (18, 2) NOT NULL,
[PublicationDate] Date,

PRIMARY KEY CLUSTERED([ISBN] ASC));

INSERT INTO Books(ISBN, Title, Price, PublicationDate)
VALUES
	(0446364193, 'Along Came A Spider', 14.99, '1993-12-01'),
	(0439064872, 'Harry Potter and the Chamber of Secrets', 23.99, '2000-09-01'),
	(0684801221, 'The Old Man and the Sea', 19.99, '1995-05-05');