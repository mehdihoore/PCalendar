using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cal_endar
{
    class sqlitedataaccess
    {
        public static List<PersonModel> LoadPeople()
        {
            using (IDbConnection cnn=new SQLiteConnection(LoadConnectionString()))
            {
                var output = cnn.Query<PersonModel>("select * from Persons", new DynamicParameters());
                return output.ToList();
            }
        }
        public static void SavePerson(PersonModel person)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                cnn.Execute("insert into Persons (Firstname, Lastname) values (@Firstname, @Lastname)", person);
            }
        }
        public static void DropPerson(PersonModel person)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                
                cnn.Execute("DELETE FROM Persons WHERE ID =*", person);
            }
        }
        private static string LoadConnectionString(string id= "Default")
        {
            return ConfigurationManager.ConnectionStrings[id].ConnectionString;
       }
    }
}
