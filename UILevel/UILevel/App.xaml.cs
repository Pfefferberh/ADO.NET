using Autofac;
using AutoMapper;
using BusisLevel.Servise;
using BusisLevel.Util;
using DBLevel;
using DBLevel.Reposetory;
using System.Data.Entity;
using System.Windows;

namespace UILevel
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<Context>().As<DbContext>().SingleInstance();
            builder.RegisterGeneric(typeof(EFRepository<>)).As(typeof(IGenericRepository<>));
            builder.RegisterType<Univers>().As<IUnivers>();
            builder.RegisterType<Mai>().AsSelf();

            var config = new MapperConfiguration(cgf => cgf.AddProfile(new MapperConfig()));
            builder.RegisterInstance(config.CreateMapper());

            using (var scope = builder.Build().BeginLifetimeScope())
            {
                var window = scope.Resolve<Mai>();
                window.ShowDialog();
            }
        }
    }
}

