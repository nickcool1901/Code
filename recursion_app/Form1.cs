using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        private int recursionDepth = 0;
        private string lastButtonClicked = "";

        public Form1()
        {
            InitializeComponent();
            btnDrawA1.Click += BtnDrawA1_Click;
            btnDrawB1.Click += BtnDrawB1_Click;
            drawPanel1.Paint += DrawPanel1_Paint;
        }

        private void BtnDrawA1_Click(object sender, EventArgs e)
        {
            if (int.TryParse(txtDepth1.Text, out recursionDepth) && recursionDepth > 0)
            {
                lastButtonClicked = "A";
                drawPanel1.Invalidate();
            }
            else
            {
                MessageBox.Show("Lūdzu, ievadiet derīgu rekursijas dziļumu!");
            }
        }

        private void BtnDrawB1_Click(object sender, EventArgs e)
        {
            if (int.TryParse(txtDepth1.Text, out recursionDepth) && recursionDepth > 0)
            {
                lastButtonClicked = "B";
                drawPanel1.Invalidate();
            }
            else
            {
                MessageBox.Show("Lūdzu, ievadiet derīgu rekursijas dziļumu!");
            }
        }

        private void DrawPanel1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.Clear(Color.White);

            if (lastButtonClicked == "A")
            {
                DrawA(g, drawPanel1.Width / 2, drawPanel1.Height / 2, recursionDepth, drawPanel1.Width / 4);
            }
            else if (lastButtonClicked == "B")
            {
                DrawB(g, drawPanel1.Width / 2, drawPanel1.Height / 2, recursionDepth, drawPanel1.Width / 3, 0);
            }
        }

        private void DrawA(Graphics g, int x, int y, int depth, int size)
        {
            if (depth <= 0) return;

            g.DrawEllipse(Pens.Black, x - size / 2, y - size / 2, size, size);

            int newSize = size / 2;
            DrawA(g, x - newSize, y, depth - 1, newSize);
            DrawA(g, x + newSize, y, depth - 1, newSize);
            DrawA(g, x, y - newSize, depth - 1, newSize);
            DrawA(g, x, y + newSize, depth - 1, newSize);
        }

        private void DrawB(Graphics g, int x, int y, int depth, int size, float rotation)
        {
            if (depth <= 0) return;

            GraphicsState state = g.Save();

            Matrix transform = new Matrix();
            transform.RotateAt(rotation, new PointF(x, y));
            g.Transform = transform;

            g.DrawRectangle(Pens.Black, x - size / 2, y - size / 2, size, size);

            g.Restore(state);

            int newSize = size * 7 / 10;
            DrawB(g, x, y, depth - 1, newSize, rotation + 45);
        }
    }
}
