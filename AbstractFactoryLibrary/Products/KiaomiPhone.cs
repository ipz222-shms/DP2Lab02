using AbstractFactoryLibrary.Products.Interfaces;

namespace AbstractFactoryLibrary.Products;

public class KiaomiPhone : ISmartphone
{
    public override string ToString() => "Kiaomi Smartphone";
}
