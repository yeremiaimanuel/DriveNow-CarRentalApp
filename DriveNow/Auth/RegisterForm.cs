using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using DriveNow.DB;
using static DriveNow.ViewCustomer;

namespace DriveNow
{
    public partial class RegisterForm : Form
    {
        public RegisterForm()
        {
            InitializeComponent();
        }

        private void showPw_CheckedChanged(object sender, EventArgs e)
        {
            register_password.PasswordChar = showPw.Checked ? '\0' : '*';
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(register_nama.Text) ||
                string.IsNullOrWhiteSpace(register_email.Text) ||
                string.IsNullOrWhiteSpace(register_alamat.Text) ||
                string.IsNullOrWhiteSpace(register_telepon.Text) ||
                string.IsNullOrWhiteSpace(register_password.Text))
            {
                MessageBox.Show("Semua field wajib diisi.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (SqlConnection conn = new SqlConnection(DBHelper.ConnStr))
            {
                try
                {
                    conn.Open();
                    string userId = "";
                    using (SqlCommand cmdId = new SqlCommand("SELECT MAX(RIGHT(id_user, 3)) FROM Users WHERE id_user LIKE 'USR%'", conn))
                    {
                        object result = cmdId.ExecuteScalar();
                        int nextNumber = 1;
                        if (result != DBNull.Value && int.TryParse(result.ToString(), out int lastNumber))
                        {
                            nextNumber = lastNumber + 1;
                        }
                        userId = "USR" + nextNumber.ToString("D3");
                    }

                    string insertUser = @"
                        INSERT INTO Users (id_user, nama, email, password, role, urlfoto) 
                        VALUES (@id, @nama, @email, @password, 'pelanggan', 'default.jpg');

                        INSERT INTO Pelanggan (id_user, alamat, no_hp, no_sim, username) 
                        VALUES (@id, @alamat, @telepon, 'SIMAUTO', @username);
                    ";

                    using (SqlCommand cmd = new SqlCommand(insertUser, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", userId);
                        cmd.Parameters.AddWithValue("@nama", register_nama.Text.Trim());
                        cmd.Parameters.AddWithValue("@username", register_nama.Text.Trim());
                        cmd.Parameters.AddWithValue("@email", register_email.Text.Trim());
                        cmd.Parameters.AddWithValue("@password", register_password.Text.Trim());
                        cmd.Parameters.AddWithValue("@alamat", register_alamat.Text.Trim());
                        cmd.Parameters.AddWithValue("@telepon", register_telepon.Text.Trim());

                        cmd.ExecuteNonQuery();
                    }

                    MessageBox.Show("Registrasi berhasil!", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    new LoginForm().Show();
                    this.Hide();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Terjadi kesalahan: " + ex.Message);
                }
            }
        }

        private void btnSignIn_Click(object sender, EventArgs e)
        {
            new LoginForm().Show();
            this.Hide();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void register_nama_MouseClick(object sender, MouseEventArgs e)
        {
            if (register_nama.Text == "Nama")
                register_nama.Clear();
        }

        private void register_nama_MouseEnter(object sender, EventArgs e)
        {
            if (register_nama.Text == "Nama")
                register_nama.Clear();
        }

        private void register_email_MouseClick(object sender, MouseEventArgs e)
        {
            if (register_email.Text == "Email Address")
                register_email.Clear();
        }

        private void register_email_MouseEnter(object sender, EventArgs e)
        {
            if (register_email.Text == "Email Address")
                register_email.Clear();
        }

        private void register_alamat_MouseClick(object sender, MouseEventArgs e)
        {
            if (register_alamat.Text == "Alamat")
                register_alamat.Clear();
        }

        private void register_alamat_MouseEnter(object sender, EventArgs e)
        {
            if (register_alamat.Text == "Alamat")
                register_alamat.Clear();
        }

        private void register_telepon_MouseEnter(object sender, EventArgs e)
        {
            if (register_telepon.Text == "No Telepon")
                register_telepon.Clear();
        }

        private void register_telepon_MouseClick(object sender, MouseEventArgs e)
        {
            if (register_telepon.Text == "No Telepon")
                register_telepon.Clear();
        }

        private void register_password_MouseClick(object sender, MouseEventArgs e)
        {
            if (register_password.Text == "Password")
            {
                register_password.Clear();
                register_password.PasswordChar = '*';
            }
        }
    }
}
