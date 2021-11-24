USE [C:\USERS\DEVIN\SOURCE\REPOS\STONEWOODBOOKS\STONEWOODBOOKS\APP_DATA\STONEWOODDATA.MDF];

CREATE TABLE [dbo].[AuthorEmail](
    [AID] int FOREIGN KEY REFERENCES Author(AID),
    [Email] VARCHAR (35) NOT NULL,
    CONSTRAINT Pk_AuthorEmail PRIMARY KEY CLUSTERED ([AID] ASC, [Email] ASC));


INSERT INTO AuthorEmail(AID, Email)
VALUES
	(1, 'jp@stonewood.com'),
	(2, 'rowlingontheriver@stonewood.com'),
	(3, 'rubberduckie@stonewood.com');