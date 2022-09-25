using Book;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Users
{
    public class AddUsers
    {

       public void AddUser()
        {
            string jsonFile = File.ReadAllText(@"UserInfo.json");
            var defualtUsers = JsonSerializer.Deserialize<List<User>>(jsonFile);
            using (var context = new Connect.BookDbContext())
            {
                Console.WriteLine(jsonFile);
                Console.WriteLine("Saving Data");
                context.users.AddRange(defualtUsers);
                context.SaveChanges();
                Console.WriteLine("Saved Data");
            }
        }
    }
}
