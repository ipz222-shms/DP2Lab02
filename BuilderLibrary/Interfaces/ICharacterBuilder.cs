namespace BuilderLibrary.Interfaces;

public interface ICharacterBuilder
{
    public ICharacterBuilder Name(string name);
    public ICharacterBuilder Sex(string sex);
    public ICharacterBuilder Height(double height);
    public ICharacterBuilder Weight(double weight);
    public ICharacterBuilder BodyType(string bodyType);
    public ICharacterBuilder Eyes(string color);
    public ICharacterBuilder Hair(string color);
    public ICharacterBuilder AddItems(Dictionary<Item, int> items);
    public ICharacterBuilder EquipItems(IEnumerable<Equipment> items);
    public Character GetCharacter();
}
