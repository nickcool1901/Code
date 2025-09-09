using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;
using System.Drawing;

namespace BookAuthor
{
    public partial class Form1 : Form
    {
        private DbContext db = new DbContext();
        private SqlDataAdapter booksAdapter;
        private SqlDataAdapter authorsAdapter;
        private DataTable booksTable;
        private DataTable authorsTable;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            AtjaunotSkaitītājus();
            AtjaunotTabulas();
            txtMeklet.Text = "Meklēt...";
            txtMeklet.ForeColor = Color.Gray;
            txtMeklet.Enter += txtMeklet_Enter;
            txtMeklet.Leave += txtMeklet_Leave;

            booksAdapter = db.GetBooksAdapter(out booksTable);
            authorsAdapter = db.GetAuthorsAdapter(out authorsTable);

            dgvGramatas.DataSource = booksTable;
            dgvAutori.DataSource = authorsTable;
        }

        private void AtjaunotSkaitītājus()
        {
            lblAutoruSkaits.Text = "Autoru: " + db.Count("Authors");
            lblGrāmatuSkaits.Text = "Grāmatu: " + db.Count("Books");
        }

        private void AtjaunotTabulas()
        {
            booksAdapter = db.GetBooksAdapter(out booksTable);
            authorsAdapter = db.GetAuthorsAdapter(out authorsTable);

            dgvGramatas.DataSource = booksTable;
            dgvAutori.DataSource = authorsTable;

            if (dgvGramatas.Columns["AuthorID"] != null)
            {
                int colIndex = dgvGramatas.Columns["AuthorID"].Index;
                dgvGramatas.Columns.Remove("AuthorID");

                var comboCol = new DataGridViewComboBoxColumn
                {
                    DataPropertyName = "AuthorID",
                    HeaderText = "Autors",
                    DataSource = authorsTable,
                    DisplayMember = "Name",
                    ValueMember = "AuthorID",
                    Name = "AuthorID"
                };

                dgvGramatas.Columns.Insert(colIndex, comboCol);
            }
        }


        private void txtMeklet_Enter(object sender, EventArgs e)
        {
            if (txtMeklet.Text == "Meklēt pēc grāmatas...")
            {
                txtMeklet.Text = "";
                txtMeklet.ForeColor = Color.Black;
            }
        }

        private void txtMeklet_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMeklet.Text))
            {
                txtMeklet.Text = "Meklēt pēc grāmatas...";
                txtMeklet.ForeColor = Color.Gray;
            }
        }

        private void btnMeklet_Click(object sender, EventArgs e)
        {
            lstRezultati.Items.Clear();
            List<string> rezultati = db.SearchBooks(txtMeklet.Text);
            foreach (string r in rezultati)
                lstRezultati.Items.Add(r);
        }

        private void btnTestaDati_Click(object sender, EventArgs e)
        {
            db.InsertTestData();
            AtjaunotSkaitītājus();
            AtjaunotTabulas();
        }
        private void btnSaglabat_Click(object sender, EventArgs e)
        {
            try
            {
                authorsAdapter.Update(authorsTable);
                booksAdapter.Update(booksTable);
                MessageBox.Show("Izmaiņas saglabātas datubāzē!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Kļūda saglabājot: " + ex.Message);
            }
            AtjaunotSkaitītājus();
            AtjaunotTabulas();
        }

        private void btnDzestVisu_Click(object sender, EventArgs e)
        {
            db.DeleteAll();
            MessageBox.Show("Visi ieraksti ir dzēsti!");
            lstRezultati.Items.Clear();
            AtjaunotSkaitītājus();
            AtjaunotTabulas();
        }
    }
}
