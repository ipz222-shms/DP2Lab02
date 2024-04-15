using AbstractFactoryLibrary.Factories.Interfaces;
using AbstractFactoryLibrary.Products;
using AbstractFactoryLibrary.Products.Interfaces;

namespace AbstractFactoryLibrary.Factories;

public class BalaxyFactory : ITechFactory
{
    public IEBook ProduceEBook() => new BalaxyEBook();

    public ILaptop ProduceLaptop() => new BalaxyLaptop();

    public INetbook ProduceNetbook() => new BalaxyNetbook();

    public ISmartphone ProduceSmartphone() => new BalaxyPhone();

    public override string ToString() => "Balaxy Factory";
}
