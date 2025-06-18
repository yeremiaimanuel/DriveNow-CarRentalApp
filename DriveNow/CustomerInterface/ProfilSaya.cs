using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Net;
using System.Windows.Forms;
using DriveNow.DB;

namespace DriveNow.Customer
{
    public partial class ProfilSaya : Form
    {
        private string fotoPath = "";

        public ProfilSaya()
        {
            InitializeComponent();
            this.Load += ProfilSaya_Load;
        }

        private void ProfilSaya_Load(object sender, EventArgs e)
        {
            this.ControlBox = false;

            string email = SessionManager.LoggedInUserEmail;
            if (string.IsNullOrEmpty(email))
            {
                MessageBox.Show("Email pengguna belum tersedia. Silakan login ulang.", "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

            string query = @"
                SELECT u.id_user, u.nama, u.email, u.urlfoto,
                       p.alamat, p.no_hp, p.no_sim, p.username
                FROM Users u
                INNER JOIN Pelanggan p ON u.id_user = p.id_user
                WHERE u.email = @Email";

            using (SqlConnection conn = dbConnection.GetConnection())
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@Email", email);

                try
                {
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        txtNama.Text = reader["nama"].ToString();
                        txtAlamat.Text = reader["alamat"].ToString();
                        textTelp.Text = reader["no_hp"].ToString();
                        textSIM.Text = reader["no_sim"].ToString();
                        txtEmail.Text = reader["email"].ToString();
                        txtUsername.Text = reader["username"].ToString();
                        txtUsername.ReadOnly = true;

                        fotoPath = reader["urlfoto"].ToString();
                        LoadFotoProfil(fotoPath);
                    }
                    else
                    {
                        MessageBox.Show("Data pelanggan tidak ditemukan.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.Close();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Gagal memuat data profil: " + ex.Message);
                    this.Close();
                }
            }
        }

        private void LoadFotoProfil(string path)
        {
            try
            {
                string fallbackPath = Path.Combine(Application.StartupPath, "Asset", "default_user.png");

                if (!string.IsNullOrEmpty(path))
                {
                    if (File.Exists(path))
                    {
                        pictureBoxFotoProfil.Image = Image.FromFile(path);
                    }
                    else if (Uri.IsWellFormedUriString(path, UriKind.Absolute))
                    {
                        using (WebClient client = new WebClient())
                        {
                            byte[] imageData = client.DownloadData(path);
                            using (MemoryStream ms = new MemoryStream(imageData))
                            {
                                pictureBoxFotoProfil.Image = Image.FromStream(ms);
                            }
                        }
                    }
                    else if (File.Exists(fallbackPath))
                    {
                        pictureBoxFotoProfil.Image = Image.FromFile(fallbackPath);
                    }
                    else
                    {
                        pictureBoxFotoProfil.Image = null;
                    }
                }
                else if (File.Exists(fallbackPath))
                {
                    pictureBoxFotoProfil.Image = Image.FromFile(fallbackPath);
                }
                else
                {
                    pictureBoxFotoProfil.Image = null;
                }

                pictureBoxFotoProfil.SizeMode = PictureBoxSizeMode.StretchImage;
            }
            catch
            {
                pictureBoxFotoProfil.Image = null;
                pictureBoxFotoProfil.SizeMode = PictureBoxSizeMode.StretchImage;
            }
        }

        private void btnEditFoto_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog
            {
                Title = "Pilih Foto Profil",
                Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp"
            };

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                fotoPath = dialog.FileName;
                try
                {
                    pictureBoxFotoProfil.Image = Image.FromFile(fotoPath);
                    pictureBoxFotoProfil.SizeMode = PictureBoxSizeMode.StretchImage;
                }
                catch
                {
                    MessageBox.Show("Gagal menampilkan gambar yang dipilih.");
                }
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string nama = txtNama.Text.Trim();
            string alamat = txtAlamat.Text.Trim();
            string telp = textTelp.Text.Trim();
            string sim = textSIM.Text.Trim();
            string email = txtEmail.Text.Trim();

            if (string.IsNullOrWhiteSpace(nama) || string.IsNullOrWhiteSpace(email))
            {
                MessageBox.Show("Nama dan Email wajib diisi.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (SqlConnection conn = dbConnection.GetConnection())
            {
                try
                {
                    conn.Open();

                    string updateUsers = @"
                        UPDATE Users 
                        SET nama = @Nama, urlfoto = @Foto 
                        WHERE email = @Email";
                    using (SqlCommand cmdUser = new SqlCommand(updateUsers, conn))
                    {
                        cmdUser.Parameters.AddWithValue("@Nama", nama);
                        cmdUser.Parameters.AddWithValue("@Foto", fotoPath);
                        cmdUser.Parameters.AddWithValue("@Email", email);
                        cmdUser.ExecuteNonQuery();
                    }

                    string updatePelanggan = @"
                        UPDATE Pelanggan 
                        SET alamat = @Alamat, no_hp = @NoHp, no_sim = @NoSim
                        WHERE id_user = (SELECT id_user FROM Users WHERE email = @Email)";
                    using (SqlCommand cmdPelanggan = new SqlCommand(updatePelanggan, conn))
                    {
                        cmdPelanggan.Parameters.AddWithValue("@Alamat", alamat);
                        cmdPelanggan.Parameters.AddWithValue("@NoHp", telp);
                        cmdPelanggan.Parameters.AddWithValue("@NoSim", sim);
                        cmdPelanggan.Parameters.AddWithValue("@Email", email);
                        cmdPelanggan.ExecuteNonQuery();
                    }

                    MessageBox.Show("Profil berhasil diperbarui.", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Gagal memperbarui data: " + ex.Message);
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBoxFotoProfil_Click(object sender, EventArgs e)
        {
            btnEditFoto_Click(sender, e);
        }
    }
}
