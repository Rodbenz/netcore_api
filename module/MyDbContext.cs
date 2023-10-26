using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

public class MyDbContext : DbContext
{
    public MyDbContext(DbContextOptions<MyDbContext> options)
        : base(options)
    { }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
    public DbSet<PROVINCE> Province { get; set; } = null!;
    public DbSet<AMPHUR> Amphurs { get; set; }  = null!;
    public DbSet<StoreProvince> StoreProvinces { get; set; }  = null!;
}