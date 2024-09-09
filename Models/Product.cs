namespace Models;

public class Product
{
    private string name;
    private int quantity;
    public int Quantity {
        get {return this.quantity;}
        set {this.quantity = value;}
    }
}
