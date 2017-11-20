using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Kumanofes2017.Models;

[assembly: Dependency(typeof(Kumanofes2017.Services.DateDataStore))]
namespace Kumanofes2017.Services
{
    public class DateDataStore : IDataStore<DateItem>
    {
        bool isInitialized;
        List<DateItem> items;

        public async Task<bool> AddItemAsync(DateItem item)
        {
            await InitializeAsync();

            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(DateItem item)
        {
            await InitializeAsync();

            var _item = items.Where((DateItem arg) => arg.Id == item.Id).FirstOrDefault();
            items.Remove(_item);
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(DateItem item)
        {
            await InitializeAsync();

            var _item = items.Where((DateItem arg) => arg.Id == item.Id).FirstOrDefault();
            items.Remove(_item);

            return await Task.FromResult(true);
        }

        public async Task<DateItem> GetItemAsync(string id)
        {
            await InitializeAsync();

            return await Task.FromResult(items.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<DateItem>> GetItemsAsync(string arg = "", bool forceRefresh = false)
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
            if (isInitialized)
                return;

            items = new List<DateItem>();
            var _items = new List<DateItem>
            {
                new DateItem{ Id = "permanent", Description = "常設企画" },
                new DateItem{ Id = "guerrilla", Description = "ゲリラ企画" },
                new DateItem{ Id = "1129", Description = "2017/11/29(水)" },
                new DateItem{ Id = "1130", Description = "2017/11/30(木)" },
                new DateItem{ Id = "1201", Description = "2017/12/01(金)" },
                new DateItem{ Id = "1202", Description = "2017/12/02(土)" },
                new DateItem{ Id = "1203", Description = "2017/12/03(日)" },
                new DateItem{ Id = "1204", Description = "2017/12/04(月)" },
                new DateItem{ Id = "1205", Description = "2017/12/05(火)" },
                new DateItem{ Id = "1206", Description = "2017/12/06(水)" },
                new DateItem{ Id = "1207", Description = "2017/12/07(木)" },
                new DateItem{ Id = "1208", Description = "2017/12/08(金)" },
                new DateItem{ Id = "1209", Description = "2017/12/09(土)" },
                new DateItem{ Id = "1210", Description = "2017/12/10(日)" },
            };

            foreach (DateItem item in _items)
            {
                items.Add(item);
            }

            isInitialized = true;
        }
    }
}
