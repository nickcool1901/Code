using System;
using System.Windows.Forms;
using System.Drawing;

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private double Function1(double x, double a, double b, double c)
        {
            return a * x * x + b * x + c;
        }

        private double Function2(double x, double a, double b, double c)
        {
            return x * (a * x + b) / (x + c);
        }

        private double Function3(double x, double a, double b, double c)
        {
            return a * Math.Sin(b * x) + c;
        }

        private void buttonTabula_Click(object sender, EventArgs e)
        {
            listBoxTabula.Items.Clear();

            try
            {
                if (!double.TryParse(textBoxA.Text, out double a))
                {
                    MessageBox.Show("Lūdzu, ievadiet derīgu vērtību 'a'.", "Kļūda", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (!double.TryParse(textBoxB.Text, out double b))
                {
                    MessageBox.Show("Lūdzu, ievadiet derīgu vērtību 'b'.", "Kļūda", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (!double.TryParse(textBoxC.Text, out double c))
                {
                    MessageBox.Show("Lūdzu, ievadiet derīgu vērtību 'c'.", "Kļūda", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (!double.TryParse(textBoxXBegin.Text, out double xBegin))
                {
                    MessageBox.Show("Lūdzu, ievadiet derīgu vērtību 'X Begin'.", "Kļūda", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (!double.TryParse(textBoxXEnd.Text, out double xEnd))
                {
                    MessageBox.Show("Lūdzu, ievadiet derīgu vērtību 'X End'.", "Kļūda", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (!double.TryParse(textBoxStep.Text, out double step) || step <= 0)
                {
                    MessageBox.Show("Lūdzu, ievadiet derīgu vērtību 'Step' (pozitīvs skaitlis).", "Kļūda", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                Func<double, double, double, double, double> selectedFunction = null;

                if (radioButton1.Checked)
                    selectedFunction = Function1;
                else if (radioButton2.Checked)
                    selectedFunction = Function2;
                else if (radioButton3.Checked)
                    selectedFunction = Function3;

                if (selectedFunction != null)
                {
                    for (double x = xBegin; x <= xEnd; x += step)
                    {
                        double y = selectedFunction(x, a, b, c);
                        listBoxTabula.Items.Add($"{x:F2}  ->  {y:F2}");
                    }
                }
                else
                {
                    MessageBox.Show("Lūdzu, izvēlieties funkciju.", "Kļūda", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Kļūda ievades datos: " + ex.Message, "Kļūda", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonGrafiks_Click(object sender, EventArgs e)
        {
            Func<double, double, double, double, double> selectedFunction = null;

            if (radioButton1.Checked)
                selectedFunction = Function1;
            else if (radioButton2.Checked)
                selectedFunction = Function2;
            else if (radioButton3.Checked)
                selectedFunction = Function3;

            if (selectedFunction != null)
            {
                if (double.TryParse(textBoxA.Text, out double a) &&
                    double.TryParse(textBoxB.Text, out double b) &&
                    double.TryParse(textBoxC.Text, out double c) &&
                    double.TryParse(textBoxXBegin.Text, out double xBegin) &&
                    double.TryParse(textBoxXEnd.Text, out double xEnd) &&
                    double.TryParse(textBoxStep.Text, out double step))
                {
                    Form2 form2 = new Form2(a, b, c, xBegin, xEnd, step, selectedFunction);
                    form2.Show();
                }
                else
                {
                    MessageBox.Show("Lūdzu, ievadiet derīgas vērtības.", "Kļūda", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Lūdzu, izvēlieties funkciju.", "Kļūda", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
