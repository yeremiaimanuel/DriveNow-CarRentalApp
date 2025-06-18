using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DriveNow.DB;

namespace DriveNow
{
    public partial class ViewCustomer : Form
    {
        private string currentFotoFileName = "";

        public ViewCustomer()
        {
            InitializeComponent();
            dataGridViewMobil.CellClick += dataGridViewMobil_CellClick;
        }

        public static class DBHelper
        {
            public static string ConnStr = @"Data Source=YERE\SQLEXPRESS;Initial Catalog=db_drivenow;Integrated Security=True;TrustServerCertificate=True";
        }

        private void panel2_Paint(object sender, PaintEventArgs e) { }

        private void LoadCustomers(string keyword = "")
        {
            using (SqlConnection conn = new SqlConnection(DBHelper.ConnStr))
            {
                conn.Open();
                string query = @"
                    SELECT u.id_user, u.nama, u.email, u.urlfoto, p.alamat, p.no_hp, p.no_sim
                    FROM Users u
                    JOIN Pelanggan p ON u.id_user = p.id_user
                    WHERE u.role = 'pelanggan'";

                if (!string.IsNullOrWhiteSpace(keyword))
                {
                    query += " AND (u.nama LIKE @kw OR u.email LIKE @kw)";
                }

                SqlCommand cmd = new SqlCommand(query, conn);
                if (!string.IsNullOrWhiteSpace(keyword))
                    cmd.Parameters.AddWithValue("@kw", "%" + keyword + "%");

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dataGridViewMobil.DataSource = dt;
            }
        }

        private void ViewCustomerInformation_Load(object sender, EventArgs e)
        {
            LoadCustomers();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            txtSearch.Text = "";
            LoadCustomers();
        }

        private void dataGridViewMobil_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    var row = dataGridViewMobil.Rows[e.RowIndex];
                    txtNama.Text = row.Cells["nama"].Value?.ToString();
                    txtEmail.Text = row.Cells["email"].Value?.ToString();
                    txtAlamat.Text = row.Cells["alamat"].Value?.ToString();
                    txtTelepon.Text = row.Cells["no_hp"].Value?.ToString();
                    txtSIM.Text = row.Cells["no_sim"].Value?.ToString();

                    string foto = row.Cells["urlfoto"].Value?.ToString();
                    currentFotoFileName = foto;
                    string path = Path.Combine(Application.StartupPath, "img_customer", foto);
                    pictureBoxCustomer.Image = File.Exists(path) ? Image.FromFile(path) : null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtEmail.Text)) return;

            var confirm = MessageBox.Show("Yakin ingin menghapus data pelanggan ini?", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (confirm == DialogResult.Yes)
            {
                using (SqlConnection conn = new SqlConnection(DBHelper.ConnStr))
                {
                    conn.Open();

                    string delete1 = "DELETE FROM Pelanggan WHERE id_user = (SELECT id_user FROM Users WHERE email = @em)";
                    string delete2 = "DELETE FROM Users WHERE email = @em";

                    SqlCommand cmd1 = new SqlCommand(delete1, conn);
                    cmd1.Parameters.AddWithValue("@em", txtEmail.Text);

                    SqlCommand cmd2 = new SqlCommand(delete2, conn);
                    cmd2.Parameters.AddWithValue("@em", txtEmail.Text);

                    cmd1.ExecuteNonQuery();
                    cmd2.ExecuteNonQuery();

                    MessageBox.Show("Data pelanggan dihapus.");
                    LoadCustomers();
                }
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtEmail.Text)) return;

            using (SqlConnection conn = new SqlConnection(DBHelper.ConnStr))
            {
                conn.Open();
                string query1 = "UPDATE Users SET nama = @nama, urlfoto = @foto WHERE email = @em";
                string query2 = "UPDATE Pelanggan SET alamat = @alamat, no_hp = @nohp, no_sim = @nosim WHERE id_user = (SELECT id_user FROM Users WHERE email = @em)";

                SqlCommand cmd1 = new SqlCommand(query1, conn);
                cmd1.Parameters.AddWithValue("@nama", txtNama.Text.Trim());
                cmd1.Parameters.AddWithValue("@foto", currentFotoFileName);
                cmd1.Parameters.AddWithValue("@em", txtEmail.Text.Trim());

                SqlCommand cmd2 = new SqlCommand(query2, conn);
                cmd2.Parameters.AddWithValue("@alamat", txtAlamat.Text.Trim());
                cmd2.Parameters.AddWithValue("@nohp", txtTelepon.Text.Trim());
                cmd2.Parameters.AddWithValue("@nosim", txtSIM.Text.Trim());
                cmd2.Parameters.AddWithValue("@em", txtEmail.Text.Trim());

                cmd1.ExecuteNonQuery();
                cmd2.ExecuteNonQuery();

                MessageBox.Show("Data pelanggan berhasil diperbarui.");
                LoadCustomers();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            txtNama.Clear();
            txtEmail.Clear();
            txtAlamat.Clear();
            txtTelepon.Clear();
            txtSIM.Clear();
            pictureBoxCustomer.Image = null;
            currentFotoFileName = "";
            txtSearch.Clear();
            LoadCustomers();
        }

        private void txtSearch_TextChanged_1(object sender, EventArgs e)
        {
            LoadCustomers(txtSearch.Text.Trim());
        }

        private void btnImportFoto_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif";
            openFileDialog.Title = "Pilih Foto Pelanggan";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;
                string fileName = Path.GetFileName(filePath);
                string targetFolder = Path.Combine(Application.StartupPath, "img_customer");
                string targetPath = Path.Combine(targetFolder, fileName);

                try
                {
                    if (!Directory.Exists(targetFolder))
                        Directory.CreateDirectory(targetFolder);

                    File.Copy(filePath, targetPath, true);
                    pictureBoxCustomer.Image = Image.FromFile(targetPath);
                    pictureBoxCustomer.SizeMode = PictureBoxSizeMode.StretchImage;

                    currentFotoFileName = fileName;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Gagal mengimpor foto: " + ex.Message);
                }
            }
        }
    }
}
