using System;

namespace Catalog.Entites
{
    public record Items
    {
        public Guid Id { get; init; }
        public string Name { get; init; }
        public Decimal Price { get; init; }
        public DateTimeOffset CreatedDate { get; init; }
    }
}