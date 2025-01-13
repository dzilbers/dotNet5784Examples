namespace Attributes;

/// <summary>
/// This constructor defines two required parameters: name and level.
/// <summary>
[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true)]
public class DeveloperAttribute(string name, int level) : Attribute
{
    // Private fields.
    private readonly string _name = name;
    private readonly int _level = level;
    private bool _reviewed = false;

    /// <summary>
    /// Define Name property.
    /// This is a read-only attribute.
    /// </summary>
    public string Name => _name;

    /// <summary>
    /// Define Level property.
    /// This is a read-only attribute.
    /// </summary>
    public virtual int Level => _level;

    /// <summary>
    /// Define Reviewed property.
    /// This is a read/write attribute.
    /// </summary>
    public virtual bool Reviewed
    {
        get => _reviewed;
        set => _reviewed = value;
    }
}