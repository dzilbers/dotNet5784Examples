
// See https://aka.ms/new-console-template for more information

Console.WriteLine("Start Cooking");
//var egg = fryEggAsync(3); // sync invokation
Task.Run(async () => fryEggAsync(3));
Console.WriteLine("Finsih Cooking");

static async Task<int> doWork(int number, int ms)
{
    await Task.Delay(ms);
    return number;
}

static async Task<Egg> fryEggAsync(int howMany)
{
    Console.WriteLine("Warming the egg pan");
    //await Task.Delay(3000);
    Thread.Sleep(3000);
    Console.WriteLine("Cooking the eggs");
    return new Egg();
}

class Egg { }