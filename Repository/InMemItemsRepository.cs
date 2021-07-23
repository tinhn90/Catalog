using System;
using System.Collections.Generic;
using System.Linq;
using Catalog.Entites;

namespace Catalog.Repository
{
    public class InMemItemsRepository : ItemsRepository
    {
        private readonly List<Items> items = new()
        {
            new Items { Id = Guid.NewGuid(), Name = "Potion", Price = 9, CreatedDate = DateTimeOffset.Now },
            new Items { Id = Guid.NewGuid(), Name = "Sword", Price = 25, CreatedDate = DateTimeOffset.Now },
            new Items { Id = Guid.NewGuid(), Name = "Shield", Price = 13, CreatedDate = DateTimeOffset.Now },
            new Items { Id = Guid.NewGuid(), Name = "Shield", Price = 15, CreatedDate = DateTimeOffset.Now }
        };

        public IEnumerable<Items> GetItems()
        {
            return items;
        }
        public Items GetItem(Guid id)
        {
            return items.Where(item => item.Id == id).FirstOrDefault();
        }

        public void AddItem(Items item)
        {
            items.Add(item);
        }

        public void UpdateItem(Items item)
        {
            var index = items.FindIndex(t => t.Id == item.Id);
            items[index] = item;
        }
    }
}
