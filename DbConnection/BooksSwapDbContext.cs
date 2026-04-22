using DbConnection.DbModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbConnection
{
    public class BooksSwapDbContext : DbContext
    {
        public DbSet<BookCondition> BookConditions { get; set; }
        public DbSet<BookGenre> BookGenres { get; set; }
        public DbSet<BookStatus> BookStatuses { get; set; }

        public DbSet<Book> Books { get; set; }
        public DbSet<User> Users { get; set; }

        public BooksSwapDbContext() : base()
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=BooksSwapDb;Trusted_Connection=True;");
        }
    }
}
