namespace Data.Entities;

public class Order
{
    public enum State
    {
        WaitingConfirmation,
        Confirmed,
        Packing,
        Shipping,
        Completed
    }

    public int Id { get; set; }
    public User User { get; set; }
    public List<Product> Products { get; set; }
    public DateTime DateCreated { get; set; }
    public State Status { get; set; }

    public Order()
    {
        Products = new List<Product>();
    }
}