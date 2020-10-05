using CodeFirst.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Windows;

namespace CodeFirstWPF
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Context context = new Context();

            var pr = new List<Product>()
            {
                new Product {Name = "IPhone" , Price = 320, Category = context.Categories.FirstOrDefault(x=>x.Name=="phones")},
                new Product {Name = "Meat" , Price = 30, Category = context.Categories.FirstOrDefault(x=>x.Name=="food")},
                new Product {Name = "vodlka" , Price = 320, Category = context.Categories.FirstOrDefault(x=>x.Name=="phones")},
                new Product {Name = "samsung" , Price = 320, Category = context.Categories.FirstOrDefault(x=>x.Name=="alcohol")},
                new Product {Name = "xiaomi" , Price = 320, Category = context.Categories.FirstOrDefault(x=>x.Name=="phones")},
            };
            context.Products.AddRange(pr);
            context.SaveChanges();

            context.Addres.Add(new Addres() 
            { Country = "Ukrain", City = "Rivne", Street = "Olesya 12" });
            context.SaveChanges();

            var cl = new List<Client>();
            cl.Add(new Client(){ Name = "Vasya" });
            context.Clients.AddRange(cl);
            context.SaveChanges();

            var or = new List<Order>();
            or.Add(new Order{ProductId=1, AdressId=1,ClientId=1,Date=DateTime.Now});
            context.Orders.AddRange(or);
            context.SaveChanges();

            dgclient.ItemsSource = cl;
            dgorder.ItemsSource = or;
            dgproduct.ItemsSource =pr;
        }
    }
}
