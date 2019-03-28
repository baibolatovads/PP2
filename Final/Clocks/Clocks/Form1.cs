using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Clocks
{
    public partial class Form1 : Form
    {
        int curBtn = 0;
        public Form1()
        {
            InitializeComponent();
            button1.BackColor = Color.Yellow;
            timer1.Start();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            for(int i = 0; i < Controls.Count; i++)
            {
                this.Controls[i].BackColor = Color.Blue;
            }
            
            this.Controls[curBtn].BackColor = Color.Yellow;
            curBtn--;
           if (curBtn < 0)
            {
                curBtn = 11;
            }
        }
    }
}
