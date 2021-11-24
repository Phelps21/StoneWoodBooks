USE [C:\USERS\DEVIN\SOURCE\REPOS\STONEWOODBOOKS\STONEWOODBOOKS\APP_DATA\STONEWOODDATA.MDF];

CREATE TABLE [dbo].[AuthorAddress](
    [AID] int FOREIGN KEY REFERENCES Author(AID),
    [StreetNum] int NOT NULL,
	[StreetName] varchar(35) NOT NULL,
	[City] varchar(35) NOT NULL,
	[State] varchar(3) FOREIGN KEY REFERENCES State(StateID),
	[Zip] int NOT NULL
	CONSTRAINT Pk_AuthorAdress PRIMARY KEY CLUSTERED([AID], [StreetNum])
    );


INSERT INTO AuthorAddress(AID, StreetNum,StreetName, City, State, Zip)
VALUES
(1, 223, 'Rodeo Dr.', 'Pflugerville', 'TX', 83207),
(2, 956, 'Jimmy Joe Blvd.', 'Los Angeles', 'CA', 90210),
(3, 609, '33rd St.', 'New York City', 'NY', 10101);