using Connect;
using Users;
using Book.Inital.Data;

namespace Book.Inital
{

    internal class Program
    {
        static void Main(string[] args)
        {
            /////<Test adduser>////
            //string strFilePath = @"C:\Users\Mohsen\source\repos\Book\Book\UserInfo.json";
            //DateTime lastModified = System.IO.File.GetLastWriteTime(strFilePath);
            //if (lastModified==DateTime.Now)
            //{
            //    AddUsers addUsers = new AddUsers();
            //    addUsers.AddUser();
            //}
            //////</Test adduser>///////
            ViewBooks viewBooks = new ViewBooks();
            BookDbContext context = new();
            Console.WriteLine("Add Users from file UserInfo.json...? Y/N");
            string? file = Console.ReadLine();
            if (file == "y")
            {
                AddUsers addUsers = new AddUsers();
                addUsers.AddUser();
            }
            Console.Write("User Name:  ");
            string? userName = Console.ReadLine();
            Console.Write("Password:   ");
            string? Password = Console.ReadLine();
            var user = context.users
     .Where(x => x.Name == userName && x.Password == Password)
     .Select(x => new { x.Name, x.Password });

            foreach (var item in user)
            {
                while (item.Name.Equals(userName) &&
                    item.Password.Equals(Password))
                {
                    viewBooks.view();
                    Console.WriteLine("Out System...? Y/N");
                    string? T = Console.ReadLine();
                    if (T=="y")
                    {
                        break;
                    }
                }
            }
        }

    }
}