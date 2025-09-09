using System;
using System.Windows.Forms;
using System.Drawing;

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        private Button buttonTabula;
        private Button buttonGrafiks;
        private ListBox listBoxTabula;
        private TextBox textBoxA, textBoxB, textBoxC, textBoxXBegin, textBoxXEnd, textBoxStep;
        private RadioButton radioButton1, radioButton2, radioButton3;
        private GroupBox groupBoxFunctions;
        private Label labelA, labelB, labelC, labelXBegin, labelXEnd, labelStep;


        private void InitializeComponent()
        {
            this.buttonTabula = new System.Windows.Forms.Button();
            this.buttonGrafiks = new System.Windows.Forms.Button();
            this.listBoxTabula = new System.Windows.Forms.ListBox();
            this.textBoxA = new System.Windows.Forms.TextBox();
            this.textBoxB = new System.Windows.Forms.TextBox();
            this.textBoxC = new System.Windows.Forms.TextBox();
            this.textBoxXBegin = new System.Windows.Forms.TextBox();
            this.textBoxXEnd = new System.Windows.Forms.TextBox();
            this.textBoxStep = new System.Windows.Forms.TextBox();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.groupBoxFunctions = new System.Windows.Forms.GroupBox();
            this.labelA = new System.Windows.Forms.Label();
            this.labelB = new System.Windows.Forms.Label();
            this.labelC = new System.Windows.Forms.Label();
            this.labelXBegin = new System.Windows.Forms.Label();
            this.labelXEnd = new System.Windows.Forms.Label();
            this.labelStep = new System.Windows.Forms.Label();
            this.groupBoxFunctions.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonTabula
            // 
            this.buttonTabula.Location = new System.Drawing.Point(20, 200);
            this.buttonTabula.Name = "buttonTabula";
            this.buttonTabula.Size = new System.Drawing.Size(75, 23);
            this.buttonTabula.TabIndex = 12;
            this.buttonTabula.Text = "Tabula";
            this.buttonTabula.Click += new System.EventHandler(this.buttonTabula_Click);
            // 
            // buttonGrafiks
            // 
            this.buttonGrafiks.Location = new System.Drawing.Point(120, 200);
            this.buttonGrafiks.Name = "buttonGrafiks";
            this.buttonGrafiks.Size = new System.Drawing.Size(75, 23);
            this.buttonGrafiks.TabIndex = 13;
            this.buttonGrafiks.Text = "Grafiks";
            this.buttonGrafiks.Click += new System.EventHandler(this.buttonGrafiks_Click);
            // 
            // listBoxTabula
            // 
            this.listBoxTabula.Location = new System.Drawing.Point(20, 240);
            this.listBoxTabula.Name = "listBoxTabula";
            this.listBoxTabula.Size = new System.Drawing.Size(250, 147);
            this.listBoxTabula.TabIndex = 14;
            // 
            // textBoxA
            // 
            this.textBoxA.Location = new System.Drawing.Point(80, 20);
            this.textBoxA.Name = "textBoxA";
            this.textBoxA.Size = new System.Drawing.Size(100, 20);
            this.textBoxA.TabIndex = 6;
            // 
            // textBoxB
            // 
            this.textBoxB.Location = new System.Drawing.Point(80, 50);
            this.textBoxB.Name = "textBoxB";
            this.textBoxB.Size = new System.Drawing.Size(100, 20);
            this.textBoxB.TabIndex = 7;
            // 
            // textBoxC
            // 
            this.textBoxC.Location = new System.Drawing.Point(80, 80);
            this.textBoxC.Name = "textBoxC";
            this.textBoxC.Size = new System.Drawing.Size(100, 20);
            this.textBoxC.TabIndex = 8;
            // 
            // textBoxXBegin
            // 
            this.textBoxXBegin.Location = new System.Drawing.Point(100, 110);
            this.textBoxXBegin.Name = "textBoxXBegin";
            this.textBoxXBegin.Size = new System.Drawing.Size(80, 20);
            this.textBoxXBegin.TabIndex = 9;
            // 
            // textBoxXEnd
            // 
            this.textBoxXEnd.Location = new System.Drawing.Point(100, 140);
            this.textBoxXEnd.Name = "textBoxXEnd";
            this.textBoxXEnd.Size = new System.Drawing.Size(80, 20);
            this.textBoxXEnd.TabIndex = 10;
            // 
            // textBoxStep
            // 
            this.textBoxStep.Location = new System.Drawing.Point(100, 170);
            this.textBoxStep.Name = "textBoxStep";
            this.textBoxStep.Size = new System.Drawing.Size(80, 20);
            this.textBoxStep.TabIndex = 11;
            // 
            // radioButton1
            // 
            this.radioButton1.Location = new System.Drawing.Point(10, 20);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(150, 24);
            this.radioButton1.TabIndex = 0;
            this.radioButton1.Text = "y = ax^2 + bx + c";
            // 
            // radioButton2
            // 
            this.radioButton2.Location = new System.Drawing.Point(10, 50);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(150, 24);
            this.radioButton2.TabIndex = 1;
            this.radioButton2.Text = "y = x(ax + b) / (x + c)";
            // 
            // radioButton3
            // 
            this.radioButton3.Location = new System.Drawing.Point(10, 80);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(150, 24);
            this.radioButton3.TabIndex = 2;
            this.radioButton3.Text = "y = a sin(bx) + c";
            // 
            // groupBoxFunctions
            // 
            this.groupBoxFunctions.Controls.Add(this.radioButton1);
            this.groupBoxFunctions.Controls.Add(this.radioButton2);
            this.groupBoxFunctions.Controls.Add(this.radioButton3);
            this.groupBoxFunctions.Location = new System.Drawing.Point(200, 20);
            this.groupBoxFunctions.Name = "groupBoxFunctions";
            this.groupBoxFunctions.Size = new System.Drawing.Size(200, 110);
            this.groupBoxFunctions.TabIndex = 15;
            this.groupBoxFunctions.TabStop = false;
            this.groupBoxFunctions.Text = "Funkcija";
            // 
            // labelA
            // 
            this.labelA.Location = new System.Drawing.Point(20, 20);
            this.labelA.Name = "labelA";
            this.labelA.Size = new System.Drawing.Size(20, 23);
            this.labelA.TabIndex = 0;
            this.labelA.Text = "a:";
            // 
            // labelB
            // 
            this.labelB.Location = new System.Drawing.Point(20, 50);
            this.labelB.Name = "labelB";
            this.labelB.Size = new System.Drawing.Size(20, 23);
            this.labelB.TabIndex = 1;
            this.labelB.Text = "b:";
            // 
            // labelC
            // 
            this.labelC.Location = new System.Drawing.Point(20, 80);
            this.labelC.Name = "labelC";
            this.labelC.Size = new System.Drawing.Size(20, 23);
            this.labelC.TabIndex = 2;
            this.labelC.Text = "c:";
            // 
            // labelXBegin
            // 
            this.labelXBegin.Location = new System.Drawing.Point(20, 110);
            this.labelXBegin.Name = "labelXBegin";
            this.labelXBegin.Size = new System.Drawing.Size(50, 23);
            this.labelXBegin.TabIndex = 3;
            this.labelXBegin.Text = "X Begin:";
            // 
            // labelXEnd
            // 
            this.labelXEnd.Location = new System.Drawing.Point(20, 140);
            this.labelXEnd.Name = "labelXEnd";
            this.labelXEnd.Size = new System.Drawing.Size(50, 23);
            this.labelXEnd.TabIndex = 4;
            this.labelXEnd.Text = "X End:";
            // 
            // labelStep
            // 
            this.labelStep.Location = new System.Drawing.Point(20, 170);
            this.labelStep.Name = "labelStep";
            this.labelStep.Size = new System.Drawing.Size(50, 23);
            this.labelStep.TabIndex = 5;
            this.labelStep.Text = "Step:";
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(450, 420);
            this.Controls.Add(this.labelA);
            this.Controls.Add(this.labelB);
            this.Controls.Add(this.labelC);
            this.Controls.Add(this.labelXBegin);
            this.Controls.Add(this.labelXEnd);
            this.Controls.Add(this.labelStep);
            this.Controls.Add(this.textBoxA);
            this.Controls.Add(this.textBoxB);
            this.Controls.Add(this.textBoxC);
            this.Controls.Add(this.textBoxXBegin);
            this.Controls.Add(this.textBoxXEnd);
            this.Controls.Add(this.textBoxStep);
            this.Controls.Add(this.buttonTabula);
            this.Controls.Add(this.buttonGrafiks);
            this.Controls.Add(this.listBoxTabula);
            this.Controls.Add(this.groupBoxFunctions);
            this.Name = "Form1";
            this.Text = "MD2";
            this.groupBoxFunctions.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}
