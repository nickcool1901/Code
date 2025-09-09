namespace MyPaint
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.panel1 = new System.Windows.Forms.Panel();
            this.Print = new System.Windows.Forms.Button();
            this.Open = new System.Windows.Forms.Button();
            this.New = new System.Windows.Forms.Button();
            this.Save = new System.Windows.Forms.Button();
            this.Line = new System.Windows.Forms.Button();
            this.Rectangle = new System.Windows.Forms.Button();
            this.Ellipse = new System.Windows.Forms.Button();
            this.Eraser = new System.Windows.Forms.Button();
            this.Pen = new System.Windows.Forms.Button();
            this.Colours = new System.Windows.Forms.Button();
            this.pic_color = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.printDialog1 = new System.Windows.Forms.PrintDialog();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightSeaGreen;
            this.panel1.Controls.Add(this.Print);
            this.panel1.Controls.Add(this.Open);
            this.panel1.Controls.Add(this.New);
            this.panel1.Controls.Add(this.Save);
            this.panel1.Controls.Add(this.Line);
            this.panel1.Controls.Add(this.Rectangle);
            this.panel1.Controls.Add(this.Ellipse);
            this.panel1.Controls.Add(this.Eraser);
            this.panel1.Controls.Add(this.Pen);
            this.panel1.Controls.Add(this.Colours);
            this.panel1.Controls.Add(this.pic_color);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(891, 83);
            this.panel1.TabIndex = 0;
            // 
            // Print
            // 
            this.Print.BackColor = System.Drawing.Color.Red;
            this.Print.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Print.Location = new System.Drawing.Point(807, 26);
            this.Print.Name = "Print";
            this.Print.Size = new System.Drawing.Size(72, 42);
            this.Print.TabIndex = 10;
            this.Print.Text = "PRINT";
            this.Print.UseVisualStyleBackColor = false;
            this.Print.Click += new System.EventHandler(this.Print_Click);
            // 
            // Open
            // 
            this.Open.BackColor = System.Drawing.Color.SkyBlue;
            this.Open.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Open.Location = new System.Drawing.Point(656, 26);
            this.Open.Name = "Open";
            this.Open.Size = new System.Drawing.Size(70, 42);
            this.Open.TabIndex = 8;
            this.Open.Text = "OPEN";
            this.Open.UseVisualStyleBackColor = false;
            this.Open.Click += new System.EventHandler(this.Open_Click);
            // 
            // New
            // 
            this.New.BackColor = System.Drawing.Color.White;
            this.New.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.New.ForeColor = System.Drawing.Color.Black;
            this.New.Location = new System.Drawing.Point(578, 3);
            this.New.Name = "New";
            this.New.Size = new System.Drawing.Size(72, 42);
            this.New.TabIndex = 7;
            this.New.Text = "NEW";
            this.New.UseVisualStyleBackColor = false;
            this.New.Click += new System.EventHandler(this.New_Click);
            // 
            // Save
            // 
            this.Save.BackColor = System.Drawing.Color.Lime;
            this.Save.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Save.Location = new System.Drawing.Point(732, 3);
            this.Save.Name = "Save";
            this.Save.Size = new System.Drawing.Size(69, 42);
            this.Save.TabIndex = 9;
            this.Save.Text = "SAVE";
            this.Save.UseVisualStyleBackColor = false;
            this.Save.Click += new System.EventHandler(this.Save_Click);
            // 
            // Line
            // 
            this.Line.BackgroundImage = global::MyPaint.Properties.Resources.line;
            this.Line.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Line.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.Line.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.Line.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Line.ForeColor = System.Drawing.Color.LavenderBlush;
            this.Line.Location = new System.Drawing.Point(338, 12);
            this.Line.Name = "Line";
            this.Line.Size = new System.Drawing.Size(62, 56);
            this.Line.TabIndex = 6;
            this.Line.UseVisualStyleBackColor = true;
            this.Line.Click += new System.EventHandler(this.Line_Click);
            // 
            // Rectangle
            // 
            this.Rectangle.BackgroundImage = global::MyPaint.Properties.Resources.rectangle;
            this.Rectangle.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Rectangle.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.Rectangle.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.Rectangle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Rectangle.ForeColor = System.Drawing.Color.LavenderBlush;
            this.Rectangle.Location = new System.Drawing.Point(406, 12);
            this.Rectangle.Name = "Rectangle";
            this.Rectangle.Size = new System.Drawing.Size(64, 56);
            this.Rectangle.TabIndex = 5;
            this.Rectangle.UseVisualStyleBackColor = true;
            this.Rectangle.Click += new System.EventHandler(this.Rectangle_Click);
            // 
            // Ellipse
            // 
            this.Ellipse.BackgroundImage = global::MyPaint.Properties.Resources.ellipse;
            this.Ellipse.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Ellipse.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.Ellipse.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.Ellipse.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Ellipse.ForeColor = System.Drawing.Color.LavenderBlush;
            this.Ellipse.Location = new System.Drawing.Point(476, 12);
            this.Ellipse.Name = "Ellipse";
            this.Ellipse.Size = new System.Drawing.Size(64, 56);
            this.Ellipse.TabIndex = 4;
            this.Ellipse.UseVisualStyleBackColor = true;
            this.Ellipse.Click += new System.EventHandler(this.Ellipse_Click);
            // 
            // Eraser
            // 
            this.Eraser.BackgroundImage = global::MyPaint.Properties.Resources.eraser;
            this.Eraser.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Eraser.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.Eraser.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.Eraser.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Eraser.ForeColor = System.Drawing.Color.LavenderBlush;
            this.Eraser.Location = new System.Drawing.Point(137, 12);
            this.Eraser.Name = "Eraser";
            this.Eraser.Size = new System.Drawing.Size(64, 54);
            this.Eraser.TabIndex = 3;
            this.Eraser.UseVisualStyleBackColor = true;
            this.Eraser.Click += new System.EventHandler(this.Eraser_Click);
            // 
            // Pen
            // 
            this.Pen.BackgroundImage = global::MyPaint.Properties.Resources.pen;
            this.Pen.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Pen.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.Pen.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.Pen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Pen.ForeColor = System.Drawing.Color.LavenderBlush;
            this.Pen.Location = new System.Drawing.Point(268, 12);
            this.Pen.Name = "Pen";
            this.Pen.Size = new System.Drawing.Size(64, 54);
            this.Pen.TabIndex = 2;
            this.Pen.UseVisualStyleBackColor = true;
            this.Pen.Click += new System.EventHandler(this.Pen_Click);
            // 
            // Colours
            // 
            this.Colours.BackgroundImage = global::MyPaint.Properties.Resources.colours;
            this.Colours.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Colours.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.Colours.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.Colours.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Colours.ForeColor = System.Drawing.Color.LavenderBlush;
            this.Colours.Location = new System.Drawing.Point(12, 12);
            this.Colours.Name = "Colours";
            this.Colours.Size = new System.Drawing.Size(64, 54);
            this.Colours.TabIndex = 1;
            this.Colours.UseVisualStyleBackColor = true;
            this.Colours.Click += new System.EventHandler(this.Colours_Click);
            // 
            // pic_color
            // 
            this.pic_color.BackColor = System.Drawing.Color.White;
            this.pic_color.Location = new System.Drawing.Point(82, 12);
            this.pic_color.Name = "pic_color";
            this.pic_color.Size = new System.Drawing.Size(49, 42);
            this.pic_color.TabIndex = 0;
            this.pic_color.UseVisualStyleBackColor = false;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.LightSeaGreen;
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 595);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(891, 10);
            this.panel2.TabIndex = 1;
            // 
            // printDialog1
            // 
            this.printDialog1.UseEXDialog = true;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.White;
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Location = new System.Drawing.Point(0, 83);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(891, 512);
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox1_Paint);
            this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDown);
            this.pictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseMove);
            this.pictureBox1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseUp);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(891, 605);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MyPaint";
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button Eraser;
        private System.Windows.Forms.Button Pen;
        private System.Windows.Forms.Button Colours;
        private System.Windows.Forms.Button pic_color;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button Print;
        private System.Windows.Forms.Button Save;
        private System.Windows.Forms.Button Open;
        private System.Windows.Forms.Button New;
        private System.Windows.Forms.Button Line;
        private System.Windows.Forms.Button Rectangle;
        private System.Windows.Forms.Button Ellipse;
        private System.Windows.Forms.PrintDialog printDialog1;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}

