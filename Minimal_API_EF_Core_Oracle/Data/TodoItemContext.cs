using Microsoft.EntityFrameworkCore;
using Minimal_API_EF_Core_Oracle.Models;

namespace Minimal_API_EF_Core_Oracle.Data
{
    public class TodoItemContext : DbContext
    {
        public TodoItemContext()
        {
        }

        public TodoItemContext(DbContextOptions<TodoItemContext> options)
        : base(options)
        {
        }

        public virtual DbSet<TodoItem> TodoItems { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json", optional: true)
                .Build();

            var connectionString = configuration.GetConnectionString("TodoItemContext");

            optionsBuilder.UseOracle( connectionString )
                .LogTo( Console.WriteLine, LogLevel.Information );
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new TodoItemConfiguration());

            modelBuilder.HasDefaultSchema("DEMODOTNET");

            modelBuilder.HasSequence("TODOITEM_SEQ");

        }
    }
}
