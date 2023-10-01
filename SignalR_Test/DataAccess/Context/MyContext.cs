using Microsoft.EntityFrameworkCore;
using SignalR_Test.Models;

namespace SignalR_Test.DataAccess.Context;

public class MyContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source = mydb.db;");
        base.OnConfiguring(optionsBuilder);
    }

    public DbSet<User> Users { get; set; }
}