CREATE	DATABASE Users

USE Users

CREATE TABLE Users(
Id bigint	PRIMARY	KEY IDENTITY	NOT null,
Username varchar(30) UNIQUE	 NOT NULL,
[Password] varchar(26) NOT null,
ProfilePicture varbinary	(max)
CHECK (datalength(ProfilePicture) <= 900 * 1024),
LastLoginTime datetime2	NOT NULL	,
IsDeleted bit NOT null)

INSERT INTO Users
(
    
    Username,
    [Password],
    LastLoginTime,
    IsDeleted
)
VALUES

    
    ('Pesho1',    '1234',     '05.05.2020',   0 ),
	('Pesho2',    '1234',     '05.05.2020',   0 ),
	('Pesho3',    '1234',     '05.05.2020',   0 ),
	('Pesho4',    '1234',     '05.05.2020',   0 ),
	('Pesho5',    '1234',     '05.05.2020',   0 )
 
   
	 SELECT	* FROM Users 
  

  CREATE TABLE People
(
 [Id] INT PRIMARY KEY Identity,
 [Name] NVARCHAR(200) NOT NULL,
 [Picture] VARBINARY(MAX),
 [Height] DECIMAL(5,2),
 [Weight] DECIMAL(5,2),
 [Gender] char(1) Not null CHECK(Gender='m' OR Gender='f'),
 Birthdate DATE Not Null,
 Biography NVARCHAR(MAX)
)
INSERT INTO People(Name,Picture,Height,Weight,Gender,Birthdate,Biography) Values
('Stela',Null,1.65,44.55,'f','2000-09-22',Null),
('Ivan',Null,2.15,95.55,'m','1989-11-02',Null),
('Qvor',Null,1.55,33.00,'m','2010-04-11',Null),
('Karolina',Null,2.15,55.55,'f','2001-11-11',Null),
('Pesho',Null,1.85,90.00,'m','1983-07-22',Null)

SELECT * FROM People


USE Minions

ALTER TABLE Users
DROP CONSTRAINT	[PK__Users__3214EC076019B560]

ALTER TABLE Users	
ADD	CONSTRAINT	PK_Users_ComIdUsername
PRIMARY	 KEY (Id,Username)

ALTER TABLE	 Users
ADD	CONSTRAINT	[CK__Users__PasswordLength]
CHECK (Len([Password]) >= 5)

ALTER TABLE	 Users	
ADD CONSTRAINT	DF_Users_LastLoginTime
DEFAULT getDate() FOR LastLoginTime


ALTER TABLE	 Users	
DROP CONSTRAINT	 PK_Users_ComIdUsername

ALTER TABLE dbo.Users
ADD CONSTRAINT PK_Users_Id
PRIMARY KEY (Id)

ALTER TABLE dbo.Users
ADD CONSTRAINT CH_Users_PasswordLenght
CHECK (LEN(Username) >= 3)


CREATE DATABASE Movies 
USE Movies

CREATE TABLE Directors (
Id int PRIMARY KEY NOT NULL ,
DirectorName char(20) NOT null,
Notes varchar(100) NOT NULL)

CREATE TABLE Genres ( 
Id int PRIMARY KEY NOT NULL ,
GenreName char(20) NOT null,
Notes varchar(100) NOT NULL)

CREATE TABLE Categories ( 
Id int PRIMARY KEY  NOT NULL ,
CategoryName char(20) NOT null,
Notes varchar(100) NOT NULL)

CREATE TABLE Movies (
Id int PRIMARY KEY NOT NULL ,
Title nvarchar NOT null,
DirectorId int FOREIGN KEY	REFERENCES	 Directors(Id) 		NOT null,
CopyrightYear date NOT null,
[Length] int NOT NULL	,
GenreId int foreign key REFERENCES	dbo.Genres	(Id)	 NOT null,
CategoryId int FOREIGN	 KEY REFERENCES	dbo.Categories	(Id)  NOT null,
Rating decimal NOT null,
Notes nvarchar(max) NOT null)



CREATE DATABASE	 SoftUni 
USE SoftUni 

CREATE TABLE Towns  (
Id int PRIMARY KEY IDENTITY	 NOT null,
[Name] nvarchar	(max) not null
)

CREATE TABLE Addresses (
Id int PRIMARY KEY IDENTITY	NOT null,
AddressText nvarchar NOT null,
TownId int FOREIGN	KEY	 REFERENCES	Towns(Id) NOT null)

CREATE	TABLE	Departments (
Id int PRIMARY KEY IDENTITY ,
[Name] nvarchar(50) )


CREATE TABLE	Employees (
Id int PRIMARY KEY IDENTITY	,
FirstName nvarchar(	50) NOT null,
MiddleName nvarchar(	50) NOT NULL	,
LastName nvarchar(	50) NOT	 null,
JobTitle nvarchar(	50) NOT NULL	,
DepartmentId int FOREIGN	 KEY	REFERENCES	Departments(Id)	,
HireDate date NOT null,
Salary decimal(7,2) NOT NULL	,
AddressId int FOREIGN	KEY REFERENCES	Addresses(Id)	 NOT null
)

INSERT INTO Towns
(
    
    [Name]
)
VALUES
    ('Sofiq'),
	('Plovdiv'),
    ('Varna'),
	('Burgas')
	 

	 INSERT	INTO Departments
	 (
	    
	     [Name]
	 )
	 VALUES
	 ('Engineering'),
	 ('Sales'),
	 ('Marketing'),
	 ('Software Development'),
	 ('Quality Assurance')
	

	    
	 	
	USE SoftUni

	SELECT	* from Departments 

	SELECT	[Name] from Departments

	SELECT	 FirstName,LastName,Salary FROM	Employees

	SELECT	FirstName,MiddleName,LastName from Employees 
	
	SELECT	(FirstName + '.' + LastName + '@softuni.bg') as [Full Email Address] from Employees 

	SELECT DISTINCT	 dbo.Employees.JobTitle FROM dbo.Employees 

	SELECT TOP 10 * FROM dbo.Projects p	
	ORDER BY	p.StartDate	ASC	, [Name] ASC	
	

	SELECT TOP 7 FirstName,LastName,HireDate FROM dbo.Employees e	
	ORDER BY e.HireDate	DESC

	
	SELECT * FROM dbo.Departments d	
	
	SELECT * FROM dbo.Employees e	

	UPDATE dbo.Employees
	SET
	   
	    Salary += dbo.Employees.Salary * 0.12
		WHERE dbo.Employees.DepartmentID	IN (1,2,4,11)
	   
	SELECT Salary FROM dbo.Employees e	

	USE [Geography]

	SELECT PeakName FROM Peaks 
	ORDER BY PeakName ASC	

	SELECT * FROM Countries



	SELECT TOP 30 CountryName,[Population] FROM Countries
	WHERE ContinentCode = 'EU'
	ORDER BY  [Population] desc

	

	SELECT CountryName ,CountryCode,
	CASE
	WHEN CurrencyCode = 'EUR' THEN 'Euro'
	ELSE 'Not Euro'
	END as [CurrencyCode]
	FROM Countries
	ORDER BY CountryName ASC	
			
	
