using Catalog_Web_API_Demo.Entities;

namespace Catalog_Web_API_Demo.Repositories;
    public interface IItemsRepository
    {
        Item GetItem(Guid id);
        IEnumerable<Item> GetItems();
    }
