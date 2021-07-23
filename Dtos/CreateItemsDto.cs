using System;

namespace Catalog.Dtos
{
    public class CreateItemsDto
    {
        public string Name { get; init; }
        public Decimal Price { get; init; }
    }
}