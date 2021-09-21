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
