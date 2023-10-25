namespace Data.Entities;

public class Product
{
    public int ID { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public double Price { get; set; }
    public DateTime CreatedDate { get; set; }
    public Shop Shop { get; set; }
    public Category Category { get; set; }
    public List<Image> Images { get; set; }
    public Image MainImage { get; set; }
    public List<Comment> Comments { get; set; }

    public Product()
    {
        Name = string.Empty;
        Description = string.Empty;
        Comments = new List<Comment>();
    }
}