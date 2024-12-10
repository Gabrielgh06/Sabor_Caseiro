using Microsoft.EntityFrameworkCore;
using SaborCaseiro.Models;


public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Prato>? Pratos { get; set; }
}
