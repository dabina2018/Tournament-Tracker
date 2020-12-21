use TournamentTracker


ALTER Table TournamentPrizes
ADD PRIMARY KEY (id);
-------------------------------------

--alter table TournamentPrizes
--drop constraint primary key;

alter table TournamentPrizes
drop column id
	-----
drop table TournamentPrizes

Create Table TournamentPrizes(
id_ int primary key identity(1,1) not null,
TournamentId int not null,
PrizeId int not null);
-------------------------------------------------------

Select *
from TournamentPrizes
---------------------------------

ALTER TABLE	Tournaments
ALTER COLUMN TournamentName varchar(50) NOT NULL

ALTER TABLE	Tournaments
ALTER COLUMN EntryFee money NOT NULL;
------------------------------------------------------

ALTER TABLE	TournamentPrizes
ALTER COLUMN TournamentId int NOT NULL

ALTER TABLE	TournamentPrizes
ALTER COLUMN PrizeId int NOT NULL;