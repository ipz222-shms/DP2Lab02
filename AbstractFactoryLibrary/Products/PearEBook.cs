using AbstractFactoryLibrary.Products.Interfaces;

namespace AbstractFactoryLibrary.Products;

public class PearEBook : IEBook
{
    public override string ToString() => "Pear EBook";
}
