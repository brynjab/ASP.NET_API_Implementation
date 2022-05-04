using ASPNET_API_Implementation.Models;
using Microsoft.EntityFrameworkCore;

namespace ASPNET_API_Implementation.Data
{
    public class SalesDbContext : DbContext
    {
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Clerk> Clerks { get; set; }


        /*
        public static void SeedDatabase()
        {
            using( var db = new SalesDbContext())
            {
                db.Database.EnsureCreated();

                var s1_exists = db.Orders.FirstOrDefault(o => o.Clerk.Name == "Martin Lawrence");
                if( s1_exists == null)
                {
                    Order o1 = new Order();
                    o1.Total_Price = 3800;
                    o1.Date = new DateTime(2001, 01, 10);

                    o1.Clerk = new Clerk() { Name = "Martin Lawrence" };
                    o1.Customer = new Customer() { CustomerNumber = 1001, Name = "ABC Company", Adress = "100 Points, Manhattan, KS 66502" };

                    o1.Products.Add(new Product() { Description = "widgit small", Quantity = 40, Unit_Price = 60 });
                    o1.Products.Add(new Product() { Description = "thingimajigger", Quantity = 20, Unit_Price = 20 });
                    o1.Products.Add(new Product() { Description = "thingibob", Quantity = 100, Unit_Price = 1000 });

                    db.Orders.Add(o1);
                }
                db.SaveChanges();
            }
        }
        */


        //passa að mismunandi customers séu ekki með sama númer
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Customer>()
                .HasIndex(c => c.CustomerNumber)
                .IsUnique();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=Sale");
        }

    }
}
