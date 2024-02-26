#pragma warning disable CA1822 // Mark members as static
#pragma warning disable IDE0060 // Remove unused parameter

using System.Diagnostics;

// Main:
Person p = new() { Id = 123, Name = "Shira" };
p.F1();
Console.WriteLine(p);

/// <summary>
/// Person class for demonstration of attributes:
/// <list type="bullet">
/// <item>DebuggerDisplay</item>
/// <item>Obsolete</item>
/// </list>
/// </summary>
//[DebuggerDisplay("{Name,nq}({Id,h})")]
//[DebuggerDisplay("{Name}({Id})")]
class Person
{
    internal int Id;
    internal string? Name;

    //[Obsolete("Please stop using this function, use F2(int) instead",true)]
    internal void F1() { }
    internal void F2(int num) { }

    //public override string ToString() => $"Person: #{Id}, name: {Name}";
}

#pragma warning restore IDE0060 // Remove unused parameter
#pragma warning restore CA1822 // Mark members as static