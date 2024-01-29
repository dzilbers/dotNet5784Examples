namespace Lesson6_CLI;

internal class User
{
    static int _counter = 0;
    readonly int _number;
    readonly Printer _printer;
    public User(Printer printer)
    {
        _number = ++_counter;
        _printer = printer;
        printer.PageOver += myPageOver;
    }
    private void myPageOver() => 
        Console.WriteLine($"User{_number}: You LAZY - bring more paper!!!");
}
