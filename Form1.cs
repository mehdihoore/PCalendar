using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;
using System.Threading;

namespace cal_endar
{
    public partial class Form1 : Form
    {

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
        public Form1()
        {
            InitializeComponent();
            
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            y = persian.GetYear(DateTime.Now);
            m = persian.GetMonth(DateTime.Now);
            d = persian.GetDayOfMonth(DateTime.Now);
            
            s = Convert.ToInt32((persian.GetDayOfWeek(DateTime.Now)));
            button5.Text ="امروز:" + string.Format(" {3} {2} {1} {0:d4}", y, pm[m - 1], d, wd[s + 1]);
        }
        

        private void Label5_Click(object sender, EventArgs e)
        {
            try
            {
                dataGridView1.Rows.Clear();
                dataGridView1.Refresh();
                y = persian.GetYear(dateTimePicker1.Value);
                m = persian.GetMonth(dateTimePicker1.Value);
                d = persian.GetDayOfMonth(dateTimePicker1.Value);
                int noflable6 = Array.IndexOf(pm, label6.Text);
                string dt1 = string.Format("{2:d2}/{1:d2}/{0:d4}", label5.Text, noflable6 + 1, 1);

                DateTime dt2 = DateTime.ParseExact(dt1, "dd/MM/yyyy", CultureInfo.CurrentCulture);
                dateTimePicker1.Value = dt2;
            }
            catch (Exception)
            {

                MessageBox.Show("لطفا ماه و سال را انتخاب کنید");
            }

            //label6.Text =dt2.ToString();
            //dataGridView1.ClearSelection();
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            y = persian.GetYear(dateTimePicker1.Value);
            m = persian.GetMonth(dateTimePicker1.Value);
            d = persian.GetDayOfMonth(dateTimePicker1.Value);


            s = Convert.ToInt32((persian.GetDayOfWeek(dateTimePicker1.Value)));
            // label2.Text = string.Format("{3} {2} {1} {0:d4}", y, pm[m - 1], d, wd[s + 1]);

            int m1= m+count1;
            if (m1<12 && m1>=0)
            {
                label6.Text = Convert.ToString(pm[m1]);

            }
            else
            {
                m = 0;
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

            int m1 = m + count1;
            if (m1 < 12 && m1 >= 0)
            {
                label6.Text = Convert.ToString(pm[m1]);

            }
            else
            {
                m = 0;
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
            label5.Text = persian.GetYear(DateTime.Now).ToString();
            label6.Text = pm[persian.GetMonth(DateTime.Now)-1];
            int y1 = 0, m1 = 0, d1 = 0, s2;
            y1 = persian.GetYear(DateTime.Now);
            m1 = persian.GetMonth(DateTime.Now);
            d1 = persian.GetDayOfMonth(DateTime.Now);
            s2 = Convert.ToInt32(persian.GetDayOfWeek(DateTime.Now));
            string today = $" {pm[m1 - 1]} {y1:d4} {d1}";

            //dataGridView1.Rows[i].Cells[j].Value = $" {pm[m1 - 1]} {y1:d4} {d1}";


            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                for (int j = 0; j < 7; j++)
                {
                    bool v1 = dataGridView1.Rows[i].Cells[j].Value != null;
                    
                    if (v1)
                    {
                        string result = Convert.ToString(dataGridView1.Rows[i].Cells[j].Value);
                        string[] word = result.Split(' ');
                        int word1 = Convert.ToInt32(word[word.Length-1]);
                        //bool v = dataGridView1.Rows[i].Cells[j].Value.ToString().Equals(today);
                        if (word1==d1 )
                        {

                            dataGridView1.Rows[i].Cells[j].Style.SelectionBackColor = Color.DarkGreen;
                            
                        }
                        //else
                        //{
                        //    string tt = dataGridView1.Rows[i].Cells[j].Value.ToString();
                        //    MessageBox.Show("  "+ word1.ToString() + "  "+ d1.ToString()) ;
                        //}
                    }
                    
                   
                    
                }
            }
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
                int noflable6 = Array.IndexOf(pm, label6.Text);
                string dt1 = string.Format("{2:d2}/{1:d2}/{0:d4}", label5.Text, noflable6 + 1, 1);

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

        private void DateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            dateTimePicker1.CustomFormat = Application.CurrentCulture.DateTimeFormat.LongDatePattern;
            try
            {

                y = persian.GetYear(dateTimePicker1.Value);
                m = persian.GetMonth(dateTimePicker1.Value);
                d = persian.GetDayOfMonth(dateTimePicker1.Value);


                s = Convert.ToInt32((persian.GetDayOfWeek(dateTimePicker1.Value)));
                label2.Text = string.Format("{3} {2} {1} {0:d4}", y, pm[m - 1], d, wd[s + 1]);

                ya = arabian.GetYear(dateTimePicker1.Value);
                ma = arabian.GetMonth(dateTimePicker1.Value);
                da = arabian.GetDayOfMonth(dateTimePicker1.Value);
                sa = Convert.ToInt32(arabian.GetDayOfWeek(dateTimePicker1.Value));
                label3.Text = string.Format("{3} {2} {1} {0:d4}", ya, pma[ma - 1], da, wda[sa + 1]);
                DataGridView t = new DataGridView();

                int iYear = persian.GetYear(dateTimePicker1.Value);
                int noflable6 = Array.IndexOf(pm, label6.Text);
                string dt1 = string.Format("{2:d2}/{1:d2}/{0:d4}", label5.Text, noflable6 + 1, 1);
                DateTime dt2 = DateTime.ParseExact(dt1, "dd/MM/yyyy", CultureInfo.CurrentCulture);
                int oyear = persian.GetYear(dt2);
                int month = persian.GetMonth(dt2);
                //int s1= Convert.ToInt32((persian.GetDayOfWeek(dt2)));
                int day = 1;

                //dataGridView1.Rows[0].Cells[s1].Value = string.Format("{3} {2} {1} {0:d4}", y, pm[m - 1], d, wd[s1]);
                for (int i = 1; i < 5; i++)
                {
                    //persian.GetDaysInMonth(iYear, noflable6)
                    //Button[] mo = new Button[persian.GetDaysInMonth(iYear, i)];

                    i = dataGridView1.Rows.Add();




                    for (int j = 0; j < 7; j++)
                    {
                        if (day <= persian.GetDaysInMonth(oyear, month))
                        {
                            int y1 = 0, m1 = 0, d1 = 0, s2, s3 ;
                            string dt3 = string.Format("{2:d2}/{1:d2}/{0:d4}", label5.Text, noflable6 + 1, day++);
                            DateTime dt4 = DateTime.ParseExact(dt3, "dd/MM/yyyy", CultureInfo.CurrentCulture);
                            y1 = persian.GetYear(dt4);
                            m1 = persian.GetMonth(dt4);
                            d1 = persian.GetDayOfMonth(dt4);
                            s2 = Convert.ToInt32(persian.GetDayOfWeek( dt4));
                            s3 = Array.IndexOf(wd, wd[s2+1]);
                            j = s3;
                            dataGridView1.Rows[i].Cells[j].Value = $" {pm[m1 - 1]} {y1:d4} {d1}";
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


                s = Convert.ToInt32((persian.GetDayOfWeek(dateTimePicker1.Value)));
                label2.Text = string.Format("{3} {2} {1} {0:d4}", y, pm[m - 1], d, wd[s + 1]);

                ya = arabian.GetYear(dateTimePicker1.Value);
                ma = arabian.GetMonth(dateTimePicker1.Value);
                da = arabian.GetDayOfMonth(dateTimePicker1.Value);
                sa = Convert.ToInt32(arabian.GetDayOfWeek(dateTimePicker1.Value));
                label3.Text = string.Format("{3} {2} {1} {0:d4}", ya, pma[ma - 1], da, wda[sa + 1]);
                DataGridView t = new DataGridView();

                int iYear = persian.GetYear(dateTimePicker1.Value);
                int noflable6 = Array.IndexOf(pm, label6.Text);
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
                            dataGridView1.Rows[i].Cells[j].Value = $"  {pm[m1 - 1]} {y1:d4} {d1}";
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
                int noflable6 = Array.IndexOf(pm, label6.Text);
                string result = Convert.ToString(dataGridView1.CurrentCell.Value);
                string[] word = result.Split(' ');
                int word1 =Convert.ToInt32( word[4]);
                string dt1 = string.Format("{2:d2}/{1:d2}/{0:d4}", label5.Text, noflable6 + 1, word1);
                
                
                DateTime dt2 = DateTime.ParseExact(dt1, "dd/MM/yyyy", CultureInfo.CurrentCulture);
                //dateTimePicker2.Value = dt2;
                MessageBox.Show(":مناسبتهای امروز "+ "\n"+ " in the next version");
            }
            catch (Exception)
            {
                y = persian.GetYear(dateTimePicker1.Value);
                m = persian.GetMonth(dateTimePicker1.Value);
                d = persian.GetDayOfMonth(dateTimePicker1.Value);
                //int noflable6 = Array.IndexOf(pm, label6.Text);
                string result = Convert.ToString(dataGridView1.CurrentCell.Value);
                string[] word = result.Split(' ');
                //.Substring(0, dataGridView1.CurrentCell.Value.ToString().Length-1);
                //int word1 = Convert.ToInt32(word[4]);
                //string dt1 = string.Format("{2:d2}/{1:d2}/{0:d4}", y, m + 1, word1);
                //DateTime dt2 = DateTime.ParseExact(dt1, "dd/MM/yyyy", CultureInfo.CurrentCulture);
                //dateTimePicker2.Value = dt2;
                //MessageBox.Show(dt1);
                //MessageBox.Show(word1.ToString());
                MessageBox.Show(":مناسبتهای امروز " + "\n" + " in the next version");
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


            label5.Text = Convert.ToString(y+count);
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
            label5.Text = Convert.ToString(y + count);
             


            //string dt1 = string.Format("{2:d2}/{1:d2}/{0:d4}", label5.Text, m, d);
           // DateTime dt2 = DateTime.ParseExact(dt1, "dd/MM/yyyy", CultureInfo.CurrentCulture);
           // dateTimePicker1.Value = dt2;

        }
    }
}
