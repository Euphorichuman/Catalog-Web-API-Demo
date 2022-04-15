using System.ComponentModel.DataAnnotations;

namespace Catalog_Web_API_Demo.DTOs;

public record CreateItemDTO
{
    [Required]
    public string Name { get; init; }

    [Required]
    [Range(0, Double.PositiveInfinity, ErrorMessage = "{0} should not be less than 0")]
    public decimal Price { get; init; }
}
