//This code was generated by a tool.
//Changes to this file will be lost if the code is regenerated.
// See the blog post here for help on using the generated code: http://erikej.blogspot.dk/2014/10/database-first-with-sqlite-in-universal.html
//using SQLite;
using System;
using System.Data.SQLite;

namespace cal_endar
{
    public class SQLiteDb
    {
        string _path;
        public SQLiteDb(string path)
        {
            _path = path;
        }
        
         public void Create()
        {
            using (SQLiteConnection db = new SQLiteConnection(_path))
            {
               // db.CreateTable<roi>();
               //db.CreateTable<roiA>();
               // db.CreateTable<roiM>();
            }
        }
    }
    public partial class roi
    {
       //[NotNull]
        public Int64 month { get; set; }
        
      //  [NotNull]
        public Int64 day { get; set; }
        
        public Decimal? Tat { get; set; }
        
        public String RoydadT { get; set; }
        
        public String RoydadC { get; set; }
        
        public String RoydadC1 { get; set; }
        
        public String RoydadC2 { get; set; }
        
    }
    
    public partial class roiA
    {
       // [NotNull]
        public Int64 month { get; set; }
        
       // [NotNull]
        public Int64 day { get; set; }
        
        public Decimal? Tat { get; set; }
        
        public String RoydadT { get; set; }
        
        public String RoydadC { get; set; }
        
        public String RoydadC1 { get; set; }
        
        public String RoydadC2 { get; set; }
        
    }
    
    public partial class roiM
    {
       // [NotNull]
        public Int64 month { get; set; }
        
       // [NotNull]
        public Int64 day { get; set; }
        
        public Decimal? Tat { get; set; }
        
        public String RoydadT { get; set; }
        
        public String RoydadC { get; set; }
        
        public String RoydadC1 { get; set; }
        
        public String RoydadC2 { get; set; }
        
    }
    
}