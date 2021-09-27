-- 01. Employees with Salary Above 35000

create procedure usp_GetEmployeesSalaryAbove35000 as 
select FirstName,LastName
from Employees
where Salary > 35000


-- 02. Employees with Salary Above Number

create procedure usp_GetEmployeesSalaryAboveNumber
(@Salary decimal (18,4))
as
select FirstName,LastName
from Employees
where Salary >= @Salary



