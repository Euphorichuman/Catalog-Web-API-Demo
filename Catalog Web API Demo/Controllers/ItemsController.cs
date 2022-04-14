﻿using Catalog_Web_API_Demo.Entities;
using Catalog_Web_API_Demo.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Catalog_Web_API_Demo.Controllers;
    
    [ApiController]
    [Route("items")]
    public class ItemsController : ControllerBase
    {
        private readonly InMemItemsRepository repository;

        public ItemsController()
        {
            repository = new InMemItemsRepository();
        }
        
        // GET /items
        [HttpGet]
        public IEnumerable<Item> GetItems()
        {
            var items = repository.GetItems();
            return items;
        }
        
        // Get /items/{id}
        [HttpGet("{id}")]
        public ActionResult<Item> GetItem(Guid id)
        {
            var item = repository.GetItem(id);
            
            if (item == null)
            {
                return NotFound();
            }
            
            return item;
        }    
    }
