using FactoryLibrary.Interfaces;
using FactoryLibrary.SubscriptionManagers;

namespace FactoryLibrary.Vendors;

public class WebSite
{
    public ISubscription DomesticSubscriptionFormSubmit(int days)
    {
        SubscriptionManager manager = new DomesticSubscriptionManager();
        return manager.BuySubscription(days);
    }
    
    public ISubscription EducationalSubscriptionFormSubmit(int days)
    {
        SubscriptionManager manager = new EducationalSubscriptionManager();
        return manager.BuySubscription(days);
    }
    
    public ISubscription PremiumSubscriptionFormSubmit(int days)
    {
        SubscriptionManager manager = new PremiumSubscriptionManager();
        return manager.BuySubscription(days);
    }
}
