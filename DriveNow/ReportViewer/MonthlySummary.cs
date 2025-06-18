using System;
using System.Windows.Forms;

namespace DriveNow.DB
{
    public partial class MonthlySummary : Form
    {
        public MonthlySummary()
        {
            InitializeComponent();
            this.Load += MonthlySummary_Load;
        }

        private void MonthlySummary_Load(object sender, EventArgs e)
        {
            try
            {
                // 1. Buat dataset utama
                var ds = new db_drivenow();
                ds.EnforceConstraints = false;

                // 2. Isi tabel dari TableAdapter
                var adapter = new db_drivenowTableAdapters.MonthlySummaryAdapter();
                adapter.Fill(ds.MonthlySummary);

                // 3. Set ReportSource dari .rpt file
                var report = new Reports.MonthlySummaryReport(); 
                report.SetDataSource(ds);

                // 4. Tampilkan ke crystal viewer
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
