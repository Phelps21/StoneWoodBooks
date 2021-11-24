
USE [C:\USERS\DEVIN\SOURCE\REPOS\STONEWOODBOOKS\STONEWOODBOOKS\APP_DATA\STONEWOODDATA.MDF];

CREATE TABLE [dbo].[CustomerAddress](
    [Username]varchar(12) FOREIGN KEY REFERENCES Customer(Username),
    [StreetNum] int NOT NULL,
	[StreetName] varchar(35) NOT NULL,
	[City] varchar(35) NOT NULL,
	[State] varchar(3) FOREIGN KEY REFERENCES State(StateID),
	[Zip] int NOT NULL
	CONSTRAINT Pk_CustomerAdress PRIMARY KEY CLUSTERED([Username], [StreetNum])
    );


INSERT INTO CustomerAddress(Username, StreetNum,StreetName, City, State, Zip)
VALUES
('devinlaterza', 123, 'Melrose St.', 'Nacogdoches', 'TX', 75965),
('wesleyphelps', 456, 'John Adams Rd.', 'Nacogdoches', 'TX', 75966);