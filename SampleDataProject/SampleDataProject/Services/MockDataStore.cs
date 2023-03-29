using Newtonsoft.Json;
using SampleDataProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace SampleDataProject.Services
{
    public class MockDataStore : IDataStore
    {
        private readonly List<Datum> items;
       
        private const string url = "https://reqres.in/api/users";

        private HttpClient _client = new HttpClient();
        public MockDataStore()
        {
           
        }       
        public async Task<Datum> GetItemAsync(string id)
        {
            return await Task.FromResult(items.FirstOrDefault(s=>s.Id.ToString()==id));
        }

        public async Task<Item> GetItemsAsync(bool forceRefresh = false)
        {
            var content = await _client.GetStringAsync(url);
            Item uList = JsonConvert.DeserializeObject<Item>(content);
           
            return uList;
        }
       
    }
}