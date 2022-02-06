namespace Api.Models.Binance;
public class Purchase {
    public string OrderNumber { get; set; }
    public decimal SourceAmount { get; set; }
    public string FiatCurrency { get; set; }
    public decimal ObtainAmount { get; set; }
    public string CryptoCurrency { get; set; }
    public decimal TotalFee { get; set; }
    public decimal Price { get; set; }
    public string Status { get; set; }
    public string CreateTime { get; set; }
    public string UpdateTime { get; set; }
}