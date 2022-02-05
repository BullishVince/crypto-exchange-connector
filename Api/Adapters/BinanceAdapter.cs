using System.Threading.Tasks;
using System;
using System.Net;
using System.Net.Http;
using Binance.Common;
using Binance.Spot;
using Binance.Spot.Models;

namespace Api.Adapters {
    public interface IBinanceAdapter {
        Task<string> GetPurchases();
    }

    ///header X-MBX-APIKEY is used for sending in the apiKey
    public class BinanceAdapter : IBinanceAdapter {
        private HttpClient _httpClient;
        private readonly Fiat _fiatClient;

        public BinanceAdapter(string apiKey, string apiSecret) {
            _httpClient = new HttpClient();
            //_httpClient.DefaultRequestHeaders.Add("X-MBX-APIKEY", apiKey);
            _fiatClient = new Fiat(_httpClient, apiKey: apiKey, apiSecret: apiSecret);
        }

        public async Task<string> GetPurchases() 
            => await _fiatClient.GetFiatPaymentsHistory(FiatPaymentTransactionType.BUY, beginTime: DateTime.Today.AddYears(6).ToBinary());
    }
}