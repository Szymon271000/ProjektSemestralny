using ProjektSemestralny.Logika;
using ProjektSemestralny.Logika.Data;
using ProjektSemestralny.Logika.Data.Models;
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

    public partial class Rejestracja : Window
    {
        private ApplicationDBContext context;
        private ShopRepository shopRepository;
        public Rejestracja()
        {
            InitializeComponent();

            context = new ApplicationDBContext();
            shopRepository = new ShopRepository(context);
        }

        private void SignUpButton_Click(object sender, RoutedEventArgs e)
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
            var result = shopRepository.AddUser(u1, PasswordBox1.Password, PasswordBox2.Password);
            if (result.Success)
            {
                MessageBox.Show($"Welcome {UsernameBox.Text} !");
                var Sklep = new Sklep(result.Data);
                Sklep.ShowDialog();
                Close();
            }
            else
            {
                MessageBox.Show(result.Message.Aggregate((x, y) => x + " " + y));
            }
        }


        private void LogInButton_Click(object sender, RoutedEventArgs e)
        {
            var mainWindow = new MainWindow();
            mainWindow.ShowDialog();
        }
    }
}

