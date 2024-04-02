using System.Reflection;

class Program
{
    public static void Main()
    {
        printInfo(typeof(MyClass));
        Console.WriteLine("-----------------------------------");
        var anonymousObject = new { Id = 2222, Name = "Yossi" };
        var anonym1 = new { Id = 2222, Name = "Yossi" };
        printInfo(anonymousObject.GetType());
        Console.WriteLine(anonymousObject == anonym1);
        Console.WriteLine(anonymousObject.Equals(anonym1));
        Console.WriteLine(anonymousObject);
        var anonym2 = anonymousObject with { Name = "Dani" };
        Console.WriteLine("-----------------------------------");
        //object[] array = new object[5];
        //array[1] = anonym2;

        //string str = "123";
        //int i = str.ToInt();
        //int j = "234".ToInt();

        //DateTime.Now.ToStringProperty();
        //anonym1.ToStringProperty();
        //new MyClass().ToStringProperty();

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
    }

    static string accessLevel(FieldInfo item) => (item.IsInitOnly ? ", readonly" : "") + ", access: " +
        item switch
        {
            { IsPrivate: true } => "private",
            { IsPublic: true } => "public",
            { IsFamily: true } => "protected",
            { IsFamilyAndAssembly: true } => "internal private",
            { IsFamilyOrAssembly: true } => "private protected",
            { IsAssembly: true } => "internal",
            _ => ""
        };
    static string accessLevel(MethodInfo item) => ", access: " +
    item switch
    {
        { IsPrivate: true } => "private",
        { IsPublic: true } => "public",
        { IsFamily: true } => "protected",
        { IsFamilyAndAssembly: true } => "internal private",
        { IsFamilyOrAssembly: true } => "private protected",
        { IsAssembly: true } => "internal",
        _ => ""
    };
    static string accessLevel(ConstructorInfo item) => ", access: " +
    item switch
    {
        { IsPrivate: true } => "private",
        { IsPublic: true } => "public",
        { IsFamily: true } => "protected",
        { IsFamilyAndAssembly: true } => "internal private",
        { IsFamilyOrAssembly: true } => "internal protected",
        { IsAssembly: true } => "internal",
        _ => ""
    };

    static void printInfo(Type type) => printInfo("", type);

    static void printInfo(string suffix, Type type)
    {
        string category = type.IsValueType ? "ValueType" : "ReferenceType";
        Console.WriteLine(suffix + $"""Type Name: {type.Name}: {category} {type switch { { IsInterface: true } => "interface", { IsEnum: true } => "enum", { IsClass: true } => "class", _ => "" }} {type switch { { IsAbstract: true } => "abstract", { IsSealed: true } => "sealed", _ => "" }} {type switch { { IsGenericType: true } => "generic", _ => "" }}""");

        Console.WriteLine(suffix + "Base Type: ");
        if (type.BaseType == null)
            Console.WriteLine(suffix + suffix + "None");
        else
            printInfo(suffix + "  ", type.BaseType);

        FieldInfo[] staticFields = type.GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static);
        FieldInfo[] instanceFields = type.GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
        PropertyInfo[] staticProperties = type.GetProperties(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static);
        PropertyInfo[] instanceProperties = type.GetProperties(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
        MethodInfo[] staticMethods = type.GetMethods(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static);
        MethodInfo[] instanceMethods = type.GetMethods(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
        ConstructorInfo[] staticConstructors = type.GetConstructors(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static);
        ConstructorInfo[] instanceConstructors = type.GetConstructors(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);

        Console.WriteLine(suffix + "Member Info:");
        if (staticFields.Length > 0)
        {
            Console.WriteLine(suffix + " Static fields:");
            foreach (var item in staticFields)
                Console.WriteLine(suffix + "  name: {0,-32} type: {1,-11} in: {2}" +
                    accessLevel(item) + (item.IsLiteral ? " literal" : ""), item.Name, item.MemberType, item.DeclaringType?.Name);
        }
        if (instanceFields.Length > 0)
        {
            Console.WriteLine(suffix + " Instance fields:");
            foreach (var item in instanceFields)
                Console.WriteLine(suffix + "  name: {0,-32} type: {1,-11} in: {2}" +
                    accessLevel(item) + (item.IsLiteral ? " literal" : ""), item.Name, item.MemberType, item.DeclaringType?.Name);
        }

        if (staticProperties.Length > 0)
        {
            Console.WriteLine(suffix + " Static properties:");
            foreach (var item in staticProperties)
            {
                Console.Write(suffix + "    name: {0,-32} type: {1,-11} in: {2}",
                                  item.Name, item.MemberType, item.DeclaringType?.Name);
                Console.WriteLine((item.CanRead ? ", GET" + accessLevel(item.GetGetMethod()!) : "") +
                                  (item.CanWrite ? ", SET" + accessLevel(item.GetSetMethod()!) : ""));
            }
        }
        if (instanceFields.Length > 0)
        {
            Console.WriteLine(suffix + " Instance properties:");
            foreach (var item in instanceProperties)
            {
                Console.Write(suffix + "  name: {0,-32} type: {1,-11} in: {2}",
                                  item.Name, item.MemberType, item.DeclaringType?.Name);
                Console.WriteLine((item.CanRead ? ", GET" + accessLevel(item.GetGetMethod()!) : "") +
                                  (item.CanWrite ? ", SET" + accessLevel(item.GetSetMethod()!) : ""));
            }
        }

        if (staticMethods.Length > 0)
        {
            Console.WriteLine(suffix + " Static methods:");
            foreach (var item in staticMethods)
                Console.WriteLine(suffix + "  name: {0,-32} type: {1,-11} in: {2}" + accessLevel(item),
                                  item.Name, item.MemberType, item.DeclaringType?.Name);
        }
        if (instanceMethods.Length > 0)
        {
            Console.WriteLine(suffix + " Instance methods:");
            foreach (var item in instanceMethods)
                Console.WriteLine(suffix + "  name: {0,-32} type: {1,-11} in: {2}" + accessLevel(item),
                                  item.Name, item.MemberType, item.DeclaringType?.Name);
        }

        if (staticConstructors.Length > 0)
        {
            Console.WriteLine(suffix + " Static constructors:");
            foreach (var item in staticConstructors)
                Console.WriteLine(suffix + "  name: {0,-32} type: {1,-11} in: {2}" + accessLevel(item),
                                  item.Name, item.MemberType, item.DeclaringType?.Name);
        }
        if (instanceConstructors.Length > 0)
        {
            Console.WriteLine(suffix + " Instance constructors:");
            foreach (var item in instanceConstructors)
                Console.WriteLine(suffix + "  name: {0,-32} type: {1,-11} in: {2}" + accessLevel(item),
                                  item.Name, item.MemberType, item.DeclaringType?.Name);
        }

        //MemberInfo[] members = type.GetMembers((BindingFlags)0x7FFF);
        //foreach (var item in members)
        //    Console.WriteLine(suffix + "name: {0,-32} type: {1,-11} in: {2}",
        //                      item.Name, item.MemberType, item.DeclaringType?.Name);
    }
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


