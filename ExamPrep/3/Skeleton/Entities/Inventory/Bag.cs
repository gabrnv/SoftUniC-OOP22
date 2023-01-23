using System;
using System.Collections.Generic;
using System.Linq;
using WarCroft.Constants;
using WarCroft.Entities.Items;

namespace WarCroft.Entities.Inventory
{
    public class Bag : IBag
    {
        private readonly List<Item> items;
        public Bag(int capacity = 100)
        {
            Capacity = capacity;
            items = new List<Item>();
        }
        public int Capacity { get; set; }
        public int Load => Items.Select(x => x.Weight).Sum();

        public IReadOnlyCollection<Item> Items
        {
            get
            {
                return items;
            }
        }

        public void AddItem(Item item)
        {
            if (Load + item.Weight > Capacity)
            {
                throw new InvalidOperationException(ExceptionMessages.ExceedMaximumBagCapacity);
            }
            items.Add(item);
            
        }

        public Item GetItem(string name)
        {
            if (!items.Any())
            {
                throw new InvalidOperationException(ExceptionMessages.EmptyBag);
            }
            Item item = items.FirstOrDefault(x => x.GetType().Name == name);
            if (item == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.ItemNotFoundInBag, name));
            }

            return item;

        }
    }
}