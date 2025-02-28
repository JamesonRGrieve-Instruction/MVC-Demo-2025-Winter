namespace DotNET_Console_Application;

class Pen
{
    public Pen(string brand = "Bic", string colour = "Black")
    {
        Brand = brand;
        Colour = colour;
        InkLevel = 100f;
    }
    public string Brand
    {
        get;

        set;

    }
    public string Colour { get; set; }
    private float _inkLevel = 0;
    public float InkLevel
    {
        get
        {
            return _inkLevel;
        }
        set
        {
            if (value < 0 || value > 100)
            {
                throw new ArgumentOutOfRangeException("value", "Ink level must be between 0 and 100");
            }
            _inkLevel = value;
        }

    }
    public void Write(int letters)
    {
        try
        {
            InkLevel -= letters * 0.5f;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message.ToString());
        }
    }
    // public string FullName => Brand + " " + Colour.ToUpper();

}