using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Class_Student
{
    class Program
    {
        class Student
        {
            string name;
            string sname;
            double gpa;

            public Student(string name = "Dariya", string sname = "Baibolatova", double gpa = "4.0")
            {
                this.name = name;
                this.sname = sname;
                this.gpa = gpa;
                
            }

            public void ReadInfo()
            {
                name = Console.ReadLine();
                sname = Console.ReadLine();
                gpa = int.Parse(Console.ReadLine());
            }

            public override string ToString()
            {
                return name + " " + sname + " " + gpa;
            }
            public void PrintInfo()
            {
                Console.WriteLine("{0} {1} {2}", name, sname, gpa);
            }

        }

        static void Main(string[] args)
        {
            Student s1 = new Student();
            Student s2 = new Student("Dariya", "Baibolatova", 4.0);
            Student s3 = new Student();

            s3.ReadInfo();

            Console.WriteLine("{0} \n{1} \n{2} \n", s1, s2, s3);
        }
    }
}
