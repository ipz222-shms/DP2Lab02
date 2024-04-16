using BuilderLibrary.Interfaces;

namespace BuilderLibrary;

public class HeroBuilder : ICharacterBuilder
{
    private Character _character;

    public HeroBuilder() => Reset();
    
    private void Reset() => _character = new Character();

    public ICharacterBuilder DoGood(string goodThing)
    {
        _character.AddAction(goodThing);
        return this;
    }

    public Character GetCharacter()
    {
        var character = _character;
        Reset();
        character.SetType("Hero");
        return character;
    }
    
    public ICharacterBuilder Name(string name)
    {
        _character.SetName(name);
        return this;
    }

    public ICharacterBuilder Sex(string sex)
    {
        _character.SetSex(sex);
        return this;
    }
    
    public ICharacterBuilder Height(double height)
    {
        if (height <= 0) return this;
        _character.SetHeight(height);
        return this;
    }
    
    public ICharacterBuilder Weight(double weight)
    {
        if (weight <= 0) return this;
        _character.SetWeight(weight);
        return this;
    }

    public ICharacterBuilder BodyType(string bodyType)
    {
        _character.SetBodyType(bodyType);
        return this;
    }

    public ICharacterBuilder Eyes(string color)
    {
        _character.SetEyes(color);
        return this;
    }

    public ICharacterBuilder Hair(string color)
    {
        _character.SetHair(color);
        return this;
    }
    
    public ICharacterBuilder AddItems(Dictionary<Item, int> items)
    {
        foreach (var (item, count) in items)
            _ = _character.AddItem(item, count);
        return this;
    }
    
    public ICharacterBuilder EquipItems(IEnumerable<Equipment> items)
    {
        foreach (var item in items)
        {
            var i = item.Clone() as Equipment;
            i.Owner = _character;
            _character.EquipItem(i);
        }
        return this;
    }
}
