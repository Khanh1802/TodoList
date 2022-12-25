using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ToDoList.Data.Data;
using ToDoList.MapperProfiles;
using ToDoList.Repository;
using ToDoList.Services;

namespace WinFormsToDoList
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            var host = CreateHostBuilder().Build();
            ServiceProvider = host.Services; // Buoc 2: Khoi tao host.Services
            Application.Run(ServiceProvider.GetRequiredService<HomePage>()); // Form1 => là project tạo từ Winform Init
        }

        public static IServiceProvider ServiceProvider { get; private set; }
        static IHostBuilder CreateHostBuilder()
        {
            return Host.CreateDefaultBuilder()
           .ConfigureServices((context, services) =>
           {
               services.AddDbContext<ToDoListDbContext>(opts =>
               {
                   var config = context.Configuration.GetConnectionString("ToDoListConnection");
                   opts.UseMySql(config, MySqlServerVersion.LatestSupportedServerVersion);
               });
               services.AddTransient<ICategoryRepository, CategoryRepository>();
               services.AddTransient<ICategoryService, CategoryService>();
               services.AddTransient<IStateRepository, StateRepository>();
               services.AddTransient<IStateService, StateService>();
               services.AddTransient<IJobRepository, JobRepository>();
               services.AddTransient<IJobService, JobService>();
               services.AddTransient<HomePage>();
               services.AddTransient<FormCategory>();
               services.AddTransient<FormJob>();
               services.AddTransient<FormState>();

               services.AddAutoMapper(typeof(JobProfile));
               services.AddAutoMapper(typeof(StateProfile));
           });
        }
    }
}