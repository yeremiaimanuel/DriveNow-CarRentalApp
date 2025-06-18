using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using DriveNow.DB;
using DriveNow.Staff;

namespace DriveNow
{
    public partial class StaffDashboard : Form
    {
        private string idUser;
        private Timer refreshTimer;

        public StaffDashboard(string idUser)
        {
            InitializeComponent();
            this.idUser = idUser;
            LoadDashboardStats();

            // Timer untuk auto-refresh
            refreshTimer = new Timer();
            refreshTimer.Interval = 5000; // 10 detik
            refreshTimer.Tick += (s, e) => LoadDashboardStats();
            refreshTimer.Start();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure want to logout and return to login screen?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                new LoginForm().Show();
                this.Hide();
            }
        }

        private void addNewCarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new AddCars().Show();
        }

        private void viewCarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new ViewCar().Show();
        }

        private void transactionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new ViewTransaction().Show();
        }

        private void bookedToolStripMenuItem_Click(object sender, EventArgs e) { }

        private void addNewCustomerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new AddCustomers().Show();
        }

        private void vIewCustomerInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new ViewCustomer().Show();
        }

        private void availableCarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new AvailableCar().Show();
        }

        private void historyToolStripMenuItem_Click(object sender, EventArgs e) { }

        private void viewReviewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new ViewReview_Staff().Show();
        }

        private void addStaffToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string password = Prompt.ShowDialog("Masukkan Password:", "Verifikasi Staff");
            if (password == "admin123")
            {
                new AddStaff().Show();
            }
            else
            {
                MessageBox.Show("Password salah!", "Akses Ditolak", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        public static class Prompt
        {
            public static string ShowDialog(string text, string caption)
            {
                Form prompt = new Form()
                {
                    Width = 350,
                    Height = 150,
                    FormBorderStyle = FormBorderStyle.FixedDialog,
                    Text = caption,
                    StartPosition = FormStartPosition.CenterScreen
                };

                Label lblText = new Label() { Left = 20, Top = 20, Text = text, AutoSize = true };
                TextBox txtInput = new TextBox() { Left = 20, Top = 50, Width = 290, UseSystemPasswordChar = true };
                Button btnOk = new Button() { Text = "OK", Left = 150, Width = 75, Top = 80, DialogResult = DialogResult.OK };

                prompt.Controls.Add(lblText);
                prompt.Controls.Add(txtInput);
                prompt.Controls.Add(btnOk);
                prompt.AcceptButton = btnOk;

                return prompt.ShowDialog() == DialogResult.OK ? txtInput.Text : "";
            }
        }

        private void listStaffToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string password = Prompt.ShowDialog("Masukkan Password:", "Verifikasi Staff");
            if (password == "admin123")
            {
                new ViewStaff().Show();
            }
            else
            {
                MessageBox.Show("Password salah!", "Akses Ditolak", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void verifiactionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Verifikasi().Show();
        }

        private void viewBookingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new ViewBooking().Show();
        }

        private void LoadDashboardStats()
        {
            using (SqlConnection conn = dbConnection.GetConnection())
            {
                conn.Open();

                // 1. Jumlah mobil tersedia
                using (SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM Mobil WHERE status_mobil = 'Available'", conn))
                {
                    lblAvailableCar.Text = Convert.ToInt32(cmd.ExecuteScalar()).ToString();
                }

                // 2. Total pelanggan
                using (SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM Users WHERE role = 'pelanggan'", conn))
                {
                    lblTotalCustomer.Text = Convert.ToInt32(cmd.ExecuteScalar()).ToString();
                }

                // 3. Total pemasukan
                using (SqlCommand cmd = new SqlCommand("SELECT ISNULL(SUM(total_pembayaran),0) FROM Transaksi", conn))
                {
                    decimal totalIncome = Convert.ToDecimal(cmd.ExecuteScalar());
                    lblTotalIncome.Text = string.Format(new System.Globalization.CultureInfo("id-ID"), "{0:C0}", totalIncome);
                }

                // 4. Chart pelanggan per bulan
                chartCustomer.Series[0].Points.Clear();
                using (SqlCommand cmd = new SqlCommand(@"
                    SELECT FORMAT(waktu_input, 'MMM yyyy') AS Bulan, COUNT(*) AS Jumlah
                    FROM Users
                    WHERE role = 'pelanggan'
                    GROUP BY FORMAT(waktu_input, 'MMM yyyy')
                    ORDER BY MIN(waktu_input)", conn))
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        chartCustomer.Series[0].Points.AddXY(reader["Bulan"].ToString(), reader["Jumlah"]);
                    }
                }

                // 5. Chart pemasukan per bulan
                chartIncome.Series[0].Points.Clear();
                using (SqlCommand cmd = new SqlCommand(@"
                    SELECT FORMAT(tanggal_transaksi, 'MMM yyyy') AS Bulan, SUM(total_pembayaran) AS Jumlah
                    FROM Transaksi
                    GROUP BY FORMAT(tanggal_transaksi, 'MMM yyyy')
                    ORDER BY MIN(tanggal_transaksi)", conn))
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        chartIncome.Series[0].Points.AddXY(reader["Bulan"].ToString(), reader["Jumlah"]);
                    }
                }
            }
        }

        private void carDataReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new carData().Show();
        }

        private void bookingReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new bookingData().Show();
        }

        private void MonthlyStatisticsReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new MonthlySummary().Show();
        }

        private void paymentReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new paymentData().Show();
        }
    }
}
