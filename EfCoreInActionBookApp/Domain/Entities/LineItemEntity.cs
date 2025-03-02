﻿using System.ComponentModel.DataAnnotations;

namespace EfCoreInActionBookApp.Domain.Entities;

public class LineItemEntity : IValidatableObject
{
    public int LineItemId { get; set; }

    [Range(1, 5, ErrorMessage =
        "ThisOrder is over the limit of 5 books.")]
    public byte LineNum { get; set; }

    public short NumBooks { get; set; }

    public decimal BookPrice { get; set; }

    public int OrderId { get; set; }

    public int BookId { get; set; }

    public BookEntity ChosenBook { get; set; }

    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        if (ChosenBook.Price < 0)
            yield return new ValidationResult(
                 $"Sorry, the book '{ChosenBook.Title}' is not for sale.");
        if (NumBooks > 100)
            yield return new ValidationResult(
    "If you want to order a 100 or more books" +
" please phone us on 01234-5678-90",
                new[] { nameof(NumBooks) });
    }
}