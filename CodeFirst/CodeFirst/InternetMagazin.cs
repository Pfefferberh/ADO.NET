namespace CodeFirst
{
    using CodeFirst.Model;
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class InternetMagazin : DbContext
    {
        // Контекст настроен для использования строки подключения "InternetMagazin" из файла конфигурации  
        // приложения (App.config или Web.config). По умолчанию эта строка подключения указывает на базу данных 
        // "CodeFirst.InternetMagazin" в экземпляре LocalDb. 
        // 
        // Если требуется выбрать другую базу данных или поставщик базы данных, измените строку подключения "InternetMagazin" 
        // в файле конфигурации приложения.
        public InternetMagazin()
            : base("name=InternetMagazin")
        {
        }

        // Добавьте DbSet для каждого типа сущности, который требуется включить в модель. Дополнительные сведения 
        // о настройке и использовании модели Code First см. в статье http://go.microsoft.com/fwlink/?LinkId=390109.
        
         public virtual DbSet<Addres> Addres { get; set; }
         public virtual DbSet<Category> Categories { get; set; }
         public virtual DbSet<Client> Clients { get; set; }
         public virtual DbSet<Manufacturer> Manufacturers { get; set; }
         public virtual DbSet<Order> Orders { get; set; }
         public virtual DbSet<Product> Products { get; set; }
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}