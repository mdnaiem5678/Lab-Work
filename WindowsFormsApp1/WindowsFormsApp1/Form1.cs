using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            //connection
            string connectionString = @"server=PC-301-29\SQLEXPRESS; Database=CoffeeShop; Integrated security=true";
            SqlConnection sqlConnection=new SqlConnection(connectionString);


            string CommandString = @"INSERT INTO Item(Name,Price) VALUES ('"+nameTextBox.Text+"',"+priceTextBox.Text+")";
            //command
            SqlCommand SqlCommand = new SqlCommand(CommandString , sqlConnection);

            //Open
            sqlConnection.Open();
            //Execution Qurry

             int isExecute = SqlCommand.ExecuteNonQuery();

             if (isExecute > 0)
             {
                 MessageBox.Show("Data Saved");
             }
             else
             {
                 MessageBox.Show("Data Not Saved");
             }


            //Close
            sqlConnection.Close();
        }

        private void showButton_Click(object sender, EventArgs e)
        {

            //connection
            string connectionString = @"server=PC-301-29\SQLEXPRESS; Database=CoffeeShop; Integrated security=true";
            SqlConnection sqlConnection = new SqlConnection(connectionString);



            string CommandString = @"SELECT *FROM Item";
            SqlCommand SqlCommand = new SqlCommand(CommandString, sqlConnection);
            //Open
            sqlConnection.Open();

            SqlDataAdapter sqlDataAdapter= new SqlDataAdapter(SqlCommand);
            DataTable dataTable=new DataTable();
            sqlDataAdapter.Fill(dataTable);
            showDataGridView.DataSource = dataTable;
           
            //Close
            sqlConnection.Close();

        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            //connection
            string connectionString = @"server=PC-301-29\SQLEXPRESS; Database=CoffeeShop; Integrated security=true";
            SqlConnection sqlConnection = new SqlConnection(connectionString);



            string CommandString = @"DELETE  FROM Item WHERE ID= "+idTextBox.Text+" ";
            SqlCommand SqlCommand = new SqlCommand(CommandString, sqlConnection);
            //Open
            sqlConnection.Open();

            //Execution Qurry
            int isExecute = SqlCommand.ExecuteNonQuery();

            if (isExecute > 0)
            {
                MessageBox.Show("Data Saved");
            }
            else
            {
                MessageBox.Show("Data Not Saved");
            }

            //Close
            sqlConnection.Close();

        }

        private void updateButton_Click(object sender, EventArgs e)
        {
            //connection
            string connectionString = @"server=PC-301-29\SQLEXPRESS; Database=CoffeeShop; Integrated security=true";
            SqlConnection sqlConnection = new SqlConnection(connectionString);



            string CommandString = @"UPDATE Item SET Name = '"+nameTextBox.Text+"',Price="+priceTextBox.Text+" where ID="+idTextBox.Text+"";
            SqlCommand SqlCommand = new SqlCommand(CommandString, sqlConnection);
            //Open
            sqlConnection.Open();

            //Execution Qurry

            int isExecute = SqlCommand.ExecuteNonQuery();

            if (isExecute > 0)
            {
                MessageBox.Show("Data Saved");
            }
            else
            {
                MessageBox.Show("Data Not Saved");
            }

            //Close
            sqlConnection.Close();

        }

        private void searchButton_Click(object sender, EventArgs e)
        {

            //connection
            string connectionString = @"server=PC-301-29\SQLEXPRESS; Database=CoffeeShop; Integrated security=true";
            SqlConnection sqlConnection = new SqlConnection(connectionString);



            string CommandString = @"SELECT * FROM Item WHERE ID= "+idTextBox.Text+"";
            SqlCommand SqlCommand = new SqlCommand(CommandString, sqlConnection);
            //Open
            sqlConnection.Open();


            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(SqlCommand);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            showDataGridView.DataSource = dataTable;

            //Close
            sqlConnection.Close();

        }
    }
}
