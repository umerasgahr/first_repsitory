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

namespace WindowsFormsApplication1
{
    public partial class Form5 : MetroForm
    {
        public Form5()
        {
            InitializeComponent();
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'DataSet1.Patient_Record' table. You can move, or remove it, as needed.
            this.Patient_RecordTableAdapter.Fill(this.DataSet1.Patient_Record);
            this.reportViewer1.PageSetupDialog();
            this.reportViewer1.RefreshReport();
            this.Patient_RecordTableAdapter.DeleteQuery();
        }
    }
}
