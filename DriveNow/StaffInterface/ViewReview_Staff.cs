using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using DriveNow.DB;
using static DriveNow.ViewCustomer;

namespace DriveNow
{
    public partial class ViewReview_Staff : Form
    {
        public ViewReview_Staff()
        {
            InitializeComponent();
            this.Load += ViewReview_Staff_Load;
        }

        private void ViewReview_Staff_Load(object sender, EventArgs e)
        {
            LoadReviews();
        }

        private void LoadReviews(string keyword = "")
        {
            using (SqlConnection conn = new SqlConnection(DBHelper.ConnStr))
            {
                string query = @"SELECT u.nama AS [Nama Customer], m.merk_mobil AS [Mobil], 
                                        ul.komentar AS [Komentar], ul.rating AS [Rating], ul.tanggal_ulasan AS [Tanggal]
                                 FROM Ulasan ul
                                 JOIN Users u ON ul.id_user = u.id_user
                                 JOIN Mobil m ON ul.id_mobil = m.id_mobil";

                if (!string.IsNullOrWhiteSpace(keyword))
                {
                    query += " WHERE u.nama LIKE @kw OR m.merk_mobil LIKE @kw OR ul.komentar LIKE @kw";
                }

                SqlCommand cmd = new SqlCommand(query, conn);
                if (!string.IsNullOrWhiteSpace(keyword))
                    cmd.Parameters.AddWithValue("@kw", "%" + keyword + "%");

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dataGridViewReview.DataSource = dt;
                dataGridViewReview.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dataGridViewReview.ReadOnly = true;
            }
        }

        private void txtSeach_TextChanged(object sender, EventArgs e)
        {
            LoadReviews(txtSeach.Text.Trim());
        }

        private void btnExportToFile_Click(object sender, EventArgs e)
        {
            if (dataGridViewReview.Rows.Count == 0)
            {
                MessageBox.Show("Tidak ada data untuk diekspor.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Filter = "CSV file (*.csv)|*.csv";
                sfd.FileName = "UlasanCustomer_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".csv";

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        using (System.IO.StreamWriter sw = new System.IO.StreamWriter(sfd.FileName, false, Encoding.UTF8))
                        {
                            // Tulis header
                            for (int i = 0; i < dataGridViewReview.Columns.Count; i++)
                            {
                                sw.Write(dataGridViewReview.Columns[i].HeaderText);
                                if (i < dataGridViewReview.Columns.Count - 1) sw.Write(",");
                            }
                            sw.WriteLine();

                            // Tulis isi baris
                            foreach (DataGridViewRow row in dataGridViewReview.Rows)
                            {
                                if (!row.IsNewRow)
                                {
                                    for (int i = 0; i < dataGridViewReview.Columns.Count; i++)
                                    {
                                        string value = row.Cells[i].Value?.ToString()?.Replace(",", ";") ?? "";
                                        sw.Write(value);
                                        if (i < dataGridViewReview.Columns.Count - 1) sw.Write(",");
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
