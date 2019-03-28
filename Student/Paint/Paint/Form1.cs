using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Paint
{
    enum Tools
    {
        Pen,
        Eraser,
        Fill,
        Rectangle,
        Circle,
        Triangle,
        Line,
        Righttriangle,
        Star
    }

    public partial class Paint : Form
    {
        Point firstPoint = default(Point);
        Point secondPoint = default(Point);
        Bitmap bmp = default(Bitmap);
        Graphics gfx = default(Graphics);
        Pen pen = new Pen(Color.Black, 1);
        Pen pen1 = new Pen(Color.White);

        Tools activeTool = Tools.Pen;
        Color init_color;

        Queue<Point> q = new Queue<Point>();

        public Paint()
        {
            InitializeComponent();
            
            bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            //pictureBox1.Image = bmp;
            gfx = Graphics.FromImage(bmp);
            pictureBox1.Image = bmp;

            gfx.Clear(Color.White);

            gfx.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            pen.EndCap = System.Drawing.Drawing2D.LineCap.Round;
            pen.StartCap = System.Drawing.Drawing2D.LineCap.Round;
        }



        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            firstPoint = e.Location;
            if (activeTool == Tools.Fill)
            {
                int x = e.X;
                int y = e.Y;
                init_color = bmp.GetPixel(x, y);
                q.Enqueue(new Point(x, y));
                bmp.SetPixel(x, y, pen.Color);
                while (q.Count != 0)
                {
                    Point p = q.Dequeue();
                    fill(p.X - 1, p.Y);
                    fill(p.X + 1, p.Y);
                    fill(p.X, p.Y - 1);
                    fill(p.X, p.Y + 1);
                }
                pictureBox1.Refresh();
            }
        }

        public void fill(int x, int y)
        {
            if (x < 0 || x > bmp.Width || y < 0 || y > bmp.Height)
                return;
            if (bmp.GetPixel(x, y) == init_color)
            {
                bmp.SetPixel(x, y, pen.Color );
                q.Enqueue(new Point(x, y));
            }
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            
            if (e.Button == MouseButtons.Left)
            {
                secondPoint = e.Location;

                switch (activeTool)
                {
                    case Tools.Pen:
                        gfx.DrawLine(pen, firstPoint, secondPoint);
                        firstPoint = secondPoint;
                        break;
                    case Tools.Eraser:
                        gfx.DrawLine(pen1, firstPoint, secondPoint);
                        firstPoint = secondPoint;
                       
                        break;
                    case Tools.Fill:
                        break;
                    case Tools.Rectangle:
                        break;
                    case Tools.Circle:
                        break;
                    case Tools.Triangle:
                        break;
                    case Tools.Line:
                        break;
                    case Tools.Righttriangle:
                        break;
                    case Tools.Star:
                        break;
                    default:
                        break;
                }
                pictureBox1.Refresh();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            activeTool = Tools.Pen;
        }

        /*private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            pen.Width = float.Parse(numericUpDown1.Value.ToString());
        }*/

        private void button3_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                pen.Color = colorDialog1.Color;
            }
        }

        

        private void button4_Click(object sender, EventArgs e)
        {
            activeTool = Tools.Fill;
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;


            switch (activeTool)
            {
                case Tools.Pen:
                    break;
                case Tools.Eraser:
                    break;
                case Tools.Fill:
                    break;
                case Tools.Rectangle:
                    e.Graphics.DrawRectangle(pen, GetRectangle(firstPoint, secondPoint));
                    break;
                case Tools.Circle:
                    e.Graphics.DrawEllipse(pen, GetRectangle(firstPoint, secondPoint));
                    break;
                case Tools.Triangle:
                    e.Graphics.DrawPolygon(pen, GetTriangle(firstPoint, secondPoint));
                    break;
                case Tools.Line:
                    e.Graphics.DrawLine(pen, firstPoint, secondPoint);
                    break;
                case Tools.Righttriangle:
                    e.Graphics.DrawPolygon(pen, GetRtriangle(firstPoint, secondPoint));
                    break;
                case Tools.Star:
                    e.Graphics.DrawPolygon(pen, GetStar(firstPoint, secondPoint));
                    break;
                default:
                    break;
            }
            
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {

            switch (activeTool)
            {
                case Tools.Pen:
                    break;
                case Tools.Fill:
                    break;
                case Tools.Rectangle:
                    gfx.DrawRectangle(pen, GetRectangle(firstPoint, secondPoint));
                    break;
                case Tools.Circle:
                    gfx.DrawEllipse(pen, GetRectangle(firstPoint, secondPoint));
                    break;
                case Tools.Triangle:
                    gfx.DrawPolygon(pen, GetTriangle(firstPoint, secondPoint));
                    break;
                case Tools.Line:
                    gfx.DrawLine(pen, firstPoint, secondPoint);
                    break;
                case Tools.Righttriangle:
                   gfx.DrawPolygon(pen, GetRtriangle(firstPoint, secondPoint));
                    break;
                case Tools.Star:
                    gfx.DrawPolygon(pen, GetStar(firstPoint, secondPoint));
                    break;
                default:
                    break;
            }
            pictureBox1.Refresh();
        }

        Rectangle GetRectangle(Point p1, Point p2)
        {
            Rectangle rec = new Rectangle(Math.Min(p1.X, p2.X), Math.Min(p1.Y, p2.Y), Math.Abs(p1.X - p2.X), Math.Abs(p1.Y - p2.Y));
            return rec;
        }
        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            pen.Width = float.Parse(numericUpDown1.Value.ToString());
        }

        private void lineToolStripMenuItem_Click(object sender, EventArgs e)
        {
            activeTool = Tools.Line;
        }

        private void rectangleToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            activeTool = Tools.Rectangle;
        }

        private void circleToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            activeTool = Tools.Circle;
        }

        private void SetupPictureBox(BmpCreationMode mode, string fileName)
        {

            if (mode == BmpCreationMode.Init)
            {
                bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            }
            else if (mode == BmpCreationMode.FromFile)
            {
                bmp = new Bitmap(Bitmap.FromFile(openFileDialog1.FileName));
            }

            gfx = Graphics.FromImage(bmp);

            if (mode == BmpCreationMode.Init)
            {
                gfx.Clear(Color.White);
            }

            pictureBox1.Image = bmp;
            gfx.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;


        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image.Save(saveFileDialog1.FileName);
            }
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                SetupPictureBox(BmpCreationMode.FromFile, openFileDialog1.FileName);
            }
        }

        private void printToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                // Assumes the default printer.
                printDocument1.Print();
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while printing", ex.ToString());
            }
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            // Draw a picture.
            e.Graphics.DrawImage(Image.FromFile("C:\\My Folder\\MyFile.bmp"), e.Graphics.VisibleClipBounds);

            // Indicate that this is the last page to print.
            e.HasMorePages = false;
        }

      
   
        private Point[] GetTriangle(Point A, Point B)
        {
            Point[] points =
            {
                new Point(A.X, B.Y),
                new Point((A.X + B.X)/2, A.Y),
                B
            };

            return points;
        }
        private Point[] GetRtriangle(Point A, Point B)
        {
            Point[] points =
            {
              A,
              B,
              new Point(A.X, B.Y)
            };

            return points;
        }

        private PointF[] GetStar(PointF A, PointF C)
        {
            PointF B = new PointF(C.X, A.Y);
            PointF D = new PointF(A.X, C.Y);

           
            PointF[] points =
            {
                 new PointF((A.X + C.X)/2, A.Y),

                 new PointF(2 * (D.X + C.X) / 3, D.Y),

                 new PointF(A.X, 2 * (A.Y + D.Y) / 3),
                 new PointF(B.X, 2 * (B.Y + C.Y) / 3),
                 new PointF((D.X + C.X) / 3, D.Y)




            };

            return points;
        }


        private void triangleToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            activeTool = Tools.Triangle;
        }

        private void rightTriangleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            activeTool = Tools.Righttriangle;
        }

        private void starToolStripMenuItem_Click(object sender, EventArgs e)
        {
            activeTool = Tools.Star;
        }

        private void eraserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            activeTool = Tools.Eraser;
            pen1.Width = 3;
            pen1.StartCap = LineCap.Round;
            pen1.EndCap = LineCap.Round;
            
        }

        private void penToolStripMenuItem_Click(object sender, EventArgs e)
        {
            activeTool = Tools.Pen;
            pen.Color = Color.Black;
        }

        

       



        /*private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image.Save(saveFileDialog1.FileName);
            }
        */
    }
    enum BmpCreationMode
    {
        AfterFill,
        FromFile,
        Init
    }
}