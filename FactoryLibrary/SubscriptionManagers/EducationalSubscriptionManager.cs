using FactoryLibrary.Interfaces;
using FactoryLibrary.Subscriptions;

namespace FactoryLibrary.SubscriptionManagers;

public class EducationalSubscriptionManager : SubscriptionManager
{
    public override int MinimalPeriod { get; set; } = 90;
    public static readonly List<string> AvailableChannels = new()
    {
        "Discovery", "Animal Planet", "Science Channel", "History Channel"
    };
    
    public override ISubscription BuySubscription(int periodDays)
    {
        if (periodDays < this.MinimalPeriod)
            throw new ArgumentException($"Minimal period for Educational subscription is {this.MinimalPeriod} days!");
        
        ISubscription subscription = new EducationalSubscription();
        subscription.Expires = DateTime.Now.AddDays(periodDays);
        subscription.Price = Math.Round(this.MinimalPeriod / subscription.Price * periodDays, 2);
        subscription.AddChannel(EducationalSubscriptionManager.AvailableChannels);
        
        return subscription;
    }
}
