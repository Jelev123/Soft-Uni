--03. Longest Magic Wand per Deposit Groups
select DepositGroup,Max(MagicWandSize) as LongestMagicWand from WizzardDeposits
group by DepositGroup

--04. Smallest Deposit Group per Magic Wand Size

select top(2) DepositGroup  from WizzardDeposits
group by  DepositGroup
order by Avg(MagicWandSize)

-- 05. Deposits Sum

select *from WizzardDeposits

select DepositGroup,Sum(DepositAmount) as TotalSum  from WizzardDeposits
group by DepositGroup