namespace Lesson6_CLI;

class Program
{
    public static void Main()
    {
        // See https://aka.ms/new-console-template for more information
        //Printer printer = new();
        //_ = new User(printer);
        //_ = new User(printer);
        //_ = new User(printer);
        //_ = new User(printer);
        //printer.PageOver();
        //Console.WriteLine("Please enter pages to print:");
        //int x = int.Parse(Console.ReadLine()!);
        //printer.Print(x);

        MyValue v = new MyValue();
        _ = new ValueObserver1(v);
        _ = new ValueObserver2(v);
        v.Value = 100;
        v.Value = 210;
        v.Value = 150;
        v.Value = 180;
    }
}