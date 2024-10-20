using System;

namespace Ecommerce.Entities;

public class ProductEntity
{
    public int Id { get; set; }

    public required string Name { get; set; }

    public required int CategoryId { get; set; }

    public required CategoryEntity Category { get; set; }

    public required decimal Price    { get; set; }

    public required string images { get; set; }

    public DateOnly CreatedDate     { get; set; }

    public DateOnly UpdatedDate      { get; set; }

}
