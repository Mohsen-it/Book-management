using Book;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Connect
{

    public class BookDbContext : DbContext
    {

        string op = "Server=DESKTOP-PDT214U\\SQLEXPRESS;Database=h;Trusted_Connection=True;MultipleActiveResultSets=true";
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var logger = new Logger();
           
            optionsBuilder.UseSqlServer(op).LogTo(log=>logger.Log(log),LogLevel.Information);

        }
        public DbSet<User>? users { get; set; }
        public DbSet<Books>? books { get; set; }
        public TextWriter Log { get; set; }
    }
}