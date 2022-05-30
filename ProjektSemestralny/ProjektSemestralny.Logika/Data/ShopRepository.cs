using Microsoft.EntityFrameworkCore;
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
            return context.Items
                .Include(x => x.CategoryProducent)
                .ThenInclude(x => x.Category)
                .Include(x => x.CategoryProducent)
                .ThenInclude(x => x.Producent)
                .ToList();

        }
        public List<User> GetAllUsers()
        {
            return context.Users.ToList();
        }

        public Result<User> UpdateUser(User u, int userId, string password1, string password2)
        {
            Result<User> result = new Result<User> { Success = true };
            var user = context.Users.FirstOrDefault(x => x.Id == userId);
            if (user == null)
            {
                result.Success = false;
                result.Message.Add("This user does not exist");
                return result;
            }
            
            if (u.Name != string.Empty)
            {
                user.Name = u.Name;
            }
            if (u.Surname != string.Empty)
            {
                user.Surname = u.Surname;
            }
            if (u.Age >= 0)
            {
                user.Age = u.Age;
            }
            if (u.Login != string.Empty)
            {
                var existUser = context.Users.FirstOrDefault(x => x.Login == u.Login);
                if (existUser != null)
                {
                    result.Message.Add("This username already exists");
                    result.Success = false;
                    return result;
                }

                user.Login = u.Login;
            }
            
            if(password1 != string.Empty)
            {
                if (password1 != password2)
                {
                    result.Message.Add("Insert the same password in the fields");
                    result.Success = false;
                }
                else if (password1 == string.Empty)
                {
                    result.Message.Add("Insert a password");
                    result.Success = false;
                }
                else if (password2 == string.Empty)
                {
                    result.Message.Add("Insert again the password");
                    result.Success = false;
                }
                else
                {
                    CreatePassword(password1, out byte[] passwordHash, out byte[] passwordSalt);
                    user.PasswordSalt = passwordSalt;
                    user.PasswordHash = passwordHash;
                }
            }

            if (u.Address != string.Empty)
            {
                user.Address = u.Address;
            }

            if (result.Success)
            {
                context.SaveChanges();
                result.Data = u;
                result.Message.Add("Your account was edited");
            }
            return result;
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
            if (password1 != password2)
            {
                result.Message.Add("Insert the same password in the fields");
                result.Success = false;
            }
            if (password1 == string.Empty)
            {
                result.Message.Add("Insert a password");
                result.Success = false;
            }
            if (password2 == string.Empty)
            {
                result.Message.Add("Insert again the password");
                result.Success = false;
            }
            if (result.Success)
            {
                CreatePassword(password1, out byte[] passwordHash, out byte[] passwordSalt);
                u.PasswordSalt = passwordSalt;
                u.PasswordHash = passwordHash;
                context.Add(u);
                context.SaveChanges();
                result.Data = u;
                result.Message.Add("Your account was created");
            }
            return result;
        }

        public Result<User> GetUser(string username, string password)
        {
            Result<User> result = new Result<User> { Success = true };
            if (username == string.Empty)
            {
                result.Message.Add("Please insert your username");
                result.Success = false;
            }
            if (username != string.Empty)
            {
                var user = context.Users.FirstOrDefault(x => x.Login == username);
                if (user == null)
                {
                    result.Message.Add("This user doesn't exist");
                    result.Success = false;

                }
                else
                {
                    if (password == string.Empty)
                    {
                        result.Message.Add("Please insert your password");
                        result.Success = false;

                    }
                    else if (!CorrectPassword(password, user.PasswordHash, user.PasswordSalt))
                    {
                        result.Message.Add("Wrong password");
                        result.Success = false;
                    }
                }
                if (result.Success)
                {
                    result.Data = user;
                    result.Message.Add($"Welcome {username}");
                }
            }
            return result;
        }

        public void CreatePassword(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            HMACSHA512 hmac = new HMACSHA512();
            passwordSalt = hmac.Key;
            passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
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

        public Result<Order> CreateOrder(int userId, List<Item> items)
        {
            var user = context.Users.FirstOrDefault(x => x.Id == userId);
            if(user == null)
            {
                return new Result<Order> { Message = { "User not found." } };
            }

            foreach (var item in items)
            {
                var it = context.Items.FirstOrDefault(x => x.Id == item.Id);
                if(it == null)
                {
                    return new Result<Order> { Message = { "Item not found id=" + item.Id } };
                }
            }

            var order = new Order
            {
                Paid = false,
                User = user
            };
            context.Add(order);
            foreach(var item in items)
            {
                var it = context.Items.FirstOrDefault(x => x.Id == item.Id);
                var orderItem = new OrderItem
                {
                    Order = order,
                    Product = it
                };
                context.Add(orderItem);
            }
            context.SaveChanges();
            return new Result<Order> { Success = true, Data = order, Message = { "Order added!" } };
        }

        public List<Order> GetAllOrders(int userId)
        {
            return context.Orders.Include(x => x.User)
                .Include(x => x.Items)
                .ThenInclude(x => x.Product)
                .ThenInclude(x => x.CategoryProducent)
                .Where(x => x.User.Id == userId)
                .ToList();
        }

        public bool AddPayment(int orderId)
        {
            var order = context.Orders.FirstOrDefault(x => x.Id == orderId);
            if(order == null)
            {
                return false;
            }
            order.Paid = true;
            context.SaveChanges();
            return true;
        }
    }
}
