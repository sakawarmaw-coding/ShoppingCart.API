namespace ShoppingCart.DbService.Entities;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options) { }

    public DbSet<TblUser> tblUser { get; set; }
    public DbSet<TblProduct> tblProduct { get; set; }
    public DbSet<TblCartItem> tblCartItem { get; set; }
}
