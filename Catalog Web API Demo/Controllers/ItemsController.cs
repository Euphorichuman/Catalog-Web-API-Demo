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
        
        // Get /items/{id}
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
    }
