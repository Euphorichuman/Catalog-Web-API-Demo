using Catalog_Web_API_Demo.Entities;

namespace Catalog_Web_API_Demo.Repositories;
public interface IItemsRepository
{
    Task<Item> GetItemAsync(Guid id);

    Task<IEnumerable<Item>> GetItemsAsync();

    Task CreateItemAsync(Item item);

    Task UpdateItemAsync(Item item);

    Task DeleteItemAsync(Guid id);
}
