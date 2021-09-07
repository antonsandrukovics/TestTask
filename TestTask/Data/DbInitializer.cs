using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestTask.Models;

namespace TestTask.Data
{
    public static class DbInitializer
    {
        public static void Initialize(ShopContext context)
        {
            context.Database.EnsureCreated();
            if (context.Clients.Any())
            {
                return;
            }
            var clients = new Client[]
            {
                new Client{ Name="Antons", Email="antons@inbox.lv", Birthdate=DateTime.Parse("1996-09-02"), Gender= Gender.Male},
                new Client{ Name="Arnis", Email="arnis@inbox.lv", Birthdate=DateTime.Parse("1995-08-03"), Gender= Gender.Male},
                new Client{ Name="Arturs", Email="arturs@inbox.lv", Birthdate=DateTime.Parse("1994-07-04"), Gender= Gender.Male},
                new Client{ Name="Aivars", Email="aivars@inbox.lv", Birthdate=DateTime.Parse("1993-06-05"), Gender= Gender.Male},
                new Client{ Name="Ainars", Email="ainars@inbox.lv", Birthdate=DateTime.Parse("1992-05-06"), Gender= Gender.Male},
                new Client{ Name="Adolfs", Email="adolfs@inbox.lv", Birthdate=DateTime.Parse("1991-04-07"), Gender= Gender.Male},
                new Client{ Name="Aigars", Email="aigars@inbox.lv", Birthdate=DateTime.Parse("1997-03-08"), Gender= Gender.Male},
                new Client{ Name="Andejs", Email="andejs@inbox.lv", Birthdate=DateTime.Parse("1998-02-09"), Gender= Gender.Male}
            };
            foreach (Client c in clients)
            {
                context.Clients.Add(c);
            }
            context.SaveChanges();

            var products = new Product[]
            {
                new Product{Code=123, Title="Item1",Price=1},
                new Product{Code=113, Title="Item2",Price=2},
                new Product{Code=133, Title="Item3",Price=3},
                new Product{Code=143, Title="Item4",Price=4},
                new Product{Code=153, Title="Item5",Price=5},
                new Product{Code=163, Title="Item6",Price=6},
                new Product{Code=173, Title="Item7",Price=7},
                new Product{Code=183, Title="Item8",Price=8}
            };
            foreach (Product p in products)
            {
                context.Products.Add(p);
            }
            context.SaveChanges();

            var orders = new Order[]
            {
                new Order{ ClientId= 1, ProductId=1, Quantity = 1, Status = Status.Created},
                new Order{ ClientId= 2, ProductId=2, Quantity = 2, Status = Status.Delivered},
                new Order{ ClientId= 3, ProductId=3, Quantity = 1, Status = Status.Paid},
                new Order{ ClientId= 4, ProductId=4, Quantity = 3, Status = Status.Created},
                new Order{ ClientId= 5, ProductId=5, Quantity = 1, Status = Status.Delivered},
                new Order{ ClientId= 6, ProductId=6, Quantity = 7, Status = Status.Created},
                new Order{ ClientId= 7, ProductId=7, Quantity = 1, Status = Status.Paid},
                new Order{ ClientId= 8, ProductId=8, Quantity = 5, Status = Status.Created},
                new Order{ ClientId= 1, ProductId=8, Quantity = 1, Status = Status.Created},
                new Order{ ClientId= 2, ProductId=7, Quantity = 2, Status = Status.Delivered},
                new Order{ ClientId= 3, ProductId=6, Quantity = 1, Status = Status.Paid},
                new Order{ ClientId= 4, ProductId=5, Quantity = 3, Status = Status.Created},
                new Order{ ClientId= 5, ProductId=4, Quantity = 1, Status = Status.Delivered},
                new Order{ ClientId= 6, ProductId=3, Quantity = 7, Status = Status.Created},
                new Order{ ClientId= 7, ProductId=2, Quantity = 1, Status = Status.Paid},
                new Order{ ClientId= 8, ProductId=1, Quantity = 5, Status = Status.Created}
            };
            foreach (Order o in orders)
            {
                context.Orders.Add(o);
            }
            context.SaveChanges();
        }
    }
}
