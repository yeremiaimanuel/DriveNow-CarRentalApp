using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using DriveNow.DB;
using static DriveNow.ViewCustomer;

namespace DriveNow.Staff
{
    public partial class ViewTransaction : Form
    {
        public ViewTransaction()
        {
            InitializeComponent();
            this.Load += ViewTransaction_Load;
        }

        private void ViewTransaction_Load(object sender, EventArgs e)
        {
            LoadTransactions();
        }

        private void txtSeach_TextChanged(object sender, EventArgs e)
        {
            LoadTransactions(txtSeach.Text.Trim());
        }

        private void LoadTransactions(string keyword = "")
        {
            using (SqlConnection conn = new SqlConnection(DBHelper.ConnStr))
            {
                string query = @"
                    SELECT t.id_transaksi, t.id_booking, u.nama AS nama_pelanggan, t.tanggal_transaksi, t.total_pembayaran
                    FROM Transaksi t
                    JOIN Users u ON t.id_user = u.id_user
                ";

                if (!string.IsNullOrWhiteSpace(keyword))
                {
                    query += " WHERE t.id_transaksi LIKE @kw OR t.id_booking LIKE @kw OR u.nama LIKE @kw";
                }

                SqlCommand cmd = new SqlCommand(query, conn);
                if (!string.IsNullOrWhiteSpace(keyword))
                {
                    cmd.Parameters.AddWithValue("@kw", "%" + keyword + "%");
                }

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dataGridViewTransaction.DataSource = dt;
            }
        }

        private void btnExportToFile_Click(object sender, EventArgs e)
        {
            if (dataGridViewTransaction.Rows.Count == 0)
            {
                MessageBox.Show("Tidak ada data untuk diekspor.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Filter = "CSV file (*.csv)|*.csv";
                sfd.FileName = "Transaksi_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".csv";

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        using (System.IO.StreamWriter sw = new System.IO.StreamWriter(sfd.FileName))
                        {
                            // Tulis header
                            for (int i = 0; i < dataGridViewTransaction.Columns.Count; i++)
                            {
                                sw.Write(dataGridViewTransaction.Columns[i].HeaderText);
                                if (i < dataGridViewTransaction.Columns.Count - 1) sw.Write(",");
                            }
                            sw.WriteLine();

                            // Tulis isi baris
                            foreach (DataGridViewRow row in dataGridViewTransaction.Rows)
                            {
                                if (!row.IsNewRow)
                                {
                                    for (int i = 0; i < dataGridViewTransaction.Columns.Count; i++)
                                    {
                                        string value = row.Cells[i].Value?.ToString().Replace(",", ";") ?? "";
                                        sw.Write(value);
                                        if (i < dataGridViewTransaction.Columns.Count - 1) sw.Write(",");
                                    }
                                    sw.WriteLine();
                                }
                            }
                        }

                        MessageBox.Show("Data berhasil diekspor ke file.", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Gagal mengekspor file: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}
