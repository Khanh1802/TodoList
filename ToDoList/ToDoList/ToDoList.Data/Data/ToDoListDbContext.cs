using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using ToDoList.Data.Configurations;
using ToDoList.Data.Models;

namespace ToDoList.Data.Data
{
    public class ToDoListDbContext : DbContext
    {
        private readonly StreamWriter _logStream = new StreamWriter("log.txt", append: true);
        public ToDoListDbContext(DbContextOptions options) : base(options)
        {

        }
        public ToDoListDbContext()
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            IConfigurationRoot configuration = new ConfigurationBuilder()
               .SetBasePath(Directory.GetCurrentDirectory())
               .AddJsonFile("appsettings.json")
               .Build();

            var connectionString = configuration.GetConnectionString("ToDoListConnection");
            optionsBuilder.UseMySql(connectionString, MySqlServerVersion.LatestSupportedServerVersion);
            optionsBuilder.LogTo(_logStream.WriteLine, LogLevel.Debug);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //C1:
            //modelBuilder.Entity<Category>()
            //    .HasMany(x => x.Jobs)
            //    .WithOne(x => x.Category)
            //    .HasForeignKey(x => x.CategoryId);

            //C2:
            modelBuilder.Entity<Job>()
                .HasOne(x => x.Category)
                .WithMany(x => x.Jobs)
                .HasForeignKey(x => x.CategoryId);

            modelBuilder.Entity<Job>()
                 .HasOne(x => x.State)
                 .WithMany(x => x.Jobs)
                 .HasForeignKey(x => x.StateId);

            new CategoryEntityTypeConfigurations().Configure(modelBuilder.Entity<Category>());
            new JobEntityTypeConfigurations().Configure(modelBuilder.Entity<Job>());
            new StateEntityTypeConfigurations().Configure(modelBuilder.Entity<State>());
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Job> Jobs { get; set; }
        public DbSet<State> States { get; set; }

        public override void Dispose()
        {
            base.Dispose();
            _logStream.Dispose();
        }

        public override async ValueTask DisposeAsync()
        {
            await base.DisposeAsync();
            await _logStream.DisposeAsync();
        }
    }
}
