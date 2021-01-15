using Caramba.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Caramba.Helpers
{
    public class DeleteUserHelper
    {
        public static void DeleteAccount(User user)
        {
            var users = GetUserInfoHelper.GetUsersData();
            var oldUser = users.Single(x => x.ID == user.ID);
            users.Remove(oldUser);
            var sortedList = users.OrderBy(o => o.ID).ToList();

            string path = Path.Combine(Environment.CurrentDirectory, @"Database\Users.txt");
            path = path.Replace(@"\bin\Debug\netcoreapp3.1\", @"\");

            string newJson = JsonConvert.SerializeObject(sortedList);
            using (StreamWriter sw = File.CreateText(path))
            {
                sw.WriteLine(newJson);
                sw.Close();
            }
        }
    }
}
