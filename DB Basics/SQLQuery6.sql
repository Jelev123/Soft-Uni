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
    Password,
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
