using System.Collections.Generic;
using System.Threading.Tasks;

namespace Kumanofes2017.Services
{
	public interface IDataStore<T>
	{
		Task<bool> AddItemAsync(T item);
		Task<bool> UpdateItemAsync(T item);
		Task<bool> DeleteItemAsync(T item);
		Task<T> GetItemAsync(string id);
		Task<IEnumerable<T>> GetItemsAsync(string arg = "", bool forceRefresh = false);

		Task InitializeAsync(string arg = "");
		Task<bool> PullLatestAsync();
		Task<bool> SyncAsync();
	}
}
