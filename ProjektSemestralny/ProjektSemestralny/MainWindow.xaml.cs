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
            if (UsernameBox.Text == string.Empty)
            {
                MessageBox.Show("Please insert your username");
            }
            if (UsernameBox.Text != string.Empty)
            {
                var user = context.Users.FirstOrDefault(x => x.Login == UsernameBox.Text);
                if (user == null)
                {
                    MessageBox.Show("This user doesn't exist");
                }
                else
                {
                    if (PasswordBox.Text == string.Empty)
                    {
                        MessageBox.Show("Please insert your password");
                    }
                    if (PasswordBox.Text != string.Empty && !CorrectPassword(PasswordBox.Text, user.PasswordHash, user.PasswordSalt))
                    {
                        MessageBox.Show("Wrong password");
                    }
                    else
                    {
                        MessageBox.Show($"Welcome {UsernameBox.Text} !");
                        var sklep = new Sklep();
                        sklep.ShowDialog();
                    }
                }
            }
        }

        public bool CorrectPassword(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            HMACSHA512 hmac = new HMACSHA512(passwordSalt);
            byte[] passwordHash2 = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            for (int i = 0; i < passwordHash.Length; i++)
            {
                if (passwordHash[i] != passwordHash2[i])
                {
                    return false;
                }
            }
            return true;
        }
    }
}
