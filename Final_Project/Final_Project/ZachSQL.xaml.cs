using System;
using System.Collections.Generic;
using System.Data;
using System.Windows;
using System.Windows.Controls;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Linq;

namespace Final_Project
{

    public partial class ZachSQL : Window
    {
        DataTable initialData = new DataTable();
        public ZachSQL()
        {
            InitializeComponent();
            //First grab all the data from the database
            initialData = getData("Select * FROM addressBook");
            dataGrid.DataContext = initialData;
            radio1.IsChecked = true;

        }

        private DataTable getData(string query)
        {
            //credentials and stuff
            string server = "ucfsh.ucfilespace.uc.edu";
            string user = "hammitzt";
            string password = "final";
            string database = "hammitzt";
            string port = "3306";
            DataTable data = new DataTable();
            try
            {
                //Format and execute the query
                string connectionString = String.Format("server={0};port={1};user id={2}; password={3}; database={4}", server, port, user, password, database);
                MySqlConnection connection = new MySqlConnection(connectionString);
                MySqlCommand cmd= new MySqlCommand(query, connection);
                data.Load(cmd.ExecuteReader());
            }
            catch(Exception Ex)
            {
                string error = Ex.ToString();
                data.Columns.Add("Name");
                data.Columns.Add("Address");
            }
            return data;
        }

        private void saveData()
        {
            try
            {
                //Add the names and addresses to seperate lists for readability
                List<string> Names = new List<string>();
                List<string> Addresses = new List<string>();
                var data = dataGrid.Items;
                data.MoveCurrentTo(0);
                for (int i = 0; i < data.Count; i++)
                {
                    Names.Add(data.CurrentItem.ToString());
                    Addresses.Add(data.CurrentItem.ToString());
                    data.MoveCurrentTo(i);
                }
                try
                {
                    //credential stuff
                    string server = "ucfsh.ucfilespace.uc.edu";
                    string user = "hammitzt";
                    string password = "final";
                    string database = "hammitzt";
                    string port = "3306";
                    string connectionString = String.Format("server={0};port={1};user id={2}; password={3}; database={4}", server, port, user, password, database);
                    MySqlConnection connection = new MySqlConnection(connectionString);
                    //Delete all the existing records
                    MySqlCommand cmd = new MySqlCommand("DELETE FROM addressbook", connection);
                    cmd.ExecuteNonQuery();
                    //Insert all of the new records
                    for (int i = 0; i < Names.Count; i++)
                    {
                        string sqlQuery = "INSERT INTO addressbook (names,addresses) VALUES (" + Names[i] + "," + Addresses[i] + ");";
                        MySqlCommand cmd2 = new MySqlCommand(sqlQuery, connection);
                        cmd2.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    string error = ex.ToString();
                }
                int x = 0;
            }
            catch(Exception exception)
            {
                string error = exception.ToString();
            }
            
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void TextBox_TextChanged_1(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void TextBox_TextChanged_2(object sender, TextChangedEventArgs e)
        {
            
        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void radio1_Checked(object sender, RoutedEventArgs e)
        {
            dataGrid.CanUserAddRows = true;
            dataGrid.CanUserDeleteRows = false;
        }

        private void radio2_Checked(object sender, RoutedEventArgs e)
        {
            dataGrid.CanUserAddRows = false;
            dataGrid.CanUserDeleteRows = true;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            saveData();
        }
    }
}
