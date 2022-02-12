namespace Api.Models.CrossAccounting;

public class FiatTransaction {
    public string Broker { get; set; }
    public string Status { get; set; }
    public string OrderId { get; set; }
    public string FiatCurrency { get; set; }
    public string CryptoCurrency { get; set; }
    public decimal FiatAmount { get; set; }
    public decimal CryptoAmount { get; set; }
    public decimal Fee { get; set; }
    public string FeeCurrency { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}