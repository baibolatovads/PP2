using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Databasetop
{
    public partial class Form1 : Form
    {
        MySqlConnection mySqlConnection;
        MySqlDataAdapter mySqlDataAdapter;
        MySqlCommandBuilder mySqlCommandBuilder;
        DataTable dataTable;
        BindingSource bindingSource;

        int row1 = 1;
        int row2 = 5;
        int start;
        int viewnow = 5;
        int swipeon = 5;
        int N;
        int curPos = 0;
        int showRows = 5;

        string order = "ID";
        string ACDC = "ASC";
        public Form1()
        {
            start = 0;
            InitializeComponent();

            mySqlConnection = new MySqlConnection(
               "SERVER= 127.0.0.1;SslMode=none;" +
               "DATABASE=database;" +
               "UID=root;" +
               "PASSWORD=;");

            mySqlConnection.Open();
            Count();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            order = "ID";
            ACDC = "ASC";
            string query = $"SELECT * FROM TBooktop LIMIT {showRows} offset {curPos};";
            Connection(query);
    
        }

        private void button2_Click(object sender, EventArgs e)
        {
            mySqlDataAdapter.Update(dataTable);
            Count();
        }
       
        private void button3_Click(object sender, EventArgs e)
        {
            string text = textBox1.Text;
            string query1 = "SELECT * FROM TBooktop WHERE Name = '" + text + "'";
            Connection(query1);

        }

        private void Connection(string query)
        {
            mySqlDataAdapter = new MySqlDataAdapter(query, mySqlConnection);
            mySqlCommandBuilder = new MySqlCommandBuilder(mySqlDataAdapter);

            mySqlDataAdapter.UpdateCommand = mySqlCommandBuilder.GetUpdateCommand();
            mySqlDataAdapter.DeleteCommand = mySqlCommandBuilder.GetDeleteCommand();
            mySqlDataAdapter.InsertCommand = mySqlCommandBuilder.GetInsertCommand();

            dataTable = new DataTable();
            mySqlDataAdapter.Fill(dataTable);

            bindingSource = new BindingSource();
            bindingSource.DataSource = dataTable;
            
            dataGridView1.DataSource = bindingSource;
            bindingNavigator1.BindingSource = bindingSource;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            order = "Date";
            ACDC = "DESC";
            string query2 = $"SELECT * FROM TBooktop ORDER BY {order} {ACDC}, Name ASC LIMIT {showRows} offset {curPos};";
            
            Connection(query2);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            order = "Date";
            ACDC = "ASC";
            string query3 = $"SELECT * FROM TBooktop ORDER BY {order} {ACDC}, Name ASC LIMIT {showRows} offset {curPos};";
            
            Connection(query3);
        }

     /*   private void button6_Click(object sender, EventArgs e)
        {
            string query4 = "SELECT * FROM TBooktop WHERE LIMIT 5 ";
            Connection(query4);
        }

        private void bindingNavigatorMoveFirstItem_Click(object sender, EventArgs e)
        {
            string query4 = "SELECT * FROM TBooktop WHERE LIMIT <=5 ";
            Connection(query4);
        }
        */
        private void Count()
        {
            string query = "SELECT COUNT(*) FROM TBooktop;";
            MySqlCommand command = new MySqlCommand(query, mySqlConnection);
            N = int.Parse(command.ExecuteScalar().ToString());
        }

        private void button7_Click(object sender, EventArgs e)
        {
            curPos += showRows;
            if (curPos >= N)
            {
                curPos = 0;
            }

            string query = $"SELECT * FROM TBooktop ORDER BY {order} {ACDC}, Name ASC LIMIT {showRows} offset {curPos};";


            Connection(query);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            
            curPos -= showRows;
            if (curPos <= 0)
            {
                curPos = 0;
            }
            string query = $"SELECT * FROM TBooktop ORDER BY {order} {ACDC}, Name ASC LIMIT {showRows} offset {curPos};";

            Connection(query);


        }

        private void ChangeList()
        {
            if (row2 > 5)
            {
                row1 -= 5;
                row2 -= 5;
            }
            if (row2 != 7)
            {
                row1 += 5;
                row2 += 5;
            }
            
        }
    }
        }
