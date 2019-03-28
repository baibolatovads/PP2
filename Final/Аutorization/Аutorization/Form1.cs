using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Аutorization
{
    
    
    public partial class Form1 : Form
    {
        serialization sr = new serialization();
        public Form1()
        {
            InitializeComponent();
            sr = sr.Load();
        }
         

        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text != "" && textBox2.Text != "")
            {
                sr.users.Add(new User(textBox1.Text, textBox2.Text));
                sr.Save();
            }
        }

        private void bindingSource1_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox3.Text != "" && textBox4.Text != "")
            {
               foreach(var u in sr.users)
                {
                    if(u.login == textBox3.Text)
                    {
                        if (u.parol == textBox4.Text)
                        {
                            label1.Text = "Authorization is confirmed!";
                        }else
                        {
                            label1.Text = "Wrong parol!";
                        }
                        break;
                    }
                    else
                    {
                        label1.Text = "Wrong login!";
                    }
                }
            }
        }
    }
}
