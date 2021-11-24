USE [C:\USERS\DEVIN\SOURCE\REPOS\STONEWOODBOOKS\STONEWOODBOOKS\APP_DATA\STONEWOODDATA.MDF];

CREATE TABLE [dbo].Author(
[AID] int IDENTITY (1, 1) NOT NULL,
[Fname] varchar(25),
[Lname] varchar(25),
[Gender] varchar(10),
[DOB] Date,
PRIMARY KEY CLUSTERED([AID] ASC));

INSERT INTO Author(Fname, Lname, Gender, DOB)
VALUES
	('James', 'Patterson', 'Male', '1947-03-22'),
	('J.K.', 'Rowling', 'Female', '1965-07-31'),
	('Ernest', 'Hemmingway', 'Male', '1899-07-21');