using Caramba.Helpers;
using Caramba.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Caramba
{
    public class UpdateUserHelper
    {
        public static void UpdateUser(User user)
        {
            var users = GetUserInfoHelper.GetUsersData();
            if (users != null)
            {
                var oldUser = users.Single(x => x.ID == user.ID);
                users.Remove(oldUser);
                users.Add(user);
                var sortedUsers = users.OrderBy(o => o.ID).ToList();
                string path = Path.Combine(Environment.CurrentDirectory, @"Database\Users.txt");
                path = path.Replace(@"\bin\Debug\netcoreapp3.1\", @"\");

                string newJson = JsonConvert.SerializeObject(sortedUsers);
                using (StreamWriter sw = File.CreateText(path))
                {
                    sw.WriteLine(newJson);
                    sw.Close();
                }

            }
            else
            {
                users = new List<User>();
                users.Add(user);
                var sortedList = users.OrderBy(o => o.ID).ToList();

                string path = Path.Combine(Environment.CurrentDirectory, @"Database\Users.txt");
                path = path.Replace(@"\bin\Debug\netcoreapp3.1\", @"\");

                string newJson = JsonConvert.SerializeObject(sortedList);
                using (StreamWriter sw = File.CreateText(path))
                {
                    sw.WriteLine(newJson);
                    sw.Close();
                }
            }
        }
        public static void EditAccount(User user)
        {
            Console.Clear();
            Console.WriteLine("");
            string _firstName, _lastName, _email;

            var _password = String.Empty;
            Console.Clear();
            Console.WriteLine("New first name:\n");
            _firstName = Console.ReadLine();
            Console.Clear();
            Console.WriteLine("New last name:\n");
            _lastName = Console.ReadLine();
            Console.Clear();
            Console.WriteLine("New email:\n");
            _email = Console.ReadLine();
            Console.Clear();
            Console.WriteLine("New Password:\n");
            _password = LoginHelper.MaskingPassword();
            var updatedUser = new User(_firstName, _lastName, user.LoginName, _email, _password);
            updatedUser.ID = user.ID;
            updatedUser.AmountOfMoney = user.AmountOfMoney;
            updatedUser.IsLogged = user.IsLogged;
            updatedUser.Orders = user.Orders;

            UpdateUserHelper.UpdateUser(updatedUser);
            PanelHelper.MainPanel(updatedUser);
        }
    }
}
