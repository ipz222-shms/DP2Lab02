using FactoryLibrary.Interfaces;

namespace FactoryLibrary.SubscriptionManagers;

public abstract class SubscriptionManager
{
    public abstract int MinimalPeriod { get; set; }
    public abstract ISubscription BuySubscription(int periodDays);
}
