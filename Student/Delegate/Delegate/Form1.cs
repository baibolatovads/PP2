using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Delegate
{
    public partial class Form1 : Form
    {

        delegate double MyDlgt(double a, double b);
        MyDlgt invoker;
        Sum sum = new Sum();


        public Form1()
        {
            InitializeComponent();
            invoker = sum.Sum1;
        }

       /* public void ShowMessage(string msg)
        {
            button1.Text = msg;
        }
        */
        private void button1_Click(object sender, EventArgs e)
        {
            Thread.Sleep(2000);
            double res = invoker.Invoke(double.Parse(textBox1.Text), double.Parse(textBox2.Text));
            MessageBox.Show(res.ToString());

        }
    }
}
