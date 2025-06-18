namespace DriveNow
{
    partial class ViewCar
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
            this.components = new System.ComponentModel.Container();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.Search = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.dataGridViewMobil = new System.Windows.Forms.DataGridView();
            this.mobilBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.driveNowDataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.txtPlatNomor = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtMerk = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtWarna = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtFotoURL = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbTransmisi = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.numericUpDown_Kapasitas = new System.Windows.Forms.NumericUpDown();
            this.cmbBBM = new System.Windows.Forms.ComboBox();
            this.cmbKategori = new System.Windows.Forms.ComboBox();
            this.btnImport = new System.Windows.Forms.Button();
            this.pictureBoxMobil = new System.Windows.Forms.PictureBox();
            this.label11 = new System.Windows.Forms.Label();
            this.cmb_status = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtHarga = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMobil)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mobilBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.driveNowDataSetBindingSource)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_Kapasitas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxMobil)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(193)))), ((int)(((byte)(18)))), ((int)(((byte)(31)))));
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(-25, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(991, 78);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 25.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(404, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(182, 53);
            this.label1.TabIndex = 1;
            this.label1.Text = "View Car";
            // 
            // Search
            // 
            this.Search.AutoSize = true;
            this.Search.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Search.ForeColor = System.Drawing.Color.Black;
            this.Search.Location = new System.Drawing.Point(341, 95);
            this.Search.Name = "Search";
            this.Search.Size = new System.Drawing.Size(56, 21);
            this.Search.TabIndex = 1;
            this.Search.Text = "Search";
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(417, 95);
            this.txtSearch.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(145, 22);
            this.txtSearch.TabIndex = 3;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged_1);
            // 
            // dataGridViewMobil
            // 
            this.dataGridViewMobil.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewMobil.Location = new System.Drawing.Point(12, 138);
            this.dataGridViewMobil.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataGridViewMobil.Name = "dataGridViewMobil";
            this.dataGridViewMobil.RowHeadersWidth = 51;
            this.dataGridViewMobil.RowTemplate.Height = 24;
            this.dataGridViewMobil.Size = new System.Drawing.Size(944, 273);
            this.dataGridViewMobil.TabIndex = 4;
            this.dataGridViewMobil.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewMobil_CellClick);
            // 
            // btnUpdate
            // 
            this.btnUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnUpdate.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdate.Location = new System.Drawing.Point(670, 268);
            this.btnUpdate.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(181, 25);
            this.btnUpdate.TabIndex = 1;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnDelete.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.Location = new System.Drawing.Point(670, 309);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(181, 25);
            this.btnDelete.TabIndex = 3;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCancel.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(670, 349);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(181, 25);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "Clear";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // txtPlatNomor
            // 
            this.txtPlatNomor.Location = new System.Drawing.Point(283, 27);
            this.txtPlatNomor.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtPlatNomor.Name = "txtPlatNomor";
            this.txtPlatNomor.Size = new System.Drawing.Size(331, 22);
            this.txtPlatNomor.TabIndex = 19;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.Black;
            this.label10.Location = new System.Drawing.Point(63, 31);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(90, 21);
            this.label10.TabIndex = 20;
            this.label10.Text = "Plat Nomor";
            // 
            // txtMerk
            // 
            this.txtMerk.Location = new System.Drawing.Point(283, 66);
            this.txtMerk.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtMerk.Name = "txtMerk";
            this.txtMerk.Size = new System.Drawing.Size(331, 22);
            this.txtMerk.TabIndex = 21;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.Black;
            this.label9.Location = new System.Drawing.Point(63, 69);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(93, 21);
            this.label9.TabIndex = 22;
            this.label9.Text = "Merk Mobil";
            // 
            // txtWarna
            // 
            this.txtWarna.Location = new System.Drawing.Point(283, 104);
            this.txtWarna.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtWarna.Name = "txtWarna";
            this.txtWarna.Size = new System.Drawing.Size(331, 22);
            this.txtWarna.TabIndex = 23;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(63, 107);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 21);
            this.label4.TabIndex = 24;
            this.label4.Text = "Warna";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(63, 146);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(69, 21);
            this.label5.TabIndex = 25;
            this.label5.Text = "Kategori";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(63, 187);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(84, 21);
            this.label6.TabIndex = 26;
            this.label6.Text = "Jenis BBM";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(63, 268);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(76, 21);
            this.label7.TabIndex = 28;
            this.label7.Text = "Kapasitas";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Silver;
            this.panel2.Controls.Add(this.txtFotoURL);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.cmbTransmisi);
            this.panel2.Controls.Add(this.label12);
            this.panel2.Controls.Add(this.numericUpDown_Kapasitas);
            this.panel2.Controls.Add(this.cmbBBM);
            this.panel2.Controls.Add(this.cmbKategori);
            this.panel2.Controls.Add(this.btnImport);
            this.panel2.Controls.Add(this.pictureBoxMobil);
            this.panel2.Controls.Add(this.label11);
            this.panel2.Controls.Add(this.cmb_status);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.txtHarga);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.txtWarna);
            this.panel2.Controls.Add(this.label9);
            this.panel2.Controls.Add(this.txtMerk);
            this.panel2.Controls.Add(this.label10);
            this.panel2.Controls.Add(this.txtPlatNomor);
            this.panel2.Controls.Add(this.btnCancel);
            this.panel2.Controls.Add(this.btnDelete);
            this.panel2.Controls.Add(this.btnUpdate);
            this.panel2.Location = new System.Drawing.Point(13, 436);
            this.panel2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(943, 439);
            this.panel2.TabIndex = 5;
            // 
            // txtFotoURL
            // 
            this.txtFotoURL.Location = new System.Drawing.Point(282, 390);
            this.txtFotoURL.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtFotoURL.Name = "txtFotoURL";
            this.txtFotoURL.Size = new System.Drawing.Size(331, 22);
            this.txtFotoURL.TabIndex = 54;
            this.txtFotoURL.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(60, 390);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(114, 21);
            this.label2.TabIndex = 52;
            this.label2.Text = "url_foto_mobil";
            this.label2.Visible = false;
            // 
            // cmbTransmisi
            // 
            this.cmbTransmisi.FormattingEnabled = true;
            this.cmbTransmisi.Items.AddRange(new object[] {
            "Manual",
            "Automatic"});
            this.cmbTransmisi.Location = new System.Drawing.Point(283, 226);
            this.cmbTransmisi.Margin = new System.Windows.Forms.Padding(4);
            this.cmbTransmisi.Name = "cmbTransmisi";
            this.cmbTransmisi.Size = new System.Drawing.Size(331, 24);
            this.cmbTransmisi.TabIndex = 51;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.Black;
            this.label12.Location = new System.Drawing.Point(63, 226);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(110, 21);
            this.label12.TabIndex = 50;
            this.label12.Text = "Tipe Transmisi";
            // 
            // numericUpDown_Kapasitas
            // 
            this.numericUpDown_Kapasitas.Location = new System.Drawing.Point(283, 267);
            this.numericUpDown_Kapasitas.Name = "numericUpDown_Kapasitas";
            this.numericUpDown_Kapasitas.Size = new System.Drawing.Size(331, 22);
            this.numericUpDown_Kapasitas.TabIndex = 49;
            // 
            // cmbBBM
            // 
            this.cmbBBM.FormattingEnabled = true;
            this.cmbBBM.Items.AddRange(new object[] {
            "Bensin",
            "Solar",
            "Pertamax",
            "Pertalite",
            "Dexlite",
            "Pertamina Dex",
            "Hybrid",
            "Listrik"});
            this.cmbBBM.Location = new System.Drawing.Point(283, 187);
            this.cmbBBM.Margin = new System.Windows.Forms.Padding(4);
            this.cmbBBM.Name = "cmbBBM";
            this.cmbBBM.Size = new System.Drawing.Size(331, 24);
            this.cmbBBM.TabIndex = 48;
            // 
            // cmbKategori
            // 
            this.cmbKategori.FormattingEnabled = true;
            this.cmbKategori.Items.AddRange(new object[] {
            "Sedan",
            "Hatchback",
            "SUV",
            "MPV",
            "Coupe",
            "Convertible",
            "Pickup",
            "Van",
            "Truck",
            "Sport Car"});
            this.cmbKategori.Location = new System.Drawing.Point(283, 146);
            this.cmbKategori.Margin = new System.Windows.Forms.Padding(4);
            this.cmbKategori.Name = "cmbKategori";
            this.cmbKategori.Size = new System.Drawing.Size(331, 24);
            this.cmbKategori.TabIndex = 47;
            // 
            // btnImport
            // 
            this.btnImport.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnImport.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnImport.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnImport.ForeColor = System.Drawing.Color.White;
            this.btnImport.Location = new System.Drawing.Point(670, 206);
            this.btnImport.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(181, 32);
            this.btnImport.TabIndex = 46;
            this.btnImport.Text = "Import";
            this.btnImport.UseVisualStyleBackColor = false;
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // pictureBoxMobil
            // 
            this.pictureBoxMobil.BackColor = System.Drawing.Color.White;
            this.pictureBoxMobil.Location = new System.Drawing.Point(670, 27);
            this.pictureBoxMobil.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBoxMobil.Name = "pictureBoxMobil";
            this.pictureBoxMobil.Size = new System.Drawing.Size(181, 181);
            this.pictureBoxMobil.TabIndex = 45;
            this.pictureBoxMobil.TabStop = false;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(243, 309);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(25, 16);
            this.label11.TabIndex = 40;
            this.label11.Text = "Rp";
            // 
            // cmb_status
            // 
            this.cmb_status.FormattingEnabled = true;
            this.cmb_status.Items.AddRange(new object[] {
            "Available",
            "Rented",
            "Maintenance",
            "Booked ",
            "Unavailable"});
            this.cmb_status.Location = new System.Drawing.Point(283, 350);
            this.cmb_status.Margin = new System.Windows.Forms.Padding(4);
            this.cmb_status.Name = "cmb_status";
            this.cmb_status.Size = new System.Drawing.Size(330, 24);
            this.cmb_status.TabIndex = 39;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(60, 351);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(54, 21);
            this.label8.TabIndex = 38;
            this.label8.Text = "Status";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(60, 309);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(127, 21);
            this.label3.TabIndex = 34;
            this.label3.Text = "Harga Sewa/hari";
            // 
            // txtHarga
            // 
            this.txtHarga.Location = new System.Drawing.Point(283, 305);
            this.txtHarga.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtHarga.Name = "txtHarga";
            this.txtHarga.Size = new System.Drawing.Size(331, 22);
            this.txtHarga.TabIndex = 33;
            // 
            // ViewCar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(968, 883);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.dataGridViewMobil);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.Search);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "ViewCar";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ViewCar";
            this.Load += new System.EventHandler(this.ViewCar_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMobil)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mobilBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.driveNowDataSetBindingSource)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_Kapasitas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxMobil)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label Search;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.DataGridView dataGridViewMobil;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.TextBox txtPlatNomor;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtMerk;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtWarna;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtHarga;
        private System.Windows.Forms.BindingSource driveNowDataSetBindingSource;
        //private DriveNowDataSet driveNowDataSet;
        private System.Windows.Forms.BindingSource mobilBindingSource;
        //private DriveNowDataSetTableAdapters.MobilTableAdapter mobilTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn idmobilDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn platnomorDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn merkmobilDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn warnaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tipeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn jenisbbmDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn kapasitasDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn hargasewaperhariDataGridViewTextBoxColumn;
        private System.Windows.Forms.ComboBox cmb_status;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button btnImport;
        private System.Windows.Forms.PictureBox pictureBoxMobil;
        private System.Windows.Forms.ComboBox cmbBBM;
        private System.Windows.Forms.ComboBox cmbKategori;
        private System.Windows.Forms.NumericUpDown numericUpDown_Kapasitas;
        private System.Windows.Forms.ComboBox cmbTransmisi;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtFotoURL;
    }
}