using Caramba.Models;
using Newtonsoft.Json;
using System;
using System.Linq;
using System.IO;
using System.Collections.Generic;

namespace Caramba
{
    
    class Program
    {
        
        //public static object WindowHandler { get;  set; }
        private static string Hello()
        {
            Console.Clear();
            Console.WriteLine("*****Caramba******\n Welcome in best car sharing system :)\n");

            Console.WriteLine("\nMENU:\n1. Log in\n2. Sign in\n3.Credits\n4.Exit\n\nYour choose(1-4):");
            string Choose = Console.ReadLine();
            return Choose;
        }
        private static List<User> GetUsersData()
        {
            string path = Path.Combine(Environment.CurrentDirectory, @"Database\Users.txt");
            path = path.Replace(@"\bin\Debug\netcoreapp3.1\", @"\");
            string result;
            using (StreamReader sr = new StreamReader(path))
            {
                result = sr.ReadToEnd();
            }
            var _ListOfUsers = JsonConvert.DeserializeObject<List<User>>(result);
            if(_ListOfUsers==null)
            {
                _ListOfUsers = new List<User>();
            }
            return _ListOfUsers;
        }
        private static User Form()
        {
            string _firstName, _lastName, _loginName, _email;
                
            var _password = String.Empty;
            Console.Clear();
            Console.WriteLine("First name:\n");
            _firstName = Console.ReadLine();
            Console.Clear();
            Console.WriteLine("Last name:\n");
            _lastName = Console.ReadLine();

            bool isUserExists=false;
            do
            {
                Console.Clear();
                if(isUserExists)
                {
                    Console.WriteLine("User already exists, try something else...");
                }
                Console.WriteLine("Login:\n");
                _loginName = Console.ReadLine();
                var _users = GetUsersData();
                var query = _users.Select(x => x.LoginName).ToList();
                foreach (string itm in query)
                {
                    isUserExists = itm.Contains(_loginName);
                }
            } while (isUserExists);

            Console.Clear();
            Console.WriteLine("Email:\n");
            _email = Console.ReadLine();
            Console.Clear();
            Console.WriteLine("Password:\n");
            _password = MaskingPassword();
            
            


            var User1 = new User(_firstName, _lastName, _loginName, _email, _password);
            return User1;
        }
        private static string MaskingPassword()
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

        private static void MainPanel (User user)
        {
            string choose;
            Console.Clear();
            Console.WriteLine(" Welcome in Your Panel, what you want?\n");
            Console.WriteLine($"Your profile:\n\tFirst name: {user.FirstName}\n\tLast name: {user.LastName}\n\tYour wallet: ${user.AmountOfMoney}");

            Console.WriteLine("\nMENU:\n1. Add Money\n2. Edit Account\n3. Rent a car\n4. My Reservations \n" +
                "5. Return a Car\n6. Log Out\n7. Deleta Account\n\nYour choose(1-7):");


            choose =Console.ReadLine();
        }

        private static void LogUser(string login)
        {
            var users = GetUsersData();
            User user = users.Select(x => x).Where(y => y.LoginName == login).First();
            user.IsLogged = true;
            MainPanel(user);
        }
        private static void LogIn()
        {
            bool isWorngPassword = false;
            string login;
            var password = string.Empty;
            while (!isWorngPassword)
            {
                Console.Clear();
                Console.WriteLine("****LOG IN***\n");
                if(isWorngPassword)
                Console.WriteLine("\nLogin or password is inncorrect, try again...\n");

                Console.WriteLine("Login:");
                login = Console.ReadLine();
                Console.WriteLine("Password:");
                password = MaskingPassword();
                var users = GetUsersData();
                var query = users.Select(x => new { x.LoginName, x.Password, x.ID }).Where(y => y.LoginName == login).ToList();
                if (query.Count > 0)
                {
                    LogUser(login);
                }
                else
                {
                    isWorngPassword = true;
                }
            }
            

        }


        private static void Register()
        {
            var user = Form();
            List<User> users = GetUsersData();
            string path = Path.Combine(Environment.CurrentDirectory, @"Database\Users.txt");
            path = path.Replace(@"\bin\Debug\netcoreapp3.1\", @"\");

            if (users.Count != 0)
            {
                user.ID = users.Count+1;
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
        static void Main(string[] args)
        {
            string Choose = String.Empty;
            while (Choose != "4")
            {
                Choose = Hello();
                switch (Choose)
                {
                    case "1":
                        {
                            LogIn();
                        }
                        break;
                    case "2":
                        Register();

                        break;
                    case "3":
                        ;
                        break;
                }
            }
        }



    }
}
