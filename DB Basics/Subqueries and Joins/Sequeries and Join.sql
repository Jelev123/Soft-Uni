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
