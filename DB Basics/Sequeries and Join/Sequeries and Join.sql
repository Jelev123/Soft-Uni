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
