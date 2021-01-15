using Caramba.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Caramba.Helpers
{
    public class PanelHelper
    {
        public static void MainPanel(User user)
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
                        CustomerServiceHelper.AddMoney(user);
                        break;
                    case "2":
                        UpdateUserHelper.EditAccount(user);
                        break;
                    case "3":
                        CustomerServiceHelper.RentCar(user);
                        break;
                    case "4":
                        CustomerServiceHelper.MyReservations(user);
                        break;
                    case "5":
                        CustomerServiceHelper.ReturnCar(user);
                        break;
                    case "6":
                        user.IsLogged = false;
                        UpdateUserHelper.UpdateUser(user);
                        StartHelper.Start("You have been logged out");
                        ;
                        break;
                    case "7":
                        DeleteUserHelper.DeleteAccount(user);
                        StartHelper.Start("Your account has been deleted");
                        ;
                        break;
                }
            }
        }
    }
}
