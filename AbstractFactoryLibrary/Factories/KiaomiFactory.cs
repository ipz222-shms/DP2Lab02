using AbstractFactoryLibrary.Factories.Interfaces;
using AbstractFactoryLibrary.Products;
using AbstractFactoryLibrary.Products.Interfaces;

namespace AbstractFactoryLibrary.Factories;

public class KiaomiFactory : ITechFactory
{
    public IEBook ProduceEBook() => new KiaomiEBook();

    public ILaptop ProduceLaptop() => new KiaomiLaptop();

    public INetbook ProduceNetbook() => new KiaomiNetbook();

    public ISmartphone ProduceSmartphone() => new KiaomiPhone();
    
    public override string ToString() => "Kiaomi Factory";
}
