using Api.Adapters;
using Api.Models;

namespace Api.Services;

public interface IDataService {
    public Task<Ticker[]> GetCachedTickers();
}

public class DataService : IDataService
{
    private ILocalDataAdapter _adapter { get; set; }
    public DataService(ILocalDataAdapter adapter) {
        _adapter = adapter;
    }
    public async Task<Ticker[]> GetCachedTickers()
    {
        return await _adapter.GetCachedTickers();
    }
}