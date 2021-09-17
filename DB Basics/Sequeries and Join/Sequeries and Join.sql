select top(5) EmployeeId,JobTitle,a.AddressID,AddressText from Employees as e
join Addresses as a 
on e.AddressId = a.AddressId
order by AddressId asc