using AbstractFactoryLibrary.Products.Interfaces;

namespace AbstractFactoryLibrary.Products;

public class PearNetbook : INetbook
{
    public override string ToString() => "Pear Netbook";
}
