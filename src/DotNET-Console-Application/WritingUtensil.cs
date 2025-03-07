namespace DotNET_Console_Application;

public abstract class WritingUtensil
{
    public WritingUtensil(string brand = "Bic")
    {
        Brand = brand;

    }
    public string Brand { get; set; }
    public abstract void Write(int letters);
}