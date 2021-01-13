using System;
using System.Collections.Generic;
using System.Text;

namespace Caramba.Models
{
    public class User
    {

        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string LoginName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public List<Order> Orders { get; set; }
        public float AmountOfMoney { get; set; }
        public bool IsLogged { get; set; }


        
    }
}
