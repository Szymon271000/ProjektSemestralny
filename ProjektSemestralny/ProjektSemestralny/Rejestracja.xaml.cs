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
            bool blad = false;
            if (NameBox.Text == string.Empty)
            {
                MessageBox.Show("Your name is required");
                blad = true;
            }
            if (SurnameBox.Text == string.Empty)
            {
                MessageBox.Show("Your surname is required");
                blad = true;
            }
            if (AgeBox.Text == string.Empty)
            {
                MessageBox.Show("Your age is required");
                blad = true;
            }
            if (UsernameBox.Text == string.Empty)
            {
                MessageBox.Show("Username is required");
                blad = true;
            }
            var user = context.Users.FirstOrDefault(x => x.Login == UsernameBox.Text);
            if (user != null)
            {
                MessageBox.Show("This username already exists");
                blad = true;
            }
            if (PasswordBox1.Text != PasswordBox2.Text)
            {
                MessageBox.Show("Insert the same password in the fieds");
                blad = true;
            }
            if (PasswordBox1.Text == string.Empty)
            {
                MessageBox.Show("Insert a password");
                blad = true;
            }
            if (PasswordBox2.Text == string.Empty)
            {
                MessageBox.Show("Insert again the password");
                blad = true;
            }
            if (PasswordBox1.Text == PasswordBox2.Text && PasswordBox1.Text != string.Empty)
            {
                CreatePassword(PasswordBox1.Text, out byte[] passwordHash, out byte[] passwordSalt);
                User u1 = new User()
                {
                    Name = NameBox.Text,
                    Surname = SurnameBox.Text,
                    Age = int.Parse(AgeBox.Text),
                    Address = AddressBox.Text,
                    Login = UsernameBox.Text,
                    PasswordHash = passwordHash,
                    PasswordSalt = passwordSalt
                };
                context.Add(u1);
                context.SaveChanges();
                blad = false;
            }
            if (blad == false)
            {
                MessageBox.Show($"Welcome {UsernameBox.Text} !");
                var Sklep = new Sklep();
                Sklep.ShowDialog();
            }
        }

        public void CreatePassword(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            HMACSHA512 hmac = new HMACSHA512();
            passwordSalt = hmac.Key;
            passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
        }

        private void LogInButton_Click(object sender, RoutedEventArgs e)
        {
            var mainWindow = new MainWindow();
            mainWindow.ShowDialog();
        }
    }
}

