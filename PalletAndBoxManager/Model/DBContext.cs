using Microsoft.EntityFrameworkCore;

namespace ConsoleApp2.Model;

public class DBContext:DbContext
{
    static readonly string connectionString = "Server=localhost; User ID=root; Password=1234; Database=test3";
    public DbSet<Pallet> Pallets { get; set; }
    public DbSet<Box> Boxes { get; set; }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
    }
}