using System.Reflection;


PrintInfo("", typeof(MyClass));
Console.WriteLine("-----------------------------------");
var anonymousObject = new { Id = 2222, Name = "Yossi" };
PrintInfo("", anonymousObject.GetType());
Console.WriteLine("-----------------------------------");

//DateTime.Now.ToStringProperty();

var myObject = new MyGenericClass<int, string>();
myObject!.MyFunction(3, "I am here");







static void PrintInfo(string suffix, Type type)
{
    Console.WriteLine(suffix + "Type Name: " + type.Name);
    Console.WriteLine(suffix + "Base Type: ");
    if (type.BaseType == null)
        Console.WriteLine(suffix + suffix + "None");
    else
        PrintInfo(suffix + "  ", type.BaseType);
    Console.WriteLine(suffix + "Member Info:");
    MemberInfo[] members = type.GetMembers();
    foreach (var item in members)
        Console.WriteLine(suffix + "name: {0,-15} type: {2,-11} in: {1}",
                          item.Name, item?.DeclaringType?.Name, item?.MemberType);
}

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
        Console.WriteLine(  "" + _myField + " and " + parm2);
    }
}

static class MyTools
{
    public static int ToInt(this string str)
    {
        return int.Parse(str);
    }
}

static class Tools
{
    public static void ToStringProperty<T>(this T t)
    {
        string str = "";
        foreach (PropertyInfo item in t!.GetType().GetProperties())
            str += "\n" + item.Name + ": " + item.GetValue(t, null);
        Console.WriteLine(str);
    }
}


