using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DriveNow.Customer;

namespace DriveNow
{
    public partial class UserDashboard : Form
    {
        private Form activeForm = null;
        private string idUser;

        public UserDashboard(string idUser)
        {
            InitializeComponent();
            this.idUser = idUser;
            panel_1.Visible = false;
            panel_2.Visible = false;
            panel_3.Visible = false;
            panel_4.Visible = false;
            panel_5.Visible = false;
            panel_6.Visible = false;
        }

        public void OpenChildForm(Form childForm)
        {
            if (activeForm != null)
                activeForm.Close();

            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.StartPosition = FormStartPosition.Manual;

            // Ukuran default childForm
            if (childForm.Width <= 300 || childForm.Height <= 300)
            {
                childForm.Size = new Size(700, 500);
            }

            panelContent.Controls.Clear();
            panelContent.Controls.Add(childForm);
            childForm.Show();

            int x = (panelContent.ClientSize.Width - childForm.Width) / 2;
            int y = (panelContent.ClientSize.Height - childForm.Height) / 2;
            childForm.Location = new Point(Math.Max(x, 0), Math.Max(y, 0));

            childForm.BringToFront();
        }

        public UserDashboard()
        {
            InitializeComponent();
            this.panelContent.Resize += new System.EventHandler(this.panelContent_Resize);
            CollapseAllPanels();
            panelContent.SendToBack(); 
        }

        private void panelContent_Resize(object sender, EventArgs e)
        {
            if (activeForm != null && panelContent.Controls.Contains(activeForm))
            {
                int x = (panelContent.ClientSize.Width - activeForm.Width) / 2;
                int y = (panelContent.ClientSize.Height - activeForm.Height) / 2;
                activeForm.Location = new Point(Math.Max(x, 0), Math.Max(y, 0));
            }
        }

        private void CollapseAllPanels()
        {
            panel_1.Visible = false;
            panel_2.Visible = false;
            panel_3.Visible = false;
            panel_4.Visible = false;
            panel_5.Visible = false;
            panel_6.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CollapseAllPanels();
            panel_1.Visible = true;
            OpenChildForm(new KatalogMobil(idUser));
        }

        private void button2_Click(object sender, EventArgs e)
        {
            CollapseAllPanels();
            panel_2.Visible = true;
            OpenChildForm(new ViewBooking());
        }

        private void btnPembayaran_Click(object sender, EventArgs e)
        {
            CollapseAllPanels();
            panel_3.Visible = true;
            OpenChildForm(new ViewPayment());
        }

        private void btnUlasan_Click(object sender, EventArgs e)
        {
            CollapseAllPanels();
            panel_4.Visible = true;
            OpenChildForm(new Ulasan(SessionManager.LoggedInUserId));
        }

        private void btnProfil_Click(object sender, EventArgs e)
        {
            CollapseAllPanels();
            panel_5.Visible = true;
            OpenChildForm(new ProfilSaya());
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            CollapseAllPanels();
            panel_6.Visible = true;

            if (MessageBox.Show("Are you sure want to exit?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                new LoginForm().Show();   
                this.Hide();
            }
        }
    }
}
