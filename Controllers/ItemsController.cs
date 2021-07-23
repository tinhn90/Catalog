using System;
using System.Collections.Generic;
using System.Linq;
using Catalog.Dtos;
using Catalog.Entites;
using Catalog.Extention;
using Catalog.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.Controller
{
    [ApiController]
    [Route("items")]
    public class ItemController : ControllerBase
    {
        private readonly ItemsRepository repository;

        public ItemController(ItemsRepository repository)
        {
            this.repository = repository;
        }
        [HttpGet]
        public IEnumerable<ItemsDto> GetItems()
        {
            var items = repository.GetItems().Select(t => t.AsDto());
            return items;
        }
        [HttpGet("{id}")]
        public ActionResult<ItemsDto> getItem(Guid id)
        {
            var items = repository.GetItem(id).AsDto();
            if (items is null) return NotFound();
            return items;
        }
        [HttpPost]
        public ActionResult<ItemsDto> createItem(CreateItemsDto item)
        {
            var createditem = new Items()
            {
                Id = Guid.NewGuid(),
                Name = item.Name,
                Price = item.Price,
                CreatedDate = DateTimeOffset.Now
            };
            repository.AddItem(createditem);
            return CreatedAtAction(nameof(getItem), new { id = createditem.Id }, createditem.AsDto());
        }
        [HttpPut("{id}")]
        public ActionResult<ItemsDto> updateItem(Guid id, UpdateItemsDto item)
        {
            var existingItem = repository.GetItem(id);
            if (existingItem is null)
            {
                return NotFound();
            }
            var updateItem = existingItem with
            {
                Name = item.Name,
                Price = item.Price
            };
            repository.UpdateItem(updateItem);
            return NoContent();
        }
    }
}