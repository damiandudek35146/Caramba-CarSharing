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

            Console.WriteLine("\nMENU:\n1. Log in\n2. Sign in\n3.Credits\n4.Exit");
            string Choose = Console.ReadLine();
            return Choose;
        }
        private static User Register()
        {
            string _firstName, _lastName,_loginName, _email, _password;
            Console.Clear();
            Console.WriteLine("First name:\n");
            _firstName = Console.ReadLine();
            Console.Clear();
            Console.WriteLine("Last name:\n");
            _lastName = Console.ReadLine();
            Console.Clear();
            Console.WriteLine("Login:\n");
            _loginName = Console.ReadLine();
            Console.Clear();
            Console.WriteLine("Email:\n");
            _email = Console.ReadLine();
            Console.Clear();
            Console.WriteLine("Password:\n");
            _password = Console.ReadLine();


            var User1 = new User(_firstName, _lastName, _loginName, _email, _password);
            return User1;
        }
        private static void PutUserToDatabase()
        {
            var user = Register();
            string path = Path.Combine(Environment.CurrentDirectory, @"Database\Users.txt");
            path = path.Replace(@"\bin\Debug\netcoreapp3.1\", @"\");
            string line;
            using (StreamReader sr = new StreamReader(path))
            {
                line = sr.ReadToEnd();
            }

            if (line.Length != 0)
            {
                var _ListOfUsers = JsonConvert.DeserializeObject<List<User>>(line);
                _ListOfUsers.Add(user);

                string newJson = JsonConvert.SerializeObject(_ListOfUsers);

                using (StreamWriter sw = File.CreateText(path))
                {
                    sw.WriteLine(newJson);
                    sw.Close();
                }
            }
            else
            {
                List<User> newEmptyList = new List<User>();
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

            while (true)
            {
                string Choose = Hello();
                switch (Choose)
                {
                    case "1":
                        ;
                        break;
                    case "2": PutUserToDatabase();
                       
                        break;
                    case "3": 
                        ;
                        break;
                    case "4":
                        ;
                        break;
                }
            }
        }
    }
}
