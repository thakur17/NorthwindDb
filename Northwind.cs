using static System.Console;
using Microsoft.EntityFrameworkCore;

namespace Database
{
    // this manages the connection to the database
    public class Northwind : DbContext
    {
        // these properties map to tables in the database 
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        protected override void OnConfiguring(
        DbContextOptionsBuilder optionsBuilder)
        {
            string path = "c:\\database\\Database\\Northwind.db";
            optionsBuilder.UseSqlite($"Filename={path}");
            //WriteLine(path);
            //ReadKey();

        }
//        protected override void OnModelCreating(
//        ModelBuilder modelBuilder)
//        {
//            // example of using Fluent API instead of attributes
//            // to limit the length of a category name to 15
//            modelBuilder.Entity<Category>()
//            .Property(category => category.CategoryName)
//            .IsRequired() // NOT NULL
//            .HasMaxLength(15);
//        }

    }
}

