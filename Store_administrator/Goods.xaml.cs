using System.Windows;
using System.Windows.Controls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System;

namespace Store_administrator
{
    /// <summary>
    /// Логика взаимодействия для Goods.xaml
    /// </summary>
    public partial class Goods : Window
    {
        string connectionString;
        SqlDataAdapter adapter;
        System.Data.DataTable goodsTable;
        public Goods()
        {
            InitializeComponent();
            connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            goodsGrid.RowEditEnding += GoodsGrid_RowEditEnding;
        }
        private void GoodsGrid_RowEditEnding(object sender, DataGridRowEditEndingEventArgs e)
        {
            UpdateDB();
        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            string sql = "SELECT * FROM Goods";
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
                adapter.InsertCommand.Parameters.Add(new SqlParameter("@name", SqlDbType.NVarChar, 50, "Name"));
                adapter.InsertCommand.Parameters.Add(new SqlParameter("@brand", SqlDbType.NVarChar, 50, "Brand"));
                adapter.InsertCommand.Parameters.Add(new SqlParameter("@type", SqlDbType.Int, 0, "Type"));
                adapter.InsertCommand.Parameters.Add(new SqlParameter("@price", SqlDbType.NVarChar, 50, "Price"));
                adapter.InsertCommand.Parameters.Add(new SqlParameter("@nicotin", SqlDbType.NVarChar, 50, "Nicotin"));
                //adapter.InsertCommand.Parameters.Add(new SqlParameter("@type", SqlDbType.NVarChar, 50, "Type"));
  
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
        private void UpdateDB()
        {
            SqlCommandBuilder comandbuilder = new SqlCommandBuilder(adapter);
            adapter.Update(goodsTable);
        }
        private void updateButton_Click(object sender, RoutedEventArgs e)
        {
            UpdateDB();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string category = textBoxCategory.Text.Trim();
            SqlConnection connection = null;
            string sql = $"SELECT * FROM Goods WHERE Type LIKE '%{category}%'";
            connection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand(sql, connection);
            adapter = new SqlDataAdapter(command);
            connection.Open();
            goodsTable.Clear();
            adapter.Fill(goodsTable);
        }

        private void deleteButton_Click(object sender, RoutedEventArgs e)
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

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            SqlConnection connection = null;
            string sql = "SELECT * FROM Goods ORDER BY Amount";
            connection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand(sql, connection);
            adapter = new SqlDataAdapter(command);
            connection.Open();
            goodsTable.Clear();
            adapter.Fill(goodsTable);
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            SqlConnection connection = null;
            string sql = "SELECT * FROM Goods WHERE Type LIKE '%Водка%'";
            connection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand(sql, connection);
            adapter = new SqlDataAdapter(command);
            connection.Open();
            goodsTable.Clear();
            adapter.Fill(goodsTable);
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            SqlConnection connection = null;
            string sql = "SELECT * FROM Goods WHERE Type LIKE '%Коньяк%'";
            connection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand(sql, connection);
            adapter = new SqlDataAdapter(command);
            connection.Open();
            goodsTable.Clear();
            adapter.Fill(goodsTable);
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            SqlConnection connection = null;
            string sql = "SELECT * FROM Goods WHERE Type LIKE '%Бальзам%'";
            connection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand(sql, connection);
            adapter = new SqlDataAdapter(command);
            connection.Open();
            goodsTable.Clear();
            adapter.Fill(goodsTable);
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            SqlConnection connection = null;
            string sql = "SELECT * FROM Goods WHERE Type LIKE '%Вино%'";
            connection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand(sql, connection);
            adapter = new SqlDataAdapter(command);
            connection.Open();
            goodsTable.Clear();
            adapter.Fill(goodsTable);
        }

        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            SqlConnection connection = null;
            string sql = "SELECT * FROM Goods ORDER BY Price";
            connection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand(sql, connection);
            adapter = new SqlDataAdapter(command);
            connection.Open();
            goodsTable.Clear();
            adapter.Fill(goodsTable);
        }

        private void Button_Click_7(object sender, RoutedEventArgs e)
        {
            Menu obj = new Menu();
            obj.Show();
            this.Close();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
           
        }

        private void Button_Click_8(object sender, RoutedEventArgs e)
        {
            string search = textBoxSearch.Text.Trim();
            SqlConnection connection = null;
            string sql = $"SELECT * FROM Goods WHERE Name LIKE '%{search}%'";
            connection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand(sql, connection);
            adapter = new SqlDataAdapter(command);
            connection.Open();
            goodsTable.Clear();
            adapter.Fill(goodsTable);
        }

        private void Button_Click_9(object sender, RoutedEventArgs e)
        {
            string proiz= textBoxManafacture.Text.Trim();
            SqlConnection connection = null;
            string sql = $"SELECT * FROM Goods WHERE Manufacturer LIKE '%{proiz}%'";
            connection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand(sql, connection);
            adapter = new SqlDataAdapter(command);
            connection.Open();
            goodsTable.Clear();
            adapter.Fill(goodsTable);
        }

        private void Button_Click_10(object sender, RoutedEventArgs e)
        {
            AddGood obj = new AddGood();
            obj.Show();
            this.Close();   
        }

        private void Button_Click_11(object sender, RoutedEventArgs e)
        {
            stock obj = new stock();
            obj.Show();
            this.Close();
        }

        private void Button_Click_12(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_13(object sender, RoutedEventArgs e)
        {
            SqlConnection connection = null;
            string sql = "SELECT * FROM Goods WHERE Amount < 1";
            connection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand(sql, connection);
            adapter = new SqlDataAdapter(command);
            connection.Open();
            goodsTable.Clear();
            adapter.Fill(goodsTable);
        }
    }
}
