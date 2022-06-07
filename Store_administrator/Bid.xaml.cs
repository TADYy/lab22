using System.Windows;
using System.Windows.Controls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System;
using Microsoft.Office.Interop.Word;
using System.Reflection;
using System.IO;
using System.Windows.Input;

namespace Store_administrator
{
    /// <summary>
    /// Логика взаимодействия для Bid.xaml
    /// </summary>
    public partial class Bid : System.Windows.Window
    {
        string connectionString;
        SqlDataAdapter adapter;
        System.Data.DataTable goodsTable;
        public Bid()
        {
            InitializeComponent();
            connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        }
        private void UpdateDB()
        {
            SqlCommandBuilder comandbuilder = new SqlCommandBuilder(adapter);
            adapter.Update(goodsTable);
        }
        private void Button_Click_8(object sender, RoutedEventArgs e)
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
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            string sql = "SELECT * FROM Bid";
            goodsTable = new System.Data.DataTable();
            SqlConnection connection = null;
            try
            {
                connection = new SqlConnection(connectionString);
                SqlCommand command = new SqlCommand(sql, connection);

                adapter = new SqlDataAdapter(command);

                // установка команды на добавление для вызова хранимой процедуры
                adapter.InsertCommand = new SqlCommand("sp_InsertBid", connection);
                adapter.InsertCommand.CommandType = CommandType.StoredProcedure;
                adapter.InsertCommand.Parameters.Add(new SqlParameter("@name", SqlDbType.NVarChar, 50, "Name"));
                adapter.InsertCommand.Parameters.Add(new SqlParameter("@capacity", SqlDbType.NVarChar, 50, "Capacity"));
                adapter.InsertCommand.Parameters.Add(new SqlParameter("@amount", SqlDbType.Int, 0, "Amount"));
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

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Add_Bid obj = new Add_Bid();
            obj.Show();
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Menu obj = new Menu();
            obj.Show();
            this.Close();
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
            goodsGrid.SelectAllCells();
            goodsGrid.ClipboardCopyMode = DataGridClipboardCopyMode.IncludeHeader;
            ApplicationCommands.Copy.Execute(null, goodsGrid);
            goodsGrid.UnselectAllCells();
            var result = (string)Clipboard.GetData(DataFormats.Text);
            dynamic wordApp = null;
            try
            {
                var sw = new StreamWriter($"{Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory)}\\отчет.doc");
                sw.WriteLine(result);
                sw.Close();
                //var proc = Process.Start("export.doc");
                Type wordType = Type.GetTypeFromProgID("Word.Application");
                wordApp = Activator.CreateInstance(wordType);
                wordApp.Documents.Add($"{ Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory)}\\отчет.doc");
                wordApp.ActiveDocument.Range.ConvertToTable(1, goodsGrid.Items.Count, goodsGrid.Columns.Count);
                MessageBox.Show("Отчет успешно создан! \n Находится на рабочем столе!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                if (wordApp != null)
                {
                    wordApp.Quit();
                }
            }
        }
    }
}