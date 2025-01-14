namespace EfCoreInActionBookApp.Domain.Entities;

public class ReviewEntity
{
    public int Id { get; set; }

    public string VoterName { get; set; }

    public int NumStars { get; set; }

    public string Comment { get; set; }

    public int BookId { get; set; }
}