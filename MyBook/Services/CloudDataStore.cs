using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using MyBook.Models;
using Newtonsoft.Json;
using Plugin.Connectivity;

namespace MyBook
{
    public class CloudDataStore : IDataStore<Item>
    {
        HttpClient client;
        IEnumerable<Item> items;

        public CloudDataStore()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri($"{App.BackendUrl}/");

            items = new List<Item>();
        }

        public async Task<IEnumerable<Item>> GetItemsAsync(string query)
        {
            if (!string.IsNullOrEmpty(query) && CrossConnectivity.Current.IsConnected)
            {
                var json = await client.GetStringAsync($"{Utils.Util.SearchUriRequest}/{query}");
                BookResponse response = await Task.Run(() => JsonConvert.DeserializeObject<BookResponse>(json));
                items = response.Books;
            }

            return items;
        }
    }
}
