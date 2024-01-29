namespace DalTest;

using System.Diagnostics;

using DalApi;

class Program
{
    //static private readonly Dal.DalImplementation s_dal = new Dal.DalImplementation();
    //static private readonly IDal s_dal = new Dal.DalImplementation();
    //static private readonly IDal s_dal = Dal.DalImplementation.Instance;
    static private readonly IDal s_dal = Dal.Factory.Get();

    public static void Main()
    {
        //Console.WriteLine("Test");
        //s_dal.Test();
        //Dal.DalImplementation dal = new Dal.DalImplementation();
        //IDal dal = new Dal.DalImplementation();
        //IDal dal = Dal.DalImplementation.Instance;
        //IDal dal = Dal.Factory.Get();
        //dal.Test();

        int[] array1 = new int[] { 5, 9, -7, 23, 2, 18, 17, 22, 1, 0 };

        var request =
            from number in array1
            where number % 2 == 0
            select number * 2;

        Console.WriteLine("Before: ");
        foreach (var number in request)
            Console.Write(number + ", ");
        Console.WriteLine();

        array1[0] = 4;
        array1[4] = 3;
        array1[9] = 11;

        Console.WriteLine("After: ");
        foreach (var number in request)
            Console.Write(number + ", ");
        Console.WriteLine();
    }
}
