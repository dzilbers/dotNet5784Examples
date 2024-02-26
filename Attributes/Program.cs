// using System.Diagnostics;

// Main:
Person p = new Person { Id = 123, Name = "Shira" };
p.F1();
Console.WriteLine(p);

/// <summary>
/// Person class for demonstration of attributes:
/// <ul>
/// <li>DebuggerDisplay</li>
/// <li>Obsolete</li>
/// </ul>
/// </summary>
//[DebuggerDisplay("{Name,nq}({Id,h})")]
class Person
{
    internal int Id;
    internal string? Name;

#pragma warning disable CA1822 // Mark members as static
    //    [Obsolete("Please stop using this function, use f2(int) instead", false)]
    internal void F1() { }
    internal void F2(int num) { }
#pragma warning restore CA1822 // Mark members as static

//    public override string ToString() => $"Person: #{Id}, name: {Name}";
}
