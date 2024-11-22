using Microsoft.EntityFrameworkCore;

namespace PhotoBooth.Context;

public class MyDbContext: DbContext
{
    protected readonly IConfiguration Configuration;

    public MyDbContext(IConfiguration configuration)
    {
        Configuration = configuration;
    }
    
    public DbSet<Layout> Layouts { get; set; }
    public DbSet<Photo> Photos { get; set; }
    public DbSet<LayoutPicture> LayoutPictures { get; set; }
    public DbSet<LayoutThemes> LayoutThemes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=Funstudio.db");
    }
}