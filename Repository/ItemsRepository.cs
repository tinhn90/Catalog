using System;
using System.Collections.Generic;
using System.Linq;
using Catalog.Entites;

namespace Catalog.Repository
{
    public interface ItemsRepository
    {
        public IEnumerable<Items> GetItems();
        public Items GetItem(Guid id);
        public void AddItem(Items item);
        public void UpdateItem(Items item);

    }
}