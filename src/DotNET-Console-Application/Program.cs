namespace DotNET_Console_Application;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("Do you want to use a pen or pencil?: ");
        string answer = Console.ReadLine().Trim().ToLower();
        if (answer == "pen" || answer == "pencil")
        {
            WritingUtensil writingUtensil = answer == "pen" ? new Pen() : new Pencil();
            while (answer != "exit")
            {
                try
                {
                    Console.Write("How many letters would you like to write?: ");
                    answer = Console.ReadLine().Trim();
                    if (answer != "exit")
                    {
                        int letters = int.Parse(answer);
                        writingUtensil.Write(letters);
                        Console.WriteLine(writingUtensil);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

            }
        }
        else
        {
            Console.WriteLine("How do I write with that?");
        }


    }
}
