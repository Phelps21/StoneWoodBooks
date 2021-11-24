USE [C:\USERS\DEVIN\SOURCE\REPOS\STONEWOODBOOKS\STONEWOODBOOKS\APP_DATA\STONEWOODDATA.MDF];

CREATE TABLE [dbo].[Supplier](
[SupplierID] int PRIMARY KEY IDENTITY(1,1)  NOT NULL,
[Name] varchar(35) NOT NULL,);

INSERT INTO Supplier(Name)
VALUES
('Baker & Taylor'),
('Midpoint Trade Books'),
('Alibris'),
('Book Express');