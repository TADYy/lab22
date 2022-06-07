using System.Windows;
using System.Windows.Controls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System;   

namespace Store_administrator
{
    /// <summary>
    /// Логика взаимодействия для stock.xaml
    /// </summary>
    public partial class stock : Window
    {
        string connectionString;
        SqlDataAdapter adapter;
        System.Data.DataTable goodsTable;
        public stock()
        {
            InitializeComponent();
            connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            string sql = "SELECT * FROM Stock";
            goodsTable = new System.Data.DataTable();
            SqlConnection connection = null;
            try
            {
                connection = new SqlConnection(connectionString);
                SqlCommand command = new SqlCommand(sql, connection);

                adapter = new SqlDataAdapter(command);

                // установка команды на добавление для вызова хранимой процедуры
                adapter.InsertCommand = new SqlCommand("sp_InsertStock", connection);
                adapter.InsertCommand.CommandType = CommandType.StoredProcedure;
                adapter.InsertCommand.Parameters.Add(new SqlParameter("@name", SqlDbType.NVarChar, 50, "Name"));
                adapter.InsertCommand.Parameters.Add(new SqlParameter("@capacity", SqlDbType.NVarChar, 50, "Capacity"));
                adapter.InsertCommand.Parameters.Add(new SqlParameter("@amount", SqlDbType.Int, 0, "Amount"));
                adapter.InsertCommand.Parameters.Add(new SqlParameter("@price", SqlDbType.NVarChar, 50, "Price"));
                adapter.InsertCommand.Parameters.Add(new SqlParameter("@manufacturer", SqlDbType.NVarChar, 50, "Manufacturer"));
                adapter.InsertCommand.Parameters.Add(new SqlParameter("@type", SqlDbType.NVarChar, 50, "Type"));

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
        private void Button_Click_8(object sender, RoutedEventArgs e)
        {
            string search = textBoxSearch.Text.Trim();
            SqlConnection connection = null;
            string sql = $"SELECT * FROM Stock WHERE Name LIKE '%{search}%'";
            connection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand(sql, connection);
            adapter = new SqlDataAdapter(command);
            connection.Open();
            goodsTable.Clear();
            adapter.Fill(goodsTable);
        }

        private void Button_Click_9(object sender, RoutedEventArgs e)
        {
            string proiz = textBoxManafacture.Text.Trim();
            SqlConnection connection = null;
            string sql = $"SELECT * FROM Stock WHERE Manufacturer LIKE '%{proiz}%'";
            connection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand(sql, connection);
            adapter = new SqlDataAdapter(command);
            connection.Open();
            goodsTable.Clear();
            adapter.Fill(goodsTable);
        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Button_Click_7(object sender, RoutedEventArgs e)
        {
            Menu obj = new Menu();
            obj.Show();
            this.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string category = textBoxCategory.Text.Trim();
            SqlConnection connection = null;
            string sql = $"SELECT * FROM Stock WHERE Type LIKE '%{category}%'";
            connection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand(sql, connection);
            adapter = new SqlDataAdapter(command);
            connection.Open();
            goodsTable.Clear();
            adapter.Fill(goodsTable);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Add_Bid obj = new Add_Bid();
            obj.Show();
            this.Close();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            SqlConnection connection = null;
            string sql = "SELECT * FROM Stock ORDER BY Amount";
            connection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand(sql, connection);
            adapter = new SqlDataAdapter(command);
            connection.Open();
            goodsTable.Clear();
            adapter.Fill(goodsTable);
        }
        private void UpdateDB()
        {
            SqlCommandBuilder comandbuilder = new SqlCommandBuilder(adapter);
            adapter.Update(goodsTable);
        }
        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            DataRowView dataRow = (DataRowView)goodsGrid.SelectedItem;
            var name = Convert.ToString(dataRow.Row.ItemArray[1]);
            //var test = (dynamic)(dataRow.Row.ItemArray[2]);
            //var capacity = float.Parse(test);
            var capacity = Convert.ToString(dataRow.Row.ItemArray[2]);
            var amount = Convert.ToInt32(dataRow.Row.ItemArray[3]);
            //var test = (dynamic)(dataRow.Row.ItemArray[4]);
            var price = Convert.ToString(dataRow.Row.ItemArray[3]);
            var proiz = Convert.ToString(dataRow.Row.ItemArray[5]);
            var type = Convert.ToString(dataRow.Row.ItemArray[6]);
            DataRowView row = (DataRowView)goodsGrid.SelectedItem;
            row.Row.Delete();
            try
            {
                SqlConnection connection = null;
                if (goodsGrid.SelectedItems != null)
                {
                    for (int i = 0; i < goodsGrid.SelectedItems.Count; i++)
                    {
                        DataRowView datarowView = goodsGrid.SelectedItems[i] as DataRowView;
                        if (datarowView != null)
                        {
                            dataRow.Delete();
                        }
                    }
                }
                UpdateDB();


                string query2 = $"INSERT INTO Goods(Name, Capacity, Amount, Price, Manufacturer, Type) values('{name}','{capacity}','{amount}','{price}','{proiz}','{type}')";
                connection = new SqlConnection(connectionString);
               
                SqlCommand command2 = new SqlCommand(query2, connection);
                connection.Open();

                if (command2.ExecuteNonQuery()==1)
                {
                    MessageBox.Show("Товар успешно перенесен", "Успех!");
                    Goods good = new Goods();
                    good.Show();
                    this.Close();
                }
                else { MessageBox.Show("Товар "); }
                connection.Close();

                //sqlite_conn.Open();
                //sqlite_cmd.CommandText = $"DELETE FROM Storage WHERE Название = '{name}';";
                //sqlite_cmd.ExecuteNonQuery();
                //sqlite_cmd.CommandText = $"INSERT INTO Products (Название,Категория,Производитель,Колличество) VALUES ('{name}','{category}','{producer}','{count}');";
                //sqlite_cmd.ExecuteNonQuery();
                //sqlite_conn.Close();
                Window_Loaded(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
