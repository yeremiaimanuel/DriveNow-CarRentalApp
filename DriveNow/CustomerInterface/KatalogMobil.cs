using System;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using DriveNow.DB; 

namespace DriveNow.Customer
{
    public partial class KatalogMobil : Form
    {
        private string currentUserId;

        public KatalogMobil(string idUser)
        {
            InitializeComponent();
            this.TopLevel = false;
            this.FormBorderStyle = FormBorderStyle.None;
            this.Load += KatalogMobil_Load;
            this.currentUserId = idUser;
        }

        private void KatalogMobil_Load(object sender, EventArgs e)
        {
            this.ControlBox = false;
            LoadKatalogMobil();
        }

        private void LoadKatalogMobil()
        {
            using (SqlConnection conn = dbConnection.GetConnection())
            {
                conn.Open();
                string query = "SELECT * FROM Mobil WHERE status_mobil = 'Available'";

                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    var item = new CustomListCar
                    {
                        IdMobil = reader["id_mobil"].ToString(),
                        NamaMobil = reader["merk_mobil"].ToString(),
                        TipeWarna = $"{reader["kategori"]} - {reader["warna"]}",
                        Kapasitas = $"{reader["kapasitas"]} Penumpang",
                        HargaDecimal = Convert.ToDecimal(reader["harga_sewa_per_hari"]),
                        HargaSewa = $"Rp {Convert.ToDecimal(reader["harga_sewa_per_hari"]).ToString("N0")} / hari",
                        Status = reader["status_mobil"].ToString()
                    };

                    // Load gambar
                    string imgFile = reader["url_foto_mobil"].ToString();
                    string imgPath = Path.Combine(Application.StartupPath, "img_mobil", imgFile);
                    if (File.Exists(imgPath))
                        item.FotoMobil = Image.FromFile(imgPath);

                    item.OnBookClicked += (s, e) =>
                    {
                        var formBooking = new Booking(
                            currentUserId,
                            item.IdMobil,
                            item.NamaMobil,
                            item.HargaDecimal
                        );
                        formBooking.ShowDialog();
                    };

                    // Tambahkan ke panel
                    flowLayoutPanelCars.Controls.Add(item);
                }
            }
        }
    }
}
