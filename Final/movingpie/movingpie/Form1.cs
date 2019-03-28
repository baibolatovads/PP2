﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace movingpie
{
    public partial class Form1 : Form
    {
        int speed = 0;
        Random rnd = new Random();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            speed++;
            Refresh();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawEllipse(new Pen(Color.White), 100, 100, 103, 103);
            e.Graphics.DrawPie(new Pen(Color.Red), 100, 100, 100, 100, 170, speed);
            label1.Text = speed.ToString();
        }
    }
}



