using AbstractFactoryLibrary.Factories.Interfaces;
using AbstractFactoryLibrary.Products;
using AbstractFactoryLibrary.Products.Interfaces;

namespace AbstractFactoryLibrary.Factories;

public class PearFactory : ITechFactory
{
    public IEBook ProduceEBook() => new PearEBook();

    public ILaptop ProduceLaptop() => new PearLaptop();

    public INetbook ProduceNetbook() => new PearNetbook();

    public ISmartphone ProduceSmartphone() => new PearPhone();
    
    public override string ToString() => "Pear Factory";
}
