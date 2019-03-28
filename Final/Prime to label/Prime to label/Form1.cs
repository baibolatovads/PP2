using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Prime_to_label
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            label1.Text = "";
            int a = int.Parse(textBox1.Text);
           for (int i=2; i<=a; ++i)
            {
                if (Prime(i))
                {
                    label1.Text+= i + " ";
                }
            }
        }

        private bool Prime(int a)
        {
            if (a == 1) return false;
            for (int i = 2; i * i <= a; i++)
            {
                if (a % i == 0) return false;
            }
            return true;
        }
    }
}
