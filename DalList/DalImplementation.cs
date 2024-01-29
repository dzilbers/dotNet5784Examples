namespace Dal;

using System.ComponentModel;

using DalApi;

sealed class DalImplementation : IDal
{
    private static int s_counter = 0;
    private int _counter;

    public static DalImplementation Instance { get; } = new DalImplementation();

    private DalImplementation() => _counter = ++s_counter;

    public void Test() =>
        Console.WriteLine($"I am in DalList #{_counter}");
}
