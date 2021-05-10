using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace _02._Average_Student_Grades
{
    class Program
    {
        static void Main(string[] args)
        {
            var student = new Dictionary<string, List<double>>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split();
                string name = input[0];
                double grade = double.Parse(input[1]);

                if (!student.ContainsKey(name))
                {
                    student.Add(name, new List<double>());
                }

                student[name].Add(grade);

            }

            foreach (var kvp in student)
            {
                var name = kvp.Key;
                var studentGrade = kvp.Value;
                var average = studentGrade.Average();
                Console.Write($"{name} ->");

                foreach (var grade in studentGrade)
                {
                    Console.Write($"{grade:f2} ");
                    Console.WriteLine($"(avg: {average:F2})");
                }
            }

        }
    }
}

