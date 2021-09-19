select top(5) EmployeeId,JobTitle,a.AddressID,AddressText from Employees as e
join Addresses as a 
on e.AddressId = a.AddressId
order by AddressId asc

select top(50) FirstName,LastName,t.[Name],AddressText from Employees as e
join Addresses as a
on e.AddressID = a.AddressId
join Towns as t
on a.TownID = t.TownID
order by FirstName asc,LastName asc

select EmployeeID,FirstName,LastName,d.[Name] as DepartmentName from Employees as e
join Departments as d
on e.DepartmentID = d.DepartmentID
where d.[Name] = 'Sales'
order by EmployeeID asc


select top ( 5) EmployeeID,FirstName,Salary,d.[Name] from Employees as e
join Departments as d
on e.DepartmentID = d.DepartmentID
where d.[Name] = 'Engineering'
order by e.DepartmentID desc


select top(3) e.EmployeeID,FirstName from Employees as e
 left join EmployeesProjects as ep
on e.EmployeeID = ep.EmployeeID
order by ep.EmployeeID asc

select FirstName,LastName,HireDate,d.[Name] as DeptName from Employees as e
join Departments as d
on e.DepartmentID = d.DepartmentID
where e.HireDate > '1999-01-01' And d.[Name] in ('Sales' ,'Finance')
order by e.HireDate asc


SELECT TOP 5 e.EmployeeID, e.FirstName, p.Name AS [ProjectName] FROM Employees AS [e]
join EmployeesProjects as ep
on e.EmployeeID = ep.EmployeeID
join Projects as p
on ep.ProjectID = p.ProjectID
AND (FORMAT(p.StartDate, 'DD-MM-YYYY') > '13/08/2002' AND p.EndDate IS NULL)
ORDER BY e.EmployeeID


select e.EmployeeID,FirstName,
Case
When DatePart(Year,p.StartDate) >= 2005 then null else p.[Name] End as [ProjectName]
from Employees as e
join EmployeesProjects as ep
on e.EmployeeID = ep.EmployeeID 
join Projects as p on ep.ProjectID = p.ProjectID
where e.EmployeeID = 24


select top(50) e1.EmployeeID,concat(e1.FirstName , ' ' , e1.LastName) as EmployeeName,
                             concat(e2.FirstName , ' ', e2.LastName) as ManagerName,
							 d.[Name] as DepartmentName
from Employees as e1
join Employees as e2 on e1.ManagerID = e2.EmployeeID 
join Departments as d on d.DepartmentID =e1.DepartmentID
order by EmployeeID

