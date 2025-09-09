using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyPaint
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            bm = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            g = Graphics.FromImage(bm);
            g.Clear(Color.White);
            pictureBox1.Image = bm;
            
        }

        Bitmap bm;
        Graphics g;
        bool paint = false;
        Point px, py;
        Pen p = new Pen(Color.Black, 2);

        Pen erase = new Pen(Color.White, 10);
        enum Tool { None, Pen, Eraser, Ellipse, Rectangle, Line }
        Tool currentTool = Tool.None;

        int x, y, sX, sY, cX, cY;

        ColorDialog cd = new ColorDialog();
        Color new_color;
        private void Pen_Click(object sender, EventArgs e)
        {
            currentTool = Tool.Pen;

        }

        private void Eraser_Click(object sender, EventArgs e)
        {
            currentTool = Tool.Eraser;
        }

        private void Rectangle_Click(object sender, EventArgs e)
        {
            currentTool = Tool.Rectangle;
        }

        private void Ellipse_Click(object sender, EventArgs e)
        {
            currentTool = Tool.Ellipse;
        }
        private void Line_Click(object sender, EventArgs e)
        {
            currentTool = Tool.Line;
        }

        private void Colours_Click(object sender, EventArgs e)
        {
            cd.ShowDialog();
            new_color = cd.Color;
            pic_color.BackColor = cd.Color;
            p.Color = cd.Color;
            System.Media.SystemSounds.Exclamation.Play();
        }
        private void New_Click(object sender, EventArgs e)
        {
            g.Clear(Color.White);
            pictureBox1.Image = bm;
            currentTool = Tool.None;
            System.Media.SystemSounds.Beep.Play();
        }
        private void Save_Click(object sender, EventArgs e)
        {
            System.Media.SystemSounds.Asterisk.Play();
            Bitmap bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            Rectangle rect = new Rectangle(0, 0, pictureBox1.Width, pictureBox1.Height);
            pictureBox1.DrawToBitmap(bmp, rect);

            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Filter = "jpeg Image|.jpg|bitmap Image|.bmp|gif Image|.gif|png Image|.png";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                if (dialog.FileName != "")
                {
                    switch (dialog.FilterIndex)
                    {
                        case 1:
                            bmp.Save(dialog.FileName,
                              System.Drawing.Imaging.ImageFormat.Jpeg);
                            break;

                        case 2:
                            bmp.Save(dialog.FileName,
                              System.Drawing.Imaging.ImageFormat.Bmp);
                            break;

                        case 3:
                            bmp.Save(dialog.FileName,
                              System.Drawing.Imaging.ImageFormat.Gif);
                            break;

                        case 4:
                            bmp.Save(dialog.FileName,
                                    System.Drawing.Imaging.ImageFormat.Png);
                            break;
                    }
                }
            }
        }

        private void Open_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "Image Files(.jpg; *.jpeg; *.gif; *.bmp; *.png)|.jpg; *.jpeg; *.gif; *.bmp; *png";
            if (open.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = new Bitmap(open.FileName);

            }
        }

        private void Print_Click(object sender, EventArgs e)
        {
            printDocument1.DefaultPageSettings.Margins.Left = 100;
            printDocument1.DefaultPageSettings.Margins.Top = 50;
            printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(myPrinting);
            if (printDialog1.ShowDialog() == DialogResult.OK)
                printDocument1.Print();
        }

        private void myPrinting(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {

            Graphics g = e.Graphics;
            g.DrawString("Drawing Export", Font, new SolidBrush(Color.Black), 100, 100);

            g.DrawEllipse(new Pen(Color.Black), 100, 100, 200, 200);

            g.DrawString(pictureBox1.Text, Font, new SolidBrush(Color.Black), e.MarginBounds.Left, e.MarginBounds.Top);
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            if (paint)
            {
                Graphics g = e.Graphics;

                int left = Math.Min(cX, x);
                int top = Math.Min(cY, y);
                int width = Math.Abs(x - cX);
                int height = Math.Abs(y - cY);

                if (currentTool == Tool.Ellipse)
                    g.DrawEllipse(p, left, top, width, height);

                if (currentTool == Tool.Rectangle)
                    g.DrawRectangle(p, left, top, width, height);

                if (currentTool == Tool.Line)
                    g.DrawLine(p, cX, cY, x, y);
            }
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            paint = true;
            py = e.Location;
            cX = e.X;
            cY = e.Y;

        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (paint)
            {
                px = e.Location;

                switch (currentTool)
                {
                    case Tool.Pen:
                        g.DrawLine(p, px, py);
                        py = px;
                        break;

                    case Tool.Eraser:
                        g.DrawLine(erase, px, py);
                        py = px;
                        break;
                }
            }

            pictureBox1.Refresh();

            x = e.X;
            y = e.Y;
            sX = e.X - cX;
            sY = e.Y - cY;
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            paint = false;
            sX = x - cX;
            sY = y - cY;

            int left = Math.Min(cX, x);
            int top = Math.Min(cY, y);
            int width = Math.Abs(x - cX);
            int height = Math.Abs(y - cY);

            switch (currentTool)
            {
                case Tool.Ellipse:
                    g.DrawEllipse(p, left, top, width, height);
                    break;

                case Tool.Rectangle:
                    g.DrawRectangle(p, left, top, width, height);
                    break;

                case Tool.Line:
                    g.DrawLine(p, cX, cY, x, y);
                    break;
            }
        }

    }
}