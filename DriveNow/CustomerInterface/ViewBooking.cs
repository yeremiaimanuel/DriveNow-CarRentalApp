using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using DriveNow.DB;

namespace DriveNow.Customer
{
    public partial class ViewBooking : Form
    {
        private string currentUserId;

        public ViewBooking()
        {
            InitializeComponent();
            currentUserId = SessionManager.LoggedInUserId;
        }

        private void btnExportToFile_Click(object sender, EventArgs e)
        {
            if (dataGridViewBooking.SelectedRows.Count == 0)
            {
                MessageBox.Show("Silakan pilih baris booking yang ingin diekspor.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "CSV file (*.csv)|*.csv",
                Title = "Simpan Data Booking",
                FileName = "DataBooking.csv"
            };

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    using (StreamWriter writer = new StreamWriter(saveFileDialog.FileName, false, Encoding.UTF8))
                    {
                        for (int i = 0; i < dataGridViewBooking.Columns.Count; i++)
                        {
                            writer.Write(dataGridViewBooking.Columns[i].HeaderText);
                            if (i < dataGridViewBooking.Columns.Count - 1)
                                writer.Write(",");
                        }
                        writer.WriteLine();

                        foreach (DataGridViewRow row in dataGridViewBooking.SelectedRows)
                        {
                            for (int i = 0; i < dataGridViewBooking.Columns.Count; i++)
                            {
                                writer.Write(row.Cells[i].Value?.ToString());
                                if (i < dataGridViewBooking.Columns.Count - 1)
                                    writer.Write(",");
                            }
                            writer.WriteLine();
                        }
                    }

                    MessageBox.Show("Data booking berhasil disimpan.", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Gagal mengekspor data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnLihatData_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(currentUserId))
            {
                MessageBox.Show("User belum login.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string query = @"SELECT b.id_booking, u.nama, m.merk_mobil, b.tanggal_booking, b.tanggal_mulai, 
                                    b.tanggal_selesai, b.durasi_hari, b.jam_pengambilan_mobil, 
                                    b.jam_pengembalian_mobil, b.status_booking
                             FROM Booking b
                             JOIN Users u ON b.id_user = u.id_user
                             JOIN Mobil m ON b.id_mobil = m.id_mobil
                             WHERE b.tanggal_booking BETWEEN @tglAwal AND @tglAkhir AND b.id_user = @userId";

            using (SqlConnection conn = dbConnection.GetConnection())
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.Add("@tglAwal", SqlDbType.Date).Value = dateTimePicker1.Value.Date;
                cmd.Parameters.Add("@tglAkhir", SqlDbType.Date).Value = dateTimePicker2.Value.Date;
                cmd.Parameters.Add("@userId", SqlDbType.VarChar, 6).Value = currentUserId;

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridViewBooking.DataSource = dt;
            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            btnLihatData_Click(sender, e);
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            btnLihatData_Click(sender, e);
        }

        private void dataGridViewBooking_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridViewBooking.Rows[e.RowIndex];
                string detailInfo = $"ID Booking: {row.Cells["id_booking"].Value}\n" +
                                    $"Nama: {row.Cells["nama"].Value}\n" +
                                    $"Mobil: {row.Cells["merk_mobil"].Value}\n" +
                                    $"Tanggal Mulai: {row.Cells["tanggal_mulai"].Value}\n" +
                                    $"Tanggal Selesai: {row.Cells["tanggal_selesai"].Value}\n" +
                                    $"Status: {row.Cells["status_booking"].Value}";

                MessageBox.Show(detailInfo, "Detail Booking", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
