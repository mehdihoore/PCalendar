using System;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Globalization;
using System.Reflection;
using System.Timers;
using System.Windows.Forms;

namespace cal_endar
{
   
    public partial class Form1 : Form
    {
    
        private SQLiteConnection sql_con;
        private SQLiteCommand sql_com;
        private SQLiteDataAdapter DB;
        private DataSet DS = new DataSet();
        private DataTable DT = new DataTable();
        GregorianCalendar geri = new GregorianCalendar();
        int yg = 0, mg = 0, dg = 0;
        PersianCalendar persian = new PersianCalendar();
        string[] wd = new string[] { "شنبه", "یکشنبه", "دوشنبه", "سه شنبه", "چهارشنبه", "پنجشنبه", "جمعه", "شنبه" };
        string[] pm = new string[] { "فروردین", "اردیبهشت", "خرداد", "تیر", "مرداد", "شهریور", "مهر", "آبان", "آذر", "دی", "بهمن", "اسفند" };
        int y = 0, m = 0, d = 0, s = 0;
        HijriCalendar arabian = new HijriCalendar();
        int ya = 0, ma = 0, da = 0, sa = 0;
        string[] wda = new string[] { "السّبت", "الأحد", "الإثنین", "الثُلاثاء", "الأربعاء", "الخمیس", "الجمعة", "السّبت" };
        string[] pma = new string[] { "محرم", "صفر", "ربیع الاول", "ربیع الثانی", "جمادی الاولی", "جمادی الثانی", "رجب", "شعبان", "رمضان", "شوال", "ذوالقعده", "ذوالحجه" };

        
        int count1;
        int count=0;
        int count2 = 0;
        ToolTip z = new ToolTip();
        private void SetConnection()
        {
            sql_con = new SQLiteConnection
            ("Data Source = rooidad.db ; Version=3; New=False; Compress=True");
        }
        //set executry
        private void ExecuteQuery(string txtQuery)
        {
            SetConnection();
            sql_con.Open();
            sql_com = sql_con.CreateCommand();
            sql_com.CommandText = txtQuery;
            sql_com.ExecuteNonQuery();
            sql_con.Close();
        }
        //set loadDb
        private void LoadData()
        {
            SetConnection();
            sql_con.Open();
            sql_com = sql_con.CreateCommand();
            string CommandText = "select * from roi";
            DB = new SQLiteDataAdapter(CommandText, sql_con);
            DS.Reset();
            DB.Fill(DS);
            DT = DS.Tables[0];
            
            sql_con.Close();

        }
        public Form1()
        {
            InitializeComponent();
            
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //LoadData();
            y = persian.GetYear(DateTime.Now);
            m = persian.GetMonth(DateTime.Now);
            d = persian.GetDayOfMonth(DateTime.Now);
            string monthp = CultureInfo.GetCultureInfo("fa-IR").DateTimeFormat.GetMonthName(m);
            string dayp = CultureInfo.GetCultureInfo("fa-IR").DateTimeFormat.GetDayName(persian.GetDayOfWeek(DateTime.Now));
            button5.Text ="امروز:" + string.Format(" {3} {2} {1} {0:d4}", y, monthp, d, dayp);
            ya = arabian.GetYear(DateTime.Now);
            ma = arabian.GetMonth(DateTime.Now);
            da = arabian.GetDayOfMonth(DateTime.Now);
            string montha = CultureInfo.GetCultureInfo("ar").DateTimeFormat.GetMonthName(ma);
            string daya = CultureInfo.GetCultureInfo("ar").DateTimeFormat.GetDayName(arabian.GetDayOfWeek(DateTime.Now));
            string arab = string.Format("{3} {2} {1} {0:d4}", ya, montha, da, daya);
            yg = geri.GetYear(DateTime.Now);
            mg = geri.GetMonth(DateTime.Now);
           
            string monname = CultureInfo.GetCultureInfo("en-US").DateTimeFormat.GetMonthName(mg);
            dg = geri.GetDayOfMonth(DateTime.Now);
            DayOfWeek sg = geri.GetDayOfWeek(DateTime.Now);
            string gerig = string.Format("{3} {2} {1} {0:d4}", yg, monname, dg, sg);
            SetConnection();
            sql_con.Open();
            sql_com = sql_con.CreateCommand();
            string CommandText = "SELECT RoydadT FROM roi WHERE month = '" + persian.GetMonth(DateTime.Now) + "' and day = '" + persian.GetDayOfMonth(DateTime.Now) + "' ";
            DB = new SQLiteDataAdapter(CommandText, sql_con);
            DS.Reset();
            DB.Fill(DS);
            DT = DS.Tables[0];
            dataGridView2.DataSource = DT;
            string monasebatha = dataGridView2.CurrentCell.Value.ToString();
            sql_con.Close();
            if (this.WindowState == FormWindowState.Normal)
            {
                
                notifyIcon1.BalloonTipIcon = ToolTipIcon.Info;
                notifyIcon1.BalloonTipTitle = "تاریخ امروز:";
                notifyIcon1.BalloonTipText = string.Format("{0}\n,{1}\n,{2},{3}", button5.Text, arab, gerig,monasebatha);
                notifyIcon1.ShowBalloonTip(6000);
            }
            string arab1 = string.Format("ه.ق: {2}/{1}/{0:d4}", ya, ma, da);
            string gerig1 = string.Format("م:{2}/{1:d2}/{0:d4}", yg, mg, dg);

            notifyIcon1.Text = string.Format("{0}\n {1}\n {2}\n ", button5.Text, gerig1, monasebatha);  

        }

        private bool dragging = false;
        private Point dragCursorPoint;
        private Point dragFormPoint;
        private System.Timers.Timer aTimer;

        public void DateBall()
        {
            SetConnection();
            sql_con.Open();
            sql_com = sql_con.CreateCommand();
            string CommandText = "SELECT RoydadT FROM roi WHERE month = '" + persian.GetMonth(DateTime.Now) + "' and day = '" + persian.GetDayOfMonth(DateTime.Now) + "' ";
            DB = new SQLiteDataAdapter(CommandText, sql_con);
            DS.Reset();
            DB.Fill(DS);
            DT = DS.Tables[0];
            dataGridView2.DataSource = DT;
            string monasebatha = dataGridView2.CurrentCell.Value.ToString();
            sql_con.Close();

        }
        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                dataGridView1.Rows.Clear();
                dataGridView1.Refresh();
                y = persian.GetYear(dateTimePicker1.Value);
                m = persian.GetMonth(dateTimePicker1.Value);
                d = persian.GetDayOfMonth(dateTimePicker1.Value);
                int noflable6 = Array.IndexOf(pm, button7.Text);
                string dt1 = string.Format("{2:d2}/{1:d2}/{0:d4}", button6.Text, noflable6 + 1, 1);

                DateTime dt2 = DateTime.ParseExact(dt1, "dd/MM/yyyy", CultureInfo.CurrentCulture);
                dateTimePicker1.Value = dt2;
            }
            catch (Exception)
            {

                MessageBox.Show("لطفا ماه و سال را انتخاب کنید");
            }
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            y = persian.GetYear(dateTimePicker1.Value);
            m = persian.GetMonth(dateTimePicker1.Value);
            d = persian.GetDayOfMonth(dateTimePicker1.Value);


            s = Convert.ToInt32((persian.GetDayOfWeek(dateTimePicker1.Value)));
            // label2.Text = string.Format("{3} {2} {1} {0:d4}", y, pm[m - 1], d, wd[s + 1]);

           
            if (count1<12 )
            {
                //int m1 = m + count1;
                button7.Text = Convert.ToString(pm[count1]);

            }
            else
            {
                count1 = 0;
                button7.Text = Convert.ToString(pm[count1]);
                // button7.Text = Convert.ToString(pm[m1]);
            }
            count1++;
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            count1--;
            y = persian.GetYear(dateTimePicker1.Value);
            m = persian.GetMonth(dateTimePicker1.Value);
            d = persian.GetDayOfMonth(dateTimePicker1.Value);


            s = Convert.ToInt32((persian.GetDayOfWeek(dateTimePicker1.Value)));
            // label2.Text = string.Format("{3} {2} {1} {0:d4}", y, pm[m - 1], d, wd[s + 1]);

            if (count1 >= 0)
            {
                //int m1 = m + count1;
                button7.Text = Convert.ToString(pm[count1]);

            }
            else
            {
                count1 = 0;
                button7.Text = Convert.ToString(pm[count1]);

                // button7.Text = Convert.ToString(pm[m1]);
            }

        }

        private void Label2_Click(object sender, EventArgs e)
        {

        }
       
        private void Button5_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            dataGridView1.Refresh();
            dateTimePicker1.Value = DateTime.Now;
            button6.Text = persian.GetYear(DateTime.Now).ToString();
            button7.Text = pm[persian.GetMonth(DateTime.Now) - 1];
            int y1 = 0, m1 = 0, d1 = 0;
            NewMethod(out y1, out m1);
            d1 = persian.GetDayOfMonth(DateTime.Now);
            
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                for (int j = 0; j < 7; j++)
                {
                    bool v1 = dataGridView1.Rows[i].Cells[j].Value != null;

                    if (v1)
                    {
                        string result = Convert.ToString(dataGridView1.Rows[i].Cells[j].Value);
                        string[] word = result.Split(' ');
                        int word1 = Convert.ToInt32(word[word.Length - 1]);
                        bool v = dataGridView1.Rows[i].Cells[j].Value.ToString().Equals(wd);
                        if (word1 == d1)
                        {
                            dataGridView1.Rows[i].Cells[j].Style.BackColor = Color.DarkGreen;
                            dataGridView1.Rows[i].Cells[j].Style.ForeColor = Color.White;
                        }
                        //else
                        //{
                        //    string tt = dataGridView1.Rows[i].Cells[j].Value.ToString();
                        //    MessageBox.Show("  " + word1.ToString() + "  " + d1.ToString());
                        //}
                    }



                }
            }
        }

        private void NewMethod(out int y1, out int m1)
        {
            y1 = persian.GetYear(DateTime.Now);
            m1 = persian.GetMonth(DateTime.Now);
        }

        private void Button6_Click(object sender, EventArgs e)
        {

            try
            {
                dataGridView1.Rows.Clear();
                dataGridView1.Refresh();
                y = persian.GetYear(dateTimePicker1.Value);
                m = persian.GetMonth(dateTimePicker1.Value);
                d = persian.GetDayOfMonth(dateTimePicker1.Value);
                int noflable6 = Array.IndexOf(pm, button7.Text);
                string dt1 = string.Format("{2:d2}/{1:d2}/{0:d4}", button6.Text, noflable6 + 1, 1);

                DateTime dt2 = DateTime.ParseExact(dt1, "dd/MM/yyyy", CultureInfo.CurrentCulture);
                dateTimePicker1.Value = dt2;
            }
            catch (Exception)
            {

                MessageBox.Show("لطفا ماه و سال را انتخاب کنید");
            }
        }

        private void DataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {

        }

        private void Button8_Click(object sender, EventArgs e)
        {
            Form2 add = new Form2();
            add.Tag = add.ShowDialog();
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            this.Opacity = 0.5;
            dragging = true;
            dragCursorPoint = Cursor.Position;
            dragFormPoint = this.Location;
        }

        private void Form1_MouseHover(object sender, EventArgs e)
        {
            this.Opacity = 1;
            z.Show("برای خروج و پنهان شدن \nکلیک راست را بفشارید", this);
        }

        private void Form1_MouseLeave(object sender, EventArgs e)
        {
           
            
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
           
            if (e.CloseReason == CloseReason.UserClosing)
                e.Cancel = true;
        }

        private void NotifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            //Application.CurrentCulture{ "Fa;IR"};
        }

        private void ContextMenuStrip2_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }

        private void تقویم_Click(object sender, EventArgs e)
        {
          this.Show();
        }

        private void محاسبهزمان_Click(object sender, EventArgs e)
        {
            Form2 f = new Form2();
            f.Tag = f.ShowDialog();
        }

        private void تعیینشفافیت_Click(object sender, EventArgs e)
        {

        }

        private void خروجToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void خروج_Click(object sender, EventArgs e)
        {

        }

        private void پنهانشدنToolStripMenuItem_Click(object sender, EventArgs e)
        {
           this.Hide();
        }

        private void Button8_MouseHover(object sender, EventArgs e)
        {
           
            ToolTip y = new ToolTip();
            y.Show("با کلیک بر این قسمت محاسبات زمان \nدر فرمی جدا به شما نمایش داده می شود.", button8);
            Opacity = 0.9;
           

        }

        private void خروجToolStripMenuItem1_MouseHover(object sender, EventArgs e)
        {
            
            z.Show("با کلیک بر این دکمه \nاز برنامه خارج می شوید ",this);
            Opacity = 0.9;
        }

        private void NotifyIcon1_DoubleClick(object sender, EventArgs e)
        {
            if (count2==0)
            {
                this.Hide();
                PersianCalendar pc = new PersianCalendar();
                DateTime thisDate = DateTime.Now;

                // Display the current date using the Gregorian and Persian calendars.
                pc.GetDayOfWeek(thisDate);
                 pc.GetMonth(thisDate);
                pc.GetDayOfMonth(thisDate);
                pc.GetYear(thisDate);
                pc.GetHour(thisDate);
                pc.GetMinute(thisDate);
                pc.GetSecond(thisDate);
                string txtQuery = "SELECT RoydadT FROM roi WHERE month= '" + pc.GetMonth(thisDate) + "' and day= '" + pc.GetDayOfMonth(thisDate) + "' "; ;
                DB = new SQLiteDataAdapter(txtQuery, sql_con);
                DS.Reset();
                DB.Fill(DS);
                DT = DS.Tables[0];
                ExecuteQuery(txtQuery);
                dataGridView2.DataSource = DT;
                string monasebat = dataGridView2.CurrentCell.Value.ToString();
                sql_con.Close();
                notifyIcon1.ShowBalloonTip(1000, "تاریخ امروز", button5.Text+"\n"+monasebat, ToolTipIcon.Info);
            }
            else if (count2 == 1)
            {
                this.Show();
            }
            else if ((count2 % 2)>0)
            {
                this.Hide();
            }
            else if ((count2 % 2) == 0)
            {
                this.Show();
            }
            count2++;
        }

        private void Button10_Click(object sender, EventArgs e)
        {
           
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
           
        }

        
        
        int i = 0;

        private void Timer1_Tick_1(object sender, EventArgs e)
        {
            i++;
            if (i==60)
            {
                y = persian.GetYear(DateTime.Now);
                m = persian.GetMonth(DateTime.Now);
                d = persian.GetDayOfMonth(DateTime.Now);
                string monthp = CultureInfo.GetCultureInfo("fa-IR").DateTimeFormat.GetMonthName(m);
                string dayp = CultureInfo.GetCultureInfo("fa-IR").DateTimeFormat.GetDayName(persian.GetDayOfWeek(DateTime.Now));
                button5.Text = "امروز:" + string.Format(" {3} {2} {1} {0:d4}", y, monthp, d, dayp);
                i = 0;
                Button5_Click(null, null);
              
            }
         
        }

        private void Button9_Click(object sender, EventArgs e)
        {
            Form4 f = new Form4();
            f.Show();
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            this.Opacity = 1;
           
        }

        private void DateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            dateTimePicker1.CustomFormat = Application.CurrentCulture.DateTimeFormat.LongDatePattern;
            try
            {

                y = persian.GetYear(dateTimePicker1.Value);
                m = persian.GetMonth(dateTimePicker1.Value);
                d = persian.GetDayOfMonth(dateTimePicker1.Value);
                string monthp = CultureInfo.GetCultureInfo("fa-IR").DateTimeFormat.GetMonthName(m);
                string dayp = CultureInfo.GetCultureInfo("fa-IR").DateTimeFormat.GetDayName(persian.GetDayOfWeek(dateTimePicker1.Value));
                label2.Text = string.Format("{3} {2} {1} {0:d4}", y, monthp, d, dayp);

                ya = arabian.GetYear(dateTimePicker1.Value);
                ma = arabian.GetMonth(dateTimePicker1.Value);
                da = arabian.GetDayOfMonth(dateTimePicker1.Value);
                sa = Convert.ToInt32(arabian.GetDayOfWeek(dateTimePicker1.Value));
                string montha = CultureInfo.GetCultureInfo("ar").DateTimeFormat.GetMonthName(ma);
                string daya = CultureInfo.GetCultureInfo("ar").DateTimeFormat.GetDayName(arabian.GetDayOfWeek(dateTimePicker1.Value));
                string arab = string.Format("{3} {2} {1} {0:d4}", ya, montha, da, daya);
                label3.Text = arab;
                DataGridView t = new DataGridView();

                int iYear = persian.GetYear(dateTimePicker1.Value);
                int noflable6 = Array.IndexOf(pm, button7.Text);
                string dt1 = string.Format("{2:d2}/{1:d2}/{0:d4}", button6.Text, noflable6 + 1, 1);
                DateTime dt2 = DateTime.ParseExact(dt1, "dd/MM/yyyy", CultureInfo.CurrentCulture);
                int oyear = persian.GetYear(dt2);
                int month = persian.GetMonth(dt2);
                //int s1= Convert.ToInt32((persian.GetDayOfWeek(dt2)));
                int day = 1;
                dataGridView1.Rows.Clear();
                dataGridView1.Refresh();
                //dataGridView1.Rows[0].Cells[s1].Value = string.Format("{3} {2} {1} {0:d4}", y, pm[m - 1], d, wd[s1]);
                for (int i = 1; i < 5; i++)
                {//persian.GetDaysInMonth(iYear, noflable6)
                    //Button[] mo = new Button[persian.GetDaysInMonth(iYear, i)];
                    i = dataGridView1.Rows.Add();
                    for (int j = 0; j < 7; j++)
                    {
                        if (day <= persian.GetDaysInMonth(oyear, month))
                        {
                            int y1 = 0, m1 = 0, d1 = 0, s2, s3 ;
                            string dt3 = string.Format("{2:d2}/{1:d2}/{0:d4}", button6.Text, noflable6 + 1, day++);
                            DateTime dt4 = DateTime.ParseExact(dt3, "dd/MM/yyyy", CultureInfo.CurrentCulture);
                            y1 = persian.GetYear(dt4);
                            m1 = persian.GetMonth(dt4);
                            d1 = persian.GetDayOfMonth(dt4);
                            s2 = Convert.ToInt32(persian.GetDayOfWeek( dt4));
                            s3 = Array.IndexOf(wd, wd[s2+1]);
                            j = s3;
                            dataGridView1.Rows[i].Cells[j].Value = $"{d1}";
                        }


                        //string.Format("{3} {2} {1} {0:d4}", y, pm[m - 1], d, wd[s]);



                    }
                }
            }
            catch (Exception)
            {


                y = persian.GetYear(dateTimePicker1.Value);
                m = persian.GetMonth(dateTimePicker1.Value);
                d = persian.GetDayOfMonth(dateTimePicker1.Value);


                string monthp = CultureInfo.GetCultureInfo("fa-IR").DateTimeFormat.GetMonthName(m);
                string dayp = CultureInfo.GetCultureInfo("fa-IR").DateTimeFormat.GetDayName(persian.GetDayOfWeek(dateTimePicker1.Value));
                label2.Text = string.Format("{3} {2} {1} {0:d4}", y, monthp, d, dayp);

                ya = arabian.GetYear(dateTimePicker1.Value);
                ma = arabian.GetMonth(dateTimePicker1.Value);
                da = arabian.GetDayOfMonth(dateTimePicker1.Value);
                string montha = CultureInfo.GetCultureInfo("ar").DateTimeFormat.GetMonthName(ma);
                string daya = CultureInfo.GetCultureInfo("ar").DateTimeFormat.GetDayName(arabian.GetDayOfWeek(dateTimePicker1.Value));
                string arab = string.Format("{3} {2} {1} {0:d4}", ya, montha, da, daya);
                label3.Text = arab;
                DataGridView t = new DataGridView();

                int iYear = persian.GetYear(dateTimePicker1.Value);
                int noflable6 = Array.IndexOf(pm, button7.Text);
                string dt1 = string.Format("{2:d2}/{1:d2}/{0:d4}", y, m, 1);
                DateTime dt2 = DateTime.ParseExact(dt1, "dd/MM/yyyy", CultureInfo.CurrentCulture);
                int oyear = persian.GetYear(dt2);
                int month = persian.GetMonth(dt2);
                int s1 = Convert.ToInt32((persian.GetDayOfWeek(dt2)));
                int day = 1;

                //    //dataGridView1.Rows[0].Cells[s1].Value = string.Format("{3} {2} {1} {0:d4}", y, pm[m - 1], d, wd[s1]);
                for (int i = 1; i < 5; i++)
                {
                    //        //persian.GetDaysInMonth(iYear, noflable6)
                    //        //Button[] mo = new Button[persian.GetDaysInMonth(iYear, i)];

                    i = dataGridView1.Rows.Add();




                    for (int j = 0; j < 7; j++)
                    {
                        if (day <= persian.GetDaysInMonth(oyear, month))
                        {
                            int y1 = 0, m1 = 0, d1 = 0, s2 = 0, s3;
                            string dt3 = string.Format("{2:d2}/{1:d2}/{0:d4}", y, m, day++);
                            DateTime dt4 = DateTime.ParseExact(dt3, "dd/MM/yyyy", CultureInfo.CurrentCulture);
                            y1 = persian.GetYear(dt4);
                            m1 = persian.GetMonth(dt4);
                            d1 = persian.GetDayOfMonth(dt4);
                            s2 = Convert.ToInt32(persian.GetDayOfWeek(dt4));
                            s3 = Array.IndexOf(wd, wd[s2 + 1]);
                            j = s3;
                            dataGridView1.Rows[i].Cells[j].Value = $"{d1}";
                        }


                        //string.Format("{3} {2} {1} {0:d4}", y, pm[m - 1], d, wd[s]);



                    }
                }
            }

            //dataGridView1.Rows[i].Cells[i].Value=

            //int[] days = new int[persian.GetDaysInMonth(iYear, i)];

            //days[i] = dataGridView1.Rows.Add();





        }



            private void Label3_Click(object sender, EventArgs e)
        {
            
        }

        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {

                y = persian.GetYear(dateTimePicker1.Value);
                m = persian.GetMonth(dateTimePicker1.Value);
                d = persian.GetDayOfMonth(dateTimePicker1.Value);
                int noflable6 = Array.IndexOf(pm, button7.Text);
                string result = Convert.ToString(dataGridView1.CurrentCell.Value);
                string[] word = result.Split(' ');
                //int word1 =Convert.ToInt32( word[4]);
                int word1 = Convert.ToInt32(word[word.Length - 1]);
                string dt1 = string.Format("{2:d2}/{1:d2}/{0:d4}", button6.Text, noflable6 + 1, word1);
                int mah = noflable6 + 1;
                
                DateTime dt2 = DateTime.ParseExact(dt1, "dd/MM/yyyy", CultureInfo.CurrentCulture);
                //dateTimePicker2.Value = dt2;
                SetConnection();
                sql_con.Open();
                sql_com = sql_con.CreateCommand();
                string txtQuery = "SELECT RoydadT FROM roi WHERE month= '" + mah + "' and day= '" + word1 + "' ";

                DB = new SQLiteDataAdapter(txtQuery, sql_con);
                DS.Reset();
                DB.Fill(DS);
                DT = DS.Tables[0];
               ExecuteQuery(txtQuery);
                dataGridView2.DataSource = DT;
                string monasebat = dataGridView2.CurrentCell.Value.ToString();
                sql_con.Close();

                //for hijri calander
                ya = arabian.GetYear(dateTimePicker1.Value);
                ma = arabian.GetMonth(dateTimePicker1.Value);
                da = arabian.GetDayOfMonth(dateTimePicker1.Value);
                 DateTime thisDate = DateTime.Now;
                thisDate = persian.ToDateTime(Convert.ToInt32( button6.Text), mah, word1,0,0,0,0);
                int rooz=arabian.GetDayOfMonth(thisDate)-1;
                int shahr = arabian.GetMonth(thisDate);
                SetConnection();
                sql_con.Open();
                sql_com = sql_con.CreateCommand();
                string txtQuery1 = "SELECT RoydadT FROM roiA WHERE month= '" + shahr + "' and day= '" + rooz + "' ";

                DB = new SQLiteDataAdapter(txtQuery1, sql_con);
                DS.Reset();
                DB.Fill(DS);
                DT = DS.Tables[0];
                ExecuteQuery(txtQuery1);
                dataGridView3.DataSource = DT;
                string monasebat1 = dataGridView3.CurrentCell.Value.ToString();
                sql_con.Close();
                //for Gerigurian calander
                 
                int dayy =geri.GetDayOfMonth(thisDate);
                int monthh = geri.GetMonth(thisDate);
                SetConnection();
                sql_con.Open();
                sql_com = sql_con.CreateCommand();
                string txtQuery2 = "SELECT RoydadT FROM roiM WHERE month= '" + monthh + "' and day= '" + dayy + "' ";

                DB = new SQLiteDataAdapter(txtQuery2, sql_con);
                DS.Reset();
                DB.Fill(DS);
                DT = DS.Tables[0];

                ExecuteQuery(txtQuery2);
                dataGridView4.DataSource = DT;
                string monasebat2 = dataGridView4.CurrentCell.Value.ToString();
                sql_con.Close();
                if (monasebat == ""&& monasebat1=="")
                {
                    MessageBox.Show(  "بی مناسبت");
                }
                else
                {
                   
                    MessageBox.Show(":مناسبتهای امروز " + "\n" + dt1+ monasebat +"\n"+ monasebat1+ "\n"+monasebat2);
                }
               
                //LoadData();
                //dataGridView2.DataSource
                //MessageBox.Show(":مناسبتهای امروز " + "\n" + " in the next version"+ "\n"+dt2.ToString()+ "\n"+ dt1+ "\n"+y.ToString()+ "\n"+m.ToString()+ "\n"+
                //    d.ToString()+ "\n"+ monasebat);
            }
            catch (Exception)
            {
              
                
                
                //MessageBox.Show(":مناسبتهای امروز " + "\n" +rooz.ToString()+shahr.ToString() +"\n"+ dayy +monthh+ "\n" );
            }




        }

        private void MonthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {

        }

        public void Button1_Click(object sender, EventArgs e)
        {
           
            y = persian.GetYear(dateTimePicker1.Value);
            m = persian.GetMonth(dateTimePicker1.Value);
            d = persian.GetDayOfMonth(dateTimePicker1.Value);


            s = Convert.ToInt32((persian.GetDayOfWeek(dateTimePicker1.Value)));
            // label2.Text = string.Format("{3} {2} {1} {0:d4}", y, pm[m - 1], d, wd[s + 1]);


            button6.Text = Convert.ToString(y+count);
            count++;
            
            //string year = dateTimePicker1.Value.ToString("yyyy");
            
            


        }

        public void Button2_Click(object sender, EventArgs e)
        {
           
            y = persian.GetYear(dateTimePicker1.Value);
            m = persian.GetMonth(dateTimePicker1.Value);
            d = persian.GetDayOfMonth(dateTimePicker1.Value);


            s = Convert.ToInt32((persian.GetDayOfWeek(dateTimePicker1.Value)));
            count--;
            button6.Text = Convert.ToString(y + count);
             


            //string dt1 = string.Format("{2:d2}/{1:d2}/{0:d4}", button6.Text, m, d);
           // DateTime dt2 = DateTime.ParseExact(dt1, "dd/MM/yyyy", CultureInfo.CurrentCulture);
           // dateTimePicker1.Value = dt2;

        }
    }
}
