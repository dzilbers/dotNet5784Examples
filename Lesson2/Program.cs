// See https://aka.ms/new-console-template for more information
using System.Reflection;

class Program
{
    public static void Main()
    {
        MyClass test1 = new();
        MyRecord test2 = new(7, "Dani");
        Console.WriteLine(test1);
        Console.WriteLine(test2);
        Console.ReadKey();

        printInfo("", typeof(MyRecord));
        Console.Write("Press any key...");
        Console.ReadKey();

        Console.WriteLine(" ID:{0} called {1}, gender={2}", 4, "Yossi", MyClass.Genders.Female);
        Console.Write("Press any key...");
        Console.ReadKey();

        MyClass myObj = new();
        // Console.WriteLine(myObj.get_Number());
        Console.WriteLine(myObj.Number);

        ValueType obj9 = MyClass.Genders.Male;
        Console.WriteLine(obj9);

        object objA = obj9;

        Console.WriteLine("Hello, World!");
        int number = (8);
        var test = 2.5;
        uint positive = (uint)number;
        Console.WriteLine(number);

        positive = 38u;

        MyClass.Genders a = MyClass.Genders.Male;
        var obj = new MyClass() { Gender = MyClass.Genders.Male };
        obj.Gender = a;
        Console.WriteLine(obj.Gender);
        Console.WriteLine(obj.Func1("something", 4, 8, 11, 2));

        obj.Func2(par2: "Dani", par1: 5, par3: 2.5);

        MyRecord rec1 = new(123, "Yossi");
        MyRecord rec3 = rec1;
        MyRecord rec2 = rec1 with { Number = 877 };
        Console.WriteLine(rec1);
        Console.WriteLine(rec2);
        rec2.Family = 8;

        int? nullableNumber = null;

        int num = 1;
        nullableNumber = num;
        num = nullableNumber ?? 0;
        num = nullableNumber!.Value;
        var check = nullableNumber!.HasValue;

        func(ref num);
        Console.WriteLine(num);
    }
    static void func(ref int i)
    {
        Console.WriteLine(i);
        i = 8;
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

    static void printInfo(string suffix, Type type)
    {
        string category = type.IsValueType ? "ValueType" : "ReferenceType";
        Console.WriteLine(suffix + $"""Type Name: {type.Name}: {category} {type switch { { IsInterface: true } => "interface", { IsEnum: true } => "enum", { IsClass: true } => "class", _ => "" }} {type switch { { IsAbstract: true } => "absract", { IsSealed: true } => "sealed", _ => "" }} {type switch { { IsGenericType: true } => "generic", _ => "" }}""");

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

record MyRecord(int Number, string Name)
{
    public int Family = 1;
}

class Try(int number)
{
    public int Number = number;
}

/// <summary>
/// f ssf ds  d d d gadfg dfg
/// </summary>
public class MyClass
{
    public enum Genders { Male, Female }

    private Genders _gender = Genders.Female;
    public Genders Gender { get => _gender; set => _gender = value; }

    public DateTime Today { get => DateTime.Now; }

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
