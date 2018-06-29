using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Report_Card
{
    class Program
    {
        static void Main(string[] args)
        {
            start();
        }

        static void start()
        {
            Restart:
            Console.Write(@"Enter Total Students: ");
            if (!int.TryParse(Console.ReadLine(), out int studentCount) || studentCount < 1)
            {
                invalidInput();
                goto Restart;
            }
            List<Student> students = new List<Student>();
            students.Add(getStudent());
            for(int i=1; i<studentCount; i++)
            {
                Console.WriteLine(@"*********************************************");
                students.Add(getStudent());
            }

            Console.WriteLine(@"

****************Report Card*******************

****************************************");

            students = students.OrderByDescending(student => student.TotalScore).ToList();

            for (int n = 0; n < students.Count; n++)
            {
                Console.WriteLine(@"Student Name: {0}, Position: {1}, Total: {2} / 300

****************************************", students[n].Name, n+1, students[n].TotalScore);
            }
            Console.ReadLine();
        }

        static void invalidInput()
        {
            Console.WriteLine(@"Your input was invalid... please try again.");
        }

        static Student getStudent()
        {
            Student student = new Student();

            Console.Write(@"Enter Student Name : ");
            student.Name = Console.ReadLine();

            student.TotalScore = enterMarks("English") + enterMarks("Math") + enterMarks("Computer");

            return student;
        }

        static int enterMarks(string className)
        {
            Marks:
            Console.Write(@"Enter {0} Marks (Out Of 100) : ", className);
            if (!int.TryParse(Console.ReadLine(), out int mark) || mark < 0 || mark > 100)
            {
                invalidInput();
                goto Marks;
            }
            return mark;
        }
    }
}
