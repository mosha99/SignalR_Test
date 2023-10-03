using Microsoft.EntityFrameworkCore;
using SignalR_Test.Models;

namespace SignalR_Test.DataAccess.Context;

public class MyContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Password=1;Persist Security Info=True;User ID=sa;Initial Catalog=SignallRTest;Data Source=.;Trust Server Certificate=true");
        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(x=>x.Name);
        });
        base.OnModelCreating(modelBuilder);
    }

    public DbSet<User> Users { get; set; }
}