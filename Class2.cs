using Microsoft.Analytics.Interfaces;
using Microsoft.Analytics.Types.Sql;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace cal_endar
{
    class PersonModel
    {
        public int id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string fullname
        {
            get
            {
                return $"{ Firstname, -10} / 'لیست' { Lastname }"; 
            }
        }
    }
}