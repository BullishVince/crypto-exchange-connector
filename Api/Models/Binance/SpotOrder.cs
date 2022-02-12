namespace Api.Models.Binance;

public class SpotOrder {
    public string Symbol { get; set; }
    public string OrderId { get; set; }
    public decimal Price { get; set; }
    public decimal OrigQty { get; set; }
    public decimal ExecutedQty { get; set; }
    public string Type { get; set; }
    public string Side { get; set; }
    public string Time { get; set; }
    public string UpdateTime { get; set; }
}