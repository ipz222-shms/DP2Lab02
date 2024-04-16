using BuilderLibrary.Interfaces;

namespace BuilderLibrary;

public class Item : ICloneable
{
    internal Character? Owner { get; set; }
    public string Name { get; set; } = "Unknown";
    public string Description { get; set; } = string.Empty;

    public Item()
    {
    }
    
    protected internal Item(Item item)
    {
        Owner = item.Owner;
        Name = item.Name;
        Description = item.Description;
    }

    public object Clone() => new Item(this);

    public override int GetHashCode() => Name.GetHashCode();
    public override bool Equals(object? obj) => obj.GetHashCode().Equals(GetHashCode());

    public override string ToString() => Name;
}
