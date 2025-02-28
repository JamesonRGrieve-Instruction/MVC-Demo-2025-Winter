namespace DotNET_Console_Application;

class Program
{
    static void Main(string[] args)
    {
        Pen pen = new Pen();
        pen.Write(100);
        pen.Write(42);
        pen.Write(200);
        Console.WriteLine($"{pen.InkLevelML:0.00}mL Ink Remaining");
    }
}
