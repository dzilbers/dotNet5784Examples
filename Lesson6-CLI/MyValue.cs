namespace Lesson6_CLI;

public class ValueChangedArgs : EventArgs
{
    public readonly int OldV;
    public readonly int NewV;
    
    public ValueChangedArgs(int oldV, int newV)
    {
        OldV = oldV;
        NewV = newV; 
    }
}

public class MyValue
{
    private int _value = 0;
    public event EventHandler<ValueChangedArgs>? OnValueChanged = null;
    private void valueChangedHandler(int oldV, int newV) =>
        OnValueChanged?.Invoke(this, new ValueChangedArgs(oldV, newV));

    public int Value
    {
        get => _value;
        set
        {
            if (value != this._value)
            {
                int temp = this._value;
                this._value = value;
                valueChangedHandler(temp, value);
            }
        }
    }
}