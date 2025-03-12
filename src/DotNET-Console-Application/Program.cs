namespace DotNET_Console_Application;



class Program
{
    static void Main(string[] args)
    {
        for (int i = 1; i <= 10; i++)
        {
            Console.WriteLine(i);
        }

        Count(1, 10);
    }
    static void Count(int from, int to)
    {
        Console.WriteLine(from);
        if (from < to)
        {
            Count(from + 1, to);
        }
    }
}
