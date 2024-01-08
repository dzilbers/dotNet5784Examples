// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");
int number = (8);
var test = 2.5;
uint positive = (uint) number;
Console.WriteLine(number);

MyClass.Gender a = MyClass.Gender.Male;
var obj = new MyClass() { MyGender = MyClass.Gender.Male };
// obj.MyGender = a;
Console.WriteLine(obj.MyGender);
Console.WriteLine(obj.Func1("something", 4, 8, 11, 2));

obj.Func2(par2: "Dani", par1: 5, par3: 2.5);

MyRecord rec1 = new(123, "Yossi");
MyRecord rec2 = rec1 with { Number = 877 };
Console.WriteLine(rec1);
Console.WriteLine(rec2);
rec2.Family = 8;

int? nullableNumber = null;

int num = 1;
func(ref num);
Console.WriteLine(num);

static void func(ref int i)
{
    Console.WriteLine(i);
    i = 8;
}


record MyRecord(int Number, string Name)
{
    public int Family = 1;
}

/// <summary>
/// f ssf ds  d d d gadfg dfg
/// </summary>
class MyClass
{
    public enum Gender { Male, Female }

    private Gender gender = Gender.Female;
    public Gender MyGender { get => gender; set => gender = value; }

    public int Number { get; set; } = 8;

    /// <summary>
    /// This functions creates a string with
    /// all the number with + beteen them
    /// </summary>
    /// <param name="begin">starting string for the result</param>
    /// <param name="numbers">all the numbers to be represented</param>
    /// <returns>the resulting string</returns>
    public string Func1(string begin, params int[] numbers)
    {
        string result = begin + ": ";
        foreach (var number in numbers)
            result += number + " + ";
        return result + "0";
    }

    public void Func2(int par1, string par2, double par3) { }
}