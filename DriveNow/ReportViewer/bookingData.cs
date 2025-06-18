using System;
using System.Windows.Forms;

namespace DriveNow.DB
{
    public partial class bookingData : Form
    {
        public bookingData()
        {
            InitializeComponent();
            this.Load += bookingData_Load;
        }

        private void bookingData_Load(object sender, EventArgs e)
        {
            try
            {
                var ds = new db_drivenow();
                ds.EnforceConstraints = false;

                var adapter = new db_drivenowTableAdapters.BookingTableAdapter();
                adapter.Fill(ds.Booking);

                var report = new Reports.BookingData();
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
 