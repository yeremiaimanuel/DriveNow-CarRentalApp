using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace DriveNow.Customer
{
    public partial class CustomListCar : UserControl
    {
        public CustomListCar()
        {
            InitializeComponent();
            btnBook.Click += BtnBook_Click; 
        }

        // ========== Custom Properties ==========

        [Category("Custom Props")]
        public string NamaMobil
        {
            get => lblNamaMobil.Text;
            set => lblNamaMobil.Text = value;
        }

        [Category("Custom Props")]
        public string TipeWarna
        {
            get => lblTipeWarna.Text;
            set => lblTipeWarna.Text = value;
        }

        [Category("Custom Props")]
        public string Kapasitas
        {
            get => lblKapasitas.Text;
            set => lblKapasitas.Text = value;
        }

        [Category("Custom Props")]
        public string HargaSewa
        {
            get => lblHargaSewa.Text;
            set => lblHargaSewa.Text = value;
        }

        [Category("Custom Props")]
        public string Status
        {
            get => lblStatus.Text;
            set => lblStatus.Text = value;
        }

        [Category("Custom Props")]
        public Image FotoMobil
        {
            get => pictureMobil.Image;
            set => pictureMobil.Image = value;
        }

        [Category("Custom Props")]
        public string IdMobil { get; set; }

        [Category("Custom Props")]
        public decimal HargaDecimal { get; set; }


        // ========== Event Book Now ==========
        public event EventHandler OnBookClicked;

        private void BtnBook_Click(object sender, EventArgs e)
        {
            OnBookClicked?.Invoke(this, e);
        }

        private void btnBook_Click_1(object sender, EventArgs e)
        {

        }
    }
}
