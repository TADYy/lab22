using System.Windows;
using System.Windows.Controls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System;

namespace Store_administrator
{
    /// <summary>
    /// Логика взаимодействия для Addadm.xaml
    /// </summary>
    public partial class Addadm : Window
    {
        string connectionString;
        SqlDataAdapter adapter;
        System.Data.DataTable goodsTable;
        public Addadm()
        {
            InitializeComponent();
            connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        }
        //string sql = "SELECT * FROM Goods";
        //goodsTable = new System.Data.DataTable();
        //    SqlConnection connection = null;
        //    try
        //    {
        //        connection = new SqlConnection(connectionString);
        //SqlCommand command = new SqlCommand(sql, connection);

        //adapter = new SqlDataAdapter(command);

        //// установка команды на добавление для вызова хранимой процедуры
        //adapter.InsertCommand = new SqlCommand("sp_InsertGoods", connection);
        //adapter.InsertCommand.CommandType = CommandType.StoredProcedure;
        //        adapter.InsertCommand.Parameters.Add(new SqlParameter("@name", SqlDbType.NVarChar, 50, "Name"));
        //        adapter.InsertCommand.Parameters.Add(new SqlParameter("@brand", SqlDbType.NVarChar, 50, "Brand"));
        //        adapter.InsertCommand.Parameters.Add(new SqlParameter("@type", SqlDbType.Int, 0, "Type"));
        //        adapter.InsertCommand.Parameters.Add(new SqlParameter("@price", SqlDbType.NVarChar, 50, "Price"));
        //        adapter.InsertCommand.Parameters.Add(new SqlParameter("@nicotin", SqlDbType.NVarChar, 50, "Nicotin"));
        //        //adapter.InsertCommand.Parameters.Add(new SqlParameter("@type", SqlDbType.NVarChar, 50, "Type"));
  
        //        SqlParameter parameter = adapter.InsertCommand.Parameters.Add("@Id", SqlDbType.Int, 0, "Id");
        //parameter.Direction = ParameterDirection.Output;

        //        connection.Open();
        //        adapter.Fill(goodsTable);
        //        goodsGrid.ItemsSource = goodsTable.DefaultView;
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            string sql = "SELECT * FROM Users";
            goodsTable = new System.Data.DataTable();
            SqlConnection connection = null;
            try
            {
                connection = new SqlConnection(connectionString);
                SqlCommand command = new SqlCommand(sql, connection);

                adapter = new SqlDataAdapter(command);

                // установка команды на добавление для вызова хранимой процедуры
                adapter.InsertCommand = new SqlCommand("sp_InsertGoods", connection);
                adapter.InsertCommand.CommandType = CommandType.StoredProcedure;
                adapter.InsertCommand.Parameters.Add(new SqlParameter("@login", SqlDbType.NVarChar, 50, "Login"));
                adapter.InsertCommand.Parameters.Add(new SqlParameter("@password", SqlDbType.NVarChar, 50, "Password"));

                SqlParameter parameter = adapter.InsertCommand.Parameters.Add("@Id", SqlDbType.Int, 0, "Id");
                parameter.Direction = ParameterDirection.Output;

                connection.Open();
                adapter.Fill(goodsTable);
                goodsGrid.ItemsSource = goodsTable.DefaultView;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (connection != null)
                    connection.Close();
            }
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            New_adm adminka = new New_adm();
            adminka.Show();
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            UpdateDB();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (goodsGrid.SelectedItems != null)
            {
                for (int i = 0; i < goodsGrid.SelectedItems.Count; i++)
                {
                    DataRowView datarowView = goodsGrid.SelectedItems[i] as DataRowView;
                    if (datarowView != null)
                    {
                        DataRow dataRow = (DataRow)datarowView.Row;
                        dataRow.Delete();
                    }
                }
            }
            UpdateDB();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            Menu obj = new Menu();
            obj.Show();
            this.Close();
        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
        private void UpdateDB()
        {
            SqlCommandBuilder comandbuilder = new SqlCommandBuilder(adapter);
            adapter.Update(goodsTable);
        }

    }
}
