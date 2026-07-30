namespace MyProductApp.Domain.Entities;

public class Product
{
    public Guid Id { get; private set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; private set; } = string.Empty;
    public decimal Price { get; private set; }
    public DateTime CreatedAt { get; private set; }

    protected Product(){}

    public Product(string name, decimal price, string description)
    {
        if(string.IsNullOrWhiteSpace(name)) throw new ArgumentException("Name is required", nameof(name));
        if(price < 0) throw new ArgumentException("Price must be >= 0", nameof(price));

        Id = Guid.NewGuid();
        Name = name;
        Price = price;
        Description = description;
    }

    public void UpdatePrice(decimal newPrice)
    {
        if(newPrice < 0) throw new ArgumentException("Price must be >= 0");
        Price = newPrice;
    }
    public void UpdateName(string name)
    {
        if (string.IsNullOrWhiteSpace(name)) throw new ArgumentException("Name is required.");
        Name = name;
    }
}