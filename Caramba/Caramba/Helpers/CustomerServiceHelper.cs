using Caramba.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using System.IO;
using System.Linq;

namespace Caramba.Helpers
{
    public class CustomerServiceHelper
    {
        public static void MyReservations(User user)
        {
            Console.Clear();
            var cars = GetVehicles();
            var myCars = cars.Select(x => x).Where(y => y.CurrentOwnerID == user.ID).ToList();
            if(myCars!=null)
            {
                Console.WriteLine("My current rentals :D\n");
                int i = 1;
                foreach (var item in myCars)
                {
                    Console.WriteLine($"{i}. {item.Brand} {item.Model} Horsepower:{item.Horsepower} Max speed:{item.MaxSpeed} Cost:${item.DollarsPerMinute} per minute");
                    i++;
                }
                Console.WriteLine("Press Enter to go back..\n");
                Console.ReadLine();
                PanelHelper.MainPanel(user);
            }
            else
            {
                Console.WriteLine("You don't have any cars currently on rent :((");
                Console.WriteLine("Press Enter to go back..\n");
                Console.ReadLine();
                PanelHelper.MainPanel(user);
            }
        }
        public static void ReturnCar(User user)
        {
            var cars = GetVehicles();
            var myCars = cars.Select(x => x).Where(y => y.CurrentOwnerID == user.ID).ToList();
            if (myCars != null)
            {
                Console.Clear();
                Console.WriteLine("\tWitch car you wan to return?\n");
                int i = 1;
                foreach (var item in myCars)
                {
                    Console.WriteLine($"{i}. {item.Brand} {item.Model} Horsepower:{item.Horsepower} Max speed:{item.MaxSpeed} Cost:${item.DollarsPerMinute} per minute");
                    i++;
                }
                Console.WriteLine("\nExit - \"e\" \n");
                Console.WriteLine($"Witch car you want? (1-{i - 1})");
                string choice = Console.ReadLine();
                if (choice == "e" || choice == "E")
                    PanelHelper.MainPanel(user);
                //int n;
                //isNumeric = int.TryParse(choice, out n);
                var vehicleToUpdate = myCars[int.Parse(choice) - 1];
                vehicleToUpdate.CurrentOwnerID = null;
                UpdateVehicles(vehicleToUpdate);
                PanelHelper.MainPanel(user);
            }
            else
            {
                Console.WriteLine("You don't have any cars currently to return");
                Console.WriteLine("Press Enter to go back..\n");
                Console.ReadLine();
                PanelHelper.MainPanel(user);
            }
        }

        public static void RentCar(User user)
        { 
            var cars = GetVehicles();
            var avaiableCars = cars.Select(x => x).Where(y => y.CurrentOwnerID == null).ToList();
            Console.Clear();
            Console.WriteLine("\t$$$$ List of available Cars $$$$\n");
            int i = 1;
            foreach (var item in avaiableCars)
            {
                    Console.WriteLine($"{i}. {item.Brand} {item.Model} Horsepower:{item.Horsepower} Max speed:{item.MaxSpeed} Cost:${item.DollarsPerMinute} per minute");
                    i++;
            }
            Console.WriteLine("\nExit - \"e\" \n");
            Console.WriteLine($"Witch car you want? (1-{i-1})");
            string choice =  Console.ReadLine();
            if (choice == "e" || choice == "E")
                PanelHelper.MainPanel(user);
            //int n;
            //isNumeric = int.TryParse(choice, out n);
            var vehicleToUpdate = avaiableCars[int.Parse(choice) - 1];
            vehicleToUpdate.CurrentOwnerID = user.ID;
            UpdateVehicles(vehicleToUpdate);
            PanelHelper.MainPanel(user);
        }
        public static void UpdateVehicles(Vehicle vehicle)
        {
            string path = Path.Combine(Environment.CurrentDirectory, @"Database\Vehicles.txt");
            path = path.Replace(@"\bin\Debug\netcoreapp3.1\", @"\");
            var vehicles = GetVehicles();
            var oldVehicle = vehicles.Select(x => x).Where(y => y.ID == vehicle.ID).FirstOrDefault();
            vehicles.Remove(oldVehicle);
            vehicles.Add(vehicle);
            var sortedList = vehicles.OrderBy(x => x.ID);
            var json = JsonConvert.SerializeObject(sortedList);
            using (StreamWriter sw = File.CreateText(path))
            {
                sw.WriteLine(json);
                sw.Close();
            }
        }
        public static List<Vehicle> GetVehicles()
        {
            string path = Path.Combine(Environment.CurrentDirectory, @"Database\Vehicles.txt");
            path = path.Replace(@"\bin\Debug\netcoreapp3.1\", @"\");
            string result;
            using (StreamReader sr = new StreamReader(path))
            {
                result = sr.ReadToEnd();
            }
            var cars = JsonConvert.DeserializeObject<List<Vehicle>>(result);
            return cars;
        }
        public static void AddMoney(User user)
        {
            string input = String.Empty;
            bool badFormat = true;
            while (badFormat)
            {
                Console.Clear();
                Console.WriteLine("How much money you want to add? (use a comma for hundredths )");
                input = Console.ReadLine();
                if (input.Contains(','))
                {
                    badFormat = false;
                }
                float result = 6;
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
            PanelHelper.MainPanel(user);
        }
    }
}
