using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Аutorization
{
    public class User
    {
        public string login;
        public string parol;

        public User()
        {

        }

        public User(string login, string parol)
        {
            this.login = login;
            this.parol = parol;
        }
    }

    public class serialization
    {
        public List<User> users = new List<User>();

        public serialization()
        {

        }
        public serialization Load()
        {
            FileStream fs = new FileStream(@"C:\Users\User_PC\Documents\PP2\Phynal\Аutorization\Аutorization\bin\Debug\access.xml", FileMode.Open, FileAccess.Read);
            XmlSerializer xs = new XmlSerializer(typeof(serialization));
            serialization s = xs.Deserialize(fs) as serialization;

            fs.Close();
            return s;
        }

        public void Save()
        {
            FileStream fs = new FileStream(@"C:\Users\User_PC\Documents\PP2\Phynal\Аutorization\Аutorization\bin\Debug\access.xml", FileMode.OpenOrCreate, FileAccess.Write);
            XmlSerializer xs = new XmlSerializer(typeof(serialization));
            xs.Serialize(fs, this);

            fs.Close();
        }






























        public serialization Load()
        {
            FileStream fs = new FileStream(@"path", FileMode.Open, FileAccess.Read);
            XmlSerializer xs = new XmlSerializer(typeof(serialization));
            serialization s = xs.Deserialize(fs) as serialization;

            fs.Close();
            return s;
        }
    }
}
