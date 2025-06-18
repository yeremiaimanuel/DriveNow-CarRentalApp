using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Windows.Forms;
using DriveNow.DB; 

namespace DriveNow.Customer
{
    public partial class ViewPayment : Form
    {
        public ViewPayment()
        {
            InitializeComponent();
        }

        private void btnLihatData_Click(object sender, EventArgs e)
        {
            string userId = SessionManager.LoggedInUserId;
            if (string.IsNullOrEmpty(userId))
            {
                MessageBox.Show("User belum login.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string query = @"
                SELECT p.id_pembayaran, p.id_transaksi, p.tanggal_pembayaran, p.metode_pembayaran,
                       p.nama_bank_pengirim, p.bukti_pembayaran, p.status_pembayaran
                FROM Pembayaran p
                JOIN Transaksi t ON p.id_transaksi = t.id_transaksi
                WHERE t.id_user = @userId AND p.tanggal_pembayaran BETWEEN @tglAwal AND @tglAkhir";

            using (SqlConnection conn = dbConnection.GetConnection())
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@userId", userId);
                cmd.Parameters.AddWithValue("@tglAwal", dateTimePicker1.Value.Date);
                cmd.Parameters.AddWithValue("@tglAkhir", dateTimePicker2.Value.Date);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridViewPayment.DataSource = dt;
            }
        }

        private void btnExportToFile_Click(object sender, EventArgs e)
        {
            if (dataGridViewPayment.Rows.Count == 0)
            {
                MessageBox.Show("Tidak ada data untuk diekspor.", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "Text File (*.txt)|*.txt",
                FileName = "LaporanPembayaran.txt"
            };

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    using (StreamWriter sw = new StreamWriter(saveFileDialog.FileName))
                    {
                        for (int i = 0; i < dataGridViewPayment.Columns.Count; i++)
                        {
                            sw.Write(dataGridViewPayment.Columns[i].HeaderText);
                            if (i < dataGridViewPayment.Columns.Count - 1)
                                sw.Write("\t");
                        }
                        sw.WriteLine();

                        foreach (DataGridViewRow row in dataGridViewPayment.Rows)
                        {
                            if (!row.IsNewRow)
                            {
                                for (int i = 0; i < dataGridViewPayment.Columns.Count; i++)
                                {
                                    sw.Write(row.Cells[i].Value?.ToString());
                                    if (i < dataGridViewPayment.Columns.Count - 1)
                                        sw.Write("\t");
                                }
                                sw.WriteLine();
                            }
                        }
                    }

                    MessageBox.Show("Data berhasil diekspor ke file TXT.", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Terjadi kesalahan saat ekspor: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
