using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace cal_endar
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //Console.OutputEncoding = Encoding.UTF8;
            // Change current culture
            CultureInfo culture;
            if (Thread.CurrentThread.CurrentCulture.Name == "en-US")
                culture = CultureInfo.CreateSpecificCulture("fa-IR");
            else
                culture = CultureInfo.CreateSpecificCulture("fa-IR");
            AppDomain domain = AppDomain.CurrentDomain;
           
            if (Thread.CurrentThread.CurrentUICulture.Name == "en-US")
                culture = CultureInfo.CreateSpecificCulture("fa-IR");
            else
                culture = CultureInfo.CreateSpecificCulture("fa-IR");

            Thread.CurrentThread.CurrentCulture = culture;
            Thread.CurrentThread.CurrentUICulture = culture;
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            DateTimePicker dateTimePicker1 = new DateTimePicker();
            dateTimePicker1.CustomFormat = Application.CurrentCulture.DateTimeFormat.LongDatePattern;
            
            Application.Run(new Form1());
        }
    }
}
