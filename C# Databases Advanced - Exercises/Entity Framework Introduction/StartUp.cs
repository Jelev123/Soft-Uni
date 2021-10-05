using System;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using SoftUni.Data;
using SoftUni.Models;

namespace SoftUni
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            SoftUniContext softUniContext = new SoftUniContext();
            string result = GetEmployee147(softUniContext);
            Console.WriteLine(result);

        }

        // 03. Employees Full Information

        public static string GetEmployeesFullInformation(SoftUniContext context)
        {
            var sb = new StringBuilder();

            var employyes = context.Employees
                .Select(e => new
                {
                    e.FirstName,
                    e.LastName,
                    e.MiddleName,
                    e.JobTitle,
                    e.Salary,
                    e.EmployeeId
                })
                .OrderBy(e => e.EmployeeId)
                .ToList();

            foreach (var employye in employyes)
            {
                sb.AppendLine(
                    $"{employye.FirstName} {employye.LastName} {employye.MiddleName} {employye.JobTitle} {employye.Salary:F2}");
            }

            return sb.ToString().TrimEnd();

        }

        // 04. Employees with Salary Over 50 000

        public static string GetEmployeesWithSalaryOver50000(SoftUniContext context)

        {
            var sb = new StringBuilder();

            var employees = context.Employees
                .Where(e => e.Salary > 50000)
                .Select(e => new
                {
                    e.FirstName,
                    e.Salary
                }).OrderBy(e => e.FirstName).ToList();

            foreach (var e in employees)
            {
                sb.AppendLine($"{e.FirstName} - {e.Salary:F2}");
            }

            return sb.ToString().TrimEnd();
        }

        // 05. Employees from Research and Development

        public static string GetEmployeesFromResearchAndDevelopment(SoftUniContext context)
        {
            var sb = new StringBuilder();

            var employee = context.Employees
                .Where(e => e.Department.Name == "Research and Development")
                .Select(e => new
                {
                    e.FirstName,
                    e.LastName,
                    DepartmentName = e.Department.Name,
                    e.Salary
                }).OrderBy(e => e.Salary).ThenByDescending(e => e.FirstName).ToList();


            foreach (var e in employee)
            {
                sb
                    .AppendLine($"{e.FirstName} {e.LastName} from {e.DepartmentName} - {e.Salary:f2}");
            }
            return sb.ToString().TrimEnd();

        }


        // 06. Adding a New Address and Updating Employee

        public static string AddNewAddressToEmployee(SoftUniContext context)
        {
            var sb = new StringBuilder();

            Address newAddress = new Address()
            {
                AddressText = "Vitoshka 15",
                TownId = 4
            };

            Employee employeeNakov = context.Employees
                .First(e => e.LastName == "Nakov");

            employeeNakov.Address = newAddress;
            context.SaveChanges();

            var employees = context.Employees
                .OrderByDescending(e => e.AddressId)
                .Take(10)
                .Select(e => e.Address.AddressText)
                .ToList();

            foreach (var e in employees)
            {
                sb.AppendLine(e);
            }

            return sb.ToString().TrimEnd();


        }


        // 08. Addresses by Town

        public static string GetAddressesByTown(SoftUniContext context)
        {
            var sb = new StringBuilder();

            var employees = context.Addresses
                .Select(a => new
                {
                    a.AddressText,
                    TownName = a.Town.Name,
                    EmployeesCount = a.Employees.Count
                })
                .OrderByDescending(a => a.EmployeesCount)
                .ThenBy(a => a.TownName)
                .ThenBy(a => a.AddressText)
                .Take(10)
                .ToList();

            foreach (var e in employees)
            {
                
                    sb.AppendLine($"{e.AddressText}, {e.TownName} - {e.EmployeesCount} employees");
                
            }

            return sb.ToString().TrimEnd();
        }

        // 09. Employee 147

        public static string GetEmployee147(SoftUniContext context)
        {
            var sb = new StringBuilder();
            var employee147 = context.Employees.Where(e => e.EmployeeId == 147)
                .Select(e => new
                {
                    e.FirstName,
                    e.LastName,
                    e.JobTitle,
                    Project = e.EmployeesProjects.Select(ep => ep.Project.Name)
                        .OrderBy(ep => ep)
                        .ToList()
                }).Single();
                

           
            
                sb
                    .AppendLine($"{employee147.FirstName} {employee147.LastName} - {employee147.JobTitle}");

                foreach (var p in employee147.Project)
                {
                    sb
                        .AppendLine(p);
                }

            

            return sb.ToString().TrimEnd();
        }
    }
}



