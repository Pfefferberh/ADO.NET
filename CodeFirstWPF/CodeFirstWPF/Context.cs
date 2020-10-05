namespace CodeFirstWPF
{
    using CodeFirst.Model;
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class Context : DbContext
    {
        public Context()
           : base("name=Context")
        {
            Database.SetInitializer<Context>(new Initializer());
        }
        public virtual DbSet<Addres> Addres { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Client> Clients { get; set; }
        public virtual DbSet<Manufacturer> Manufacturers { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Product> Products { get; set; }
    }

}