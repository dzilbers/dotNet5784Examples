namespace Attributes;
using System.Diagnostics;

//[DebuggerDisplay("{Name,nq}({Id,h})")]
class Person
{
    internal int Id;
    internal string Name;
//    [Obsolete("Please stop using this function, use f2(int) instead", false)]
    internal void f1() { }
    internal void f2(int num) { }
//    public override string ToString() => $"Person: #{Id}, name: {Name}";
}

class Program
{
    static void Main(string[] args)
    {
        Person p = new Person { Id = 123, Name = "Shira" };
        p.f1();
        Console.WriteLine(p);
    }
}
