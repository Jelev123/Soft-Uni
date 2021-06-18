using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading;

namespace BakeryOpenning
{
    public class Bakery

    {
        private Dictionary<string, Employee> employees = new Dictionary<string, Employee>();
        public Bakery(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;
            
        }

       
        public string Name { get; set; }        
        public int Capacity { get; set; }

        public int Count
        {
            get
            {
                return employees.Count;
            }
        }


        public  void Add(Employee employee)
        {

            if (employees.Count < Capacity)
            {
                employees.Add(employee.Name,employee);
            }
            
        }

        public bool Remove(string name)
        {
            if (employees.ContainsKey(name))
            {
                employees.Remove(name);
                return true;
            }
            return false;

        }

        public Employee GetOldestEmployee()
        {
            Employee oldestEmplyee = null;

            foreach (var employee in employees)
            {
                oldestEmplyee = new Employee(employee.Value.Name, employee.Value.Age, employee.Value.Country);
                break;
            }

            return oldestEmplyee;
        }

        public Employee GetEmployee(string name)
        {
            Employee employee = null;

            if (employees.ContainsKey(name))
            {
                employee = employees[name];
                return employee;
            }

            return null;
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Employees working at Bakery {Name}:");

            foreach (var employee in employees)
            {
                sb.AppendLine($"Employee: {employee.Value.Name}, {employee.Value.Age} ({employee.Value.Country})");
            }

            return sb.ToString().TrimEnd();
        }

    }
}