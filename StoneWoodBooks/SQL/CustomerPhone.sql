USE [C:\USERS\DEVIN\SOURCE\REPOS\STONEWOODBOOKS\STONEWOODBOOKS\APP_DATA\STONEWOODDATA.MDF];

CREATE TABLE [dbo].[CustomerPhone](
    [Username] varchar(12) FOREIGN KEY REFERENCES Customer(Username),
    [Phone] bigint NOT NULL,
    CONSTRAINT Pk_CustomerPhone PRIMARY KEY ([Username], [Phone]));


INSERT INTO CustomerPhone(Username, Phone)
VALUES
	('devinlaterza', 9035550132),
	('wesleyphelps', 9365550134);