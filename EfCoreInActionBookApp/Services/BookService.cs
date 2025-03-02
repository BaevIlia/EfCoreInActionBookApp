using EfCoreInActionBookApp.Domain.Dtos;
using EfCoreInActionBookApp.Domain.Entities;
using EfCoreInActionBookApp.Domain.Enums;
using System.Runtime.CompilerServices;

namespace EfCoreInActionBookApp.Services;

public static class BookService
{
    public static IQueryable<BookListDto> MapBookToDto(this IQueryable<BookEntity> books) 
    {
        return books.Select(book => new BookListDto
        {
            BookId = book.Id,
            Title = book.Title,
            Price = book.Price,
            PublishedOn = book.PublishedOn,
            ActualPrice = book.Promotion == null
            ? book.Price
            : book.Promotion.NewPrice,
            PromotionPromotionalText = book.Promotion == null
            ? null
            : book.Promotion.PromotionalText,
            AuthorsOrdered = string.Join(", ", 
            book.AuthorLinks
            .OrderBy(ba=>ba.Order)
            .Select(ba=>ba.Author.Name)),
            ReviewsCount = book.Reviews.Count,
            ReviewsAverageVotes = book.Reviews
            .Select(review=>(double?)review.NumStars).Average(),
            TagStrings = book.Tags.Select(x=>x.Id).ToArray(),
        }) ;
    }

    public static IQueryable<BookListDto> OrderBooksBy(this IQueryable<BookListDto> books, OrderOptions orderByOptions) 
    {
        switch (orderByOptions) 
        {
            case OrderOptions.SimpleOrder:
                return books.OrderByDescending(
                    x => x.BookId);
            case OrderOptions.ByVotes:
                return books.OrderByDescending(
                    x => x.ReviewsAverageVotes);
            case OrderOptions.ByPublicationDate:
                return books.OrderByDescending(
                    x => x.PublishedOn);
            case OrderOptions.ByPriceLowerFirst:
                return books.OrderBy(
                    x => x.ActualPrice);
            case OrderOptions.ByPriceHigherFirst:
                return books.OrderByDescending(
                    x => x.ActualPrice);
            default:
                throw new ArgumentOutOfRangeException(nameof(orderByOptions), orderByOptions, null);
        }
    }

    public static 
}