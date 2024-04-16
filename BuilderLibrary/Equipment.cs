using BuilderLibrary.Interfaces;

namespace BuilderLibrary;

public class Equipment : Item, IEquipment
{
    public Equipment()
    {
    }

    private Equipment(Equipment equipment) : base(equipment)
    {
    }
    
    public void Equip()
    {
        if (IsEquipped()) return;
        
        Owner._equipments.Add(this);
        if (Owner._inventory[(Item)this] == 1)
            Owner._inventory.Remove(this);
        else
            Owner._inventory[this]--;
    }

    public void TakeOff()
    {
        if (!IsEquipped()) return;

        Owner._equipments.Remove(this);
        if (Owner._inventory.ContainsKey(this))
            Owner._inventory[this]++;
        else
            Owner._inventory.Add(this, 1);
    }

    public bool IsEquipped() => Owner._equipments.Contains(this);

    public bool IsOwner(Character character) => Owner == character;
    
    public new object Clone() => new Equipment(this);
}
