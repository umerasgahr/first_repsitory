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
using MetroFramework;
using System.Data.SQLite;
using WindowsFormsApplication1.DataSet1TableAdapters;
using MetroFramework.Controls;
using WindowsFormsApplication1.DataSet1TableAdapters;
using Tulpep.NotificationWindow;


namespace WindowsFormsApplication1
{
    public partial class Form2 : MetroForm
    {
        private SQLiteConnection sqlite;
        private Form1 f;
        public DataSet ds = new DataSet();
        public Label l, l1, l2, l3, l4;
        public string updn = "", updp = "";
        public TextBox tb, tb1, tb2, tb3;
        public string row0, row1, row2;
        public MetroDateTime m;
        public DataTable t = new DataTable();
        static int x = 0;
        static int y = 0;
       // public DataTable rt = new DataTable();
        public Form2()
        {
            InitializeComponent();
            sqlite = new SQLiteConnection("Data Source=clinic.sqlite");
            t=selectQuery("Select * from notify");
            setnotifications();

        }
        public Form2(Form1 obj)
        {
            InitializeComponent();
            sqlite = new SQLiteConnection("Data Source=clinic.sqlite");
            t = selectQuery("Select * from notify");
            setnotifications();
            f = obj;
        }
        public Form2(Form1 obj, string adpass)
        {
            InitializeComponent();
            sqlite = new SQLiteConnection("Data Source=clinic.sqlite");
            t = selectQuery("Select * from notify");
            setnotifications();
            f = obj;
            if (adpass == "employ")
            {
                metroTabControl2.TabPages.RemoveAt(4);
                metroTile5.Visible = false;
                metroButton7.Visible = false;
                metroLabel27.Text = metroLabel27.Text + "Employee";
            }
            if (adpass == "sehrish1993")
            {
                metroLabel27.Text = metroLabel27.Text + "Admin";
            }
        }
        private void Form2_Load(object sender, EventArgs e)
        {
            PopupNotifier popup = new PopupNotifier();
            popup.Image = Properties.Resources.info;
            popup.TitleText = "Notification!";
            // TODO: This line of code loads data into the 'dataSet1.notify' table. You can move, or remove it, as needed.
          //  this.notifyTableAdapter.Fill(this.dataSet1.notify);
            // TODO: This line of code loads data into the 'dataSet1.temp_data' table. You can move, or remove it, as needed.
           // this.temp_dataTableAdapter.Fill(this.dataSet1.temp_data);
            string cd = DateTime.Now.ToString("yyyy-MM-dd");
            DateTime week = DateTime.Now;
            string[] cdarr = cd.Split('-');
            string temp1 = cd.Replace("-", "");
            Double b = Convert.ToDouble(temp1);
            int m = 0, da = 0, y = 0, m1 = 0, da1 = 0, y1 = 0;
            m = Convert.ToInt32(cdarr[1]);
            da = Convert.ToInt32(cdarr[2]);
            y = Convert.ToInt32(cdarr[0]);
            string d = "";
            int c = 0;
            for (int i = 0; i < t.Rows.Count; i++)
            {
                d = t.Rows[i][1].ToString();
               
                string[] d1 = d.Split('-');
                m1 = Convert.ToInt32(d1[1]);
                da1 = Convert.ToInt32(cdarr[2]);
                y1 = Convert.ToInt32(cdarr[0]);
                string temp = d.Replace("-", "");
                Double a = Convert.ToDouble(temp);
                if (week.DayOfWeek.ToString() == "Saturday")
                {

                    if (b + 2 == a)
                    {


                        popup.ContentText = "Appointment Tomorrow \n" + t.Rows[i][0].ToString()
                            + "\n" + t.Rows[i][3].ToString();
                        popup.Popup();
                        metroGrid5.Rows.Add();
                        metroGrid5.Rows[c].Cells[0].Value = t.Rows[i][0];
                        metroGrid5.Rows[c].Cells[1].Value = t.Rows[i][3];
                        metroGrid5.Rows[c].Cells[2].Value = t.Rows[i][1];
                        metroGrid5.Update();
                        c++;
                       

                        //this.notifyIcon1.ShowBalloonTip(1000, "Appointment Tomorrow", t.Rows[i][0].ToString() + "\n" +
                        //  t.Rows[i][3].ToString(),ToolTipIcon.Info);
                    }
                    if (m < 8)
                    {
                        if (m % 2 != 0)
                        {
                            if (da == 31)
                            {

                                if (y == y1 && m + 1 == m1 && da1 == 2)
                                {
                                    popup.ContentText = "Appointment Tomorrow \n" + t.Rows[i][0].ToString()
                               + "\n" + t.Rows[i][3].ToString();
                                    popup.Popup();
                                    metroGrid5.Rows.Add();
                                    metroGrid5.Rows[c].Cells[0].Value = t.Rows[i][0];
                                    metroGrid5.Rows[c].Cells[1].Value = t.Rows[i][3];
                                    metroGrid5.Rows[c].Cells[2].Value = t.Rows[i][1];
                                    metroGrid5.Update();
                                    c++;
                                }
                            }
                        }
                        if (m % 2 == 0)
                        {
                            if (m == 2)
                            {
                                if (da == 28)
                                {
                                    if (y == y1 && m + 1 == m1 && da1 == 2)
                                    {
                                        popup.ContentText = "Appointment Tomorrow \n" + t.Rows[i][0].ToString()
                     + "\n" + t.Rows[i][3].ToString();
                                        popup.Popup();
                                        metroGrid5.Rows.Add();
                                        metroGrid5.Rows[c].Cells[0].Value = t.Rows[i][0];
                                        metroGrid5.Rows[c].Cells[1].Value = t.Rows[i][3];
                                        metroGrid5.Rows[c].Cells[2].Value = t.Rows[i][1];
                                        metroGrid5.Update();
                                        c++;
                                    }

                                }
                            }
                            if (da == 30)
                            {
                                if (y == y1 && m + 1 == m1 && da1 == 2)
                                {
                                    popup.ContentText = "Appointment Tomorrow \n" + t.Rows[i][0].ToString()
                               + "\n" + t.Rows[i][3].ToString();
                                    popup.Popup();
                                    metroGrid5.Rows.Add();
                                    metroGrid5.Rows[c].Cells[0].Value = t.Rows[i][0];
                                    metroGrid5.Rows[c].Cells[1].Value = t.Rows[i][3];
                                    metroGrid5.Rows[c].Cells[2].Value = t.Rows[i][1];
                                    metroGrid5.Update();
                                    c++;
                                }
                            }
                        }
                    }
                    if (m > 7)
                    {
                        if (m % 2 == 0)
                        {
                            if (da == 31)
                            {
                                if (m == 12)
                                {
                                    if (y + 1 == y1 && m1 == 1 && da1 == 2)
                                    {
                                        popup.ContentText = "Appointment Tomorrow \n" + t.Rows[i][0].ToString()
                      + "\n" + t.Rows[i][3].ToString();
                                        popup.Popup();
                                        metroGrid5.Rows.Add();
                                        metroGrid5.Rows[c].Cells[0].Value = t.Rows[i][0];
                                        metroGrid5.Rows[c].Cells[1].Value = t.Rows[i][3];
                                        metroGrid5.Rows[c].Cells[2].Value = t.Rows[i][1];
                                        metroGrid5.Update();
                                        c++;
                                    }
                                }
                                if (y == y1 && m + 1 == m1 && da1 == 2)
                                {
                                    popup.ContentText = "Appointment Tomorrow \n" + t.Rows[i][0].ToString()
                               + "\n" + t.Rows[i][3].ToString();
                                    popup.Popup();
                                    metroGrid5.Rows.Add();
                                    metroGrid5.Rows[c].Cells[0].Value = t.Rows[i][0];
                                    metroGrid5.Rows[c].Cells[1].Value = t.Rows[i][3];
                                    metroGrid5.Rows[c].Cells[2].Value = t.Rows[i][1];
                                    metroGrid5.Update();
                                    c++;
                                }
                            }
                        }
                        if (m % 2 != 0)
                        {
                            if (da == 30)
                            {
                                if (y == y1 && m + 1 == m1 && da1 == 2)
                                {
                                    popup.ContentText = "Appointment Tomorrow \n" + t.Rows[i][0].ToString()
                               + "\n" + t.Rows[i][3].ToString();
                                    popup.Popup();
                                    metroGrid5.Rows.Add();
                                    metroGrid5.Rows[c].Cells[0].Value = t.Rows[i][0];
                                    metroGrid5.Rows[c].Cells[1].Value = t.Rows[i][3];
                                    metroGrid5.Rows[c].Cells[2].Value = t.Rows[i][1];
                                    metroGrid5.Update();
                                    c++;
                                }
                            }
                        }
                    }
                }
                else { 
                if (b + 1 == a)
                {
                  
                    
                    popup.ContentText = "Appointment Tomorrow \n" + t.Rows[i][0].ToString()
                        + "\n" + t.Rows[i][3].ToString();
                    popup.Popup();
                    metroGrid5.Rows.Add();
                    metroGrid5.Rows[c].Cells[0].Value = t.Rows[i][0];
                    metroGrid5.Rows[c].Cells[1].Value = t.Rows[i][3];
                    metroGrid5.Rows[c].Cells[2].Value = t.Rows[i][1];
                    metroGrid5.Update();
                    c++;
                    //this.notifyIcon1.ShowBalloonTip(1000, "Appointment Tomorrow", t.Rows[i][0].ToString() + "\n" +
                      //  t.Rows[i][3].ToString(),ToolTipIcon.Info);
                }
                if (m < 8)
                {
                    if (m % 2 != 0)
                    {
                        if (da == 31)
                        {
                           
                            if (y == y1 && m + 1 == m1 && da1 == 1)
                            {
                                popup.ContentText = "Appointment Tomorrow \n" + t.Rows[i][0].ToString()
                           + "\n" + t.Rows[i][3].ToString();
                                popup.Popup();
                                metroGrid5.Rows.Add();
                                metroGrid5.Rows[c].Cells[0].Value = t.Rows[i][0];
                                metroGrid5.Rows[c].Cells[1].Value = t.Rows[i][3];
                                metroGrid5.Rows[c].Cells[2].Value = t.Rows[i][1];
                                metroGrid5.Update();
                                c++;
                            }
                        }
                    }
                    if (m % 2 == 0)
                    {
                        if (m == 2)
                        {
                            if (da == 28)
                            {
                                if (y == y1 && m + 1 == m1 && da1 == 1)
                                {
                                    popup.ContentText = "Appointment Tomorrow \n" + t.Rows[i][0].ToString()
                 + "\n" + t.Rows[i][3].ToString();
                                    popup.Popup();
                                    metroGrid5.Rows.Add();
                                    metroGrid5.Rows[c].Cells[0].Value = t.Rows[i][0];
                                    metroGrid5.Rows[c].Cells[1].Value = t.Rows[i][3];
                                    metroGrid5.Rows[c].Cells[2].Value = t.Rows[i][1];
                                    metroGrid5.Update();
                                    c++;
                                }
                               
                            }
                        }
                        if (da == 30)
                        {
                            if (y == y1 && m + 1 == m1 && da1 == 1)
                            {
                                popup.ContentText = "Appointment Tomorrow \n" + t.Rows[i][0].ToString()
                           + "\n" + t.Rows[i][3].ToString();
                                popup.Popup();
                                metroGrid5.Rows.Add();
                                metroGrid5.Rows[c].Cells[0].Value = t.Rows[i][0];
                                metroGrid5.Rows[c].Cells[1].Value = t.Rows[i][3];
                                metroGrid5.Rows[c].Cells[2].Value = t.Rows[i][1];
                                metroGrid5.Update();
                                c++;
                            }
                        }
                    }
                }
                if (m > 7)
                {
                    if (m % 2 == 0)
                    {
                        if (da == 31)
                        {
                            if (m == 12)
                            {
                                if (y + 1 == y1 && m1 == 1 && da1 == 1)
                                {
                                    popup.ContentText = "Appointment Tomorrow \n" + t.Rows[i][0].ToString()
                  + "\n" + t.Rows[i][3].ToString();
                                    popup.Popup();
                                    metroGrid5.Rows.Add();
                                    metroGrid5.Rows[c].Cells[0].Value = t.Rows[i][0];
                                    metroGrid5.Rows[c].Cells[1].Value = t.Rows[i][3];
                                    metroGrid5.Rows[c].Cells[2].Value = t.Rows[i][1];
                                    metroGrid5.Update();
                                    c++;
                                }
                            }
                            if (y == y1 && m + 1 == m1 && da1 == 1)
                            {
                                popup.ContentText = "Appointment Tomorrow \n" + t.Rows[i][0].ToString()
                           + "\n" + t.Rows[i][3].ToString();
                                popup.Popup();
                                metroGrid5.Rows.Add();
                                metroGrid5.Rows[c].Cells[0].Value = t.Rows[i][0];
                                metroGrid5.Rows[c].Cells[1].Value = t.Rows[i][3];
                                metroGrid5.Rows[c].Cells[2].Value = t.Rows[i][1];
                                metroGrid5.Update();
                                c++;
                            }
                        }
                    }
                    if (m % 2 != 0)
                    {
                        if (da == 30)
                        {
                            if (y == y1 && m + 1 == m1 && da1 == 1)
                            {
                                popup.ContentText = "Appointment Tomorrow \n" + t.Rows[i][0].ToString()
                           + "\n" + t.Rows[i][3].ToString();
                                popup.Popup();
                                metroGrid5.Rows.Add();
                                metroGrid5.Rows[c].Cells[0].Value = t.Rows[i][0];
                                metroGrid5.Rows[c].Cells[1].Value = t.Rows[i][3];
                                metroGrid5.Rows[c].Cells[2].Value = t.Rows[i][1];
                                metroGrid5.Update();
                                c++;
                            }
                        }
                    }
                }

                }


            }
            metroPanel1.SendToBack();
            metroPanel1.Visible = false;
            metroPanel1.Enabled = false;
            metroTile6.Visible = false;
            metroButton9.Enabled = false;
          //  this.infoTableAdapter1.Fill(dataSet1.info);
        }

        private void metroPanel1_Paint(object sender, PaintEventArgs e)
        {
          
        }

        private void metroTile4_Click(object sender, EventArgs e)
        {

        }
        public DataTable selectQuery(string query)
        {
            SQLiteDataAdapter ad;
            DataTable dt = new DataTable();

            try
            {
                SQLiteCommand cmd;
                sqlite.Open();  //Initiate connection to the db
                cmd = sqlite.CreateCommand();
                cmd.CommandText = query;  //set the passed query
                ad = new SQLiteDataAdapter(cmd);
                ad.Fill(dt); //fill the datasource
            }
            catch (SQLiteException ex)
            {
                MessageBox.Show(ex.Message);
            }
            sqlite.Close();
            return dt;
        }
        public void InsertQuery()
        {
            try
            {
               
                infoTableAdapter i = new infoTableAdapter();
                i.InsertQuery(metroTextBox10.Text,metroTextBox11.Text,metroTextBox9.Text,"",
                    "",0,DateTime.Now.ToString("dd-MM-yyyy"),0,Convert.ToDecimal(tb.Text));

            }
            catch (Exception e)
            {
                MetroMessageBox.Show(Owner,e.Message,"Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            // SQLiteDataAdapter ad;
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
           
            //MetroMessageBox.Show(Owner, "Data Successfully Added", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void metroTile1_Click(object sender, EventArgs e)
        {
            infoTableAdapter i = new DataSet1TableAdapters.infoTableAdapter();
            DataSet1.infoDataTable t = new DataSet1.infoDataTable();
            if(metroTextBox12.Text.Any(char.IsDigit)){
                MessageBox.Show("Invalid Name");
                return;
            }
            if (metroTextBox25.Text.Any(char.IsLetter))
            {
                MessageBox.Show("Invalid Phone No");
                return;
            }
            if (metroTextBox12.Text == "" && metroTextBox25.Text == "")
            {
                MessageBox.Show("Text Fields are Empty");
                return;
            }
            if (metroTextBox12.Text != "" && metroTextBox25.Text == "")
            {
                i.FillBy(t, metroTextBox12.Text);
            }
            if (metroTextBox12.Text != "" && metroTextBox25.Text != "")
            {
                i.FillBy1(t, metroTextBox25.Text, metroTextBox12.Text);
            }
            if (metroTextBox12.Text == "" && metroTextBox25.Text != "")
            {
                i.FillBy2(t, metroTextBox25.Text);
            }
            if (t.Rows==null)
            {
                MessageBox.Show("No Data Found");
                return;
            }
            int count=0;
            foreach (DataRow rows in t.Rows)
            {
                 metroGrid4.Rows.Add();
                 metroGrid4.Rows[count].Cells[0].Value = rows.Field<string>("name");
                 metroGrid4.Rows[count].Cells[1].Value = rows.Field<string>("phn");
                 metroGrid4.Rows[count].Cells[2].Value = rows.Field<string>("add");
                 metroGrid4.Rows[count].Cells[3].Value = rows.Field<string>("Advise");
                 metroGrid4.Rows[count].Cells[4].Value = rows.Field<string>("disease");
                 metroGrid4.Rows[count].Cells[5].Value = rows.Field<double>("last_bill");
                 metroGrid4.Rows[count].Cells[6].Value = rows.Field<double>("due_pay");
                 metroGrid4.Rows[count].Cells[7].Value = rows.Field<string>("date");
                 count++;
                //mm.Field<double>("due_pay");
                //MessageBox.Show(aa.ToString());
            }
           // metroGrid4.Update();
            metroGrid4.Refresh();
            metroPanel1.BringToFront();
            metroPanel1.Enabled = true;
            metroPanel1.Visible = true;
            metroTile6.Enabled = true;
            metroTile6.Visible = true;
           
        

        }
        public  void setvalues(string n, string phn, string add, string adv, string d)
        {
            metroTextBox16.Text = n;
            metroTextBox17.Text = phn;
            metroTextBox15.Text = add;
            metroTextBox14.Text = adv;
            metroTextBox13.Text = d;
        }

        private void metroTile3_Click(object sender, EventArgs e)
        {
            int result=0;
                if (int.TryParse(metroTextBox10.Text, out result))
            {
                MessageBox.Show("Invaid Name");
                return;
            }
            if (metroTextBox11.Text.Any(char.IsLetter))
            {
                MessageBox.Show("Invaid Phone No");
                return;
            }
            if (metroTextBox10.Text == "" || metroTextBox9.Text == "" || metroTextBox11.Text == "")
            {
                MessageBox.Show("Text Fields cant be left empty");
            }
              
            else
            {

                createForm(metroTextBox10.Text);
            }
           
        }
        private void ok_Click(object sender, EventArgs e)
        {
            //Form form = (sender as Control).Parent as Form;
            //form.DialogResult = DialogResult.OK;
            //form.Close();
            bool b = true;
            if (tb.Text == "")
            {
                MessageBox.Show("Fields cant be left empty");
                return;
            }
            int result=0;
            if(!int.TryParse(tb.Text,out result)){
                MessageBox.Show("Please Enter numeric Value");
                return;
            }
            if (metroGrid1.Rows[0].Cells[0].Value == null)
            {
                metroGrid1.Rows.Add();
                metroGrid1.Rows[y].Cells[0].Value = tb.Text;
                metroGrid1.Rows[y].Cells[1].Value = tb1.Text;
                metroGrid1.Rows[y].Cells[2].Value = metroTextBox11.Text;
                metroGrid1.Update();
                y++;
                this.InsertQuery();
            }
            else
            {
                for (int i = 0; i < metroGrid1.Rows.Count - 1; i++)
                {
                    if (metroGrid1.Rows[i].Cells[0].Value.ToString().Equals(tb.Text))
                    {
                        b = false;

                    }
                }
                if (b == false)
                {
                    
                    MetroMessageBox.Show(Owner, "Token Already Assigned", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    metroGrid1.Rows.Add();
                    metroGrid1.Rows[y].Cells[0].Value = tb.Text;
                    metroGrid1.Rows[y].Cells[1].Value = tb1.Text;
                    metroGrid1.Rows[y].Cells[2].Value = metroTextBox11.Text;
                    metroGrid1.Update();
                    y++;
                    this.InsertQuery();
                }
           
            }
            Form form = (sender as Control).Parent as Form;
            form.DialogResult = DialogResult.OK;
            form.Close();
          
        }

        private void metroTile4_Click_1(object sender, EventArgs e)
        {
            MetroForm dc = new MetroForm();
            dc.Style = MetroColorStyle.Lime;
            dc.Text = "Set Notification";

            dc.HelpButton = dc.MinimizeBox = dc.MaximizeBox = false;
            dc.ShowIcon = dc.ShowInTaskbar = false;
            dc.TopMost = true;

            dc.Height = 350;
            dc.Width = 350;
            dc.MinimumSize = new Size(dc.Width, dc.Height);

            // int margin = 150;
            Size size = dc.ClientSize;
            l2 = new Label();
            l2.Text = "Patient Name";
            l2.Height = 15;
            l2.Width = 80;
            l2.Location = new Point(100, 100);
            l2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            dc.Controls.Add(l2);

            l3 = new Label();
            l3.Text = "Phn No";
            l3.Height = 15;
            l3.Width = 80;
            l3.Location = new Point(100, 150);
            l3.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            dc.Controls.Add(l3);
            tb2 = new TextBox();
            tb2.TextAlign = HorizontalAlignment.Left;
            tb2.Height = 20;
            tb2.Width = 100;
            tb2.Location = new Point(100, 120);
            tb2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            dc.Controls.Add(tb2);
            tb3 = new TextBox();
            tb3.TextAlign = HorizontalAlignment.Left;
            tb3.Height = 20;
            tb3.Width = 100;
            tb3.Location = new Point(100, 170);
            tb3.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            dc.Controls.Add(tb3);

            Button ok = new Button();
            ok.Text = "Ok";
            ok.Click += new EventHandler(ok_Click2);
            ok.Height = 23;
            ok.Width = 75;
            ok.Location = new Point(110, 260);
            ok.Anchor = AnchorStyles.Bottom;
            dc.Controls.Add(ok);
            dc.AcceptButton = ok;

            m = new MetroDateTime();
            m.Height = 23;
            m.Width = 220;
            m.Location = new Point(50, 220);
            m.Anchor = AnchorStyles.Bottom;
            dc.Controls.Add(m);

            l4 = new Label();
            l4.Text = "Appointment Date";
            l4.Height = 15;
            l4.Width = 120;
            l4.Location = new Point(100, 200);
            l4.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            dc.Controls.Add(l4);
            dc.ShowDialog();
        }
        private void ok_Click2(object sender, EventArgs e)
        {
            if (tb2.Text == "" || tb3.Text=="")
            {
                MessageBox.Show("Fields Cant be left empty");
                return;
            }
            int result=0;
            if (int.TryParse(tb2.Text, out result))
            {
                MessageBox.Show("Enter a Valid Name");
                return;
            }
            if (tb3.Text.Any(char.IsLetter))
            {
                MessageBox.Show("Enter a Valid Phone No");
                return;
            }

            notifyTableAdapter n = new DataSet1TableAdapters.notifyTableAdapter();
            n.InsertQuery(tb2.Text, m.Value.ToString("yyyy-MM-dd"), "null", tb3.Text);
        
            MetroMessageBox.Show(Owner, "Notification Set", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            t = selectQuery("Select * from notify");
            setnotifications();
            //int c = 0;
            //for (int i = 0; i < t.Rows.Count; i++)
            //{
            //    string date = t.Rows[i][1].ToString();
            //    date = date.Replace("-", "");

            //    Double d = Convert.ToDouble(date);
            //    Double cd = Convert.ToDouble(DateTime.Now.ToString("yyyy-MM-dd").Replace("-", ""));
            //    if (d > cd+1)
            //    {
            //        metroGrid2.Rows.Add();
            //        metroGrid2.Rows[c].Cells[0].Value = t.Rows[i][0];
            //        metroGrid2.Rows[c].Cells[1].Value = t.Rows[i][3];
            //        metroGrid2.Rows[c].Cells[2].Value = t.Rows[i][1];
            //        metroGrid2.Update();
            //        c++;
            //    }

            //}
            metroGrid2.Update();
            metroGrid2.Refresh();
            setmetrogrid5();
            //metroGrid1.Rows.Add();
            //metroGrid1.Rows[metroGrid1.Rows.Count - 1].Cells[0].Value = tb.Text;
            //metroGrid1.Rows[metroGrid1.Rows.Count - 1].Cells[1].Value = tb1.Text;
            //metroGrid1.Refresh();
            Form form = (sender as Control).Parent as Form;
            form.DialogResult = DialogResult.OK;
            form.Close();
        }

        private void metroTile5_Click(object sender, EventArgs e)
        {
          // metroPanel2.Visible = false;
           // metroPanel2.Enabled = false;
            metroGrid3.Visible = true;
            metroGrid3.BringToFront();
            metroGrid5.SendToBack();
            metroGrid5.Visible = false;
           x++;
           if (x % 2 != 0)
           {
               metroGrid3.Visible = true;
               int c = 0;
               for (int i = 0; i < t.Rows.Count; i++)
               {
                   string date = t.Rows[i][1].ToString();
                   date = date.Replace("-", "");

                   Double d = Convert.ToDouble(date);
                   Double cd = Convert.ToDouble(DateTime.Now.ToString("yyyy-MM-dd").Replace("-", ""));
                   if (d <= cd)
                   {
                       metroGrid3.Rows.Add();
                       metroGrid3.Rows[c].Cells[0].Value = t.Rows[i][0];
                       metroGrid3.Rows[c].Cells[1].Value = t.Rows[i][3];
                       metroGrid3.Rows[c].Cells[2].Value = t.Rows[i][1];
                       metroGrid3.Update();
                       c++;
                   }
               }
           }
           else
           {
               metroGrid3.Visible = false;
               metroButton11.Enabled = false;
           }
        }

        private void metroButton3_Click(object sender, EventArgs e)
        {
           
        }

        private void metroTextBox18_Leave(object sender, EventArgs e)
        {
           // metroTextBox21.Text = metroTextBox18.Text;
        }

        private void metroTextBox19_Leave(object sender, EventArgs e)
        {
            //Double c_fee = 0, p_fee = 0;
            //c_fee = Convert.ToDouble(metroTextBox18.Text);
            //p_fee = Convert.ToDouble(metroTextBox19.Text);
            //metroTextBox21.Text = (c_fee + p_fee).ToString();
        }

        private void metroTextBox20_Leave(object sender, EventArgs e)
        {
            //Double c_fee = 0, p_fee = 0, m_fee = 0;
            //c_fee = Convert.ToDouble(metroTextBox18.Text);
            //p_fee = Convert.ToDouble(metroTextBox19.Text);
            //m_fee = Convert.ToDouble(metroTextBox20.Text);
            //metroTextBox21.Text = (c_fee + p_fee + m_fee).ToString();
        }

        private void metroTextBox18_Validating(object sender, CancelEventArgs e)
        {
          //  metroTextBox21.Text = metroTextBox18.Text;
        }

        private void metroTextBox18_TextChanged(object sender, EventArgs e)
        {
            try
            {
                metroTextBox21.Text = metroTextBox18.Text;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Plese Enter Numeric Value");
            }
        }

        private void metroTextBox19_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Double c_fee = 0, p_fee = 0;
                if (metroTextBox18.Text != "")
                {
                    c_fee = Convert.ToDouble(metroTextBox18.Text);
                }
                if (metroTextBox19.Text != "")
                {
                    p_fee = Convert.ToDouble(metroTextBox19.Text);
                }
                metroTextBox21.Text = (c_fee + p_fee).ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Plese Enter Numeric Value");
            }
        }

        private void metroTextBox20_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Double c_fee = 0, p_fee = 0, m_fee = 0;
                if (metroTextBox18.Text != "")
                    c_fee = Convert.ToDouble(metroTextBox18.Text);
                if (metroTextBox19.Text != "")
                    p_fee = Convert.ToDouble(metroTextBox19.Text);
                if (metroTextBox20.Text != "")
                    m_fee = Convert.ToDouble(metroTextBox20.Text);
                metroTextBox21.Text = (c_fee + p_fee + m_fee).ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Plese Enter Numeric Value");
            }
        }

        private void metroGrid4_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int rowIndex = e.RowIndex;
                DataGridViewRow row = metroGrid4.Rows[rowIndex];
               metroTextBox16.Text = row.Cells[0].Value.ToString();
               metroTextBox17.Text = row.Cells[1].Value.ToString();
                metroTextBox15.Text = row.Cells[2].Value.ToString();
                metroTextBox14.Text = row.Cells[3].Value.ToString();
                metroTextBox13.Text = row.Cells[4].Value.ToString();
                metroPanel1.SendToBack();
                metroPanel1.Visible = false;
                metroPanel1.Enabled = false;
                metroTile6.Enabled = false;
                metroTile6.Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void metroTile6_Click(object sender, EventArgs e)
        {
            
            metroPanel1.SendToBack();
            metroPanel1.Visible = false;
            metroPanel1.Enabled = false;
            metroTile6.Enabled = false;
            metroTile6.Visible = false;
            metroGrid4.Rows.Clear();

        }

        private void metroTile7_Click(object sender, EventArgs e)
        {
            if (metroTextBox16.Text == "")
            {
                MessageBox.Show("No record");
                return;
            }
            MetroForm dc = new MetroForm();
            dc.Style = MetroColorStyle.Lime;
            dc.Text = "Enter Token";

            dc.HelpButton = dc.MinimizeBox = dc.MaximizeBox = false;
            dc.ShowIcon = dc.ShowInTaskbar = false;
            dc.TopMost = true;

            dc.Height = 350;
            dc.Width = 350;
            dc.MinimumSize = new Size(dc.Width, dc.Height);

            // int margin = 150;
            Size size = dc.ClientSize;
            l = new Label();
            l.Text = "Tokken No";
            l.Height = 15;
            l.Width = 80;
            l.Location = new Point(100, 100);
            l.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            dc.Controls.Add(l);

            l1 = new Label();
            l1.Text = "Patient Name";
            l1.Height = 15;
            l1.Width = 80;
            l1.Location = new Point(100, 150);
            l1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            dc.Controls.Add(l1);
            tb = new TextBox();
            tb.TextAlign = HorizontalAlignment.Left;
            tb.Height = 20;
            tb.Width = 100;
            tb.Location = new Point(100, 120);
            tb.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            dc.Controls.Add(tb);
            tb1 = new TextBox();
            tb1.TextAlign = HorizontalAlignment.Left;
            tb1.Height = 20;
            tb1.Width = 100;
            tb1.Text = metroTextBox16.Text;
            tb1.Location = new Point(100, 170);
            tb1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            dc.Controls.Add(tb1);

            Button ok = new Button();
            ok.Text = "Ok";
            ok.Click += new EventHandler(ok_Click3);
            ok.Height = 23;
            ok.Width = 75;
            ok.Location = new Point(120, 250);
            ok.Anchor = AnchorStyles.Bottom;
            dc.Controls.Add(ok);
            dc.AcceptButton = ok;

            dc.ShowDialog();
        }
        public void createForm(string name){
            MetroForm dc = new MetroForm();
            dc.Style = MetroColorStyle.Lime;
            dc.Text = "Enter Token";

            dc.HelpButton = dc.MinimizeBox = dc.MaximizeBox = false;
            dc.ShowIcon = dc.ShowInTaskbar = false;
            dc.TopMost = true;

            dc.Height = 350;
            dc.Width = 350;
            dc.MinimumSize = new Size(dc.Width, dc.Height);

            // int margin = 150;
            Size size = dc.ClientSize;
            l = new Label();
            l.Text = "Tokken No";
            l.Height = 15;
            l.Width = 80;
            l.Location = new Point(100, 100);
            l.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            dc.Controls.Add(l);

            l1 = new Label();
            l1.Text = "Patient Name";
            l1.Height = 15;
            l1.Width = 80;
            l1.Location = new Point(100, 150);
            l1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            dc.Controls.Add(l1);
            tb = new TextBox();
            tb.TextAlign = HorizontalAlignment.Left;
            tb.Height = 20;
            tb.Width = 100;
            tb.Location = new Point(100, 120);
            tb.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            dc.Controls.Add(tb);
            tb1 = new TextBox();
            tb1.TextAlign = HorizontalAlignment.Left;
            tb1.Height = 20;
            tb1.Width = 100;
            tb1.Text = name;
            tb1.Location = new Point(100, 170);
            tb1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            dc.Controls.Add(tb1);

            Button ok = new Button();
            ok.Text = "Ok";
            ok.Click += new EventHandler(ok_Click);
            ok.Height = 23;
            ok.Width = 75;
            ok.Location = new Point(120, 250);
            ok.Anchor = AnchorStyles.Bottom;
            dc.Controls.Add(ok);
            dc.AcceptButton = ok;

            dc.ShowDialog();
        }
        private void ok_Click3(object sender, EventArgs e)
        {
            
            bool b = true;
            if (tb.Text == "")
            {
                MessageBox.Show("Fields cant be left empty");
                return;
            }
            int result = 0;
            if (!int.TryParse(tb.Text, out result))
            {
                MessageBox.Show("Please Enter numeric Value");
                return;
            }
            if (metroGrid1.Rows[0].Cells[0].Value == null)
            {
                metroGrid1.Rows.Add();
                metroGrid1.Rows[y].Cells[0].Value = tb.Text;
                metroGrid1.Rows[y].Cells[1].Value = tb1.Text;
                metroGrid1.Rows[y].Cells[2].Value = metroTextBox17.Text;
                metroGrid1.Update();
                y++;
                this.UpdateQuery(tb1.Text, metroTextBox17.Text);
            }
            else
            {
                for (int i = 0; i < metroGrid1.Rows.Count - 1; i++)
                {
                    if (metroGrid1.Rows[i].Cells[0].Value.ToString().Equals(tb.Text))
                    {
                        b = false;

                    }
                }
                if (b == false)
                {

                    MetroMessageBox.Show(Owner, "Token Already Assigned", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    metroGrid1.Rows.Add();
                    metroGrid1.Rows[y].Cells[0].Value = tb.Text;
                    metroGrid1.Rows[y].Cells[1].Value = tb1.Text;
                    metroGrid1.Rows[y].Cells[2].Value = metroTextBox17.Text;
                    metroGrid1.Update();
                    y++;
                    this.UpdateQuery(tb1.Text, metroTextBox17.Text);
                }

            }
            Form form = (sender as Control).Parent as Form;
            form.DialogResult = DialogResult.OK;
            form.Close();
        }
        public void UpdateQuery(string name,string phn){
            infoTableAdapter i = new infoTableAdapter();
            i.UpdateQuery(Convert.ToDecimal(tb.Text), name, phn);

        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            try
            {
                infoTableAdapter i = new DataSet1TableAdapters.infoTableAdapter();
                DataSet1.infoDataTable t = new DataSet1.infoDataTable();

                DataGridViewRow row = metroGrid1.SelectedRows[0];
                int r = row.Index;

                object temp = row.Cells[3].Value;
                object temp2 = row.Cells[4].Value;
                row0 = row.Cells[0].Value.ToString();
                row1 = row.Cells[1].Value.ToString();
                row2 = row.Cells[2].Value.ToString();

                i.FillBy1(t, row2, row1);
                double aa = 0;
                foreach (DataRow mm in t.Rows)
                {
                    aa = mm.Field<double>("due_pay");
                    //MessageBox.Show(aa.ToString());
                }

                MetroGrid m = new MetroGrid();
                m.DataSource = t;

                decimal b = Convert.ToDecimal(metroTextBox21.Text);
                if (Convert.ToBoolean(temp))
                {

                    //  
                    metroButton3.Enabled = true;
                    if (aa != 0)
                    {
                        b = b + Convert.ToDecimal(aa);
                        //  i.Updateduepay(Convert.ToDecimal(0), row1, row2);
                    }
                    // MessageBox.Show(row.Cells[0].Value.ToString());
                    decimal d = Convert.ToDecimal(row.Cells[0].Value.ToString());
                    //   MessageBox.Show(d.ToString());
                    // Double y = d;
                    i.Updatelastbill(b, row1, row2);



                    metroGrid1.Rows.RemoveAt(r);
                    MessageBox.Show("Bill Paid! \nClick the Invoice Button to generate a Invoice Report");

                }
                else
                {
                    if (Convert.ToBoolean(temp2))
                    {
                        metroButton3.Enabled = false;
                        if (aa != 0)
                        {
                            b = b + Convert.ToDecimal(aa);
                        }
                        i.Updateduepay(b, row1, row2);
                        metroGrid1.Rows.RemoveAt(r);
                        MessageBox.Show("Due Payment is Added to Patient History");
                    }
                }
                metroGrid1.Update();
                metroGrid1.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Invalid Operation");
            }


        }

        private void metroTile8_Click(object sender, EventArgs e)
        {
            if (metroTextBox16.Text == "" || metroTextBox17.Text == "")
            {
                MessageBox.Show("No Data");
                return;
            }
            infoTableAdapter i = new infoTableAdapter();
            i.UpdateQuery1(metroTextBox14.Text, metroTextBox13.Text,metroTextBox16.Text, metroTextBox17.Text);
            MetroMessageBox.Show(Owner, "Data Updated", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void metroButton3_Click_1(object sender, EventArgs e)
        {
            infoTableAdapter i = new DataSet1TableAdapters.infoTableAdapter();
            invoiceTableAdapter it = new DataSet1TableAdapters.invoiceTableAdapter();
            temp_dataTableAdapter temp = new DataSet1TableAdapters.temp_dataTableAdapter();
            DataSet1.infoDataTable t = new DataSet1.infoDataTable();

            DataGridViewRow row = metroGrid1.SelectedRows[0];
            i.FillBy1(t, row2, row1);
            double aa = 0;
            string nam="", p="", add="", adv="", dis="";
            foreach (DataRow mm in t.Rows)
            {
                aa = mm.Field<double>("due_pay");
                nam = mm.Field<string>("name");
                p = mm.Field<string>("phn");
                add = mm.Field<string>("add");
                adv = mm.Field<string>("Advise");
                dis = mm.Field<string>("disease");
                //MessageBox.Show(aa.ToString());
            }
            MetroGrid m = new MetroGrid();
            m.DataSource = t;
            decimal total = Convert.ToDecimal(metroTextBox21.Text);
            if (aa != 0)
            {
                total = total + Convert.ToDecimal(aa);
                i.Updateduepay(Convert.ToDecimal(0), row1, row2);
            }
           it.InsertQuery(nam,Convert.ToDecimal(metroTextBox18.Text),
               Convert.ToDecimal( metroTextBox19.Text),Convert.ToDecimal(metroTextBox20.Text),total,
               Convert.ToDecimal(row0),Convert.ToDecimal(aa));
           temp.InsertQuery(nam, p, add, adv, dis);
            Form3 f = new Form3();
            f.Show();
        }

        private void metroGrid2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void metroPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void metroTile9_Click(object sender, EventArgs e)
        {
            metroPanel2.Visible = true;
           
        }

        private void metroTile9_Click_1(object sender, EventArgs e)
        {
            metroGrid5.Visible = true;
            metroPanel2.Visible = true;
            metroPanel2.Enabled = true;
            metroGrid3.Visible = false;
            metroPanel2.BringToFront();
            metroGrid3.SendToBack();
        }
        public void setnotifications()
        {
            int c = 0;
            for (int i = 0; i < t.Rows.Count; i++)
            {
                string date = t.Rows[i][1].ToString();
                date = date.Replace("-", "");

                Double d = Convert.ToDouble(date);
                Double cd = Convert.ToDouble(DateTime.Now.ToString("yyyy-MM-dd").Replace("-", ""));
                if (d > cd + 1)
                {
                    metroGrid2.Rows.Add();
                    metroGrid2.Rows[c].Cells[0].Value = t.Rows[i][0];
                    metroGrid2.Rows[c].Cells[1].Value = t.Rows[i][3];
                    metroGrid2.Rows[c].Cells[2].Value = t.Rows[i][1];
                    metroGrid2.Update();
                    c++;
                }

            }
        }
        public void setmetrogrid5()
        {
            int c = 0;
            for (int i = 0; i < t.Rows.Count; i++)
            {
                string date = t.Rows[i][1].ToString();
                date = date.Replace("-", "");

                Double d = Convert.ToDouble(date);
                Double cd = Convert.ToDouble(DateTime.Now.ToString("yyyy-MM-dd").Replace("-", ""));
                if (d == cd + 1)
                {
                    metroGrid5.Rows.Add();
                    metroGrid5.Rows[c].Cells[0].Value = t.Rows[i][0];
                    metroGrid5.Rows[c].Cells[1].Value = t.Rows[i][3];
                    metroGrid5.Rows[c].Cells[2].Value = t.Rows[i][1];
                    metroGrid5.Update();
                    c++;
                }

            }
        }

        private void metroButton4_Click(object sender, EventArgs e)
        {
            metroTextBox18.Text = "";
            metroTextBox19.Text = "";
            metroTextBox20.Text = "";
            metroTextBox21.Text = "";
            metroButton3.Enabled = false;

        }

        private void metroTextBox10_Click(object sender, EventArgs e)
        {

        }

        private void metroButton5_Click(object sender, EventArgs e)
        {
            metroTextBox9.Text = "";
            metroTextBox10.Text = "";
            metroTextBox11.Text = "";
        }

        private void metroButton6_Click(object sender, EventArgs e)
        {
            metroTextBox13.Text = "";
            metroTextBox14.Text = "";
            metroTextBox15.Text = "";
            metroTextBox17.Text = "";
            metroTextBox16.Text = "";
        }

        private void metroGrid2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            metroButton7.Enabled = true;

        }

        private void metroButton7_Click(object sender, EventArgs e)
        {
            DataGridViewRow r = new DataGridViewRow();
            r = metroGrid2.SelectedRows[0];
            int i = r.Index;
            notifyTableAdapter.DeleteQuery(r.Cells[0].Value.ToString(), r.Cells[1].Value.ToString());
            metroGrid2.Rows.RemoveAt(i);
           
        }

        private void metroTile10_Click(object sender, EventArgs e)
        {
           
           
           
        }

        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            f.Close();
        }

        private void metroButton8_Click(object sender, EventArgs e)
        {
            this.infoTableAdapter1.Fill(dataSet1.info);

        }

        private void metroButton9_Click(object sender, EventArgs e)
        {
            
            DataGridViewRow r = new DataGridViewRow();
            r = metroGrid6.SelectedRows[0];
            int i = r.Index;
            this.infoTableAdapter1.DeleteQuery(r.Cells[0].Value.ToString(), r.Cells[1].Value.ToString());
            metroGrid6.Rows.RemoveAt(i);
            metroGrid6.Update();
            metroGrid6.Refresh();
            MetroMessageBox.Show(Owner, "Data Successfully Deleted", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            
        }

        private void metroGrid6_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            metroButton9.Enabled = true;
        }

        private void metroTile11_Click(object sender, EventArgs e)
        {
            this.infoTableAdapter1.UpdateQuery2(metroTextBox7.Text, metroTextBox8.Text, metroTextBox22.Text,
                metroTextBox23.Text, metroTextBox24.Text, updn, updp);
            MetroMessageBox.Show(Owner, "Data Successfully Updated", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            updn = "";
            updp = "";
            metroTextBox7.Text = "";
            metroTextBox8.Text = "";
            metroTextBox22.Text = "";
            metroTextBox23.Text = "";
            metroTextBox24.Text = "";
            metroTile11.Enabled = false;

        }

        private void metroGrid6_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            metroPanel3.BringToFront();
            metroPanel3.Visible = true;
            metroPanel3.Enabled = true;
            metroGrid6.Visible = false;
            metroTile11.Enabled = true;
            metroGrid6.SendToBack();
            int i = e.RowIndex;
            metroTextBox7.Text = metroGrid6.Rows[i].Cells[0].Value.ToString();
            metroTextBox8.Text = metroGrid6.Rows[i].Cells[1].Value.ToString();
            metroTextBox22.Text = metroGrid6.Rows[i].Cells[2].Value.ToString();
            metroTextBox23.Text = metroGrid6.Rows[i].Cells[3].Value.ToString();
            metroTextBox24.Text = metroGrid6.Rows[i].Cells[4].Value.ToString();
            updn = metroGrid6.Rows[i].Cells[0].Value.ToString();
            updp = metroGrid6.Rows[i].Cells[1].Value.ToString();
        }

        private void metroTile12_Click(object sender, EventArgs e)
        {
            metroGrid6.Visible = true;
            metroGrid6.BringToFront();
            metroPanel3.SendToBack();
            metroPanel3.Visible = false;
        }

        private void metroGrid1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
         
        }

        private void metroGrid1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = metroGrid1.SelectedRows[0];
            int r = row.Index;

            object temp = row.Cells[3].Value;
            object temp2 = row.Cells[4].Value;
            row1 = row.Cells[1].Value.ToString();
            row2 = row.Cells[2].Value.ToString();
            Form4 f2 = new Form4(row1, row2);
            f2.Show();
        }

        private void metroLabel27_Click(object sender, EventArgs e)
        {

        }

        private void metroTile8_Click_1(object sender, EventArgs e)
        {

        }

        private void metroTile8_Click_2(object sender, EventArgs e)
        {
            try
            {
               
                if (metroTextBox26.Text.Any(char.IsDigit))
                {
                    MessageBox.Show("Invalid Name");
                    return;
                }
                if (metroTextBox27.Text.Any(char.IsLetter))
                {
                    MessageBox.Show("Invalid Phone No");
                    return;
                }
                if (metroTextBox26.Text == "" && metroTextBox27.Text == "")
                {
                    MessageBox.Show("Text Fields are Empty");
                    return;
                }
                if (metroTextBox26.Text != "" && metroTextBox27.Text == "")
                {
                    this.infoTableAdapter1.FillBy(dataSet1.info, metroTextBox26.Text);
                }
                if (metroTextBox26.Text != "" && metroTextBox27.Text != "")
                {
                    this.infoTableAdapter1.FillBy1(dataSet1.info, metroTextBox27.Text, metroTextBox26.Text);
                }
                if (metroTextBox26.Text == "" && metroTextBox27.Text != "")
                {

                    this.infoTableAdapter1.FillBy2(dataSet1.info, metroTextBox27.Text);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void metroGrid6_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            if(metroGrid6.Rows[0].Cells[0].Value!=null)
            metroButton10.Enabled = true;
        }

        private void metroButton10_Click(object sender, EventArgs e)
        {
            Patient_RecordTableAdapter pr = new DataSet1TableAdapters.Patient_RecordTableAdapter();
            for(int i=0; i<metroGrid6.Rows.Count-1; i++)
            {
                pr.InsertQuery(metroGrid6.Rows[i].Cells[0].Value.ToString(),
                    metroGrid6.Rows[i].Cells[1].Value.ToString(), metroGrid6.Rows[i].Cells[2].Value.ToString(),
                    metroGrid6.Rows[i].Cells[3].Value.ToString(), metroGrid6.Rows[i].Cells[4].Value.ToString(),
                    Convert.ToDecimal(metroGrid6.Rows[i].Cells[5].Value.ToString()), Convert.ToDecimal(metroGrid6.Rows[i].Cells[6].Value.ToString()),
                    metroGrid6.Rows[i].Cells[7].Value.ToString());
            }
            Form5 f5 = new Form5();
            f5.Show();
        }

        private void metroTile10_Click_1(object sender, EventArgs e)
        {
            this.infoTableAdapter1.Fill(dataSet1.info);
        }

        private void metroButton11_Click(object sender, EventArgs e)
        {
            notifyTableAdapter n = new DataSet1TableAdapters.notifyTableAdapter();
            DataGridViewRow r = new DataGridViewRow();
            r = metroGrid3.SelectedRows[0];
            int i = r.Index;
            n.DeleteQuery(r.Cells[0].Value.ToString(), r.Cells[1].Value.ToString());
            metroGrid3.Rows.RemoveAt(i);
        }

        private void metroGrid3_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            metroButton11.Enabled = true;
        }

        private void metroGrid3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
