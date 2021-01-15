using Caramba.Models;
using Newtonsoft.Json;
using System;
using System.Linq;
using System.IO;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Caramba
{
    
    class Program
    {
        
        //public static object WindowHandler { get;  set; }
        private static string Hello(string info)
        {
            Console.Clear();
            Console.WriteLine(info);
            Console.WriteLine("*****Caramba******\n Welcome in best car sharing system :)\n");

            Console.WriteLine("\nMENU:\n1. Log in\n2. Sign in\n3.Credits\n4.Exit\n\nYour choice(1-4):");
            string choice = Console.ReadLine();
            return choice;
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
        public static void MainPanel (User user)
        {
            string choice;
            while (true)
            {
                Console.Clear();
                Console.WriteLine(" Welcome in Your Panel, what you want?\n");
                Console.WriteLine($"Your profile:\n\tUser number: {user.ID}\n\tFirst name: {user.FirstName}\n\tLast name: {user.LastName}\n\tYour wallet: ${user.AmountOfMoney}");

                Console.WriteLine("\nMENU:\n1. Add Money\n2. Edit Account\n3. Rent a car\n4. My Reservations \n" +
                "5. Return a Car\n6. Log Out\n7. Delete Account\n\nYour choice(1-7):");
                choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        AddMoney(user);
                        break;
                    case "2":
                        EditAccount(user);
                        break;
                    case "3":
                        RentCar();
                        break;
                    case "4":MyReservations();
                        break;
                    case "5":ReturnCar();
                        ;
                        break;
                    case "6":
                        user.IsLogged = false;
                        UpdateUserHelper.UpdateUser(user);
                        Start("You have been logged out");
                        ;
                        break;
                    case "7":
                        DeleteAccount(user);
                        Start("Your account has been deleted");
                        ;
                        break;
                }
            }
        }

        private static void DeleteAccount(User user)
        {
            var users = GetUserInfoHelper.GetUsersData();
            var oldUser = users.Single(x => x.ID == user.ID);
            users.Remove(oldUser);
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

        private static void ReturnCar()
        {
            throw new NotImplementedException();
        }

        private static void MyReservations()
        {
            throw new NotImplementedException();
        }

        private static void RentCar()
        {
            throw new NotImplementedException();
        }

        private static void EditAccount(User user)
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
            MainPanel(updatedUser);
        }

        private static void AddMoney(User user)
        {
            string input = String.Empty;
            bool badFormat = true;
            while(badFormat)
            {
                Console.Clear();
                Console.WriteLine("How much money you want to add? (use a comma for hundredths )");
                input = Console.ReadLine();
                if (input.Contains(','))
                {
                    badFormat = false;
                }
                float result=6;
                if (float.TryParse(input, out result))
                {
                    badFormat = false;
                }
            }
            float newMoney = float.Parse(input);
            float rounded = (float)(Math.Round((double)newMoney, 2));

            user.AmountOfMoney += rounded;
            UpdateUserHelper.UpdateUser(user);
            Console.WriteLine($"You added ${rounded} to account. \n Press Enter to back to main menu...");
            Console.ReadLine();
            MainPanel(user);
        }


        
        private static void Register()
        {
            var user = Form();
            List<User> users = GetUserInfoHelper.GetUsersData();
            string path = Path.Combine(Environment.CurrentDirectory, @"Database\Users.txt");
            path = path.Replace(@"\bin\Debug\netcoreapp3.1\", @"\");
            User newesUser;
            if(users.Count>0)
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
                user.ID = newesUser.ID+1;
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
        private static void Start(string info)
        {
            string choice = String.Empty;
            while (choice != "4")
            {
                choice = Hello(info);
                switch (choice)
                {
                    case "1":
                        {
                            LoginHelper.LogIn();
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
        static void Main(string[] args)
        {
            Start("");
        }



    }
}
