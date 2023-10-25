namespace Data.Entities;

public class Category
{
    public int Id { get; set; }
    public string Name { get; set; }
    public List<Category> Childs { get; set; }
    public Category? Parent { get; set; }

    public Category()
    {
        Childs = new List<Category>();
    }
}