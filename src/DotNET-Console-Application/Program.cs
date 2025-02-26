namespace DotNET_Console_Application;

class Program
{
    static void Main(string[] args)
    {
        Person person = new Person(lastName: "Shmoe");
        Console.WriteLine($"{person.FirstName} {person.LastName}");
        person.FirstName = "        Jane  ";
        Console.WriteLine($"{person.FirstName} {person.LastName}");
        Console.WriteLine(person.FullName);
        Console.WriteLine(person.HungerLevel);
        person.Eat(12f);
        Console.WriteLine(person.HungerLevel);
    }
}
