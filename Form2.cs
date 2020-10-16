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
using System.Diagnostics;
using Microsoft.Data.Sqlite;


namespace cal_endar
{


    public partial class Form2 : Form
    {

        PersianCalendar persian = new PersianCalendar();
        string[] wd = new string[] { "شنبه", "یکشنبه", "دوشنبه", "سه شنبه", "چهارشنبه", "پنجشنبه", "جمعه", "شنبه" };
        string[] pm = new string[] { "فروردین", "اردیبهشت", "خرداد", "تیر", "مرداد", "شهریور", "مهر", "آبان", "آذر", "دی", "بهمن", "اسفند" };
        int y = 0, m = 0, d = 0, s = 0;
        HijriCalendar arabian = new HijriCalendar();
        int ya = 0, ma = 0, da = 0, sa = 0;
        string[] wda = new string[] { "السّبت", "الأحد", "الإثنین", "الثُلاثاء", "الأربعاء", "الخمیس", "الجمعة", "السّبت" };

        private void Form2_Load(object sender, EventArgs e)
        {
            label4.Text = null;
            label2.Text = null;
        }

        private void Label2_Click(object sender, EventArgs e)
        {

        }

        private void Label5_Click(object sender, EventArgs e)
        {

        }

        private void Button7_Click(object sender, EventArgs e)
        {
            Form3 day = new Form3();
            day.ShowDialog();

            label9.Text = day.label2.Text;
        }

        private void TextBox2_Enter(object sender, EventArgs e)
        {

        }

        private void TextBox2_TextChanged(object sender, EventArgs e)
        {
      
        }

        private void NumericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void Button4_Click(object sender, EventArgs e)
        {
            try
            {
                string[] word = label9.Text.Split(' ');
                //int word1 =Convert.ToInt32( word[4]);
                int year = Convert.ToInt32(word[word.Length - 1]);
                string month = word[word.Length - 2];
                int noflable6 = Array.IndexOf(pm, month);
                int mon = noflable6 + 1;
                int day = Convert.ToInt32(word[word.Length - 3]);

                string dt1 = string.Format("{0:d4},{1:d2},{2:d2}", year, mon, day);


                DateTime dt2 = DateTime.ParseExact(dt1, "yyyy,MM,dd", CultureInfo.CurrentCulture);
                TimeSpan result = TimeSpan.FromHours(Convert.ToDouble(numericUpDown1.Value));


                DateTime bday = dt2;
                DateTime cday = DateTime.Today;
                Age age = new Age(bday, cday);
                label10.Text = string.Format(" {0} سال و ,{1} ماه و ,  {2} روز از تولد شما میگذرد", age.Years, age.Months, age.Days);
            }
            catch (Exception)
            {
                if ( label9.Text == "")
                {
                    MessageBox.Show("لطفا ابتدا تارخ تولد را مشخص نمایید");
                }
                else
                {
                    MessageBox.Show("تاریخ تولد باید پیشتر از زمان حاضر باشد");
                }
            }
            
        }

        private void Label4_Click(object sender, EventArgs e)
        {

        }

        private void Button6_Click(object sender, EventArgs e)
        {
            try
            {
                string[] word = label9.Text.Split(' ');
                //int word1 =Convert.ToInt32( word[4]);
                int year = Convert.ToInt32(word[word.Length - 1]);
                string month = word[word.Length - 2];
                int noflable6 = Array.IndexOf(pm, month);
                int mon = noflable6 + 1;
                int day = Convert.ToInt32(word[word.Length - 3]);

                string dt1 = string.Format("{0:d4},{1:d2},{2:d2}", year, mon, day);
                DateTime dt2 = DateTime.ParseExact(dt1, "yyyy,MM,dd", CultureInfo.CurrentCulture);
                int numerd = Convert.ToInt32(numericUpDown1.Value);
                int numerm = Convert.ToInt32(numericUpDown2.Value);
                int numery = Convert.ToInt32(numericUpDown3.Value);
                DateTime endDate = dt2.AddDays(numerd);
                DateTime endm = endDate.AddMonths(numerm);
                DateTime endy = endm.AddYears(numery);
                label10.Text = endy.ToString();
            }
            catch (Exception)
            {

                MessageBox.Show("لطفا تاریخ را انتخاب نمایید");
            }
            
            //int yearadd = year + Convert.ToInt32( numericUpDown3.Value);
            //int oyear = persian.GetYear(dt2);
            //int month1 = persian.GetMonth(dt2);
            //int numer1 = Convert.ToInt32(numericUpDown1.Value);
            //int DaysIncdayMonth = persian.GetDaysInMonth(oyear, month1);
            //int DaysRemain = (DaysIncdayMonth - day);
           
            //if (DaysRemain>numer )
            //{
            //    dt1 = string.Format("{0:d4},{1:d2},{2:d2}", yearadd, month1, day +numer );
            //    dt2 = DateTime.ParseExact(dt1, "yyyy,MM,dd", CultureInfo.CurrentCulture);
            //    label10.Text = dt2.ToString();
            //  }
            //else if (DaysRemain < numer && month1<=11)
            //{
            //    DateTime date = dt2;
            //    int daysInYear = DateTime.IsLeapYear(date.Year) ? 366 : 365;
            //    int daysLeftInYear = daysInYear - date.DayOfYear;
                
            //    while (daysLeftInYear < numer1)
            //    {
            //        yearadd++;
            //        int dayof = numer - daysLeftInYear;
            //        numer1 = dayof;
            //    }
            //    if (DaysRemain == 0)
            //    {
            //        DaysRemain = numer;
            //    }
            //    while (DaysRemain > DaysIncdayMonth )
            //    {
            //        int  numday = DaysRemain;
            //        month1++;
            //        DaysRemain =  numday - (DaysIncdayMonth );
            //    }
            //    dt1 = string.Format("{0:d4},{1:d2},{2:d2}", yearadd, month1+1, Math.Abs( DaysRemain));
            //    dt2 = DateTime.ParseExact(dt1, "yyyy,MM,dd", CultureInfo.CurrentCulture);
            //    label10.Text = dt2.ToString();
            //}
           
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            try
            {
                string[] word = label9.Text.Split(' ');
                //int word1 =Convert.ToInt32( word[4]);
                int year = Convert.ToInt32(word[word.Length - 1]);
                string month = word[word.Length - 2];
                int noflable6 = Array.IndexOf(pm, month);
                int mon = noflable6 + 1;
                int day = Convert.ToInt32(word[word.Length - 3]);

                string dt1 = string.Format("{0:d4},{1:d2},{2:d2}", year, mon, day);
                DateTime dt2 = DateTime.ParseExact(dt1, "yyyy,MM,dd", CultureInfo.CurrentCulture);
                int numerd = Convert.ToInt32(numericUpDown1.Value);
                int numerm = Convert.ToInt32(numericUpDown2.Value);
                int numery = Convert.ToInt32(numericUpDown3.Value);
                DateTime endDate = dt2.AddDays(-numerd);
                DateTime endm = endDate.AddMonths(-numerm);
                DateTime endy = endm.AddYears(-numery);
                label10.Text = endy.ToString();
            }
            catch (Exception)
            {
                MessageBox.Show("لطفا تاریخ را انتخاب نمایید");
            }
            
        }

        string[] pma = new string[] { "محرم", "صفر", "ربیع الاول", "ربیع الثانی", "جمادی الاولی", "جمادی الثانی", "رجب", "شعبان", "رمضان", "شوال", "ذوالقعده", "ذوالحجه" };
        Form3 day = new Form3();
        public Form2()
        {
            InitializeComponent();
            
        }


        private void Button1_Click(object sender, EventArgs e)
        {
            Form3 day = new Form3();
            day.ShowDialog();
            
            label2.Text = day.label2.Text;


        }

        private void Button2_Click(object sender, EventArgs e)
        {
            
            day.ShowDialog();

            label4.Text = day.label2.Text;
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (label2.Text != "" && label4.Text != "")
                {
                    string[] word = label2.Text.Split(' ');
                    //int word1 =Convert.ToInt32( word[4]);
                    int year = Convert.ToInt32(word[word.Length - 1]);
                    string month = word[word.Length - 2];
                    int noflable6 = Array.IndexOf(pm, month);
                    int mon = noflable6 + 1;
                    int day = Convert.ToInt32(word[word.Length - 3]);

                    string dt1 = string.Format("{0:d4}/{1:d2}/{2:d2}", year, mon, day);


                    DateTime dt2 = DateTime.ParseExact(dt1, "yyyy/MM/dd", CultureInfo.CurrentCulture);
                    string[] word1 = label4.Text.Split(' ');
                    //int word1 =Convert.ToInt32( word[4]);
                    int year1 = Convert.ToInt32(word1[word1.Length - 1]);
                    string month1 = word1[word1.Length - 2];
                    int noflable61 = Array.IndexOf(pm, month1);
                    int mon1 = noflable61 + 1;
                    int day1 = Convert.ToInt32(word1[word1.Length - 3]);

                    string dt11 = string.Format("{0:d4}/{1:d2}/{2:d2}", year1, mon1, day1);


                    DateTime dt3 = DateTime.ParseExact(dt11, "yyyy/MM/dd", CultureInfo.CurrentCulture);
                    TimeSpan ts = dt2 - dt3;
                    var sw = Stopwatch.StartNew();
                    // business logic

                    label5.Text = $" { Convert.ToString(ts.TotalDays)} روز کل روزها  \n " +
                        $"و {Convert.ToString(ts.TotalHours) }ساعت کل ساعات \n";
                    //$" {Convert.ToString(ts.Hours)} {Convert.ToString(sw.Elapsed)}"  ;
                    DateTime day2 = DateTime.Parse(numericUpDown1.Value.ToString());
                    TimeSpan ts1 = day2 - dt3;
                    label9.Text = Convert.ToString(ts1.TotalDays);
                }
                else if (label4.Text == "" || label2.Text == "" || label4.Text == " " || label2.Text == " ")
                {
                    MessageBox.Show("لطفا تاریخها را انتخاب کنید");
                }
                    //    string[] word = label2.Text.Split(' ');
                    //    //int word1 =Convert.ToInt32( word[4]);
                    //    int year = Convert.ToInt32(word[word.Length - 1]);
                    //    string month = word[word.Length - 2];
                    //    int noflable6 = Array.IndexOf(pm, month);
                    //    int mon = noflable6 + 1;
                    //    int day = Convert.ToInt32(word[word.Length - 3]);

                    //    string dt1 = string.Format("{0:d4}/{1:d2}/{2:d2}", year, mon, day);
                    //    DateTime dt2 = DateTime.ParseExact(dt1, "yyyy/MM/dd", CultureInfo.CurrentCulture);
                    //    string[] word1 = label4.Text.Split(' ');
                    //    //int word1 =Convert.ToInt32( word[4]);
                    //    int year1 = Convert.ToInt32(word1[word1.Length - 1]);
                    //    string month1 = word1[word1.Length - 2];
                    //    int noflable61 = Array.IndexOf(pm, month1);
                    //    int mon1 = noflable61 + 1;
                    //    int day1 = Convert.ToInt32(word1[word1.Length - 3]);

                    //    string dt11 = string.Format("{0:d4}/{1:d2}/{2:d2}", year1, mon1, day1);


                    //    DateTime dt3 = DateTime.ParseExact(dt11, "yyyy/MM/dd", CultureInfo.CurrentCulture);

                    //    label4.Text = Convert.ToString(dt2 + label5.Text);

                    //    label2.Text = Convert.ToString(dt3 + label5.Text); return;
                    //}
                }
            catch (Exception)
            {


                //MessageBox.Show("لطفا تاریخها را انتخاب کنید");
            }


            }
            
            
        }
    }
           
           
            
 

