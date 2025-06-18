namespace DriveNow.Customer
{
    partial class KatalogMobil
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
            this.flowLayoutPanelCars = new System.Windows.Forms.FlowLayoutPanel();
            this.SuspendLayout();
            // 
            // flowLayoutPanelCars
            // 
            this.flowLayoutPanelCars.AutoScroll = true;
            this.flowLayoutPanelCars.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanelCars.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanelCars.Name = "flowLayoutPanelCars";
            this.flowLayoutPanelCars.Padding = new System.Windows.Forms.Padding(10);
            this.flowLayoutPanelCars.Size = new System.Drawing.Size(1099, 653);
            this.flowLayoutPanelCars.TabIndex = 0;
            //this.flowLayoutPanelCars.Paint += new System.Windows.Forms.PaintEventHandler(this.flowLayoutPanelCars_Paint);
            // 
            // KatalogMobil
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1099, 653);
            this.Controls.Add(this.flowLayoutPanelCars);
            this.Name = "KatalogMobil";
            this.Text = "KatalogMobil";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelCars;
    }
}