namespace EfCoreInActionBookApp.Domain.Entities;

public class TagEntity
{
    public string Id { get; set; }

    public ICollection<BookEntity> Books { get; set; }
}