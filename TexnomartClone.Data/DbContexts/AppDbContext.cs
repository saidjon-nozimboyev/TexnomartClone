using Microsoft.EntityFrameworkCore;
using TexnomartClone.Domain.Entities;
using TexnomartClone.Domain.Enums;

namespace TexnomartClone.Data.DbContexts;

public class AppDbContext(DbContextOptions<AppDbContext> options) 
    : DbContext(options)
{
    public DbSet<User> Users { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Order> Orders { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>().HasData(
           new User
           {
               Id = 1,
               FirstName = "SuperAdmin",
               LastName = "Boss",
               Email = "saidjonnozimboyevv@gmail.com",
               PhoneNumber = "+998930469959",
               Gender = Gender.Male,
               IsVerified = true,
               Password = "6596443e7768f0c1ae055535783a3b6fcd3c2efb4fc0725336e31e087c4d10fc",
               Role = Role.SuperAdmin,
           });
    }
}