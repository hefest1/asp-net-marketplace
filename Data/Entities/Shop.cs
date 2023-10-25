namespace Data.Entities;

public class Shop
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public User Owner { get; set; }
    public List<Product> Products { get; set; }
    public Image Logo { get; set; }

    public Shop()
    {
        Products = new List<Product>();
    }
}