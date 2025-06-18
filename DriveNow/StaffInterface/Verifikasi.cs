using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Windows.Forms;
using DriveNow.DB;

namespace DriveNow
{
    public partial class Verifikasi : Form
    {
        public Verifikasi()
        {
            InitializeComponent();
            this.dataGridView.CellClick += new DataGridViewCellEventHandler(this.dataGridView_CellClick);
            this.Load += Verifikasi_Load;
        }

        private void Verifikasi_Load(object sender, EventArgs e)
        {
            LoadVerifikasiData();
        }

        private void LoadVerifikasiData(string keyword = "")
        {
            using (SqlConnection conn = dbConnection.GetConnection())
            {
                string query = @"
                    SELECT b.id_booking, u.nama AS pelanggan, m.merk_mobil, b.tanggal_mulai, b.tanggal_selesai,
                           t.total_pembayaran, p.bukti_pembayaran, p.status_pembayaran
                    FROM Booking b
                    JOIN Users u ON b.id_user = u.id_user
                    JOIN Mobil m ON b.id_mobil = m.id_mobil
                    LEFT JOIN Transaksi t ON b.id_booking = t.id_booking
                    LEFT JOIN Pembayaran p ON t.id_transaksi = p.id_transaksi
                    WHERE p.status_pembayaran = 'Menunggu'";

                if (!string.IsNullOrWhiteSpace(keyword))
                {
                    query += " AND (b.id_booking LIKE @kw OR u.nama LIKE @kw OR m.merk_mobil LIKE @kw)";
                }

                SqlCommand cmd = new SqlCommand(query, conn);
                if (!string.IsNullOrWhiteSpace(keyword))
                    cmd.Parameters.AddWithValue("@kw", "%" + keyword + "%");

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView.DataSource = dt;

                dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dataGridView.ReadOnly = true;
                dataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dataGridView.MultiSelect = false;
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            LoadVerifikasiData(txtSearch.Text.Trim());
        }

        private void dataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView.Rows[e.RowIndex];
                lblIdBooking.Text = row.Cells["id_booking"].Value?.ToString() ?? "-";
                lblCustomer.Text = row.Cells["pelanggan"].Value?.ToString() ?? "-";
                lblMobil.Text = row.Cells["merk_mobil"].Value?.ToString() ?? "-";

                string tanggalMulai = Convert.ToDateTime(row.Cells["tanggal_mulai"].Value).ToString("dd MMM yyyy");
                string tanggalSelesai = Convert.ToDateTime(row.Cells["tanggal_selesai"].Value).ToString("dd MMM yyyy");
                lblTanggalSewa.Text = $"{tanggalMulai} s.d. {tanggalSelesai}";

                if (decimal.TryParse(row.Cells["total_pembayaran"].Value?.ToString(), out decimal total))
                    lblTotalBayar.Text = total.ToString("C0", new CultureInfo("id-ID"));
                else
                    lblTotalBayar.Text = "-";

                string buktiPath = row.Cells["bukti_pembayaran"].Value?.ToString() ?? "";
                string fullPath = Path.Combine(Application.StartupPath, "bukti_pembayaran", buktiPath);
                if (File.Exists(fullPath))
                {
                    using (FileStream stream = new FileStream(fullPath, FileMode.Open, FileAccess.Read))
                    {
                        pictureBox_Pembayaran.Image = Image.FromStream(stream);
                    }
                    pictureBox_Pembayaran.SizeMode = PictureBoxSizeMode.StretchImage;
                }
                else
                {
                    MessageBox.Show("File bukti pembayaran tidak ditemukan: " + fullPath);
                    pictureBox_Pembayaran.Image = null;
                }

                pictureBox_Pembayaran.SizeMode = PictureBoxSizeMode.StretchImage;
            }
        }

        private void btnVerifikasi_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(lblIdBooking.Text) || cbAksi.SelectedIndex == -1)
            {
                MessageBox.Show("Pilih booking dan aksi terlebih dahulu.");
                return;
            }

            string aksi = cbAksi.SelectedItem.ToString();
            string statusBaru = aksi == "Setujui" ? "Dikonfirmasi" : "Ditolak";

            using (SqlConnection conn = dbConnection.GetConnection())
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand(@"
                    UPDATE Pembayaran
                    SET status_pembayaran = @status
                    WHERE id_transaksi = (
                        SELECT TOP 1 t.id_transaksi
                        FROM Transaksi t
                        WHERE t.id_booking = @id_booking
                    );

                    UPDATE Booking
                    SET status_booking = @bookingStatus
                    WHERE id_booking = @id_booking;", conn);

                cmd.Parameters.AddWithValue("@status", statusBaru);
                cmd.Parameters.AddWithValue("@bookingStatus", aksi == "Setujui" ? "Diterima" : "Ditolak");
                cmd.Parameters.AddWithValue("@id_booking", lblIdBooking.Text);

                cmd.ExecuteNonQuery();
                MessageBox.Show("Verifikasi berhasil diproses.");
                LoadVerifikasiData();
            }
        }

        private void btnBatal_Click(object sender, EventArgs e)
        {
            lblIdBooking.Text = "-";
            lblCustomer.Text = "-";
            lblMobil.Text = "-";
            lblTanggalSewa.Text = "-";
            lblTotalBayar.Text = "-";
            cbAksi.SelectedIndex = -1;
            pictureBox_Pembayaran.Image = null;
        }

        private void pictureBox_Pembayaran_Click(object sender, EventArgs e)
        {
            pictureBox_Pembayaran.Enabled = false;
        }
    }
}
