namespace BuilderLibrary.Interfaces;

public interface IEquipment
{
    public void Equip();
    public void TakeOff();
    public bool IsEquipped();
    public bool IsOwner(Character character);
}
