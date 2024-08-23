using System;
using UserAuthentication;

namespace Calculator
{
    public class Program
    {
        public static void Main(string[] args)
        {

        }
    }
    public class UserService() : IUserService
    {
        List<User> users = new List<User>();
        public bool Register(string name, string password)
        {
            var user = users.FirstOrDefault(u => u.Username == name);
            if (user != null)
            {
                return false;
            }
            else
            {
                users.Add(new User(name, password));
                return true;
            }
        }

        public bool Login(string name, string password)
        {
            var user = users.FirstOrDefault(u => u.Username == name && u.Password == password);
            return user != null;
        }

        public void ChangePassword(string name, string oldPassword, string newPassword)
        {
            var user = users.FirstOrDefault(u => u.Username == name && u.Password == oldPassword);
            if (user != null)
            {
                user.Password = newPassword;
            }
        }
    }

    public interface IUserService
    {
        bool Register(string name, string password);
        bool Login(string name, string password);
        void ChangePassword(string name, string oldPassword, string newPassword);
    }
}