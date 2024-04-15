using AbstractFactoryLibrary.Products.Interfaces;

namespace AbstractFactoryLibrary.Factories.Interfaces;

public interface ITechFactory
{
    public IEBook ProduceEBook();
    public ILaptop ProduceLaptop();
    public INetbook ProduceNetbook();
    public ISmartphone ProduceSmartphone();
}
