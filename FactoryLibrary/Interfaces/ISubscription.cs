namespace FactoryLibrary.Interfaces;

public interface ISubscription
{
    public decimal Price { get; set; }
    public DateTime Expires { get; set; }
    public IEnumerable<string> Channels { get; set; }

    public bool IsExpired => DateTime.Now > Expires;

    public void AddChannel(string channel)
    {
        if (!Channels.Contains(channel))
            _ = this.Channels.Append(channel);
    }

    public void AddChannel(IEnumerable<string> channels)
        => this.Channels = this.Channels.Concat(channels.Except(this.Channels));

    public void RemoveChannel(string channel)
    {
        var list = this.Channels.ToList();
        list.Remove(channel);
        this.Channels = list;
    }

    public void RemoveChannel(IEnumerable<string> channels)
        => this.Channels = this.Channels.Except(channels);
}
