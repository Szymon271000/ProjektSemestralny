using ProjektSemestralny.Logika.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ProjektSemestralny.Logika.Data
{
    public class ShopRepository
    {
        private readonly ApplicationDBContext context;
        public ShopRepository(ApplicationDBContext context)
        {
            this.context = context;
        }

        public List<Item> GetAllItems()
        {
            return context.Items.ToList();
        }
        public List<User> GetAllUsers()
        {
            return context.Users.ToList();
        }

        public Result<User> AddUser(User u, string password1, string password2)
        {
            Result<User> result = new Result<User> { Success = true };
            if (u.Name == string.Empty)
            {
                result.Message.Add("Your name is required.");
                result.Success = false;
            }
            if (u.Surname == string.Empty)
            {
                result.Message.Add("Your surname is required.");
                result.Success = false;
            }
            if (u.Age <= 0)
            {
                result.Message.Add("Your age is required.");
                result.Success = false;
            }
            if (u.Login == string.Empty)
            {
                result.Message.Add("Your username is required.");
                result.Success = false;
            }
            var user = context.Users.FirstOrDefault(x => x.Login == u.Login);
            if (user != null)
            {
                result.Message.Add("This username already exists");
                result.Success = false;
            }
            //if (PasswordBox1.Password != PasswordBox2.Password)
            //{
            //    MessageBox.Show("Insert the same password in the fieds");
            //    blad = true;
            //}
            //if (PasswordBox1.Password == string.Empty)
            //{
            //    MessageBox.Show("Insert a password");
            //    blad = true;
            //}
            //if (PasswordBox2.Password == string.Empty)
            //{
            //    MessageBox.Show("Insert again the password");
            //    blad = true;
            //}
            if (result.Success)
            {
                CreatePassword(password1, out byte[] passwordHash, out byte[] passwordSalt);
                context.Add(u);
                context.SaveChanges();
                result.Data = u;
                result.Message.Add("Your account was created");
            }
            return result;
        }

        public Result<User> GetUser(string username, string password)
        {
            return null;
        }

        public void CreatePassword(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            HMACSHA512 hmac = new HMACSHA512();
            passwordSalt = hmac.Key;
            passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
        }
    }
}
