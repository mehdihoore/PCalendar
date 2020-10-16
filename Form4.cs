using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace cal_endar
{
    public partial class Form4 : Form
    {


        List<PersonModel> People = new List<PersonModel>();
        

        public Form4()
        {
            InitializeComponent();
            LoadPeopleList();
        }
        
        private SQLiteConnection sql_con;
        private SQLiteCommand sql_com;
        private SQLiteDataAdapter DB;
        private DataSet DS = new DataSet();
        private DataTable DT = new DataTable();
        private void Form4_Load(object sender, EventArgs e)
        {

            LoadData();
        }

        private void LoadPeopleList()
        {
            People = sqlitedataaccess.LoadPeople();
           
            WireupPeopleList();
        }
        //set connection
        private void SetConnection()
        {
            sql_con = new SQLiteConnection
            ("Data Source = tagh.db;Version=3; New=False; Compress=True");
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
            string CommandText = "select * from Persons";
            DB = new SQLiteDataAdapter(CommandText, sql_con);
            DS.Reset();
            DB.Fill(DS);
            DT = DS.Tables[0];
            dataGridView1.DataSource = DT;
            sql_con.Close();

        }
        private void WireupPeopleList()
        {
            //listpeoplelistbox.DataSource = null;
            listpeoplelistbox.DataSource = People;
            listpeoplelistbox.DisplayMember = "FullName";
            



        }

        private void BindingSource1_CurrentChanged(object sender, EventArgs e)
        {

        }

       
        private void BindingNavigator1_RefreshItems(object sender, EventArgs e)
        {

        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Label1_Click(object sender, EventArgs e)
        {

        }

        private void People_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Refresh_Click(object sender, EventArgs e)
        {
            LoadPeopleList();
            LoadData();
        }

        private void Addpeople_Click(object sender, EventArgs e)
        {
            //PersonModel p = new PersonModel
            //{
            //    Firstname = fname.Text,
            //    Lastname = lname.Text
            //};

            //sqlitedataaccess.SavePerson(p);

            //fname.Text = " ";
            //lname.Text = " ";
            string txtQuery = "insert into Persons (Firstname, Lastname) values ('" + fname.Text + "', '" + lname.Text + "' )";
            ExecuteQuery(txtQuery);
            //LoadPeopleList();
            LoadData();

        }

        private void Fname_TextChanged(object sender, EventArgs e)
        {

        }

        private void Listpeoplelistbox_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void Drop_Click(object sender, EventArgs e)
        {
            try
            {
                string txtQuery = "delete from Persons where id= '" + dataGridView1.SelectedRows[0].Cells[0].Value + "'";
                ExecuteQuery(txtQuery);
                LoadData();

            }
            catch (Exception)
            {
                MessageBox.Show("لطفا روی ردیف کلیک کنید  یا \nاز حروف استاندارد استفاده کنید");
            }
        }

        private void Lname_TextChanged(object sender, EventArgs e)
        {

        }

        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                //var uu = dataGridView1.SelectedRows[0].Cells[0].Value;
                //fname.Text = uu.ToString();
                //MessageBox.Show(dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
                string txtQuery = "update Persons set Firstname='" + fname.Text + "' , Lastname = '" + lname.Text + "' where id= '" + dataGridView1.SelectedRows[0].Cells[0].Value + "' ";
                ExecuteQuery(txtQuery);
                LoadData();
            }
            catch (Exception)
            {
                MessageBox.Show("لطفا روی ردیف کلیک کنید  یا \nاز حروف استاندارد استفاده کنید");

               
            }
           


        }

        private void DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //fname.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            //lname.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            fname.Text = dataGridView1.SelectedCells[0].Value.ToString();
        }
    }
}
