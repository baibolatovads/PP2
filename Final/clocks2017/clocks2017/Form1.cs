using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace clocks2017
{
    public partial class Form1 : Form
    {
        int minute, seconds;
        public Form1()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Refresh();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            seconds++;
            if (seconds == 60)
            {
                seconds = 0;
                minute++;
            }

            e.Graphics.DrawPie(new Pen(Color.Red), 100, 100, 100, 100, 270 + seconds * 6, 1);
            e.Graphics.DrawPie(new Pen(Color.Blue), 100, 100, 100, 100, 270 + minute * 6, 1);

            label1.ForeColor = Color.Black;

            if (minute == 6)
            {
                label1.ForeColor = Color.Red;
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
