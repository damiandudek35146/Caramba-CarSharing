using Caramba.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Caramba
{
    public static class GetUserInfoHelper
    {
        public static List<User> GetUsersData()
        {
            string path = Path.Combine(Environment.CurrentDirectory, @"Database\Users.txt");
            path = path.Replace(@"\bin\Debug\netcoreapp3.1\", @"\");
            string result;
            using (StreamReader sr = new StreamReader(path))
            {
                result = sr.ReadToEnd();
            }
            var _ListOfUsers = JsonConvert.DeserializeObject<List<User>>(result);
            if (_ListOfUsers == null)
            {
                _ListOfUsers = new List<User>();
            }
            return _ListOfUsers;
        }
    }
}
