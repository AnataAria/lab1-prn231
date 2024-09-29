namespace Models.Dto;

public class ProductDto {
    public string ProductName {get; set;}
    public int CategoryId {get; set;}
    public int UnitsInStock {get; set;}
    public decimal UnitPrice {get; set;}
}