namespace Data.Entities;

public class Comment
{
    public int Id { get; set; }
    public Product Product { get; set; }
    public DateTime DateCreated { get; set; }
    public User Author { get; set; }
    public string Text { get; set; }
    public List<Image> Images { get; set; }
}