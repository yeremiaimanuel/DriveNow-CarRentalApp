using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using DriveNow.DB;

namespace DriveNow.Staff
{
    public partial class ViewBooking : Form
    {
        public ViewBooking()
        {
            InitializeComponent();
            this.Load += ViewBooking_Load;
        }

        private void ViewBooking_Load(object sender, EventArgs e)
        {
            LoadBookings();
        }

        private void LoadBookings(string keyword = "")
        {
            try
            {
                using (SqlConnection conn = dbConnection.GetConnection())
                {
                    string query = @"
                        SELECT b.id_booking, u.nama AS nama_user, m.merk_mobil AS nama_mobil, b.tanggal_booking, 
                               b.tanggal_mulai, b.tanggal_selesai, b.durasi_hari,
                               b.jam_pengambilan_mobil, b.jam_pengembalian_mobil, b.status_booking
                        FROM Booking b
                        JOIN Users u ON b.id_user = u.id_user
                        JOIN Mobil m ON b.id_mobil = m.id_mobil
                    ";

                    if (!string.IsNullOrWhiteSpace(keyword))
                    {
                        query += " WHERE b.id_booking LIKE @kw OR u.nama LIKE @kw OR b.status_booking LIKE @kw";
                    }

                    SqlCommand cmd = new SqlCommand(query, conn);
                    if (!string.IsNullOrWhiteSpace(keyword))
                    {
                        cmd.Parameters.AddWithValue("@kw", "%" + keyword + "%");
                    }

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dataGridViewBooking.DataSource = dt;
                    dataGridViewBooking.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal memuat data booking: " + ex.Message);
            }
        }

        private void txtSearch_TextChanged_1(object sender, EventArgs e)
        {
            LoadBookings(txtSearch.Text.Trim());
        }
    }
}
