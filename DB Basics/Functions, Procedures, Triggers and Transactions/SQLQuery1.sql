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


-- 05. Salary Level Function

create function ufn_GetSalaryLevel(@salary DECIMAL(18,4)) 

returns varchar(7)
as
begin
declare @SalaryLevel varchar(7)

if (@salary < 30000) begin set @SalaryLevel = 'Low' end
else if (@salary >= 30000 and @salary <=50000) begin  set @SalaryLevel = 'Average' end
else 
begin
set @SalaryLevel = 'High'
end
return @SalaryLevel
end

-- 06. Employees by Salary Level


create procedure usp_EmployeesBySalaryLevel (@SalaryLevel varchar(7))
as 
begin
select FirstName,LastName
from Employees
where dbo.ufn_GetSalaryLevel(Salary) = @SalaryLevel
end 


