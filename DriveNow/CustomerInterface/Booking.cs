using System;
using System.Windows.Forms;

namespace DriveNow.Customer
{
    public partial class Booking : Form
    {
        private readonly string idUser;
        private readonly string idMobil;
        private readonly string merkMobil;
        private readonly decimal hargaSewa;

        public Booking(string idUser, string idMobil, string merkMobil, decimal hargaSewa)
        {
            InitializeComponent();
            this.idUser = idUser;
            this.idMobil = idMobil;
            this.merkMobil = merkMobil;
            this.hargaSewa = hargaSewa;

            lblSewaPerHari.Text = hargaSewa.ToString("N0");
            lblTotalHarga.Text = "0";

            dateTimePickerJamPengambilan.Format = DateTimePickerFormat.Time;
            dateTimePickerJamPengambilan.ShowUpDown = true;

            dateTimePickerTanggalMulai.ValueChanged += UpdateTotalHarga;
            dateTimePickerTanggalSelesai.ValueChanged += UpdateTotalHarga;

            UpdateTotalHarga(null, null);
        }

        private void UpdateTotalHarga(object sender, EventArgs e)
        {
            if (dateTimePickerTanggalSelesai.Value.Date < dateTimePickerTanggalMulai.Value.Date)
            {
                dateTimePickerTanggalSelesai.Value = dateTimePickerTanggalMulai.Value;
            }

            int jumlahHari = (int)(dateTimePickerTanggalSelesai.Value.Date - dateTimePickerTanggalMulai.Value.Date).TotalDays + 1;
            if (jumlahHari < 1) jumlahHari = 1;

            decimal total = jumlahHari * hargaSewa;
            lblTotalHarga.Text = total.ToString("N0");
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            try
            {
                // Validasi tanggal
                if (dateTimePickerTanggalMulai.Value.Date > dateTimePickerTanggalSelesai.Value.Date)
                {
                    MessageBox.Show("Tanggal selesai tidak boleh sebelum tanggal mulai.", "Validasi Gagal", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Hitung total harga
                if (!decimal.TryParse(lblTotalHarga.Text.Replace(".", "").Replace(",", ""), out decimal totalHarga))
                {
                    MessageBox.Show("Gagal menghitung total harga. Silakan periksa input tanggal.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                DateTime tanggalMulai = dateTimePickerTanggalMulai.Value.Date;
                DateTime tanggalSelesai = dateTimePickerTanggalSelesai.Value.Date;
                TimeSpan jamPengambilan = dateTimePickerJamPengambilan.Value.TimeOfDay;

                // Cek apakah tanggal mulai di masa lalu
                if (tanggalMulai < DateTime.Today)
                {
                    MessageBox.Show("Tanggal mulai tidak boleh di masa lalu.", "Validasi Gagal", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Buka form pembayaran
                var pembayaranForm = new Pembayaran(idUser, idMobil, merkMobil, totalHarga, tanggalMulai, tanggalSelesai, jamPengambilan);
                this.Hide();
                pembayaranForm.ShowDialog();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Terjadi kesalahan saat memproses booking:\n" + ex.Message, "Kesalahan Tidak Terduga", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



    }
}
