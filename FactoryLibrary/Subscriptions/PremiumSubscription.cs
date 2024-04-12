using FactoryLibrary.Interfaces;

namespace FactoryLibrary.Subscriptions;

public class PremiumSubscription : ISubscription
{
    public decimal Price { get; set; } = 24.99m;
    public DateTime Expires { get; set; }
    public IEnumerable<string> Channels { get; set; } = new List<string>();

    public override string ToString()
        => $"Premium Subscription:\n\tPrice: ${Price}" +
           $"\n\tExpires: {Expires:f} ({(((ISubscription)this).IsExpired ? "Expired" : "Valid")})" +
           $"\n\tChannels: {string.Join(", ", this.Channels)}";
}