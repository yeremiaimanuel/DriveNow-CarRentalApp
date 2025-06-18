using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Net;
using System.Windows.Forms;
using DriveNow.DB;

namespace DriveNow
{
    public partial class ViewCar : Form
    {
        public ViewCar()
        {
            InitializeComponent();
        }

        private void ViewCar_Load(object sender, EventArgs e)
        {
            cmbKategori.Items.AddRange(new string[] { "SUV", "Sedan", "Hatchback", "MPV" });
            cmbBBM.Items.AddRange(new string[] { "Bensin", "Solar" });
            cmb_status.Items.AddRange(new string[] { "Tersedia", "Disewa", "Servis" });

            cmbKategori.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbBBM.DropDownStyle = ComboBoxStyle.DropDownList;
            cmb_status.DropDownStyle = ComboBoxStyle.DropDownList;

            LoadMobilData();
        }

        private void LoadMobilData()
        {
            using (SqlConnection conn = dbConnection.GetConnection())
            {
                try
                {
                    string query = "SELECT * FROM Mobil";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dataGridViewMobil.DataSource = dt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Gagal memuat data mobil: " + ex.Message);
                }
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            CariMobilBerdasarkanKeyword();
        }

        private void txtHarga_Leave(object sender, EventArgs e)
        {
            if (decimal.TryParse(txtHarga.Text, out decimal harga))
                txtHarga.Text = harga.ToString("N2");
        }

        private void dataGridViewMobil_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            DataGridViewRow selectedRow = dataGridViewMobil.Rows[e.RowIndex];
            string idMobil = selectedRow.Cells["id_mobil"].Value.ToString();
            panel1.Visible = true;

            using (SqlConnection conn = dbConnection.GetConnection())
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM Mobil WHERE id_mobil = @id", conn);
                cmd.Parameters.AddWithValue("@id", idMobil);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    DataRow row = dt.Rows[0];
                    txtPlatNomor.Text = row["id_mobil"].ToString();
                    txtMerk.Text = row["merk_mobil"].ToString();
                    txtWarna.Text = row["warna"].ToString();
                    cmbKategori.Text = row["kategori"].ToString();
                    cmbBBM.Text = row["jenis_bbm"].ToString();
                    cmbTransmisi.Text = row["tipe_transmisi"].ToString();
                    numericUpDown_Kapasitas.Value = Convert.ToInt32(row["kapasitas"]);
                    txtHarga.Text = Convert.ToDecimal(row["harga_sewa_per_hari"]).ToString("N2");
                    cmb_status.Text = row["status_mobil"].ToString();
                    txtFotoURL.Text = row["url_foto_mobil"].ToString();
                    LoadGambarMobilFromURL(row["url_foto_mobil"].ToString());
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridViewMobil.SelectedRows.Count == 0)
            {
                MessageBox.Show("Silakan pilih data yang ingin dihapus.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string idMobil = dataGridViewMobil.SelectedRows[0].Cells["id_mobil"].Value.ToString();
            var confirm = MessageBox.Show("Yakin ingin menghapus data ini?", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (confirm == DialogResult.Yes)
            {
                using (SqlConnection conn = dbConnection.GetConnection())
                {
                    try
                    {
                        conn.Open();
                        SqlCommand cmd = new SqlCommand("DELETE FROM Mobil WHERE id_mobil = @id", conn);
                        cmd.Parameters.AddWithValue("@id", idMobil);
                        int result = cmd.ExecuteNonQuery();

                        if (result > 0)
                        {
                            MessageBox.Show("Data berhasil dihapus.");
                            LoadMobilData();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Gagal menghapus data: " + ex.Message);
                    }
                }
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (dataGridViewMobil.SelectedRows.Count == 0)
            {
                MessageBox.Show("Silakan pilih data yang ingin diperbarui.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (SqlConnection conn = dbConnection.GetConnection())
            {
                try
                {
                    conn.Open();
                    string query = @"UPDATE Mobil SET 
                                    merk_mobil = @merk,
                                    warna = @warna,
                                    kategori = @kategori,
                                    tipe_transmisi = @transmisi,
                                    jenis_bbm = @bbm,
                                    kapasitas = @kapasitas,
                                    harga_sewa_per_hari = @harga,
                                    status_mobil = @status,
                                    url_foto_mobil = @foto
                                WHERE id_mobil = @id";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@merk", txtMerk.Text.Trim());
                    cmd.Parameters.AddWithValue("@warna", txtWarna.Text.Trim());
                    cmd.Parameters.AddWithValue("@kategori", cmbKategori.Text.Trim());
                    cmd.Parameters.AddWithValue("@transmisi", cmbTransmisi.Text.Trim());
                    cmd.Parameters.AddWithValue("@bbm", cmbBBM.Text.Trim());
                    cmd.Parameters.AddWithValue("@kapasitas", (int)numericUpDown_Kapasitas.Value);
                    cmd.Parameters.AddWithValue("@harga", decimal.Parse(txtHarga.Text.Trim()));
                    cmd.Parameters.AddWithValue("@status", cmb_status.Text.Trim());
                    cmd.Parameters.AddWithValue("@foto", txtFotoURL.Text.Trim());
                    cmd.Parameters.AddWithValue("@id", txtPlatNomor.Text.Trim());

                    int result = cmd.ExecuteNonQuery();
                    if (result > 0)
                    {
                        MessageBox.Show("Data berhasil diupdate.");
                        LoadMobilData();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Gagal update data: " + ex.Message);
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            txtPlatNomor.Clear();
            txtMerk.Clear();
            txtWarna.Clear();
            cmbKategori.SelectedIndex = -1;
            cmbBBM.SelectedIndex = -1;
            cmbTransmisi.SelectedIndex = -1;
            numericUpDown_Kapasitas.Value = 0;
            txtHarga.Clear();
            cmb_status.SelectedIndex = -1;
            txtFotoURL.Clear();
            pictureBoxMobil.Image = null;
        }

        private void LoadGambarMobilFromURL(string path)
        {
            try
            {
                if (File.Exists(path))
                {
                    pictureBoxMobil.Image = Image.FromFile(path);
                    pictureBoxMobil.SizeMode = PictureBoxSizeMode.StretchImage;
                }
                else
                {
                    using (WebClient client = new WebClient())
                    {
                        byte[] imageData = client.DownloadData(path);
                        using (MemoryStream ms = new MemoryStream(imageData))
                        {
                            pictureBoxMobil.Image = Image.FromStream(ms);
                            pictureBoxMobil.SizeMode = PictureBoxSizeMode.StretchImage;
                        }
                    }
                }
            }
            catch
            {
                pictureBoxMobil.Image = null;
            }
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif";
            openFileDialog.Title = "Pilih Gambar Mobil";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;

                try
                {
                    pictureBoxMobil.Image = Image.FromFile(filePath);
                    pictureBoxMobil.SizeMode = PictureBoxSizeMode.StretchImage;
                    txtFotoURL.Text = filePath;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Gagal memuat gambar: " + ex.Message);
                }
            }
        }

        private void CariMobilBerdasarkanKeyword()
        {
            string keyword = txtSearch.Text.Trim();
            using (SqlConnection conn = dbConnection.GetConnection())
            {
                string query = "SELECT * FROM Mobil WHERE merk_mobil LIKE @keyword";
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                da.SelectCommand.Parameters.AddWithValue("@keyword", "%" + keyword + "%");
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridViewMobil.DataSource = dt;
            }
        }

        private void txtSearch_TextChanged_1(object sender, EventArgs e)
        {
            CariMobilBerdasarkanKeyword();
        }
    }
}
