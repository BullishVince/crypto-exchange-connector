using Api.Models;
using Newtonsoft.Json;

namespace Api.Adapters;

public interface ILocalDataAdapter {
    public Task<Ticker[]>? GetCachedTickers();
}

public class LocalDataAdapter : ILocalDataAdapter
{
    public async Task<Ticker[]>? GetCachedTickers()
    {
        Ticker[] tickerList = {};
        try {
            byte[] result;
            using (FileStream fs = File.Open("Data/binance_tickers.json", FileMode.Open))
            {
                result = new byte[fs.Length];
                await fs.ReadAsync(result, 0, (int)fs.Length);
            }
            tickerList = JsonConvert.DeserializeObject<Ticker[]>(System.Text.Encoding.ASCII.GetString(result));
        } catch (FileNotFoundException) {
        }
        return tickerList;
    }
}