using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Kumanofes2017.Models;

using Xamarin.Forms;
using System.Net.Http;
using Newtonsoft.Json;

[assembly: Dependency(typeof(Kumanofes2017.Services.MockDataStore))]
namespace Kumanofes2017.Services
{
	public class MockDataStore : IDataStore<Item>
	{
        string HOST_NAME = "https://kumanofes2017json.herokuapp.com/";
		bool isInitialized;
		List<Item> items;

		public async Task<bool> AddItemAsync(Item item)
		{
			await InitializeAsync();

			items.Add(item);

			return await Task.FromResult(true);
		}

		public async Task<bool> UpdateItemAsync(Item item)
		{
			await InitializeAsync();

			var _item = items.Where((Item arg) => arg.Id == item.Id).FirstOrDefault();
			items.Remove(_item);
			items.Add(item);

			return await Task.FromResult(true);
		}

		public async Task<bool> DeleteItemAsync(Item item)
		{
			await InitializeAsync();

			var _item = items.Where((Item arg) => arg.Id == item.Id).FirstOrDefault();
			items.Remove(_item);

			return await Task.FromResult(true);
		}

		public async Task<Item> GetItemAsync(string id)
		{
			await InitializeAsync();

			return await Task.FromResult(items.FirstOrDefault(s => s.Id == id));
		}

		public async Task<IEnumerable<Item>> GetItemsAsync(string arg = "", bool forceRefresh = false)
		{
			await InitializeAsync(arg);
            if (arg == "permanent")
            {
                return await Task.FromResult(items.Where((Item item) => item.Type == arg));
            }
            else if (arg == "guerrilla")
            {
                return await Task.FromResult(items.Where((Item item) => item.Type == arg));
            }
            else if (arg != "")
            {
                return await Task.FromResult(items.Where((Item item) => item.DateId == arg));
            }
            else
            {
                return await Task.FromResult(items);
            }
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
			if (isInitialized)
				return;

			items = new List<Item>();
            // TODO: ここにjsonですべての企画一覧を取得するコードを書く
            
            HttpClient client = new HttpClient();
            
            string json = await client.GetStringAsync(HOST_NAME + "list");
            var data = JsonConvert.DeserializeObject<List<Item>>(json);

            foreach (Item item in data)
            {
                items.Add(item);
            }

            /*
            var _items = new List<Item>
            {
                new Item { Id = Guid.NewGuid().ToString(),
                    Text = "Buy some cat food",
                    Description ="The cats are hungry",
                    DateId = "1129",
                    Start = "11/29" + " 10:00",
                    End = "11/29" + " 11:00",
                    Place = "食堂",
                    ImagePath = "avalon.jpg",
                },
                new Item { Id = Guid.NewGuid().ToString(),
                    Text = "Learn F#",
                    Description ="Seems like a functional idea",
                    DateId = "1129",
                    Start = "11/29" + " 10:00",
                    End = "11/29" + " 11:00",
                    Place = "食堂",
                    ImagePath = "a.png",
                },
                new Item { Id = Guid.NewGuid().ToString(),
                    Text = "Learn to play guitar",
                    Description ="Noted",
                    DateId = "1201",
                    Start = "12/01" + " 10:00",
                    End = "12/01" + " 11:00",
                    Place = "民生池",
                    ImagePath = "a.png",
                },
				new Item { Id = Guid.NewGuid().ToString(),
                    Text = "Buy some new candles",
                    Description ="Pine and cranberry for that winter feel.odsa;jfjk;Pine and cranberry for that winter feel.",
                    DateId = "1202",
                    Start = "12/02" + " 10:00",
                    End = "12/02" + " 11:00",
                    Place = "ロビー",
                    ImagePath = "a.png",
                },
				new Item { Id = Guid.NewGuid().ToString(),
                    Text = "Complete holiday shopping",
                    Description ="Keep it a secret!",
                    DateId = "1203",
                    Start = "12/03" + " 10:00",
                    End = "12/03" + " 11:00",
                    Place = "ビリヤード周辺",
                    ImagePath = "a.png",
                },
				new Item { Id = Guid.NewGuid().ToString(),
                    Text = "Finish a todo list",
                    Description ="Done",
                    DateId = "1210",
                    Start = "12/10" + " 10:00",
                    End = "12/10" + " 11:00",
                    Place = "寮外",
                    ImagePath = "a.png",
                },
			};

			foreach (Item item in _items)
			{
				items.Add(item);
			}
            */

            // ------------------------------------------

			isInitialized = true;
		}
	}
}
