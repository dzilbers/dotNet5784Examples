namespace Lesson6_CLI;

internal class User
{
    static int s_counter = 0;
    readonly int _number;
    readonly Printer _printer;
    public User(Printer printer)
    {
        _number = ++s_counter;
        _printer = printer;
        //        printer.PageOver += myPageOver;
        _printer.PageOver += myPageOver;
    }

    static readonly Random _random = new();

    private void myPageOver(object? printer, PrinterEventArgs printerArgs)
    {
        //PrinterEventArgs printerArgs = args as PrinterEventArgs ?? throw new ArgumentException("Bad event arguments");
        if (printerArgs.Done) return;
        Console.WriteLine($"User{_number}: You LAZY - bring more paper!!!");
        Console.WriteLine($"Not printer:{(printerArgs).NotPrinted}");
        if (_random.NextDouble() < 0.5)
        {
            Console.WriteLine("I will bring it!");
            printerArgs.Done = true;
        }
        else
        {
            Console.WriteLine(  "Sorry, I'm busy... Someone else will bring it!");
        }
    }
}
