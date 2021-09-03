CREATE TABLE Passports(
PassportID int PRIMARY KEY NOT null,
PassportNumber nvarchar (30) NOT null)




CREATE TABLE Persons( 
PersonID int PRIMARY KEY NOT null,
FirstName nvarchar(	10) NOT null,
Salary decimal NOT NULL ,
PassportID int FOREIGN	KEY REFERENCES dbo.Passports (PassportID))




INSERT INTO dbo.Persons
(
    PersonID,
    FirstName,
    Salary,
    PassportID
)
VALUES

    (1, 'Roberto', 43300.00, 102 ),
	(2, 'Tom', 56100.00, 103 ),
	(3, 'Yana', 60200.00, 101 )
    
     
	 SELECT * FROM dbo.Persons p	
   
