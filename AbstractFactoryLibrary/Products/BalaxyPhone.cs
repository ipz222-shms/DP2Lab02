using AbstractFactoryLibrary.Products.Interfaces;

namespace AbstractFactoryLibrary.Products;

public class BalaxyPhone : ISmartphone
{
    public override string ToString() => "Balaxy Smartphone";
}
