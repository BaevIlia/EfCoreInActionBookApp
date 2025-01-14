using EfCoreInActionBookApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace EfCoreInActionBookApp.Domain;

public class BookAppDbContext : DbContext
{
    public DbSet<BookEntity> Books { get; set; }
    
    public DbSet<AuthorEntity> Authors { get; set; }

    public DbSet<TagEntity> Tags { get; set; }

    public DbSet<PriceOfferEntity> PriceOffers { get; set; }

    public BookAppDbContext(DbContextOptions<BookAppDbContext> options) : base(options)
    {
        
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql("Host=localhost; Port=5432; Database=BookDb; username=postgres; Password=14863");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<BookAuthorEntity>()
            .HasKey(x => new { x.BookId, x.AuthorId });

    }
}