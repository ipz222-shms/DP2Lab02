using System.Text;

namespace PrototypeLibrary;

public class Virus : IClone
{
    private readonly HashSet<Virus> _children;
    
    public string Name { get; set; }
    public string Type { get; }
    public double Weight { get; set; }
    public int Age { get; set; }

    public Virus(string name, string type, double weight, int age)
    {
        _children = new HashSet<Virus>();
        Name = name;
        Type = type;
        Weight = weight;
        Age = age;
    }

    public Virus(Virus virus) : this(virus.Name, virus.Type, virus.Weight, virus.Age)
    {
        foreach (var child in virus._children) 
            _ = _children.Add((Virus)child.Clone());
    }

    public bool AddChild(Virus child) => _children.Add(child);

    public bool RemoveChild(Virus child) => _children.Remove(child);

    public IEnumerable<Virus> GetChildren() => new List<Virus>(_children);

    public IClone Clone() => new Virus(this);

    public override string ToString()
    {
        StringBuilder sb = new($"Virus {Name} ({Type}): Age: {Age} years, Weight: {Math.Round(Weight, 5)} attogram, Children: ");

        if (_children.Any())
        {
            sb.Append("[\n");
            var i = 1;
            foreach (var child in _children)
                sb.Append($"Child #{i++}: {child}");
            sb.Append("\n]");
        }
        else
            sb.Append("None");

        return sb.ToString();
    }
}
