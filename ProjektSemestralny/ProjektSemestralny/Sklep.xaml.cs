using ProjektSemestralny.Logika.Data;
using ProjektSemestralny.Logika.Data.Models;
using System;
using System.Collections.Generic;
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

namespace ProjektSemestralny
{
    /// <summary>
    /// Interaction logic for Sklep.xaml
    /// </summary>
    public partial class Sklep : Window
    {
        private readonly User user;
        private ApplicationDBContext context;
        private ShopRepository shopRepository;
        private List<Item> BoughtItems = new List<Item>();


        public Sklep(User user)
        {
            InitializeComponent();
            this.user = user;
            context = new ApplicationDBContext();
            shopRepository = new ShopRepository(context);
            
            McDataGrid.ItemsSource = shopRepository.GetAllItems();
            OrderGrid.ItemsSource = shopRepository.GetAllOrders(user.Id);
            NameBox.Text = user.Name;
            SurnameBox.Text = user.Surname;
            AgeBox.Text = user.Age.ToString();
            UsernameBox.Text = user.Login;
            AddressBox.Text = user.Address;
        }

        public void AddBought(Item item)
        {
            BoughtItems.Add(item);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (McDataGrid.SelectedItem is Item item)
            {
                AddBought(item);
                Bought.ItemsSource = BoughtItems;
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if(BoughtItems.Count > 0)
            {
                var result = shopRepository.CreateOrder(user.Id, BoughtItems);
                if(result.Success)
                {
                    BoughtItems.Clear();
                    Bought.ItemsSource = new List<Item>();
                    MessageBox.Show("Order created!");
                }
                else
                {
                    MessageBox.Show(result.Message[0]);
                }
            }
            else
            {
                MessageBox.Show("You have no items in basket.");
            }
        }
        private void OrderGrid_Selected(object sender, RoutedEventArgs e)
        {
            OrderGrid.ItemsSource = shopRepository.GetAllOrders(user.Id);
            var selected = OrderGrid.SelectedItem;
            if(selected is Order order)
            {
                OrderItems.ItemsSource = order.Items.Select(x => x.Product.Name).ToList();
            }
        }

        private void BuyButton(object sender, RoutedEventArgs e)
        {
            var selected = OrderGrid.SelectedItem;
            if (selected is Order order)
            {
                shopRepository.AddPayment(order.Id);
                OrderGrid.ItemsSource = shopRepository.GetAllOrders(user.Id);
            }
        }

        private void ChangeSettingsButton_Click(object sender, RoutedEventArgs e)
        {
            int.TryParse(AgeBox.Text, out int age);
            User u1 = new User()
            {
                Name = NameBox.Text,
                Surname = SurnameBox.Text,
                Age = age,
                Address = AddressBox.Text,
                Login = UsernameBox.Text,
            };
            var result = shopRepository.UpdateUser(u1, user.Id, PasswordBox1.Password, PasswordBox2.Password);
            if (result.Success)
            {
                MessageBox.Show($"Edited {UsernameBox.Text} !");
            }
            else
            {
                MessageBox.Show(result.Message.Aggregate((x, y) => x + " " + y));
            }
        }
    }
}
