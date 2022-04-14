using Catalog_Web_API_Demo.DTOs;
using Catalog_Web_API_Demo.Entities;

namespace Catalog_Web_API_Demo;

public static class Extensions
{
    public static ItemDTO AsDTO(this Item item)
    {
        return new ItemDTO
        {
            Id = item.Id,
            Name = item.Name,
            Price = item.Price,
            CreatedDate = item.CreatedDate,
        };
    }
}
