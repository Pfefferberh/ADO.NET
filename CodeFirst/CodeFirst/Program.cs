using CodeFirst.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CodeFirst
{
    class Program
    {
        static void Main(string[] args)
        {
            InternetMagazin internetMagazin = new InternetMagazin();

            //internetMagazin.Clients.AddRange(new List<Client>() {
            //    new Client()
            //    {
            //        Name = "Tom"
            //    },
            //    new Client()
            //    {
            //        Name = "Bill"
            //    },
            //    new Client()
            //    {
            //        Name = "Sergey"
            //    },
            //    new Client()
            //      {
            //        Name = "Karrrl"
            //    }});
            //internetMagazin.SaveChanges();

            //internetMagazin.Categories.AddRange(new List<Category>() {
            //    new Category {Name = "Shose" },
            //    new Category {Name = "food" },
            //    new Category {Name = "alcohol" },
            //    new Category {Name = "phones" }

            //});
            //internetMagazin.SaveChanges();

            //internetMagazin.Products.AddRange(new List<Product>() {
            //new Product {Name = "IPhone" , Price = 320, Category = internetMagazin.Categories.FirstOrDefault(x=>x.Name=="phones")},
            //new Product {Name = "Meat" , Price = 30, Category = internetMagazin.Categories.FirstOrDefault(x=>x.Name=="food")},
            //new Product {Name = "vodlka" , Price = 320, Category = internetMagazin.Categories.FirstOrDefault(x=>x.Name=="phones")},
            //new Product {Name = "samsung" , Price = 320, Category = internetMagazin.Categories.FirstOrDefault(x=>x.Name=="alcohol")},
            //new Product {Name = "xiaomi" , Price = 320, Category = internetMagazin.Categories.FirstOrDefault(x=>x.Name=="phones")},
            //});
            //internetMagazin.SaveChanges();

            internetMagazin.Orders.AddRange(new List<Order>()
            {
                new Order {Date = Convert.ToDateTime("20.12.2019"), TotalPrice=3244 , Client = internetMagazin.Clients.FirstOrDefault(x=>x.Name=="Tom"),
                    Addres = internetMagazin.Addres.FirstOrDefault(x=>x.City=="Rovno"), ProductId = internetMagazin.Products.FirstOrDefault(x=>x.Name == "samsung").Id },
                new Order {Date = Convert.ToDateTime("20.11.2019"), TotalPrice=3244 , Client = internetMagazin.Clients.FirstOrDefault(x=>x.Name=="Bill"),
                    Addres = internetMagazin.Addres.FirstOrDefault(x=>x.City=="Zmerenka"), ProductId = internetMagazin.Products.FirstOrDefault(x=>x.Name == "vodlka").Id },
                new Order {Date = Convert.ToDateTime("23.12.2019"), TotalPrice=3244 , Client = internetMagazin.Clients.FirstOrDefault(x=>x.Name=="Tom"),
                    Addres = internetMagazin.Addres.FirstOrDefault(x=>x.City=="Vladikavkas"), ProductId = internetMagazin.Products.FirstOrDefault(x=>x.Name == "vodlka").Id },
                new Order {Date = Convert.ToDateTime("21.12.2019"), TotalPrice=3244 , Client = internetMagazin.Clients.FirstOrDefault(x=>x.Name=="Karrrl"),
                    Addres = internetMagazin.Addres.FirstOrDefault(x=>x.City=="Tokio"), ProductId = internetMagazin.Products.FirstOrDefault(x=>x.Name == "vodlka").Id },
            });
            internetMagazin.SaveChanges();
        }
    }
}
