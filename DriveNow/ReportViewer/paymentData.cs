using System;
using System.Windows.Forms;

namespace DriveNow.DB
{
    public partial class paymentData : Form
    {
        public paymentData()
        {
            InitializeComponent();
            this.Load += paymentData_Load;
        }

        private void paymentData_Load(object sender, EventArgs e)
        {
            try
            {
                var ds = new db_drivenow();
                ds.EnforceConstraints = false;

                var adapter = new db_drivenowTableAdapters.PembayaranTableAdapter();
                adapter.Fill(ds.Pembayaran);

                var report = new Reports.PaymentDataReport(); 
                report.SetDataSource(ds);
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
