USE [C:\USERS\DEVIN\SOURCE\REPOS\STONEWOODBOOKS\STONEWOODBOOKS\APP_DATA\STONEWOODDATA.MDF];

CREATE TABLE [dbo].[SupplierRep](
[RepID] int PRIMARY KEY IDENTITY(1,1)  NOT NULL,
[Lname] varchar(30),
[Fname] varchar(30),
[CellNum] bigint,
[WorkNum] bigint NOT NULL,
[Email] varchar(35) NOT NULL,
[SupplierID] int FOREIGN KEY REFERENCES Supplier([SupplierID]));

INSERT INTO SupplierRep(Lname, Fname, CellNum, WorkNum, Email, SupplierID)
VALUES
('Blow', 'Joe', 3334445555, 4340320886, 'jb@books.com', 2),
('Doe', 'Jim', 3534649555, 4340320886, 'jim@hotmail.com', 1),
('David', 'Larry', 3126660534, 0001119967, 'dldude@enron.com', 3);