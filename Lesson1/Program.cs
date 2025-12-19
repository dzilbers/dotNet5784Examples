// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");
//Test.TestClass obj = new();
//obj.id = 3;
//obj.print();

for (int i = 0; i < 10; i++) ;

Console.WriteLine("Another hello to you!");

if (!int.TryParse(Console.ReadLine(), out int input))
    Console.WriteLine("Wrong input");
else
    Console.WriteLine($"Number: {input}");
// obj.print();

string str1 = "abcdef";
string str2 = str1;
Console.WriteLine(str1[3]);
// str1[3] = 'a';
str1 += "ghij";
Console.WriteLine(str1);
Console.WriteLine(str2);

Object obj2 = new();

