USE [C:\USERS\DEVIN\SOURCE\REPOS\STONEWOODBOOKS\STONEWOODBOOKS\APP_DATA\STONEWOODDATA.MDF];

CREATE TABLE [dbo].[CustomerEmail](
    [Username] varchar(12) FOREIGN KEY REFERENCES Customer(Username),
    [Email] VARCHAR (30) NOT NULL,
    CONSTRAINT Pk_CustomerEmail PRIMARY KEY CLUSTERED ([Username] ASC, [Email] ASC));


INSERT INTO CustomerEmail(Username, Email)
VALUES
	('devinlaterza', 'devin@stonewood.com'),
	('wesleyphelps', 'wes@stonewood.com');