using System;
using System.Linq;
using System.Text;
using SoftUni.Data;

namespace SoftUni
{
  public class StartUp
    {
        static void Main(string[] args)
        {
            SoftUniContext softUniContext = new SoftUniContext();
            string result = GetEmployeesFullInformation(softUniContext);
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
    }
}
