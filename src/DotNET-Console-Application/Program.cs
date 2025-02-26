namespace DotNET_Console_Application;

class Program
{
    static void Main(string[] args)
    {
        Person person = new Person();
        person.FirstName = "Jane";
        person.LastName = "Doe";

        Console.WriteLine($"{person.FirstName} {person.LastName}");
    }
}
