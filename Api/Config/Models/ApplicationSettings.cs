public class ApplicationSettings {
    public bool UseMocks { get; set; }
    public ApiSettings CoinbaseSettings { get; set; }
    public ApiSettings BinanceSettings { get; set; }
    public ApiSettings FreeCurrencyApiSettings { get; set; }
}

public class ApiSettings {
    public string ApiKey { get; set; }
    public string ApiSecret { get; set; }
}