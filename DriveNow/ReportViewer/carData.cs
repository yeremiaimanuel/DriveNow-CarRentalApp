using System;
using System.Windows.Forms;
using DriveNow.Reports;

namespace DriveNow.DB
{
    public partial class carData : Form
    {
        public carData()
        {
            InitializeComponent();
            this.Load += carData_Load;
        }

        private void carData_Load(object sender, EventArgs e)
        {
            try
            {
                // 1. Inisialisasi DataSet dan Adapter
                var dataset = new db_drivenow(); // DataSet (xsd)
                var mobilAdapter = new db_drivenowTableAdapters.MobilTableAdapter();
                dataset.EnforceConstraints = false;

                // 2. Isi data Mobil
                mobilAdapter.ClearBeforeFill = true;
                mobilAdapter.Fill(dataset.Mobil);

                if (dataset.Mobil.Rows.Count == 0)
                {
                    MessageBox.Show("Data mobil kosong.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // 3. Siapkan dan isi report
                var report = new CarDataReport(); 
                report.SetDataSource(dataset);    

                // 4. Tampilkan di viewer
                crystalReportViewer1.ReportSource = report;
                crystalReportViewer1.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal memuat laporan: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
