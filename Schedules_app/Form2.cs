using System;
using System.Windows.Forms;
using System.Drawing;
using System.Collections.Generic;

namespace WindowsFormsApp2
{
    public partial class Form2 : Form
    {
        private double a, b, c, xBegin, xEnd, step;
        private Func<double, double, double, double, double> selectedFunction;
        private float scaleX, scaleY;

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private int margin = 50;

        public Form2(double a, double b, double c, double xBegin, double xEnd, double step, Func<double, double, double, double, double> selectedFunction)
        {
            Console.WriteLine("Form2_Paint called");
            InitializeComponent();
            this.a = a;
            this.b = b;
            this.c = c;
            this.xBegin = xBegin;
            this.xEnd = xEnd;
            this.step = step;
            this.selectedFunction = selectedFunction;
        }

        //private void InitializeComponent()
        //{
        //    this.SuspendLayout();
        //    // 
        //    // Form2
        //    // 
        //    this.ClientSize = new System.Drawing.Size(700, 600);
        //    this.Name = "Form2";
        //    this.Text = "Grafiks";
        //    this.Load += new System.EventHandler(this.Form2_Load);
        //    this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form2_Paint);
        //    this.ResumeLayout(false);

        //}

        private void Form2_Paint(object sender, PaintEventArgs e)
        {
            try
            {
                Graphics g = e.Graphics;
                g.Clear(Color.White);

                Pen axisPen = new Pen(Color.Black, 2);
                Pen graphPen = new Pen(Color.Blue, 2);

                int width = this.ClientSize.Width - 2 * margin;
                int height = this.ClientSize.Height - 2 * margin;
                float zeroX = margin + width / 2;
                float zeroY = margin + height / 2;

                double minY, maxY;
                FindYRange(out minY, out maxY);

                if (Math.Abs(maxY - minY) < 1e-10)
                {
                    maxY += 1;
                    minY -= 1;
                }

                scaleX = width / (float)(xEnd - xBegin);
                scaleY = height / (float)(maxY - minY);

                g.DrawLine(axisPen, margin, zeroY, margin + width, zeroY);
                g.DrawLine(axisPen, zeroX, margin, zeroX, margin + height);

                List<PointF> points = new List<PointF>();
                for (double x = xBegin; x <= xEnd; x += step)
                {
                    double y = selectedFunction(x, a, b, c);

                    if (double.IsNaN(y) || double.IsInfinity(y))
                        continue;

                    float screenX = margin + (float)((x - xBegin) * scaleX);
                    float screenY = margin + height - (float)((y - minY) * scaleY);

                    if (screenY < margin || screenY > this.ClientSize.Height - margin)
                        continue;

                    points.Add(new PointF(screenX, screenY));
                }

                if (points.Count > 1)
                {
                    for (int i = 0; i < points.Count - 1; i++)
                    {
                        g.DrawLine(graphPen, points[i], points[i + 1]);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка в Paint: " + ex.Message);
            }
        }


        private void FindYRange(out double minY, out double maxY)
        {
            minY = double.MaxValue;
            maxY = double.MinValue;

            for (double x = xBegin; x <= xEnd; x += step)
            {
                double y = selectedFunction(x, a, b, c);
                if (double.IsNaN(y) || double.IsInfinity(y))
                    continue;

                if (y < minY) minY = y;
                if (y > maxY) maxY = y;
            }

            if (minY == maxY)
            {
                minY -= 1;
                maxY += 1;
            }
        }
    }
}
