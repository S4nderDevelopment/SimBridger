namespace SimBridger.RbrNgp;

[AttributeUsage(AttributeTargets.Field)]
internal sealed class NgpChannelAttribute(string name) : Attribute
{
    public string Name { get; } = name;
}
