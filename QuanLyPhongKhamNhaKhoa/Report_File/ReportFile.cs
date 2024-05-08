using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyPhongKhamNhaKhoa.Report_File
{
    public partial class ReportFile : Form
    {
        public ReportFile()
        {
            InitializeComponent();
        }
        public string reportpath { get; set; }
        public string dataset { get; set; }
        public DataTable dataTable { get; set; }

        private void Report_File_Load(object sender, EventArgs e)
        {
            this.reportViewer1.LocalReport.ReportPath = reportpath;
            this.reportViewer1.LocalReport.DataSources.Clear();
            var dataSource = new ReportDataSource(dataset, dataTable);

            this.reportViewer1.LocalReport.DataSources.Clear();
            this.reportViewer1.LocalReport.DataSources.Add(dataSource);
            this.reportViewer1.LocalReport.EnableExternalImages = true;
            this.reportViewer1.RefreshReport();
        }
    }
}
