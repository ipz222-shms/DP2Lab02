using FactoryLibrary.Interfaces;
using FactoryLibrary.SubscriptionManagers;
using FactoryLibrary.Vendors.enums;

namespace FactoryLibrary.Vendors;

public class ManagerCall
{
    private SubscriptionManager? _selectedSubscription;
    private int _selectedPeriod;
    
    public void AcceptCall()
    {
        // Welcome user
        // Verify user's credentials
    }

    public void AskForSubscriptionType(SubscriptionType type)
    {
        // Instead of type param directly get type inside
        
        _selectedSubscription = type switch
        {
            SubscriptionType.Domestic => new DomesticSubscriptionManager(),
            SubscriptionType.Educational => new EducationalSubscriptionManager(),
            SubscriptionType.Premium => new PremiumSubscriptionManager(),
            _ => throw new NotImplementedException("Unknown type of subscription!")
        };
    }

    public void AskForPeriod(int periodDays)
    {
        // Instead of periodDays param directly get amount inside
        
        if (periodDays < _selectedSubscription.MinimalPeriod)
            throw new ArgumentException($"Minimal period for Educational subscription is {_selectedSubscription.MinimalPeriod} days!");

        _selectedPeriod = periodDays;
    }

    public ISubscription ConfirmPurchase()
        => _selectedSubscription.BuySubscription(_selectedPeriod);
}
