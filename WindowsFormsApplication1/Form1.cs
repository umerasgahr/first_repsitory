using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using MetroFramework.Forms;
using MetroFramework;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApplication1.DataSet1TableAdapters;
using System.Threading;

namespace WindowsFormsApplication1
{
    public partial class Form1 : MetroForm
    {
        public Form1()
        {
            InitializeComponent();
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           
          
        }

        private void metroPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
        private void metroButton1_Click(object sender, EventArgs e)
        {
            if (metroTextBox1.Text == "Perfect" && metroTextBox2.Text =="sehrish1993")
            {
                Form2 f = new Form2(this,metroTextBox2.Text);
                f.Show();
                this.Hide();
                //var t = new Thread(() => Application.Run(new Form2()));
                //t.Start();
                //this.Close();
            }
            if (metroTextBox1.Text == "Perfect" && metroTextBox2.Text == "employ")
            {
                Form2 f = new Form2(this, metroTextBox2.Text);
                f.Show();
                this.Hide();
            }
            else
            {
                metroLabel3.Visible = true;
            }
 
        }
    }
}
