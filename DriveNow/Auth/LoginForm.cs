using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using DriveNow.Customer;
using DriveNow.DB;
using DriveNow.Staff;
using static DriveNow.ViewCustomer;

namespace DriveNow
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
            txtEmail.Text = "Email";
            txtPassword.Text = "Password";
            txtPassword.PasswordChar = '\0';
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void txtEmail_MouseEnter(object sender, EventArgs e)
        {
            if (txtEmail.Text == "Email")
                txtEmail.Clear();
        }

        private void txtEmail_MouseClick(object sender, MouseEventArgs e)
        {
            if (txtEmail.Text == "Email")
                txtEmail.Clear();
        }

        private void txtPassword_MouseClick(object sender, MouseEventArgs e)
        {
            if (txtPassword.Text == "Password")
            {
                txtPassword.Clear();
                txtPassword.PasswordChar = '*';
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (txtEmail.Text == "Email" || txtPassword.Text == "Password")
            {
                MessageBox.Show("Silakan isi email dan password terlebih dahulu.", "Input Kosong", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (SqlConnection conn = new SqlConnection(DBHelper.ConnStr))
            {
                try
                {
                    conn.Open();
                    string query = @"
                        SELECT id_user, nama, role 
                        FROM [Users] 
                        WHERE email = @email AND password = @password";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@email", txtEmail.Text.Trim());
                        cmd.Parameters.AddWithValue("@password", txtPassword.Text.Trim());

                        SqlDataReader reader = cmd.ExecuteReader();
                        if (reader.Read())
                        {
                            string userId = reader["id_user"].ToString();
                            string namaUser = reader["nama"].ToString();
                            string role = reader["role"].ToString();

                            SessionManager.LoggedInUserId = userId;
                            SessionManager.LoggedInUserEmail = txtEmail.Text.Trim();

                            MessageBox.Show($"Welcome, {namaUser}!\nYou are logged in as {role}.", "Login Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            if (role == "staff" || role == "admin")
                            {
                                new StaffDashboard(userId).Show();
                            }
                            else if (role == "pelanggan")
                            {
                                new UserDashboard(userId).Show();
                            }
                            else
                            {
                                MessageBox.Show("Role tidak dikenali, hubungi admin.", "Login Gagal", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }

                            this.Hide();
                        }
                        else
                        {
                            MessageBox.Show("Email atau password salah", "Login Gagal", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Terjadi kesalahan: " + ex.Message);
                }
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            txtPassword.PasswordChar = checkBox1.Checked ? '\0' : '*';
        }

        private void button2_Click(object sender, EventArgs e)
        {
            new RegisterForm().Show();
            this.Hide();
        }
    }
}
