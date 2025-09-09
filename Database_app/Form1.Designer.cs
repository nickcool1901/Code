namespace BookAuthor
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtMeklet = new System.Windows.Forms.TextBox();
            this.btnMeklet = new System.Windows.Forms.Button();
            this.lstRezultati = new System.Windows.Forms.ListBox();
            this.dgvAutori = new System.Windows.Forms.DataGridView();
            this.dgvGramatas = new System.Windows.Forms.DataGridView();
            this.lblAutoruSkaits = new System.Windows.Forms.Label();
            this.lblGrāmatuSkaits = new System.Windows.Forms.Label();
            this.btnTestaDati = new System.Windows.Forms.Button();
            this.btnDzestVisu = new System.Windows.Forms.Button();
            this.btnSaglabat = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAutori)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGramatas)).BeginInit();
            this.SuspendLayout();
            // 
            // txtMeklet
            // 
            this.txtMeklet.Location = new System.Drawing.Point(10, 10);
            this.txtMeklet.Name = "txtMeklet";
            this.txtMeklet.Size = new System.Drawing.Size(172, 20);
            this.txtMeklet.TabIndex = 0;
            // 
            // btnMeklet
            // 
            this.btnMeklet.Location = new System.Drawing.Point(189, 10);
            this.btnMeklet.Name = "btnMeklet";
            this.btnMeklet.Size = new System.Drawing.Size(86, 20);
            this.btnMeklet.TabIndex = 1;
            this.btnMeklet.Text = "🔍 Meklēt";
            this.btnMeklet.UseVisualStyleBackColor = true;
            this.btnMeklet.Click += new System.EventHandler(this.btnMeklet_Click);
            // 
            // lstRezultati
            // 
            this.lstRezultati.FormattingEnabled = true;
            this.lstRezultati.Location = new System.Drawing.Point(10, 36);
            this.lstRezultati.Name = "lstRezultati";
            this.lstRezultati.Size = new System.Drawing.Size(265, 82);
            this.lstRezultati.TabIndex = 2;
            // 
            // dgvAutori
            // 
            this.dgvAutori.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAutori.Location = new System.Drawing.Point(10, 122);
            this.dgvAutori.Name = "dgvAutori";
            this.dgvAutori.RowTemplate.Height = 25;
            this.dgvAutori.Size = new System.Drawing.Size(380, 130);
            this.dgvAutori.TabIndex = 3;
            // 
            // dgvGramatas
            // 
            this.dgvGramatas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvGramatas.Location = new System.Drawing.Point(10, 260);
            this.dgvGramatas.Name = "dgvGramatas";
            this.dgvGramatas.RowTemplate.Height = 25;
            this.dgvGramatas.Size = new System.Drawing.Size(470, 130);
            this.dgvGramatas.TabIndex = 4;
            // 
            // lblAutoruSkaits
            // 
            this.lblAutoruSkaits.AutoSize = true;
            this.lblAutoruSkaits.Location = new System.Drawing.Point(400, 122);
            this.lblAutoruSkaits.Name = "lblAutoruSkaits";
            this.lblAutoruSkaits.Size = new System.Drawing.Size(50, 13);
            this.lblAutoruSkaits.TabIndex = 5;
            this.lblAutoruSkaits.Text = "Autoru: 0";
            // 
            // lblGrāmatuSkaits
            // 
            this.lblGrāmatuSkaits.AutoSize = true;
            this.lblGrāmatuSkaits.Location = new System.Drawing.Point(490, 260);
            this.lblGrāmatuSkaits.Name = "lblGrāmatuSkaits";
            this.lblGrāmatuSkaits.Size = new System.Drawing.Size(59, 13);
            this.lblGrāmatuSkaits.TabIndex = 6;
            this.lblGrāmatuSkaits.Text = "Grāmatu: 0";
            // 
            // btnTestaDati
            // 
            this.btnTestaDati.BackColor = System.Drawing.Color.Yellow;
            this.btnTestaDati.Location = new System.Drawing.Point(454, 17);
            this.btnTestaDati.Name = "btnTestaDati";
            this.btnTestaDati.Size = new System.Drawing.Size(129, 20);
            this.btnTestaDati.TabIndex = 7;
            this.btnTestaDati.Text = "📥 Pievienot testa datus";
            this.btnTestaDati.UseVisualStyleBackColor = false;
            this.btnTestaDati.Click += new System.EventHandler(this.btnTestaDati_Click);
            // 
            // btnDzestVisu
            // 
            this.btnDzestVisu.BackColor = System.Drawing.Color.Red;
            this.btnDzestVisu.Location = new System.Drawing.Point(454, 42);
            this.btnDzestVisu.Name = "btnDzestVisu";
            this.btnDzestVisu.Size = new System.Drawing.Size(129, 20);
            this.btnDzestVisu.TabIndex = 8;
            this.btnDzestVisu.Text = "🗑️ Dzēst visu";
            this.btnDzestVisu.UseVisualStyleBackColor = false;
            this.btnDzestVisu.Click += new System.EventHandler(this.btnDzestVisu_Click);
            // 
            // btnSaglabat
            // 
            this.btnSaglabat.BackColor = System.Drawing.Color.Lime;
            this.btnSaglabat.Location = new System.Drawing.Point(454, 68);
            this.btnSaglabat.Name = "btnSaglabat";
            this.btnSaglabat.Size = new System.Drawing.Size(129, 20);
            this.btnSaglabat.TabIndex = 0;
            this.btnSaglabat.Text = "💾 Saglabāt";
            this.btnSaglabat.UseVisualStyleBackColor = false;
            this.btnSaglabat.Click += new System.EventHandler(this.btnSaglabat_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(295, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(153, 19);
            this.label1.TabIndex = 9;
            this.label1.Text = "Luksoforu nesajaucu!";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 407);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnSaglabat);
            this.Controls.Add(this.btnDzestVisu);
            this.Controls.Add(this.btnTestaDati);
            this.Controls.Add(this.lblGrāmatuSkaits);
            this.Controls.Add(this.lblAutoruSkaits);
            this.Controls.Add(this.dgvGramatas);
            this.Controls.Add(this.dgvAutori);
            this.Controls.Add(this.lstRezultati);
            this.Controls.Add(this.btnMeklet);
            this.Controls.Add(this.txtMeklet);
            this.Name = "Form1";
            this.Text = "📚 Bibliotēka";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAutori)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGramatas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtMeklet;
        private System.Windows.Forms.Button btnMeklet;
        private System.Windows.Forms.ListBox lstRezultati;
        private System.Windows.Forms.DataGridView dgvAutori;
        private System.Windows.Forms.DataGridView dgvGramatas;
        private System.Windows.Forms.Label lblAutoruSkaits;
        private System.Windows.Forms.Label lblGrāmatuSkaits;
        private System.Windows.Forms.Button btnTestaDati;
        private System.Windows.Forms.Button btnDzestVisu;
        private System.Windows.Forms.Button btnSaglabat;
        private System.Windows.Forms.Label label1;
    }
}

