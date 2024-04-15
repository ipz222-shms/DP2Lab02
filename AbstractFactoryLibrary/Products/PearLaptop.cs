using AbstractFactoryLibrary.Products.Interfaces;

namespace AbstractFactoryLibrary.Products;

public class PearLaptop : ILaptop
{
    public override string ToString() => "Pear Laptop";
}
