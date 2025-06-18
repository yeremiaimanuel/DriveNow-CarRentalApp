using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using DriveNow.DB;

namespace DriveNow
{
    public partial class Ulasan : Form
    {
        private readonly string currentUserId;
        private string selectedTransaksiId = "";

        public Ulasan(string userId)
        {
            InitializeComponent();
            this.TopLevel = false;
            this.FormBorderStyle = FormBorderStyle.None;
            currentUserId = userId;

            numericUpDown_rating.Minimum = 1;
            numericUpDown_rating.Maximum = 5;
            numericUpDown_rating.Value = 1;

            txtIdTransaksi.ReadOnly = true;
        }

        private void Ulasan_Load(object sender, EventArgs e)
        {
            this.ControlBox = false;
            dataGridViewUlasan.CellClick += dataGridViewUlasan_CellContentClick;
        }

        private void LoadTransaksiToGrid()
        {
            if (string.IsNullOrEmpty(currentUserId)) return;

            string query = @"
                SELECT t.id_transaksi, m.merk_mobil, b.tanggal_mulai AS tanggal_pinjam, b.tanggal_selesai AS tanggal_kembali
                FROM Transaksi t
                JOIN Booking b ON t.id_booking = b.id_booking
                JOIN Mobil m ON b.id_mobil = m.id_mobil
                WHERE t.id_user = @userId
                  AND b.tanggal_mulai >= @tglAwal
                  AND b.tanggal_selesai <= @tglAkhir";

            using (SqlConnection conn = dbConnection.GetConnection())
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@userId", currentUserId);
                cmd.Parameters.AddWithValue("@tglAwal", dateTimePicker1.Value.Date);
                cmd.Parameters.AddWithValue("@tglAkhir", dateTimePicker2.Value.Date);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridViewUlasan.DataSource = dt;
            }
        }

        private void btnLihatData_Click(object sender, EventArgs e)
        {
            selectedTransaksiId = "";
            txtIdTransaksi.Clear();
            LoadTransaksiToGrid();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtIdTransaksi.Text) || string.IsNullOrWhiteSpace(richTextBox_komentar.Text))
            {
                MessageBox.Show("Pilih transaksi dan isi komentar terlebih dahulu.", "Validasi Gagal", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string komentar = richTextBox_komentar.Text.Trim();
            int rating = (int)numericUpDown_rating.Value;
            DateTime tanggal = DateTime.Today;
            string idTransaksi = txtIdTransaksi.Text;

            string getNextIdQuery = "SELECT MAX(CAST(SUBSTRING(id_ulasan, 3, 3) AS INT)) FROM Ulasan WHERE ISNUMERIC(SUBSTRING(id_ulasan, 3, 3)) = 1";
            int nextNumber = 1;

            using (SqlConnection conn = dbConnection.GetConnection())
            {
                conn.Open();

                using (SqlCommand cmdMax = new SqlCommand(getNextIdQuery, conn))
                {
                    object result = cmdMax.ExecuteScalar();
                    if (result != DBNull.Value && result != null)
                        nextNumber = Convert.ToInt32(result) + 1;
                }

                string newId = "UL" + nextNumber.ToString("D3");

                string insertQuery = @"
                    INSERT INTO Ulasan (id_ulasan, id_user, id_mobil, komentar, rating, tanggal_ulasan)
                    SELECT @id_ulasan, t.id_user, b.id_mobil, @komentar, @rating, @tanggal
                    FROM Transaksi t
                    JOIN Booking b ON t.id_booking = b.id_booking
                    WHERE t.id_transaksi = @id_transaksi AND t.id_user = @userId";

                using (SqlCommand cmdInsert = new SqlCommand(insertQuery, conn))
                {
                    cmdInsert.Parameters.AddWithValue("@id_ulasan", newId);
                    cmdInsert.Parameters.AddWithValue("@komentar", komentar);
                    cmdInsert.Parameters.AddWithValue("@rating", rating);
                    cmdInsert.Parameters.AddWithValue("@tanggal", tanggal);
                    cmdInsert.Parameters.AddWithValue("@id_transaksi", idTransaksi);
                    cmdInsert.Parameters.AddWithValue("@userId", currentUserId);

                    int result = cmdInsert.ExecuteNonQuery();
                    if (result > 0)
                    {
                        MessageBox.Show("Ulasan berhasil disimpan.", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        btnCancel.PerformClick();
                        LoadTransaksiToGrid();
                    }
                    else
                    {
                        MessageBox.Show("Gagal menyimpan ulasan.", "Gagal", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            selectedTransaksiId = "";
            txtIdTransaksi.Clear();
            numericUpDown_rating.Value = 1;
            richTextBox_komentar.Clear();
        }

        private void dataGridViewUlasan_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var row = dataGridViewUlasan.Rows[e.RowIndex];
                selectedTransaksiId = row.Cells[0].Value?.ToString();
                txtIdTransaksi.Text = selectedTransaksiId;
            }
        }
    }
}
