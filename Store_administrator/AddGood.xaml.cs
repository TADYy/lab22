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
    /// Логика взаимодействия для AddGood.xaml
    /// </summary>
    public partial class AddGood : Window
    {
        string connectionString;
        public string s;
        public string obm;
        public AddGood()
        {
            InitializeComponent();
            connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        }

        private void textBoxManafacture_Copy1_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void ButtonAdd_Click_8(object sender, RoutedEventArgs e)
        {
            SqlConnection connection = null;
            
            var amount = Convert.ToInt32(textBoxAmount.Text);
            var manafacture = textBoxManafacture.Text;
            var price = textBoxPrice.Text;
            var type = textBoxType.Text;
            var name = textBoxName.Text;
            var value = obm;

            string query = $"INSERT INTO Goods(Name, Capacity, Amount, Price, Manufacturer, Type) values('{name}','{value}','{amount}','{price}','{manafacture}','{type}')";

            connection = new SqlConnection(connectionString);



            SqlCommand command = new SqlCommand(query, connection);


            connection.Open();
            if (textBoxAmount.Text.Length == null|| textBoxManafacture.Text.Length == null || textBoxPrice.Text.Length == null || textBoxName.Text.Length == null )
            {
                MessageBox.Show("Заполните поле!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            if (command.ExecuteNonQuery() == 1)
            {
                MessageBox.Show("Товар успешно создан", "Успех!");
                Goods good = new Goods();
                good.Show();
                this.Close();
            }
            else { MessageBox.Show("ТОвар не создан"); }
            connection.Close();
        }

        private void capacityList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var item = (ComboBoxItem)capacityList.SelectedValue;
            obm = (string)item.Content;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Goods good = new Goods();
            good.Show();
            this.Close();
        }

        private void textBoxType_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}

            //    SqlConnection connection = null;
            //    var amount = textBoxAmount.Text.Trim();
            //    var manafacture = textBoxManafacture.Text.Trim();
            //    var price = textBoxPrice.Text.Trim();
            //    var type = textBoxtype.Text.Trim();
            //    var name = textBoxName.Text.Trim();
            //    var value = textBoxValue.Text.Trim();

//    string query = $"INSERT INTO Goods(Name, Capacity, Amount, Price, Manufacturer, Type) values('{name}','{value}','{amount}','{price}','{manafacture}','{type}')";

//    connection = new SqlConnection(connectionString);


//    SqlCommand command = new SqlCommand(query, connection);

//    connection.Open();
//    if (textBoxAmount.Text.Length == 0 || textBoxManafacture.Text.Length == 0 || textBoxPrice.Text.Length == 0 || textBoxtype.Text.Length == 0 || textBoxName.Text.Length == 0 || textBoxValue.Text.Length == 0)
//    {
//        MessageBox.Show("Заполните поле!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
//    }
//    if (command.ExecuteNonQuery() == 1)
//    {
//        MessageBox.Show("Аккаунт успешно создан", "Успех!");

//    }
//    else { MessageBox.Show("Аккаунт не создан"); }
//    connection.Close();
//}