using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework.Forms;
using WindowsFormsApplication1.DataSet1TableAdapters;

namespace WindowsFormsApplication1
{
    public partial class Form3 : MetroForm
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'DataSet1.temp_data' table. You can move, or remove it, as needed.
            this.temp_dataTableAdapter.Fill(this.DataSet1.temp_data);
            // TODO: This line of code loads data into the 'DataSet1.invoice' table. You can move, or remove it, as needed.
            this.invoiceTableAdapter.Fill(this.DataSet1.invoice);

            this.reportViewer1.RefreshReport();
            invoiceTableAdapter i = new DataSet1TableAdapters.invoiceTableAdapter();
           i.DeleteQuery();
            temp_dataTableAdapter t = new temp_dataTableAdapter();
            t.DeleteQuery1();
            this.reportViewer1.RefreshReport();
            this.reportViewer1.RefreshReport();
         
        }

        private void reportViewer1_Print(object sender, Microsoft.Reporting.WinForms.ReportPrintEventArgs e)
        {
        //  MessageBox.Show("Its is working");
        }
    }
}









