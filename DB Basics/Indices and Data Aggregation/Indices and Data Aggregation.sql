--03. Longest Magic Wand per Deposit Groups
select DepositGroup,Max(MagicWandSize) as LongestMagicWand from WizzardDeposits
group by DepositGroup

--04. Smallest Deposit Group per Magic Wand Size

select top(2) DepositGroup  from WizzardDeposits
group by  DepositGroup
order by Avg(MagicWandSize)

-- 05. Deposits Sum

select DepositGroup,Sum(DepositAmount) as TotalSum  from WizzardDeposits
group by DepositGroup

--06. Deposits Sum for Ollivander Family

select *from WizzardDeposits

select DepositGroup ,Sum(DepositAmount) as TotalSum from WizzardDeposits
where MagicWandCreator = 'Ollivander family'
group by DepositGroup

-- 07. Deposits Filter
select *from WizzardDeposits


select DepositGroup ,Sum(DepositAmount) as TotalSum from WizzardDeposits
where MagicWandCreator = 'Ollivander family'
group by DepositGroup
having Sum(DepositAmount) < 150000
order by Sum(DepositAmount) desc


--08. Deposit Charge
select *from WizzardDeposits

SELECT DepositGroup, MagicWandCreator AS [MagicWandCreator], MIN(DepositCharge) AS MinDepositCharge FROM WizzardDeposits
GROUP BY DepositGroup, MagicWandCreator
ORDER BY MagicWandCreator, DepositGroup


-- 09. Age Groups

select * from WizzardDeposits

Select 
case
when Age between 0 and 10 then '[0-10]'
When Age between 11 and 20 then '[11-20]'
When Age between 21 and 30 then '[21-30]'
When Age between 31 and 40 then '[31-40]'
When Age between 41 and 50 then '[41-50]'
When Age between 51 and 60 then '[51-60]'
else '[61+]'
end
as AgeGroup ,Count(*) as WizzardsCount from WizzardDeposits

group by 
(case
when Age between 0 and 10 then '[0-10]'
When Age between 11 and 20 then '[11-20]'
When Age between 21 and 30 then '[21-30]'
When Age between 31 and 40 then '[31-40]'
When Age between 41 and 50 then '[41-50]'
When Age between 51 and 60 then '[51-60]'
else '[61+]'
end)


-- 10. First Letter

select * from WizzardDeposits

select  distinct left (FirstName , 1) as FirstLetter from WizzardDeposits
group by FirstName, DepositGroup 
having DepositGroup = 'Troll Chest' 

--11. Average Interest

select * from WizzardDeposits

select DepositGroup , IsDepositExpired,avg(DepositInterest) as AverageInterest from WizzardDeposits
where DepositStartDate > '01/01/1985'
group by DepositGroup, IsDepositExpired 
order by DepositGroup desc,IsDepositExpired asc


-- 13. Departments Total Salaries

select * from Employees

Select DepartmentID, Sum(Salary) from Employees
group by DepartmentID
order by DepartmentID


