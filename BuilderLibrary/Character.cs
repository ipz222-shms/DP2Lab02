using System.Text;
using BuilderLibrary.Interfaces;

namespace BuilderLibrary;

public class Character
{
    private string? _type;
    private string? _name;
    private string? _sex;
    private double? _height;
    private double? _weight;
    private string? _bodyType;
    private string? _eyesColor;
    private string? _hairColor;
    internal HashSet<Equipment> _equipments = new();
    internal Dictionary<Item, int> _inventory = new();
    private readonly List<string> _actions = new();
    
    internal void SetType(string type) => _type = type;
    internal void SetName(string name) => _name = name;
    internal void SetSex(string sex) => _sex = sex;
    internal void SetHeight(double height) => _height = height;
    internal void SetWeight(double weight) => _weight = weight;
    internal void SetBodyType(string bodyType) => _bodyType = bodyType;
    internal void SetEyes(string color) => _eyesColor = color;
    internal void SetHair(string color) => _hairColor = color;
    internal void AddAction(string action) => _actions.Add(action);

    public IEnumerable<Equipment> GetEquipments() => new List<Equipment>(_equipments);
    public Dictionary<Item, int> GetInventory() => new(_inventory);
    public IEnumerable<string> GetActions() => new List<string>(_actions);
    
    public void EquipItem(Equipment item)
    {
        if (item.IsOwner(this))
            item.Equip();
    }

    public void TakeOffItem(Equipment item)
    {
        if (item.IsOwner(this))
            item.TakeOff();
    }

    public bool AddItem(Item item, int count = 1)
    {
        if (count < 1) return false;
        
        if (_inventory.ContainsKey(item))
            _inventory[item] += count;
        else
        {
            var cloned = item.Clone() as Item;
            cloned.Owner = this;
            _inventory.Add(cloned, count);
        }

        return true;
    }

    public bool RemoveItem(Item item, int count = 1)
    {
        if (count < 1 || !_inventory.ContainsKey(item))
            return false;
        
        if (_inventory[item] <= count)
            _inventory.Remove(item);
        else
            _inventory[item] -= count;
            
        return true;
    }

    public override string ToString()
    {
        StringBuilder sb = new($"[{_type.ToUpper()}] {_name}");
        if (_sex is not null)
            sb.Append($"\n\tSex: {_sex}");
        if (_height is not null)
            sb.Append($"\n\tHeight: {_height}");
        if (_weight is not null)
            sb.Append($"\n\tWeight: {_weight}");
        if (_bodyType is not null)
            sb.Append($"\n\tBody type: {_bodyType}");
        if (_eyesColor is not null)
            sb.Append($"\n\tEyes: {_eyesColor}");
        if (_hairColor is not null)
            sb.Append($"\n\tHair: {_hairColor}");
        if (_actions.Any())
            sb.Append($"\n\tActions: {string.Join(", ", _actions)}");
        if (_equipments.Any())
        {
            sb.Append("\n\tEquipments:");
            foreach (Item equipment in _equipments)
                sb.Append($"\n\t\t{equipment}");
        }
        if (_inventory.Any())
        {
            sb.Append("\n\tInventory:");
            foreach (var (item, count) in _inventory)
                sb.Append($"\n\t\t{item}: x{count}");
        }
        return sb.ToString();
    }
}
