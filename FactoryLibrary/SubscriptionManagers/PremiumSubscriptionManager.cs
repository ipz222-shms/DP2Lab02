using FactoryLibrary.Interfaces;
using FactoryLibrary.Subscriptions;

namespace FactoryLibrary.SubscriptionManagers;

public class PremiumSubscriptionManager : SubscriptionManager
{
    public override int MinimalPeriod { get; set; } = 31;
    public static readonly List<string> AvailableChannels = new()
    {
        "TLC", "True Crime Network", "Motor Trend", "Comet", "TNT", "HDNet Movies", "Sony Movies", "MTV Live",
        "Cartoon Network", "Adult Swim", "NBA League Pass", "Sportsman Channel"
    };
    
    public override ISubscription BuySubscription(int periodDays)
    {
        if (periodDays < this.MinimalPeriod)
            throw new ArgumentException($"Minimal period for Educational subscription is {this.MinimalPeriod} days!");

        ISubscription subscription = new PremiumSubscription();
        subscription.Expires = DateTime.Now.AddDays(periodDays);
        subscription.Price = Math.Round(this.MinimalPeriod / subscription.Price * periodDays, 2);
        subscription.AddChannel(PremiumSubscriptionManager.AvailableChannels);
        
        return subscription;
    }
}
