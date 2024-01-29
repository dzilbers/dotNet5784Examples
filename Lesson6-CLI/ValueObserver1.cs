namespace Lesson6_CLI;

internal class ValueObserver1
{
    public ValueObserver1(MyValue v) => v.OnValueChanged += myOnValueChanged;

    private void myOnValueChanged(object? sender, ValueChangedArgs args) =>
        Console.WriteLine($"Value changed by {args.NewV - args.OldV}");
}