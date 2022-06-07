using System;
using System.Windows.Controls;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows;
using System.Windows.Media;
using System.Configuration;
using System.Data;

namespace Store_administrator
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string connectionString;
        SqlDataAdapter adapter;
        public MainWindow()
        {
            InitializeComponent();

            connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            textBoxLogin.MaxLength = 50;
            passBox.MaxLength = 50;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection connection = null;
            var loguser = textBoxLogin.Text;
            var passuser = passBox.Password;

            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable table = new DataTable();
            connection = new SqlConnection(connectionString);

            string query = $"SELECT * FROM Users WHERE login = '{loguser}' and password = '{passuser}'";

            SqlCommand command = new SqlCommand(query, connection);
            adapter.SelectCommand = command;
            adapter.Fill(table);

            if (table.Rows.Count == 1)
            {
                MessageBox.Show("Авторизация прошла успешно", "neerror", MessageBoxButton.OK, MessageBoxImage.Information);
                Menu obj = new Menu();
                obj.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Авторизация прошла неудачно", "error", MessageBoxButton.OK, MessageBoxImage.Question);
            }
        }

    }
}
