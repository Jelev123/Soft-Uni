CREATE TABLE Passports(
PassportID int PRIMARY KEY IDENTITY	 NOT null,
PassportNumber nvarchar (30) NOT null)

CREATE TABLE Persons( 
PersonID int PRIMARY KEY NOT null,
FirstName nvarchar(	10) NOT null,
Salary decimal (7,2) NOT NULL ,
PassportID int  not null FOREIGN 	KEY REFERENCES dbo.Passports (PassportID) UNIQUE	)


SET IDENTITY_INSERT	dbo.Passports	ON	

INSERT	INTO		dbo.Passports
(
    PassportID,
    PassportNumber
)
VALUES

(101,'N34FG21B'),
(102,'K65LO4R7'),
(103,'ZE657QP2')
    



INSERT INTO dbo.Persons
(
    PersonID,
    [FirstName],
    Salary,
    PassportID
)
VALUES

    (1, 'Roberto', 43300.00, 102 ),
	(2, 'Tom', 56100.00, 103 ),
	(3, 'Yana', 60200.00, 101 )
    
     
	 SELECT * FROM dbo.Persons p	
	 SELECT * FROM dbo.Passports p	
   
   CREATE TABLE Manufacturers(
   ManufacturerID int PRIMARY KEY IDENTITY	NOT null,
   [Name] char(10) ,
   EstablishedOn date	
   
   )

   CREATE TABLE	Models(
   ModelID int PRIMARY KEY IDENTITY NOT null,
   [Name] char(10) ,
   ManufacturerID int FOREIGN	KEY REFERENCES	   Manufacturers(ManufacturerID) 
   )


   INSERT INTO	dbo.Manufacturers
   (
       
       Name,
       EstablishedOn
   )
   VALUES
  ('BMW','07/03/1916'),
  ('Tesla','01/01/2003'),
  ('Lada','01/05/1966')

  INSERT INTO dbo.Models
  (
     
      Name,
      ManufacturerID
  )
  VALUES
  ('X1',1),
  ('i6',1),
  ('Model S',2),
  ('Model X',2),
  ('Model 3',2),
  ('Nova',3)



  CREATE TABLE Teachers
  (
    TeacherID int PRIMARY key NOT null,
	[Name] char(10) NOT null,
	ManagerID int FOREIGN	 KEY REFERENCES	dbo.Teachers	(TeacherID	)
	
  )

  INSERT INTO dbo.Teachers
  (
      TeacherID,
      [Name],
      ManagerID
  )
  VALUES
  (101,'John', NULL	),
  (102,'Maya', 106	),
  (103,'Silvia', 106	),
  (104,'Ted', 105),
  (105,'Mark', 101	),
  (106,'Greta', 101)


 