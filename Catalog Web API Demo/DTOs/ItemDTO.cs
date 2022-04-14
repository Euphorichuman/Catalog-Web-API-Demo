﻿namespace Catalog_Web_API_Demo.DTOs;

public class ItemDTO
{
    public Guid Id { get; init; }
    public string Name { get; init; }
    public decimal Price { get; init; }
    public DateTimeOffset CreatedDate { get; init; }
}
