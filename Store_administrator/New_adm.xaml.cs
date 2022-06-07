using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Configuration;
using System.Data;
using System.Globalization;

namespace Store_administrator
{
    /// <summary>
    /// Логика взаимодействия для New_adm.xaml
    /// </summary>
    public partial class New_adm : Window
    {
        string connectionString;
        SqlDataAdapter adapter;
        public New_adm()
        {
            InitializeComponent();
            connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        }

        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection connection = null;
            var login = textBoxLogin.Text;
            var password = textBoxPassword.Text;

            string query = $"INSERT INTO Users(Login, Password) values('{login}','{password}')";

            connection = new SqlConnection(connectionString);

            SqlCommand command = new SqlCommand(query, connection);


            connection.Open();
            if (textBoxLogin.Text.Length == 0 || textBoxPassword.Text.Length == 0 )
            {
                MessageBox.Show("Заполните поле!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            if (command.ExecuteNonQuery() == 1)
            {
                MessageBox.Show("Администратор успешно создан", "Успех!");
                Addadm adm = new Addadm();
                adm.Show();
                this.Close();
            }
            else { MessageBox.Show("Администратор не добавлен"); }
            connection.Close();
        }
    }
}
