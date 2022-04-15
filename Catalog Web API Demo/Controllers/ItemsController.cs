using Catalog_Web_API_Demo.DTOs;
using Catalog_Web_API_Demo.Entities;
using Catalog_Web_API_Demo.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Catalog_Web_API_Demo.Controllers;

[ApiController]
[Route("items")]
public class ItemsController : ControllerBase
{
    private readonly IItemsRepository repository;

    public ItemsController(IItemsRepository repository)
    {
        this.repository = repository;
    }

    // GET /items
    [HttpGet]
    public IEnumerable<ItemDTO> GetItems()
    {
        var items = repository.GetItems().Select(item => item.AsDTO());
        return items;
    }

    // GET /items/{id}
    [HttpGet("{id}")]
    public ActionResult<ItemDTO> GetItem(Guid id)
    {
        var item = repository.GetItem(id);

        if (item == null)
        {
            return NotFound();
        }

        return item.AsDTO();
    }

    // POST /items
    [HttpPost]
    public ActionResult<ItemDTO> CreateItem(CreateItemDTO itemDTO)
    {
        Item item = new()
        {
            Id = Guid.NewGuid(),
            Name = itemDTO.Name,
            Price = itemDTO.Price,
            CreatedDate = DateTimeOffset.UtcNow,
        };

        repository.CreateItem(item);

        return CreatedAtAction(nameof(GetItem), new { id = item.Id }, item.AsDTO());
    }

    // PUT /items
    [HttpPut("{id}")]
    public ActionResult UpdateItem(Guid id, UpdateItemDTO itemDTO)
    {
        var existingItem = repository.GetItem(id);

        if (existingItem == null)
        {
            return NotFound();
        }

        Item updatedItem = existingItem with
        {
            Name = itemDTO.Name,
            Price = itemDTO.Price,
        };

        repository.UpdateItem(updatedItem);

        return NoContent();
    }

    // DELETE /items
    [HttpDelete("{id}")]
    public ActionResult DeleteItem(Guid id)
    {
        var existingItem = repository.GetItem(id);

        if (existingItem == null)
        {
            return NotFound();
        }

        repository.DeleteItem(id);

        return NoContent();
    }
}
