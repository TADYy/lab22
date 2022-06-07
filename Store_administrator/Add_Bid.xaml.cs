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
    /// Логика взаимодействия для Add_Bid.xaml
    /// </summary>
    /// 
    public partial class Add_Bid : Window
    {
        string connectionString;
        SqlDataAdapter adapter;
        public string s;
        public string obm;
        public Add_Bid()
        {
            InitializeComponent();
            connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        }

        private void ButtonAdd_Click_8(object sender, RoutedEventArgs e)
        {
            SqlConnection connection = null;

            var amount = Convert.ToInt32(textBoxAmount.Text) + "     ";
            var type = textBoxType + "       ";
            var name = textBoxName.Text + "   ";
            var value = obm + "       ";

            string query = $"INSERT INTO Bid(Name, Amount, Type, Capacity) values('{name}','{amount}','{type}','{value}')";

            connection = new SqlConnection(connectionString);

            SqlCommand command = new SqlCommand(query, connection);

            connection.Open();
            if (command.ExecuteNonQuery() == 1)
            {
                MessageBox.Show("Заявка успешно создана", "Успех!");
                stock good = new stock();
                good.Show();
                this.Close();
            }
            else { MessageBox.Show("Товар не создан"); }
            connection.Close();
        }

        private void capacityList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var item = (ComboBoxItem)capacityList.SelectedValue;
            obm = (string)item.Content;
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            stock good = new stock();
            good.Show();
            this.Close();
        }
    }
}
