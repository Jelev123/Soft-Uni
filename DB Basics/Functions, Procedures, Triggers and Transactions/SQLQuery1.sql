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

-- 04. Employees from Town

create procedure usp_GetEmployeesFromTown  (@TownName varchar(50))
as
begin
select e.FirstName,e.LastName from Employees as e
join Addresses as a on e.AddressID = a.AddressID
join Towns as t on a.TownID= t.TownID
where t.[Name] = @TownName
end
execute usp_GetEmployeesFromTown  'Sofia'


