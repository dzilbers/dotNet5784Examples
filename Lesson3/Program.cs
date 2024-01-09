using System.Reflection;

//PrintInfo("", typeof(MyClass));
//Console.WriteLine("-----------------------------------");
//var anonymousObject = new { Id = 2222, Name = "Yossi" };
var anonym1 = new { Id = 2222, Name = "Yossi" };
//PrintInfo("", anonymousObject.GetType());
//Console.WriteLine(anonymousObject == anonym1);
//Console.WriteLine(anonymousObject.Equals(anonym1));
//Console.WriteLine(anonymousObject);
//var anonym2 = anonymousObject with { Name = "Dani" };
//Console.WriteLine("-----------------------------------");
//object[] array = new object[5];
//array[1] = anonym2;

//string str = "123";
//int i = str.ToInt();
//int j = "234".ToInt();

DateTime.Now.ToStringProperty();
anonym1.ToStringProperty();
new MyClass().ToStringProperty();

//var myObject = new MyGenericClass<int, string>();
//myObject!.MyFunction(3, "I am here");


//foreach (var number in func())
//    Console.WriteLine(number);

//foreach (var number in func())
//    Console.WriteLine(number);

//SomeDelegate myDlgt = new SomeDelegate(sum);
//myDlgt += mult; myDlgt += sub; myDlgt -= sum;

//foreach (var d in myDlgt.GetInvocationList()) Console.WriteLine(d.Method);

//if (myDlgt is Delegate) Console.WriteLine("myDlgt is Delegate == true");
//foreach (var item in myDlgt.GetInvocationList()) // (Delegate item …)
//    Console.WriteLine(item.DynamicInvoke(3, 2));




//    static int sum(int num1, int num2) => num1 + num2;
//    static int mult(int num1, int num2) => num1 * num2;
//    static int sub(int num1, int num2) => num1 - num2;

//static IEnumerable<int> func()
//{
//    yield return 25;
//    yield return 36;
//}

static void PrintInfo(string suffix, Type type)
{
    Console.WriteLine(suffix + "Type Name: " + type.Name);
    Console.WriteLine(suffix + "Base Type: ");
    if (type.BaseType == null)
        Console.WriteLine(suffix + suffix + "None");
    else
        PrintInfo(suffix + "  ", type.BaseType);
    Console.WriteLine(suffix + "Member Info:");
    MemberInfo[] members = type.GetMembers((BindingFlags)65535);
    foreach (var item in members)
        Console.WriteLine(suffix + "name: {0,-15} type: {2,-11} in: {1}",
                          item.Name, item?.DeclaringType?.Name, item?.MemberType);
}

public delegate int SomeDelegate(int x, int y);

class MyClass
{
    public int Id;
    public string? Name;
}

class MyGenericClass<T, U>
{
    T? _myField;
    internal void MyFunction(T parm1, U parm2)
    {
        _myField = parm1;
        Console.WriteLine("" + _myField + " and " + parm2);
    }
}

static class MyTools
{
    public static int ToInt(this string str) => int.Parse(str);

    public static void ToStringProperty<T>(this T t)
    {
        string str = "";
        foreach (PropertyInfo item in t!.GetType().GetProperties())
            str += "\n" + item.Name + ": " + item.GetValue(t, null);
        Console.WriteLine(str);
    }
}


