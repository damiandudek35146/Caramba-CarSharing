using System;
using System.Collections.Generic;
using System.Text;

namespace Caramba.Models
{
    public abstract class Car
    {
        public string Brand { get; set; }
        public string Model { get; set; }
        public int Horsepower { get; set; }
        public float DollarsPerMinute  { get; set; }
        public int MaxSpeed { get; set; }
    }
}
