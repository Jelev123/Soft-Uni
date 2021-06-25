using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassroomProject
{
    public class Classroom
    {
        public Classroom(int capacity)
        {
            Capacity = capacity;
            students = new List<Student>();
        }

        private readonly List<Student> students = new List<Student>();

        public int Capacity { get; }
        public int Count => students.Count;


        public string RegisterStudent(Student student)
        {
            if (Count < Capacity)
            {
                students.Add((student));
                return $"Added student {student.FirstName} {student.LastName}";
            }

            return "No seats in the classroom";
        }

        public  string DismissStudent(string firstName, string lastName)
        {
            if (students.Exists(x=>x.FirstName== firstName && lastName == lastName))
            {
                students.Remove(students.FirstOrDefault(x=>x.FirstName==firstName && lastName == lastName));
                return $"Dismissed student {firstName} {lastName}";
            }

            return "Student not found";
        }

        public string GetSubjectInfo(string subject)
        {
            var sb = new StringBuilder();
            var studentSubject = students.Where(x => x.Subject == subject).ToList();
            if (studentSubject.Count > 0)
            {
                sb.AppendLine($"Subject: {subject}")
                    .AppendLine("Students:");

                foreach (Student student in studentSubject)
                {
                    sb.AppendLine($"{student.FirstName} {student.LastName}");
                }

                return sb.ToString().TrimEnd();
            }


        
                return "No students enrolled for the subject";

        }

        public int GetStudentsCount() => students.Count;

        public Student GetStudent(string firstName, string lastName)
            => students.FirstOrDefault(x => x.FirstName == firstName && lastName == lastName);





    }
}