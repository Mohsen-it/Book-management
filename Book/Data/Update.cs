using Connect;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Book.Inital.Data
{
    public class Update
    {
        BookDbContext db = new ();
        public void Edit(int s)
        {
            var bookInfo = db.books.FirstOrDefault(c => c.Id == s);
            Console.Write("The new name of the book : ");
            string? Name = Console.ReadLine();
            Console.Write("New price for the book  :  ");
            decimal Price = decimal.Parse(Console.ReadLine());
            Console.Write("New book description  :  ");
            string? Description = Console.ReadLine();
            bookInfo.Name = Name;
            bookInfo.Price = Price;
            bookInfo.Description = Description;
            db.books.Update(bookInfo);
            db.SaveChanges();
        }
        public void Delete(int s)
        {
            var bookDelete=db.books.FirstOrDefault(c => c.Id == s);
            db.books.Remove(bookDelete);
            db.SaveChanges();
        }
        public void Detaile(int s)
        {
            var bookDetaile=db.books.FirstOrDefault(c => c.Id == s);
            Console.WriteLine("----------Book detaile Id: " + bookDetaile.Id+"----------");
            Console.WriteLine("-----Book Id : "+bookDetaile.Id);
            Console.WriteLine("---Book name : " + bookDetaile.Name);
            Console.WriteLine("--Book price : " + bookDetaile.Price);
            Console.WriteLine("Book details : " + bookDetaile.Description);
        }

    }
}