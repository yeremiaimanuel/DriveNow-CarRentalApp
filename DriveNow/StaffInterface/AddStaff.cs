using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using DriveNow.DB; 

namespace DriveNow
{
    public partial class AddStaff : Form
    {
        private string fotoPath = string.Empty;

        public AddStaff()
        {
            InitializeComponent();
        }

        private void checkBoxShowPw_CheckedChanged(object sender, EventArgs e)
        {
            txtPw.PasswordChar = checkBoxShowPw.Checked ? '\0' : '*';
        }

        private void btnFoto_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif";
                ofd.Title = "Pilih Foto Staff";

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    fotoPath = ofd.FileName;
                    pictureBoxFoto.Image = Image.FromFile(fotoPath);
                    pictureBoxFoto.SizeMode = PictureBoxSizeMode.StretchImage;
                }
            }
        }

        private string GenerateNextUserId()
        {
            using (SqlConnection conn = dbConnection.GetConnection())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT TOP 1 id_user FROM Users WHERE id_user LIKE 'USR%' ORDER BY id_user DESC", conn);
                var result = cmd.ExecuteScalar();

                if (result != null)
                {
                    string lastId = result.ToString(); 
                    int num = int.Parse(lastId.Substring(3)) + 1;
                    return "USR" + num.ToString("D3"); 
                }
                else
                {
                    return "USR001";
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string nama = txtNama.Text.Trim();
            string email = txtEmail.Text.Trim();
            string password = txtPw.Text.Trim();
            string id = GenerateNextUserId();
            string fileName = string.IsNullOrEmpty(fotoPath) ? string.Empty : Path.GetFileName(fotoPath);

            if (string.IsNullOrWhiteSpace(nama) || string.IsNullOrWhiteSpace(email) ||
                string.IsNullOrWhiteSpace(password) || string.IsNullOrWhiteSpace(fotoPath))
            {
                MessageBox.Show("Semua field wajib diisi!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string targetDir = Path.Combine(Application.StartupPath, "img_staff");
            string destPath = Path.Combine(targetDir, fileName);

            try
            {
                if (!Directory.Exists(targetDir))
                    Directory.CreateDirectory(targetDir);

                if (!File.Exists(destPath))
                    File.Copy(fotoPath, destPath);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal menyimpan foto: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using (SqlConnection conn = dbConnection.GetConnection())
            {
                try
                {
                    conn.Open();

                    string insertUser = "INSERT INTO Users (id_user, nama, email, password, role, urlfoto) VALUES (@id, @nama, @email, @pw, 'staff', @foto)";
                    string insertStaff = "INSERT INTO Staff (id_user) VALUES (@id)";

                    using (SqlCommand cmdUser = new SqlCommand(insertUser, conn))
                    {
                        cmdUser.Parameters.AddWithValue("@id", id);
                        cmdUser.Parameters.AddWithValue("@nama", nama);
                        cmdUser.Parameters.AddWithValue("@email", email);
                        cmdUser.Parameters.AddWithValue("@pw", password);
                        cmdUser.Parameters.AddWithValue("@foto", fileName);
                        cmdUser.ExecuteNonQuery();
                    }

                    using (SqlCommand cmdStaff = new SqlCommand(insertStaff, conn))
                    {
                        cmdStaff.Parameters.AddWithValue("@id", id);
                        cmdStaff.ExecuteNonQuery();
                    }

                    MessageBox.Show("Staff berhasil ditambahkan.", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Gagal menambahkan staff: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}