using FactoryLibrary.Interfaces;
using FactoryLibrary.SubscriptionManagers;
using FactoryLibrary.Vendors.enums;

namespace FactoryLibrary.Vendors;

public class MobileApp
{
    private SubscriptionManager? _selectedSubscription;
    private int _enteredPeriod;

    public void SelectSubscription(SubscriptionType type)
    {
        _selectedSubscription = type switch
        {
            SubscriptionType.Domestic => new DomesticSubscriptionManager(),
            SubscriptionType.Educational => new EducationalSubscriptionManager(),
            SubscriptionType.Premium => new PremiumSubscriptionManager(),
            _ => throw new NotImplementedException("Unknown type of subscription!")
        };

        // Show next dialog for input
        // this.AskForPeriod(); 
    }

    public void AskForPeriod(int periodDays)
    {
        // Show dialog and get input instead of periodDays param
        if (periodDays < _selectedSubscription.MinimalPeriod)
            throw new ArgumentException($"Minimal period for Educational subscription is {_selectedSubscription.MinimalPeriod} days!");
        
        _enteredPeriod = periodDays;
    }

    public ISubscription ConfirmSubscriptionPurchase()
        => _selectedSubscription.BuySubscription(_enteredPeriod);
}