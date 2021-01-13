using System;
using System.Collections.Generic;
using System.Text;

namespace Caramba.Models
{
    public class Order
    {
        public int ID { get; set; }
        public int UserID { get; set; }
        public int ViehicleID { get; set; }
        public int RentTime { get; set; }
        public float RentPrice { get; set; }
    }
}