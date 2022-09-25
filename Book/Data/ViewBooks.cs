using Connect;
using Book;
using Microsoft.EntityFrameworkCore.Query.Internal;
using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using System;
using Serilog.Context;

namespace Book.Inital.Data
{
    internal class ViewBooks
    {
        BookDbContext db = new BookDbContext();
        public void view()
        {
            int countBooks = 0;
            Update update = new Update();
            List<Books> books = db.books.Select(p => new Books
                { Name = p.Name, Id = p.Id }).ToList();

            var query = db.books.GroupBy(x => x.Name)
                          .Where(g => g.Count() >= 1)
                          .Select(y => new { Book = y.Key, Counter = y.Count() })
                          .ToList();
            foreach (var item in books)
                {
                    countBooks++;
                    Console.WriteLine("Id Book :  " + item.Id + "  Name Book: " + item.Name);
                }
            foreach (var item in query)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("Number books:" + countBooks);
                /////Options////
                Console.WriteLine("Choose the process : 1=Edit, 2=Delete ,3=Detaile ");
                int process = int.Parse(Console.ReadLine());
                Console.Write("Id of book : ");
                int id = int.Parse(Console.ReadLine());
                switch (process)
                {
                     case 1:
                        update.Edit(id);
                        break;
                    case 2:
                        update.Delete(id);
                        break;
                    case 3:
                        update.Detaile(id);
                        break;
                }
        }
    }
}
