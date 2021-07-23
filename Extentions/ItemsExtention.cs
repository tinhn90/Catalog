using Catalog.Dtos;
using Catalog.Entites;

namespace Catalog.Extention
{
    public static class ItemsExtention
    {
        public static ItemsDto AsDto(this Items item)
        {
            ItemsDto itemsdto = new ItemsDto()
            {
                Id = item.Id,
                Name = item.Name,
                Price = item.Price,
                CreatedDate = item.CreatedDate,
            };
            return itemsdto;


        }
    }
}