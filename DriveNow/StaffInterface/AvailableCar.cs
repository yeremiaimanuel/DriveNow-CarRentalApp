using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using DriveNow.DB;

namespace DriveNow
{
    public partial class AvailableCar : Form
    {
        public AvailableCar()
        {
            InitializeComponent();
            this.Load += AvailableCar_Load;
        }

        private void AvailableCar_Load(object sender, EventArgs e)
        {
            LoadAvailableCars();
        }

        private void LoadAvailableCars(string keyword = "")
        {
            using (SqlConnection conn = dbConnection.GetConnection())
            {
                string query = "SELECT * FROM Mobil WHERE status_mobil = 'Available' AND merk_mobil LIKE @keyword";
                using (SqlDataAdapter da = new SqlDataAdapter(query, conn))
                {
                    da.SelectCommand.Parameters.AddWithValue("@keyword", "%" + keyword + "%");
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dataGridView1.DataSource = dt;
                }
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            LoadAvailableCars(txtSearch.Text.Trim());
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            LoadAvailableCars(txtSearch.Text.Trim());
        }
    }
}
