using FactoryLibrary.Interfaces;
using FactoryLibrary.Subscriptions;

namespace FactoryLibrary.SubscriptionManagers;

public class DomesticSubscriptionManager : SubscriptionManager
{
    public override int MinimalPeriod { get; set; } = 30;
    public static readonly List<string> AvailableChannels = new()
    {
        "CBC News", "CNN", "Link TV", "Free Speech TV"
    };
    
    public override ISubscription BuySubscription(int periodDays)
    {
        if (periodDays < this.MinimalPeriod)
            throw new ArgumentException($"Minimal period for Domestic subscription is {this.MinimalPeriod} days!");
        
        ISubscription subscription = new DomesticSubscription();
        subscription.Expires = DateTime.Now.AddDays(periodDays);
        subscription.Price = Math.Round(this.MinimalPeriod / subscription.Price * periodDays, 2);
        subscription.AddChannel(DomesticSubscriptionManager.AvailableChannels);
        
        return subscription;
    }
}
