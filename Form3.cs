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

namespace cal_endar
{
    public partial class Form3 : Form
    {
        
        PersianCalendar persian = new PersianCalendar();
        string[] wd = new string[] { "شنبه", "یکشنبه", "دوشنبه", "سه شنبه", "چهارشنبه", "پنجشنبه", "جمعه", "شنبه" };
        string[] pm = new string[] { "فروردین", "اردیبهشت", "خرداد", "تیر", "مرداد", "شهریور", "مهر", "آبان", "آذر", "دی", "بهمن", "اسفند" };
        int y = 0, m = 0, d = 0, s = 0;
        HijriCalendar arabian = new HijriCalendar();
        int ya = 0, ma = 0, da = 0, sa = 0;
        string[] wda = new string[] { "السّبت", "الأحد", "الإثنین", "الثُلاثاء", "الأربعاء", "الخمیس", "الجمعة", "السّبت" };
        string[] pma = new string[] { "محرم", "صفر", "ربیع الاول", "ربیع الثانی", "جمادی الاولی", "جمادی الثانی", "رجب", "شعبان", "رمضان", "شوال", "ذوالقعده", "ذوالحجه" };

        private void Button1_Click(object sender, EventArgs e)
        {


            y = persian.GetYear(dateTimePicker1.Value);
            m = persian.GetMonth(dateTimePicker1.Value);
            d = persian.GetDayOfMonth(dateTimePicker1.Value);


            s = Convert.ToInt32((persian.GetDayOfWeek(dateTimePicker1.Value)));
            // label2.Text = string.Format("{3} {2} {1} {0:d4}", y, pm[m - 1], d, wd[s + 1]);


            button6.Text = Convert.ToString(y + count);
            count++;
        }

        private void Button2_Click(object sender, EventArgs e)
        {

            y = persian.GetYear(dateTimePicker1.Value);
            m = persian.GetMonth(dateTimePicker1.Value);
            d = persian.GetDayOfMonth(dateTimePicker1.Value);


            s = Convert.ToInt32((persian.GetDayOfWeek(dateTimePicker1.Value)));
            count--;
            button6.Text = Convert.ToString(y + count);

        }

        private void Button4_Click(object sender, EventArgs e)
        {

            y = persian.GetYear(dateTimePicker1.Value);
            m = persian.GetMonth(dateTimePicker1.Value);
            d = persian.GetDayOfMonth(dateTimePicker1.Value);


            s = Convert.ToInt32((persian.GetDayOfWeek(dateTimePicker1.Value)));
            // label2.Text = string.Format("{3} {2} {1} {0:d4}", y, pm[m - 1], d, wd[s + 1]);


            if (count1 < 12)
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

        private void Button7_Click(object sender, EventArgs e)
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

        private void DateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            dateTimePicker1.CustomFormat = Application.CurrentCulture.DateTimeFormat.LongDatePattern;
            try
            {
                dataGridView1.Rows.Clear();
                dataGridView1.Refresh();
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
                int noflable6 = Array.IndexOf(pm, button7.Text);
                string dt1 = string.Format("{2:d2}/{1:d2}/{0:d4}", button6.Text, noflable6 + 1, 1);
                DateTime dt2 = DateTime.ParseExact(dt1, "dd/MM/yyyy", CultureInfo.CurrentCulture);
                int oyear = persian.GetYear(dt2);
                int month = persian.GetMonth(dt2);
                //int s1= Convert.ToInt32((persian.GetDayOfWeek(dt2)));
                int day = 1;
                
                //dataGridView1.Rows[0].Cells[s1].Value = string.Format("{3} {2} {1} {0:d4}", y, pm[m - 1], d, wd[s1]);
                for (int i = 1; i < 5; i++)
                {//persian.GetDaysInMonth(iYear, noflable6)
                    //Button[] mo = new Button[persian.GetDaysInMonth(iYear, i)];
                    i = dataGridView1.Rows.Add();
                    for (int j = 0; j < 7; j++)
                    {
                        if (day <= persian.GetDaysInMonth(oyear, month))
                        {
                            int y1 = 0, m1 = 0, d1 = 0, s2, s3;
                            string dt3 = string.Format("{2:d2}/{1:d2}/{0:d4}", button6.Text, noflable6 + 1, day++);
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
               label5.Text = y.ToString();
                label6.Text = pm[m - 1];
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
                label5.Text = y.ToString();
                label6.Text = pm[m - 1];
            }
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            this.Close();
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


                DateTime dt2 = DateTime.ParseExact(dt1, "dd/MM/yyyy", CultureInfo.CurrentCulture);
                y = persian.GetYear(dt2);
                m = persian.GetMonth(dt2);
                d = persian.GetDayOfMonth(dt2);


                s = Convert.ToInt32((persian.GetDayOfWeek(dt2)));
                label2.Text = string.Format("{3} {2} {1} {0:d4}", y, pm[m - 1], d, wd[s + 1]);

                ya = arabian.GetYear(dt2);
                ma = arabian.GetMonth(dt2);
                da = arabian.GetDayOfMonth(dt2);
                sa = Convert.ToInt32(arabian.GetDayOfWeek(dt2));
                label3.Text = string.Format("{3} {2} {1} {0:d4}", ya, pma[ma - 1], da, wda[sa + 1]);
               // MessageBox.Show(":مناسبتهای امروز " + "\n" + " in the next version");
            }
            catch (Exception)
            {
                y = persian.GetYear(dateTimePicker1.Value);
                m = persian.GetMonth(dateTimePicker1.Value);
                d = persian.GetDayOfMonth(dateTimePicker1.Value);
                //int noflable6 = Array.IndexOf(pm, button7.Text);
                string result = Convert.ToString(dataGridView1.CurrentCell.Value);
                string[] word = result.Split(' ');
                //.Substring(0, dataGridView1.CurrentCell.Value.ToString().Length - 1);
                int word1 = Convert.ToInt32(word[word.Length - 1]);
                string dt1 = string.Format("{2:d2}/{1:d2}/{0:d4}", y, m , word1);
                DateTime dt2 = DateTime.ParseExact(dt1, "dd/MM/yyyy", CultureInfo.CurrentCulture);
                y = persian.GetYear(dt2);
                m = persian.GetMonth(dt2);
                d = persian.GetDayOfMonth(dt2);


                s = Convert.ToInt32((persian.GetDayOfWeek(dt2)));
                label2.Text = string.Format("{3} {2} {1} {0:d4}", y, pm[m - 1], d, wd[s + 1]);

                ya = arabian.GetYear(dt2);
                ma = arabian.GetMonth(dt2);
                da = arabian.GetDayOfMonth(dt2);
                sa = Convert.ToInt32(arabian.GetDayOfWeek(dt2));
                label3.Text = string.Format("{3} {2} {1} {0:d4}", ya, pma[ma - 1], da, wda[sa + 1]);
            }
        }

        private void Label2_Click(object sender, EventArgs e)
        {
           
        }

        int count1;
        int count = 0;

        public Form3()
        {
            InitializeComponent();
          

        }

        private void Form3_Load(object sender, EventArgs e)
        {
            y = persian.GetYear(DateTime.Now);
            m = persian.GetMonth(DateTime.Now);
            d = persian.GetDayOfMonth(DateTime.Now);

            s = Convert.ToInt32((persian.GetDayOfWeek(DateTime.Now)));
            // button5.Text = "امروز:" + string.Format(" {3} {2} {1} {0:d4}", y, pm[m - 1], d, wd[s + 1]);
            dateTimePicker1.Value = DateTime.Now;
            
        }
        
    }
}
