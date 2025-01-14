namespace EfCoreInActionBookApp.Domain.Entities;

public class BookEntity
{
    public int Id { get; set; }

    public string Title { get; set; }

    public string Description { get; set; }

    public DateTime PublishedOn { get; set; }

    public string Publisher { get; set; }

    public decimal Price { get; set; }

    public string ImageUrl { get; set; }

    public PriceOfferEntity Promotion { get; set; }

    public ICollection<ReviewEntity> Reviews { get; set; }

    public ICollection<TagEntity> Tags { get; set; }

    public ICollection<BookAuthorEntity> AuthorLinks { get; set; }
}