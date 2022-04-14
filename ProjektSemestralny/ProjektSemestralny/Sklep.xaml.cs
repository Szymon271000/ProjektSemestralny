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
    }
}
