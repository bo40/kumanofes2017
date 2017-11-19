using Kumanofes2017.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Kumanofes2017.Services
{
    public class InfoDataStore : IDataStore<InfoItem>
    {
        string HOST_NAME = "https://kumanofes2017json.herokuapp.com/";
        bool isInitialized;
        List<InfoItem> items;

        public async Task<bool> AddItemAsync(InfoItem item)
        {
            await InitializeAsync();

            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(InfoItem item)
        {
            await InitializeAsync();

            var _item = items.Where((InfoItem arg) => arg.Id == item.Id).FirstOrDefault();
            items.Remove(_item);
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(InfoItem item)
        {
            await InitializeAsync();

            var _item = items.Where((InfoItem arg) => arg.Id == item.Id).FirstOrDefault();
            items.Remove(_item);

            return await Task.FromResult(true);
        }

        public async Task<InfoItem> GetItemAsync(string id)
        {
            await InitializeAsync();

            return await Task.FromResult(items.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<InfoItem>> GetItemsAsync(string arg = "", bool forceRefresh = false)
        {
            await InitializeAsync();

            return await Task.FromResult(items);
        }

        public Task<bool> PullLatestAsync()
        {
            return Task.FromResult(true);
        }


        public Task<bool> SyncAsync()
        {
            return Task.FromResult(true);
        }

        public async Task InitializeAsync(string arg = "")
        {
            items = new List<InfoItem>();
            // TODO: ここにjsonですべての企画一覧を取得するコードを書く

            HttpClient client = new HttpClient();

            string json = await client.GetStringAsync(HOST_NAME + "info");
            var data = JsonConvert.DeserializeObject<List<InfoItem>>(json);

            foreach (InfoItem item in data)
            {
                items.Add(item);
            }
            isInitialized = true;
        }
    }
}