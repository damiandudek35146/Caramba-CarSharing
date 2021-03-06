﻿using Caramba.Models;
using Newtonsoft.Json;
using System;
using System.Linq;
using System.IO;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Caramba.Helpers;
using Caramba.Database;

namespace Caramba
{
    
    class Program
    {
        static void Main(string[] args)
        {
            // AvailableViehicles.CreateVehicles();
            //[{"ID":1,"CurrentOwnerID":null,"Brand":"BMW","Model":"M5","Horsepower":250,"DollarsPerMinute":1.0,"MaxSpeed":320},{"ID":2,"CurrentOwnerID":null,"Brand":"Mercedes-Benz","Model":"BKlasa C","Horsepower":200,"DollarsPerMinute":2.0,"MaxSpeed":270},{"ID":3,"CurrentOwnerID":null,"Brand":"Opel","Model":"Astra","Horsepower":97,"DollarsPerMinute":0.5,"MaxSpeed":180},{"ID":4,"CurrentOwnerID":null,"Brand":"Toyota","Model":"C-HR","Horsepower":150,"DollarsPerMinute":1.0,"MaxSpeed":230},{"ID":5,"CurrentOwnerID":null,"Brand":"Audi","Model":"A6","Horsepower":252,"DollarsPerMinute":2.0,"MaxSpeed":280},{"ID":6,"CurrentOwnerID":null,"Brand":"Hyundai","Model":"Santa Fe","Horsepower":185,"DollarsPerMinute":1.3,"MaxSpeed":220},{"ID":7,"CurrentOwnerID":null,"Brand":"Mercedes-Benz","Model":"Klasa A","Horsepower":306,"DollarsPerMinute":3.0,"MaxSpeed":330},{"ID":8,"CurrentOwnerID":null,"Brand":"Porsche","Model":"Taycan","Horsepower":760,"DollarsPerMinute":5.0,"MaxSpeed":400},{"ID":9,"CurrentOwnerID":null,"Brand":"Ferrari","Model":"458 Italia","Horsepower":605,"DollarsPerMinute":4.0,"MaxSpeed":380},{"ID":10,"CurrentOwnerID":null,"Brand":"Rolls-Royce","Model":"Cullinan","Horsepower":570,"DollarsPerMinute":8.0,"MaxSpeed":350}]

            StartHelper.Start("");
        }
    }
}
