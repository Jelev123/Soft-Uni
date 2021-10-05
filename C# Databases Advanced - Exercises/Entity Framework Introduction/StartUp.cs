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
            string result = GetEmployeesByFirstNameStartingWithSa(softUniContext);
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
                    Project=e.EmployeesProjects.Select(ep=>ep.Project.Name).OrderBy(pn=>pn).ToList()
                                       
                })
                .Single();

            
                sb
                    .AppendLine($"{employee147.FirstName} {employee147.LastName} - {employee147.JobTitle}");

                foreach (var VARIABLE in employee147.Project)
                {
                    sb.AppendLine(VARIABLE);
                }
               

            return sb.ToString().TrimEnd();
        }


        // 10. Departments with More Than 5 Employees


        public static string GetDepartmentsWithMoreThan5Employees(SoftUniContext context)
        {
            var sb = new StringBuilder();

            var deparments = context.Departments
                .Where(d => d.Employees.Count() > 5)
                .OrderBy(e => e.Employees.Count())
                .ThenBy(d => d.Name)
                .Select(d => new
                {
                    d.Name,
                    managerFirstName = d.Manager.FirstName,
                    managerLastName = d.Manager.LastName,
                    depEmployees = d.Employees
                        .Select(e => new
                        {
                            employeeFirstname = e.FirstName,
                            employeeLastName = e.LastName,
                            jobTitle = e.JobTitle
                        })
                        .OrderBy(e => e.employeeFirstname)
                        .ThenBy(e => e.employeeLastName).ToList()
                })
                .ToList();


            foreach (var e in deparments)
            {
                sb
                    .AppendLine($"{e.Name} – {e.managerFirstName} {e.managerLastName}");

                foreach (var d in e.depEmployees)
                {
                    sb.AppendLine($"{d.employeeFirstname}  {d.employeeLastName} - {d.jobTitle}");
                }
            }
                

            return sb.ToString().TrimEnd();
        }

        //11. Find Latest 10 Projects

        public static string GetLatestProjects(SoftUniContext context)
        {
            var sb = new StringBuilder();

            var projects = context.Projects.OrderByDescending(p => p.StartDate)
                .Take(10).OrderBy(p => p.Name);

            foreach (var p in projects)
            {
                sb.AppendLine(p.Name);
                sb.AppendLine(p.Description);
                sb.AppendLine(p.StartDate.ToString("M/d/yyyy h:mm:ss tt"));
            }

            return sb.ToString().TrimEnd();

        }

        // 12. Increase Salaries

        public static string IncreaseSalaries(SoftUniContext context)
        {
            var sb = new StringBuilder();

            var employees=context.Employees
                    .Where(e=>e.Department.Name == "Engineering" || e.Department.Name == "Tool Design" || e.Department.Name == "Information Services " || e.Department.Name == "Marketing");

            foreach (Employee e in employees)
            {
                e.Salary += e.Salary * 0.12m;
            }

            context.SaveChanges();

            var employeeInfo = employees.Select(e => new
            {
                e.FirstName,
                e.LastName,
                e.Salary
            }).OrderBy(e => e.FirstName).ThenBy(e => e.LastName).ToList();

            foreach (var em in employeeInfo)
            {
                sb
                    .AppendLine($"{em.FirstName} {em.LastName} ({em.Salary:F2})");
            }

            return sb.ToString().TrimEnd();
        }


        // 13. Find Employees by First Name Starting With Sa

        public static string GetEmployeesByFirstNameStartingWithSa(SoftUniContext context)
        {
            var sb = new StringBuilder();

            var employees = context.Employees
                .Where(e => e.FirstName.StartsWith("Sa"))
                .OrderBy(e => e.FirstName).ThenBy(e => e.LastName);

            foreach (var e in employees)
            {
                sb.AppendLine($"{e.FirstName} {e.LastName} - {e.JobTitle} - (${e.Salary:F2})");
            }

            return sb.ToString().TrimEnd();
        }
    }
}



