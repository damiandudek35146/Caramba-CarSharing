using Caramba.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Caramba
{
    public static class LoginHelper
    {
        public static void LogIn()
        {
            bool isWorngPassword = false;
            string login;
            var password = string.Empty;
            while (true)
            {
                Console.Clear();
                Console.WriteLine("****LOG IN****\n");
                if (isWorngPassword)
                    Console.WriteLine("\nLogin or password is inncorrect, try again...\n");

                Console.WriteLine("Login:");
                login = Console.ReadLine();
                Console.WriteLine("Password:");
                password = LoginHelper.MaskingPassword();
                var users = GetUserInfoHelper.GetUsersData();
                var query = users.Select(x => new { x.LoginName, x.Password, x.ID }).Where(y => y.LoginName == login).ToList();
                if (query.Count > 0)
                {
                    if (query[0].Password == password)
                    {
                        ChangeUserStatusIsLogged(login);
                    }
                    isWorngPassword = true;

                }
                else
                {
                    isWorngPassword = true;
                }
            }
        }
        private static void ChangeUserStatusIsLogged(string login)
        {
            var users = GetUserInfoHelper.GetUsersData();
            User user = users.Select(x => x).Where(y => y.LoginName == login).First();
            user.IsLogged = true;
            UpdateUserHelper.UpdateUser(user);
            Program.MainPanel(user);
        }
        public static string MaskingPassword()
        {
            var password = string.Empty;
            ConsoleKey key;
            do
            {
                var keyInfo = Console.ReadKey(intercept: true);
                key = keyInfo.Key;

                if (key == ConsoleKey.Backspace && password.Length > 0)
                {
                    Console.Write("\b \b");
                    password = password[0..^1];
                }
                else if (!char.IsControl(keyInfo.KeyChar))
                {
                    Console.Write("*");
                    password += keyInfo.KeyChar;
                }
            } while (key != ConsoleKey.Enter);
            return password;

        }
    }
}
