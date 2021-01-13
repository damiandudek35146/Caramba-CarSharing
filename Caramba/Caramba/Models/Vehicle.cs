using System;
using System.Collections.Generic;
using System.Text;

namespace Caramba.Models
{
    public class Vehicle : Car
    {
        public Vehicle(string brand, string model, int horsePower, float dollarsPerMinute, int maxSpeed)
        {
            Brand = brand;
            Model = model;
            Horsepower = horsePower;
            DollarsPerMinute = dollarsPerMinute;
            MaxSpeed = maxSpeed;
        }
        public int ID { get; set; }
        public int CurrentOwnerID { get; set; }
        public bool IsRentable { get; set; }
    }
}
