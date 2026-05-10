namespace SimBridger.Main;

[AttributeUsage(AttributeTargets.Field)]
internal sealed class SimXperienceChannelAttribute(string name, float scale = 1.0f) : Attribute
{
    public string Name { get; } = name;
    public float Scale { get; } = scale;
}
