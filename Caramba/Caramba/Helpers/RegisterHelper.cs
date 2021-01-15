using Caramba.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Caramba.Helpers
{
    public class RegisterHelper
    {
        public static void Register()
        {
            var user = Form();
            List<User> users = GetUserInfoHelper.GetUsersData();
            string path = Path.Combine(Environment.CurrentDirectory, @"Database\Users.txt");
            path = path.Replace(@"\bin\Debug\netcoreapp3.1\", @"\");
            User newesUser;
            if (users.Count > 0)
            {
                newesUser = users.OrderByDescending(u => u.ID).FirstOrDefault();
            }
            else
            {
                newesUser = new User();
                newesUser.ID = 0;
            }
            if (users.Count != 0)
            {
                user.ID = newesUser.ID + 1;
                users.Add(user);
                string newJson = JsonConvert.SerializeObject(users);
                using (StreamWriter sw = File.CreateText(path))
                {
                    sw.WriteLine(newJson);
                    sw.Close();
                }
            }
            else
            {
                List<User> newEmptyList = new List<User>();
                user.ID = 1;
                newEmptyList.Add(user);
                string json = JsonConvert.SerializeObject(newEmptyList);
                using (StreamWriter sw = File.CreateText(path))
                {
                    sw.WriteLine(json);
                    sw.Close();
                }
            }
        }
        public static User Form()
        {
            string _firstName, _lastName, _loginName, _email;

            var _password = String.Empty;
            Console.Clear();
            Console.WriteLine("First name:\n");
            _firstName = Console.ReadLine();
            Console.Clear();
            Console.WriteLine("Last name:\n");
            _lastName = Console.ReadLine();

            bool isUserExists = false;
            do
            {
                Console.Clear();
                if (isUserExists)
                {
                    Console.WriteLine("User already exists, try something else...");
                }
                Console.WriteLine("Login:\n");
                _loginName = Console.ReadLine();
                var _users = GetUserInfoHelper.GetUsersData();
                var query = _users.Select(x => x.LoginName).ToList();
                foreach (string itm in query)
                {
                    isUserExists = itm.Contains(_loginName);
                }
            } while (isUserExists);

            Console.Clear();
            Console.WriteLine("Email:\n");
            _email = Console.ReadLine();
            _email.IsEmail();
            Console.Clear();
            Console.WriteLine("Password:\n");
            _password = LoginHelper.MaskingPassword();
            var User1 = new User(_firstName, _lastName, _loginName, _email, _password);
            return User1;
        }
    }
}
