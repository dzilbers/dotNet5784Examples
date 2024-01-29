namespace Lesson6_CLI;

internal class ValueObserver2
{
    private int _sum = 0;
    private int _count = 0;

    public ValueObserver2(MyValue v) => v.OnValueChanged += myOnValueChanged;

    private void myOnValueChanged(object? sender, ValueChangedArgs args)
    {
        _count++;
        _sum += args.NewV - args.OldV;
        Console.WriteLine($"Value average change is {(double)_sum / _count}");
    }
}