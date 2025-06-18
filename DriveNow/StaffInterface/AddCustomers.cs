using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using DriveNow.DB; 

namespace DriveNow
{
    public partial class AddCustomers : Form
    {
        private string fotoPath = "";

        public AddCustomers()
        {
            InitializeComponent();
        }

        private void AddCustomers_Load(object sender, EventArgs e)
        {
            txtPw.PasswordChar = '*';
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            txtPw.PasswordChar = checkBox1.Checked ? '\0' : '*';
        }

        private void btnImportFoto_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "Image Files|*.jpg;*.jpeg;*.png";
            if (open.ShowDialog() == DialogResult.OK)
            {
                fotoPath = open.FileName;
                pictureBoxFoto.Image = Image.FromFile(fotoPath);
                pictureBoxFoto.SizeMode = PictureBoxSizeMode.StretchImage;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private string GenerateNextUserId()
        {
            using (SqlConnection conn = dbConnection.GetConnection())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT MAX(RIGHT(id_user, 3)) FROM Users WHERE id_user LIKE 'USR%'", conn);
                object result = cmd.ExecuteScalar();
                int nextNumber = 1;

                if (result != DBNull.Value && int.TryParse(result.ToString(), out int lastNumber))
                {
                    nextNumber = lastNumber + 1;
                }

                return "USR" + nextNumber.ToString("D3");
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string id = GenerateNextUserId();
            string nama = txtNama.Text.Trim();
            string email = txtEmail.Text.Trim();
            string alamat = richTextBoxAlamat.Text.Trim();
            string telp = txtTelp.Text.Trim();
            string sim = txtSIM.Text.Trim();
            string pw = txtPw.Text.Trim();
            string username = email.Contains("@") ? email.Split('@')[0] : email;
            string foto = Path.GetFileName(fotoPath);

            if (string.IsNullOrWhiteSpace(nama) || string.IsNullOrWhiteSpace(email) ||
                string.IsNullOrWhiteSpace(alamat) || string.IsNullOrWhiteSpace(telp) ||
                string.IsNullOrWhiteSpace(sim) || string.IsNullOrWhiteSpace(pw) || string.IsNullOrEmpty(fotoPath))
            {
                MessageBox.Show("Semua field dan foto harus diisi!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string folderPath = Path.Combine(Application.StartupPath, "img_customer");
            if (!Directory.Exists(folderPath))
                Directory.CreateDirectory(folderPath);

            string savePath = Path.Combine(folderPath, foto);
            try
            {
                File.Copy(fotoPath, savePath, true);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal menyimpan foto: " + ex.Message, "Foto Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using (SqlConnection conn = dbConnection.GetConnection())
            {
                conn.Open();
                SqlTransaction trans = conn.BeginTransaction();

                try
                {
                    string insertUser = "INSERT INTO Users (id_user, nama, email, password, role, urlfoto) " +
                                        "VALUES (@id, @nama, @email, @pw, 'pelanggan', @foto)";
                    using (SqlCommand cmdUser = new SqlCommand(insertUser, conn, trans))
                    {
                        cmdUser.Parameters.AddWithValue("@id", id);
                        cmdUser.Parameters.AddWithValue("@nama", nama);
                        cmdUser.Parameters.AddWithValue("@email", email);
                        cmdUser.Parameters.AddWithValue("@pw", pw);
                        cmdUser.Parameters.AddWithValue("@foto", foto);
                        cmdUser.ExecuteNonQuery();
                    }

                    string insertPelanggan = "INSERT INTO Pelanggan (id_user, alamat, no_hp, no_sim, username) " +
                                             "VALUES (@id, @alamat, @telp, @sim, @username)";
                    using (SqlCommand cmdPelanggan = new SqlCommand(insertPelanggan, conn, trans))
                    {
                        cmdPelanggan.Parameters.AddWithValue("@id", id);
                        cmdPelanggan.Parameters.AddWithValue("@alamat", alamat);
                        cmdPelanggan.Parameters.AddWithValue("@telp", telp);
                        cmdPelanggan.Parameters.AddWithValue("@sim", sim);
                        cmdPelanggan.Parameters.AddWithValue("@username", username);
                        cmdPelanggan.ExecuteNonQuery();
                    }

                    trans.Commit();
                    MessageBox.Show("Pelanggan berhasil ditambahkan!", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                catch (Exception ex)
                {
                    trans.Rollback();
                    MessageBox.Show("Gagal menambahkan pelanggan: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
