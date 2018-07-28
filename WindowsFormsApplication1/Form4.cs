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
    public partial class Form4 : MetroForm
    {
        private string name = "";
        private string phn = "";
        public Form4()
        {
            InitializeComponent();
        }
        public Form4(string n, string p)
        {
            InitializeComponent();
            name = n;
            phn = p;
        }

        private void Form4_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (metroTextBox1.Text == "" || metroTextBox2.Text == "")
                {
                    MessageBox.Show("Empty fields cannot be updated");
                    return;
                }
                this.infoTableAdapter1.UpdateQuery1(metroTextBox1.Text, metroTextBox2.Text, name, phn);
                MessageBox.Show("Record Updated");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
