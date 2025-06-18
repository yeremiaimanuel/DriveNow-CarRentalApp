using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using DriveNow.DB;
using static DriveNow.ViewCustomer;

namespace DriveNow.Staff
{
    public partial class ViewStaff : Form
    {
        private string currentUserRole = "Staff";
        private string selectedUserId = "";
        private string selectedFoto = "";

        public ViewStaff(string userRole = "Staff")
        {
            InitializeComponent();
            currentUserRole = userRole;
            this.Load += ViewStaff_Load;
            dataGridViewStaff.CellClick += dataGridViewStaff_CellClick;
        }

        private void ViewStaff_Load(object sender, EventArgs e)
        {
            LoadStaff();
            SetButtonAccess();
        }

        private void SetButtonAccess()
        {
            btnUpdate.Enabled = true;
            btnDelete.Enabled = true;
            txtNama.ReadOnly = false;
            txtEmail.ReadOnly = false;
            cmb_Role.Enabled = true;
        }

        private void LoadStaff(string keyword = "")
        {
            using (SqlConnection conn = new SqlConnection(DBHelper.ConnStr))
            {
                string query = @"SELECT u.id_user, u.nama, u.email, u.urlfoto, u.role
                                 FROM Users u
                                 JOIN Staff s ON u.id_user = s.id_user
                                 WHERE u.role = 'staff'";

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
                dataGridViewStaff.DataSource = dt;
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            LoadStaff(txtSearch.Text.Trim());
        }

        private void dataGridViewStaff_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridViewStaff.Rows[e.RowIndex];
                selectedUserId = row.Cells["id_user"].Value?.ToString();
                txtNama.Text = row.Cells["nama"].Value?.ToString();
                txtEmail.Text = row.Cells["email"].Value?.ToString();
                selectedFoto = row.Cells["urlfoto"].Value?.ToString();

                cmb_Role.Items.Clear();
                cmb_Role.Items.Add("admin");
                cmb_Role.Items.Add("staff");
                cmb_Role.SelectedItem = row.Cells["role"].Value?.ToString();

                string fotoPath = Path.Combine(Application.StartupPath, "img_staff", selectedFoto);
                pictureBoxFoto.Image = File.Exists(fotoPath) ? Image.FromFile(fotoPath) : null;
                pictureBoxFoto.SizeMode = PictureBoxSizeMode.StretchImage;
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(selectedUserId)) return;

            using (SqlConnection conn = new SqlConnection(DBHelper.ConnStr))
            {
                string query = "UPDATE Users SET nama = @nama, email = @email, role = @role, urlfoto = @foto WHERE id_user = @id";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@nama", txtNama.Text.Trim());
                cmd.Parameters.AddWithValue("@email", txtEmail.Text.Trim());
                cmd.Parameters.AddWithValue("@role", cmb_Role.SelectedItem?.ToString() ?? "staff");
                cmd.Parameters.AddWithValue("@foto", selectedFoto);
                cmd.Parameters.AddWithValue("@id", selectedUserId);

                conn.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Data staff berhasil diperbarui.");
                LoadStaff();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(selectedUserId)) return;
            var confirm = MessageBox.Show("Yakin ingin menghapus staff ini?", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (confirm == DialogResult.Yes)
            {
                using (SqlConnection conn = new SqlConnection(DBHelper.ConnStr))
                {
                    conn.Open();
                    SqlCommand cmd1 = new SqlCommand("DELETE FROM Staff WHERE id_user = @id", conn);
                    SqlCommand cmd2 = new SqlCommand("DELETE FROM Users WHERE id_user = @id", conn);
                    cmd1.Parameters.AddWithValue("@id", selectedUserId);
                    cmd2.Parameters.AddWithValue("@id", selectedUserId);
                    cmd1.ExecuteNonQuery();
                    cmd2.ExecuteNonQuery();
                    MessageBox.Show("Staff berhasil dihapus.");
                    LoadStaff();
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            txtNama.Clear();
            txtEmail.Clear();
            cmb_Role.SelectedIndex = -1;
            pictureBoxFoto.Image = null;
            selectedUserId = "";
            selectedFoto = "";
        }

        private void btnImportFoto_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                string filePath = ofd.FileName;
                string fileName = Path.GetFileName(filePath);
                string destPath = Path.Combine(Application.StartupPath, "img_staff", fileName);

                try
                {
                    if (!Directory.Exists(Path.GetDirectoryName(destPath)))
                        Directory.CreateDirectory(Path.GetDirectoryName(destPath));

                    File.Copy(filePath, destPath, true);
                    selectedFoto = fileName;
                    pictureBoxFoto.Image = Image.FromFile(destPath);
                    pictureBoxFoto.SizeMode = PictureBoxSizeMode.StretchImage;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Gagal mengimpor foto: " + ex.Message);
                }
            }
        }
    }
}
