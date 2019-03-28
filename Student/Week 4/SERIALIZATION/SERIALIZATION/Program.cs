using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace SERIALIZATION
{

    public class Student {


        public Student()
        {

        }
        public Student(string name, double gpa)
        {
            this.name = name;
            this.gpa = gpa;
        }

        string name;
        double gpa; 

        public string GetInfo()
        {
            return name + " " + gpa;
        }

        class Program
        {
            static void Main(string[] args)
            {
                //F1();
                F2();

            }

            private static void F1()
            {
                FileStream fs = new FileStream("student.xml", FileMode.Open, FileAccess.Read);
                XmlSerializer xs = new XmlSerializer(typeof(Student));
                Student s = xs.Deserialize(fs) as Student;

                fs.Close();
            }

            private static void F2()
            {
                Student s = new Student("ABC", 1);
                FileStream fs = new FileStream("student.xml", FileMode.OpenOrCreate, FileAc cess.Write);
                XmlSerializer xs = new XmlSerializer(typeof(Student));
                xs.Serialize(fs, s);
                fs.Close();
            }
        }
    }
}
