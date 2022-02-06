namespace Api.Adapters
{
    public interface IFreeCurrencyApiAdapter{

    }

    public class FreeCurrencyApiAdapter : IFreeCurrencyApiAdapter {
        private HttpClient _httpClient;
        public FreeCurrencyApiAdapter(string apiKey, string apiSecret) {
            _httpClient = new HttpClient();
        }
    }
}