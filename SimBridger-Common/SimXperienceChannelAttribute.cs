namespace SimBridger.Common;

[AttributeUsage(AttributeTargets.Field)]
public sealed class SimXperienceChannelAttribute(string name, float scale = 1.0f) : Attribute
{
    public string Name { get; } = name;
    public float Scale { get; } = scale;
}
