namespace Api.Models.Binance;
public class FiatPayments {
    public string Code { get; set; }
    public string Message { get; set; }
    public Purchase[] Data { get; set; }
}