using System;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using DriveNow.DB;

namespace DriveNow.Customer
{
    public partial class Pembayaran : Form
    {
        private string idUser;
        private string idMobil;
        private decimal totalHarga;
        private DateTime tanggalMulai, tanggalSelesai;
        private TimeSpan jamPengambilan;
        private string merkMobil;
        private string pathBukti = "";

        public Pembayaran(string idUser, string idMobil, string merkMobil, decimal totalHarga, DateTime mulai, DateTime selesai, TimeSpan jamAmbil)
        {
            InitializeComponent();
            this.idUser = idUser;
            this.idMobil = idMobil;
            this.merkMobil = merkMobil;
            this.totalHarga = totalHarga;
            this.tanggalMulai = mulai;
            this.tanggalSelesai = selesai;
            this.jamPengambilan = jamAmbil;

            lblTotalHarga.Text = totalHarga.ToString("N0");
            lblTanggalBayar.Text = DateTime.Today.ToString("yyyy-MM-dd");

            cmbMetodePembayaran.Items.AddRange(new string[] { "Transfer", "QRIS", "Cash" });
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(idUser))
            {
                MessageBox.Show("ID User tidak ditemukan. Harap login ulang.", "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (cmbMetodePembayaran.SelectedItem == null ||
                string.IsNullOrWhiteSpace(txtNamaBankPengirim.Text) ||
                string.IsNullOrEmpty(pathBukti))
            {
                MessageBox.Show("Mohon lengkapi semua data pembayaran.", "Validasi Gagal", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string metode = cmbMetodePembayaran.SelectedItem.ToString();
            string namaBank = txtNamaBankPengirim.Text.Trim();
            string fileName = Path.GetFileName(pathBukti);

            string destFolder = Path.Combine(Application.StartupPath, "bukti_pembayaran");
            if (!Directory.Exists(destFolder))
                Directory.CreateDirectory(destFolder);

            string destPath = Path.Combine(destFolder, fileName);

            try
            {
                File.Copy(pathBukti, destPath, true); // Simpan gambar ke folder lokal aplikasi

                using (SqlConnection conn = dbConnection.GetConnection())
                {
                    conn.Open();

                    // ID Booking
                    string idBooking = GenerateId(conn, "Booking", "id_booking", "BKG");

                    // Insert Booking
                    SqlCommand cmdBooking = new SqlCommand(@"INSERT INTO Booking 
                        (id_booking, id_user, id_mobil, tanggal_booking, tanggal_mulai, tanggal_selesai, durasi_hari,
                         jam_pengambilan_mobil, jam_pengembalian_mobil, status_booking)
                        VALUES (@id_booking, @id_user, @id_mobil, @tgl_booking, @tgl_mulai, @tgl_selesai, @durasi, @jam_ambil, @jam_kembali, @status_book)", conn);
                    cmdBooking.Parameters.AddWithValue("@id_booking", idBooking);
                    cmdBooking.Parameters.AddWithValue("@id_user", idUser);
                    cmdBooking.Parameters.AddWithValue("@id_mobil", idMobil);
                    cmdBooking.Parameters.AddWithValue("@tgl_booking", DateTime.Today);
                    cmdBooking.Parameters.AddWithValue("@tgl_mulai", tanggalMulai);
                    cmdBooking.Parameters.AddWithValue("@tgl_selesai", tanggalSelesai);
                    cmdBooking.Parameters.AddWithValue("@durasi", (tanggalSelesai - tanggalMulai).Days + 1);
                    cmdBooking.Parameters.AddWithValue("@jam_ambil", jamPengambilan);
                    cmdBooking.Parameters.AddWithValue("@jam_kembali", jamPengambilan.Add(TimeSpan.FromHours(8)));
                    cmdBooking.Parameters.AddWithValue("@status_book", "Menunggu");
                    cmdBooking.ExecuteNonQuery();

                    // Update status mobil
                    SqlCommand cmdUpdateMobil = new SqlCommand("UPDATE Mobil SET status_mobil = 'Booked' WHERE id_mobil = @id_mobil", conn);
                    cmdUpdateMobil.Parameters.AddWithValue("@id_mobil", idMobil);
                    cmdUpdateMobil.ExecuteNonQuery();

                    // ID Transaksi
                    string idTransaksi = GenerateId(conn, "Transaksi", "id_transaksi", "TRX");

                    // Insert Transaksi
                    SqlCommand cmdTrans = new SqlCommand(@"INSERT INTO Transaksi 
                        (id_transaksi, id_booking, id_user, tanggal_transaksi, total_pembayaran)
                        VALUES (@id, @booking, @user, @tgl, @total)", conn);
                    cmdTrans.Parameters.AddWithValue("@id", idTransaksi);
                    cmdTrans.Parameters.AddWithValue("@booking", idBooking);
                    cmdTrans.Parameters.AddWithValue("@user", idUser);
                    cmdTrans.Parameters.AddWithValue("@tgl", DateTime.Today);
                    cmdTrans.Parameters.AddWithValue("@total", totalHarga);
                    cmdTrans.ExecuteNonQuery();

                    // ID Pembayaran
                    string idPembayaran = GenerateId(conn, "Pembayaran", "id_pembayaran", "PMB");

                    // Insert Pembayaran
                    SqlCommand cmd = new SqlCommand(@"INSERT INTO Pembayaran 
                        (id_pembayaran, id_transaksi, tanggal_pembayaran, metode_pembayaran, nama_bank_pengirim, bukti_pembayaran, status_pembayaran)
                        VALUES (@id, @trans, @tgl, @metode, @bank, @bukti, @status)", conn);
                    cmd.Parameters.AddWithValue("@id", idPembayaran);
                    cmd.Parameters.AddWithValue("@trans", idTransaksi);
                    cmd.Parameters.AddWithValue("@tgl", DateTime.Today);
                    cmd.Parameters.AddWithValue("@metode", metode);
                    cmd.Parameters.AddWithValue("@bank", namaBank);
                    cmd.Parameters.AddWithValue("@bukti", fileName);
                    cmd.Parameters.AddWithValue("@status", "Menunggu");
                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("Pembayaran & Booking berhasil dikonfirmasi.", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal menyimpan pembayaran: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string GenerateId(SqlConnection conn, string tableName, string idColumn, string prefix)
        {
            string query = $"SELECT MAX(CAST(SUBSTRING({idColumn}, 4, 3) AS INT)) FROM {tableName}";
            SqlCommand cmd = new SqlCommand(query, conn);
            object result = cmd.ExecuteScalar();
            int nextId = (result != DBNull.Value && result != null) ? Convert.ToInt32(result) + 1 : 1;
            return prefix + nextId.ToString("D3");
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnUpload_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "Image Files|*.jpg;*.jpeg;*.png;";
            if (open.ShowDialog() == DialogResult.OK)
            {
                pathBukti = open.FileName;
                pictureBoxBuktiTransfer.Image = Image.FromFile(pathBukti);
                pictureBoxBuktiTransfer.SizeMode = PictureBoxSizeMode.Zoom;
            }
        }
    }
}
