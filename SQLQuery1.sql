use TournamentTracker;


-- https://www.w3schools.com/sql/sql_insert.asp
insert into People
values ('Douglass', 'Frederick', 'd.fred@aol.com','080-324-3000');

insert into People (FirstName, LastName, EmailAddress)
values ('Coco', 'Chanel', 'c.chanel@hotmail.com');

select* from People

---------------------------------

EXEC dbo.spTestPerson_GetByLastName @LastName = 'Chanel';