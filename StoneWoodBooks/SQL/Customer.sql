DROP TABLE [dbo].[Customer];

USE [C:\USERS\DEVIN\SOURCE\REPOS\STONEWOODBOOKS\STONEWOODBOOKS\APP_DATA\STONEWOODDATA.MDF];

CREATE TABLE [dbo].[Customer] (
    [Username] VARCHAR (12) NOT NULL,
    [Password] VARCHAR (12) NOT NULL,
    [Fname]    VARCHAR (65) NOT NULL,
	[Lname]    VARCHAR (65) NOT NULL,
    PRIMARY KEY CLUSTERED ([Username] ASC)
);

INSERT INTO Customer VALUES('devinlaterza', 'devinthedude', 'Devin', 'Laterza');
INSERT INTO Customer VALUES('wesleyphelps', 'westheman', 'Wesley', 'Phelps');