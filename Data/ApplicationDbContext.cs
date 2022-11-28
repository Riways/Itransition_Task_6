using Microsoft.EntityFrameworkCore;
using MudBlazor;
using Task_6_Blazor_Server.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Task_6_Blazor_Server.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserModel>().HasAlternateKey(u => u.Name);
        }

        public ApplicationDbContext() => Database.EnsureCreated();

        public DbSet<UserModel> Users => Set<UserModel>();
        public DbSet<MessageModel> Messages => Set<MessageModel>();
        public DbSet<DialogModel> Dialogs => Set<DialogModel>();
    }
}