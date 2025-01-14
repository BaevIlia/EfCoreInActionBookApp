namespace EfCoreInActionBookApp.Domain.Entities;

public class PriceOfferEntity
{
    public int Id { get; set; }

    public decimal NewPrice { get; set; }

    public string PromotionalText { get; set; }

    public int BookId { get; set; }
}