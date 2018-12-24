using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBook
{
    public class MockDataStore : IDataStore<Item>
    {
        List<Item> items;

        public MockDataStore()
        {
            items = new List<Item>();
            var _items = new List<Item>
            {
                new Item { Isbn13 = Guid.NewGuid().ToString(), Title = "First item", Subtitle ="This is a nice description"},
                new Item { Isbn13 = Guid.NewGuid().ToString(), Title = "Second item", Subtitle="This is a nice description"},
                new Item { Isbn13 = Guid.NewGuid().ToString(), Title = "Third item", Subtitle="This is a nice description"},
                new Item { Isbn13 = Guid.NewGuid().ToString(), Title = "Fourth item", Subtitle="This is a nice description"},
                new Item { Isbn13 = Guid.NewGuid().ToString(), Title = "Fifth item", Subtitle="This is a nice description"},
                new Item { Isbn13 = Guid.NewGuid().ToString(), Title = "Sixth item", Subtitle="This is a nice description" },
            };

            foreach (Item item in _items)
            {
                items.Add(item);
            }
        }

        public async Task<IEnumerable<Item>> GetItemsAsync(string query)
        {
            return await Task.FromResult(items);
        }
    }
}
