namespace EfCoreInActionBookApp.Domain.Entities;

public class AuthorEntity
{
    public int Id { get; set; }

    public string Name { get; set; }

    public ICollection<BookAuthorEntity> BookLink { get; set; }
}