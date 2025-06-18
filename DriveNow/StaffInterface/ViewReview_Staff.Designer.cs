namespace DriveNow
{
    partial class ViewReview_Staff
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
            this.dataGridViewReview = new System.Windows.Forms.DataGridView();
            this.txtSeach = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnExportToFile = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewReview)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(193)))), ((int)(((byte)(18)))), ((int)(((byte)(31)))));
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(968, 78);
            this.panel1.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 25.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(185, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(592, 53);
            this.label1.TabIndex = 1;
            this.label1.Text = "Customer Review and Feedback";
            // 
            // dataGridViewReview
            // 
            this.dataGridViewReview.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewReview.Location = new System.Drawing.Point(55, 152);
            this.dataGridViewReview.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataGridViewReview.Name = "dataGridViewReview";
            this.dataGridViewReview.RowHeadersWidth = 51;
            this.dataGridViewReview.RowTemplate.Height = 24;
            this.dataGridViewReview.Size = new System.Drawing.Size(841, 367);
            this.dataGridViewReview.TabIndex = 9;
            //this.dataGridViewReview.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewReview_CellContentClick);
            // 
            // txtSeach
            // 
            this.txtSeach.Location = new System.Drawing.Point(411, 108);
            this.txtSeach.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtSeach.Name = "txtSeach";
            this.txtSeach.Size = new System.Drawing.Size(145, 22);
            this.txtSeach.TabIndex = 8;
            this.txtSeach.TextChanged += new System.EventHandler(this.txtSeach_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(312, 108);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 21);
            this.label2.TabIndex = 6;
            this.label2.Text = "Search";
            // 
            // btnExportToFile
            // 
            this.btnExportToFile.Location = new System.Drawing.Point(55, 535);
            this.btnExportToFile.Name = "btnExportToFile";
            this.btnExportToFile.Size = new System.Drawing.Size(841, 29);
            this.btnExportToFile.TabIndex = 15;
            this.btnExportToFile.Text = "Export to File";
            this.btnExportToFile.UseVisualStyleBackColor = true;
            this.btnExportToFile.Click += new System.EventHandler(this.btnExportToFile_Click);
            // 
            // ViewReview_Staff
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(968, 617);
            this.Controls.Add(this.btnExportToFile);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dataGridViewReview);
            this.Controls.Add(this.txtSeach);
            this.Controls.Add(this.label2);
            this.Name = "ViewReview_Staff";
            this.Text = "ViewReview_Staff";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewReview)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridViewReview;
        private System.Windows.Forms.TextBox txtSeach;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnExportToFile;
    }
}