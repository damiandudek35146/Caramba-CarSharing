using Caramba.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Caramba
{
    public class UpdateUserHelper
    {
        public static void UpdateUser(User user)
        {
            var users = GetUserInfoHelper.GetUsersData();
            if (users != null)
            {
                var oldUser = users.Single(x => x.ID == user.ID);
                users.Remove(oldUser);
                users.Add(user);
                var sortedUsers = users.OrderBy(o => o.ID).ToList();
                string path = Path.Combine(Environment.CurrentDirectory, @"Database\Users.txt");
                path = path.Replace(@"\bin\Debug\netcoreapp3.1\", @"\");

                string newJson = JsonConvert.SerializeObject(sortedUsers);
                using (StreamWriter sw = File.CreateText(path))
                {
                    sw.WriteLine(newJson);
                    sw.Close();
                }

            }
            else
            {
                users = new List<User>();
                users.Add(user);
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
}
