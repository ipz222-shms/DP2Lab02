using AbstractFactoryLibrary.Products.Interfaces;

namespace AbstractFactoryLibrary.Products;

public class PearPhone : ISmartphone
{
    public override string ToString() => "Pear Smartphone";
}
