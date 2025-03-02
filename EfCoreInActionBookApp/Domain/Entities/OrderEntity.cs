namespace EfCoreInActionBookApp.Domain.Entities;

public class OrderEntity
{
    public int OrderId { get; set; }

    public DateTime DateOrderedUtc { get; set; }

    public Guid CustomerId { get; set; }

    public ICollection<LineItemEntity> LineItems { get; set; }

    public string OrderNumber => $"SO{OrderId:D6}";

    public OrderEntity() 
    {
        DateOrderedUtc = DateTime.UtcNow;
    }
}