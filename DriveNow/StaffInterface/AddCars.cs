using System;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using DriveNow.DB;

namespace DriveNow
{
    public partial class AddCars : Form
    {
        string urlFotoMobil = "";

        public AddCars()
        {
            InitializeComponent();
        }

        private void AddCars_Load(object sender, EventArgs e)
        {
            comboBox_Transmisi.Items.AddRange(new[] { "Manual", "Matic" });
            comboBox_BBM.Items.AddRange(new[] { "Bensin", "Solar", "Listrik" });
            comboBox_Kategori.Items.AddRange(new[] { "SUV", "MPV", "Sedan", "Hatchback", "Pickup" });
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string platNomor = txtPlatNomor.Text.Trim();
            string merkMobil = txtMerk.Text.Trim();
            string warna = txtWarna.Text.Trim();
            string kategori = comboBox_Kategori.Text.Trim();
            string transmisi = comboBox_Transmisi.Text.Trim();
            string bbm = comboBox_BBM.Text.Trim();
            int kapasitas = (int)numericUpDown_Kapasitas.Value;
            string hargaStr = txtHarga.Text.Trim();

            if (string.IsNullOrWhiteSpace(platNomor) || string.IsNullOrWhiteSpace(merkMobil) || string.IsNullOrWhiteSpace(warna) ||
                string.IsNullOrWhiteSpace(kategori) || string.IsNullOrWhiteSpace(transmisi) || string.IsNullOrWhiteSpace(bbm) ||
                string.IsNullOrWhiteSpace(hargaStr) || string.IsNullOrWhiteSpace(urlFotoMobil))
            {
                MessageBox.Show("Semua field wajib diisi.", "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!decimal.TryParse(hargaStr, out decimal harga))
            {
                MessageBox.Show("Harga tidak valid.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Copy image
            string targetDir = Path.Combine(Application.StartupPath, "img_mobil");
            if (!Directory.Exists(targetDir)) Directory.CreateDirectory(targetDir);

            string fileName = Path.GetFileName(urlFotoMobil);
            string destPath = Path.Combine(targetDir, fileName);

            // Cegah overwrite file lama dengan nama sama
            int counter = 1;
            string baseName = Path.GetFileNameWithoutExtension(fileName);
            string extension = Path.GetExtension(fileName);
            while (File.Exists(destPath))
            {
                fileName = $"{baseName}_{counter}{extension}";
                destPath = Path.Combine(targetDir, fileName);
                counter++;
            }

            File.Copy(urlFotoMobil, destPath);

            // Simpan full path
            string fullPathToSave = destPath;

            using (SqlConnection conn = dbConnection.GetConnection())
            {
                try
                {
                    conn.Open();

                    // Cek plat
                    string checkQuery = "SELECT COUNT(*) FROM Mobil WHERE id_mobil = @plat";
                    SqlCommand checkCmd = new SqlCommand(checkQuery, conn);
                    checkCmd.Parameters.AddWithValue("@plat", platNomor);
                    int exists = (int)checkCmd.ExecuteScalar();

                    if (exists > 0)
                    {
                        MessageBox.Show("Plat nomor sudah terdaftar!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    string query = @"INSERT INTO Mobil 
                        (id_mobil, merk_mobil, warna, kategori, tipe_transmisi, jenis_bbm, kapasitas, harga_sewa_per_hari, url_foto_mobil, status_mobil)
                        VALUES (@plat, @merk, @warna, @kategori, @transmisi, @bbm, @kapasitas, @harga, @foto, 'Available')";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@plat", platNomor);
                        cmd.Parameters.AddWithValue("@merk", merkMobil);
                        cmd.Parameters.AddWithValue("@warna", warna);
                        cmd.Parameters.AddWithValue("@kategori", kategori);
                        cmd.Parameters.AddWithValue("@transmisi", transmisi);
                        cmd.Parameters.AddWithValue("@bbm", bbm);
                        cmd.Parameters.AddWithValue("@kapasitas", kapasitas);
                        cmd.Parameters.AddWithValue("@harga", harga);
                        cmd.Parameters.AddWithValue("@foto", fullPathToSave);

                        int result = cmd.ExecuteNonQuery();
                        if (result > 0)
                        {
                            MessageBox.Show("Data mobil berhasil disimpan!", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            ClearForm();
                        }
                        else
                        {
                            MessageBox.Show("Gagal menyimpan data.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Terjadi kesalahan: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnImport_Click_1(object sender, EventArgs e)
        {
            using (OpenFileDialog open = new OpenFileDialog { Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp" })
            {
                if (open.ShowDialog() == DialogResult.OK)
                {
                    urlFotoMobil = open.FileName;
                    pictureCar.Image = Image.FromFile(urlFotoMobil);
                    pictureCar.SizeMode = PictureBoxSizeMode.StretchImage;
                }
            }
        }

        private void btnCancel_Click_1(object sender, EventArgs e)
        {
            var confirm = MessageBox.Show("Apakah Anda yakin ingin membatalkan?", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm == DialogResult.Yes) this.Close();
        }

        private void ClearForm()
        {
            txtPlatNomor.Clear();
            txtMerk.Clear();
            txtWarna.Clear();
            comboBox_Kategori.SelectedIndex = -1;
            comboBox_Transmisi.SelectedIndex = -1;
            comboBox_BBM.SelectedIndex = -1;
            numericUpDown_Kapasitas.Value = 0;
            txtHarga.Clear();
            pictureCar.Image = null;
            urlFotoMobil = "";
        }
    }
}
