using ProjektSemestralny.Logika;
using ProjektSemestralny.Logika.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ProjektSemestralny
{

    public partial class MainWindow : Window
    {
        private ApplicationDBContext context;
        private ShopRepository shopRepository;
        public MainWindow()
        {
            InitializeComponent();
            
            context = new ApplicationDBContext();
            shopRepository = new ShopRepository(context);
        }

        private void SignUpButton_Click(object sender, RoutedEventArgs e)
        {
            var Rejestracja = new Rejestracja();
            Rejestracja.ShowDialog();
        }

        private void LogInButton_Click(object sender, RoutedEventArgs e)
        {
            var result = shopRepository.GetUser(UsernameBox.Text, PasswordBox.Password);
            if (result.Success)
            {
                var sklep = new Sklep(result.Data);
                sklep.ShowDialog();
            }
            else
            {
                MessageBox.Show(result.Message.Aggregate((x, y) => x + " " + y));
            }
        }
    }
}
