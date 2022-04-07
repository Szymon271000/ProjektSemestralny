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

        public Sklep(User user)
        {
            InitializeComponent();
            this.user = user;
            context = new ApplicationDBContext();
            shopRepository = new ShopRepository(context);
            McDataGrid.ItemsSource = shopRepository.GetAllItems();
        }

    }
}
