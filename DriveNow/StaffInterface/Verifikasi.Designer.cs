namespace DriveNow
{
    partial class Verifikasi
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.Search = new System.Windows.Forms.Label();
            this.btnVerifikasi = new System.Windows.Forms.Button();
            this.btnBatal = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.pictureBox_Pembayaran = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.cbAksi = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.lblTotalBayar = new System.Windows.Forms.Label();
            this.lblTanggalSewa = new System.Windows.Forms.Label();
            this.lblMobil = new System.Windows.Forms.Label();
            this.lblCustomer = new System.Windows.Forms.Label();
            this.lblIdBooking = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Pembayaran)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(193)))), ((int)(((byte)(18)))), ((int)(((byte)(31)))));
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1032, 78);
            this.panel1.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 25.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(398, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(228, 53);
            this.label1.TabIndex = 1;
            this.label1.Text = "Verification";
            // 
            // dataGridView
            // 
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Location = new System.Drawing.Point(40, 149);
            this.dataGridView.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.RowHeadersWidth = 51;
            this.dataGridView.RowTemplate.Height = 24;
            this.dataGridView.Size = new System.Drawing.Size(944, 273);
            this.dataGridView.TabIndex = 10;
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(445, 106);
            this.txtSearch.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(145, 22);
            this.txtSearch.TabIndex = 9;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // Search
            // 
            this.Search.AutoSize = true;
            this.Search.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Search.ForeColor = System.Drawing.Color.Black;
            this.Search.Location = new System.Drawing.Point(346, 106);
            this.Search.Name = "Search";
            this.Search.Size = new System.Drawing.Size(92, 21);
            this.Search.TabIndex = 7;
            this.Search.Text = "Merk Mobil";
            // 
            // btnVerifikasi
            // 
            this.btnVerifikasi.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnVerifikasi.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVerifikasi.Location = new System.Drawing.Point(108, 340);
            this.btnVerifikasi.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnVerifikasi.Name = "btnVerifikasi";
            this.btnVerifikasi.Size = new System.Drawing.Size(197, 25);
            this.btnVerifikasi.TabIndex = 1;
            this.btnVerifikasi.Text = "Verifikasi";
            this.btnVerifikasi.UseVisualStyleBackColor = true;
            this.btnVerifikasi.Click += new System.EventHandler(this.btnVerifikasi_Click);
            // 
            // btnBatal
            // 
            this.btnBatal.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnBatal.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBatal.Location = new System.Drawing.Point(338, 340);
            this.btnBatal.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnBatal.Name = "btnBatal";
            this.btnBatal.Size = new System.Drawing.Size(197, 25);
            this.btnBatal.TabIndex = 3;
            this.btnBatal.Text = "Batal";
            this.btnBatal.UseVisualStyleBackColor = true;
            this.btnBatal.Click += new System.EventHandler(this.btnBatal_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.Black;
            this.label10.Location = new System.Drawing.Point(118, 60);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(87, 21);
            this.label10.TabIndex = 20;
            this.label10.Text = "ID Booking";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.Black;
            this.label9.Location = new System.Drawing.Point(118, 98);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(79, 21);
            this.label9.TabIndex = 22;
            this.label9.Text = "Customer";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(118, 136);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(51, 21);
            this.label4.TabIndex = 24;
            this.label4.Text = "Mobil";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(118, 175);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(104, 21);
            this.label5.TabIndex = 25;
            this.label5.Text = "Tanggal Sewa";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(118, 216);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(88, 21);
            this.label6.TabIndex = 26;
            this.label6.Text = "Total Bayar";
            // 
            // pictureBox_Pembayaran
            // 
            this.pictureBox_Pembayaran.BackColor = System.Drawing.Color.White;
            this.pictureBox_Pembayaran.Location = new System.Drawing.Point(588, 83);
            this.pictureBox_Pembayaran.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox_Pembayaran.Name = "pictureBox_Pembayaran";
            this.pictureBox_Pembayaran.Size = new System.Drawing.Size(230, 282);
            this.pictureBox_Pembayaran.TabIndex = 45;
            this.pictureBox_Pembayaran.TabStop = false;
            this.pictureBox_Pembayaran.Click += new System.EventHandler(this.pictureBox_Pembayaran_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Silver;
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.cbAksi);
            this.panel2.Controls.Add(this.label13);
            this.panel2.Controls.Add(this.lblTotalBayar);
            this.panel2.Controls.Add(this.lblTanggalSewa);
            this.panel2.Controls.Add(this.lblMobil);
            this.panel2.Controls.Add(this.lblCustomer);
            this.panel2.Controls.Add(this.lblIdBooking);
            this.panel2.Controls.Add(this.pictureBox_Pembayaran);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.label9);
            this.panel2.Controls.Add(this.label10);
            this.panel2.Controls.Add(this.btnBatal);
            this.panel2.Controls.Add(this.btnVerifikasi);
            this.panel2.Location = new System.Drawing.Point(41, 447);
            this.panel2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(943, 424);
            this.panel2.TabIndex = 11;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(629, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(139, 21);
            this.label2.TabIndex = 60;
            this.label2.Text = "Bukti Pembayaran";
            // 
            // cbAksi
            // 
            this.cbAksi.FormattingEnabled = true;
            this.cbAksi.Items.AddRange(new object[] {
            "Approved",
            "Rejected"});
            this.cbAksi.Location = new System.Drawing.Point(338, 256);
            this.cbAksi.Name = "cbAksi";
            this.cbAksi.Size = new System.Drawing.Size(121, 24);
            this.cbAksi.TabIndex = 59;
            //this.cbAksi.SelectedIndexChanged += new System.EventHandler(this.cbAksi_SelectedIndexChanged);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.Black;
            this.label13.Location = new System.Drawing.Point(118, 256);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(122, 21);
            this.label13.TabIndex = 58;
            this.label13.Text = "Status Verifikasi";
            // 
            // lblTotalBayar
            // 
            this.lblTotalBayar.AutoSize = true;
            this.lblTotalBayar.Location = new System.Drawing.Point(335, 221);
            this.lblTotalBayar.Name = "lblTotalBayar";
            this.lblTotalBayar.Size = new System.Drawing.Size(0, 16);
            this.lblTotalBayar.TabIndex = 54;
            //this.lblTotalBayar.Click += new System.EventHandler(this.lblTotalBayar_Click);
            // 
            // lblTanggalSewa
            // 
            this.lblTanggalSewa.AutoSize = true;
            this.lblTanggalSewa.Location = new System.Drawing.Point(335, 180);
            this.lblTanggalSewa.Name = "lblTanggalSewa";
            this.lblTanggalSewa.Size = new System.Drawing.Size(0, 16);
            this.lblTanggalSewa.TabIndex = 53;
            //this.lblTanggalSewa.Click += new System.EventHandler(this.lblTanggalSewa_Click);
            // 
            // lblMobil
            // 
            this.lblMobil.AutoSize = true;
            this.lblMobil.Location = new System.Drawing.Point(335, 141);
            this.lblMobil.Name = "lblMobil";
            this.lblMobil.Size = new System.Drawing.Size(0, 16);
            this.lblMobil.TabIndex = 52;
            //this.lblMobil.Click += new System.EventHandler(this.lblMobil_Click);
            // 
            // lblCustomer
            // 
            this.lblCustomer.AutoSize = true;
            this.lblCustomer.Location = new System.Drawing.Point(335, 103);
            this.lblCustomer.Name = "lblCustomer";
            this.lblCustomer.Size = new System.Drawing.Size(0, 16);
            this.lblCustomer.TabIndex = 51;
            //this.lblCustomer.Click += new System.EventHandler(this.lblCustomer_Click);
            // 
            // lblIdBooking
            // 
            this.lblIdBooking.AutoSize = true;
            this.lblIdBooking.Location = new System.Drawing.Point(335, 65);
            this.lblIdBooking.Name = "lblIdBooking";
            this.lblIdBooking.Size = new System.Drawing.Size(0, 16);
            this.lblIdBooking.TabIndex = 50;
            //this.lblIdBooking.Click += new System.EventHandler(this.lblIdBooking_Click);
            // 
            // Verifikasi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1029, 896);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.Search);
            this.Name = "Verifikasi";
            this.Text = "Verifikasi";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Pembayaran)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        //private DriveNowDataSetTableAdapters.MobilTableAdapter mobilTableAdapter;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.BindingSource mobilBindingSource;
        private System.Windows.Forms.BindingSource driveNowDataSetBindingSource;
        //private DriveNowDataSet driveNowDataSet;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label Search;
        private System.Windows.Forms.Button btnVerifikasi;
        private System.Windows.Forms.Button btnBatal;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.PictureBox pictureBox_Pembayaran;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblIdBooking;
        private System.Windows.Forms.Label lblCustomer;
        private System.Windows.Forms.Label lblTanggalSewa;
        private System.Windows.Forms.Label lblMobil;
        private System.Windows.Forms.Label lblTotalBayar;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ComboBox cbAksi;
        private System.Windows.Forms.Label label2;
    }
}