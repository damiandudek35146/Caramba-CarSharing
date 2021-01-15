using System;
using System.Collections.Generic;
using System.Text;

namespace Caramba.Helpers
{
    public class StartHelper
    {
        public static string Hello(string info)
        {
            Console.Clear();
            Console.WriteLine(info);
            Console.WriteLine("*****Caramba******\n Welcome in best car sharing system :)\n");

            Console.WriteLine("\nMENU:\n1. Log in\n2. Sign in" +
               // "\n3.Credits" +
                "\n3.Exit\n\nYour choice(1-4):");
            string choice = Console.ReadLine();
            return choice;
        }
        public static void Start(string info)
        {
            string choice = String.Empty;
            while (true)
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
                        RegisterHelper.Register();
                        break;
                    //case "3":
                    //    ;
                    //    break;
                    case "3":Environment.Exit(0);
                        ;
                        break;
                }
            }
        }
    }
}
