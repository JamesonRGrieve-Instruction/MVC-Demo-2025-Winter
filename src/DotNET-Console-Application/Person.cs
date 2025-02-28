namespace DotNET_Console_Application;

class Pen
{
    public Pen(string brand = "Bic", string colour = "Black", float inkLevelML = 50f)
    {
        Brand = brand;
        Colour = colour;
        _inkLevelMLMax = inkLevelML;
        InkLevelML = inkLevelML;
    }
    public string Brand
    {
        get;
        set;
    }
    public string Colour { get; set; }
    private float _inkLevelML = 0;
    private float _inkLevelMLMax = 0;
    public float InkLevelML
    {
        get
        {
            return _inkLevelML;
        }
        set
        {
            if (value < 0 || value > _inkLevelMLMax)
            {
                throw new ArgumentOutOfRangeException("value", $"Ink level must be between 0 and the maximum ink level {_inkLevelMLMax}mL.");
            }
            _inkLevelML = value;
        }

    }
    public void Write(int letters)
    {
        try
        {
            InkLevelML -= letters * 0.1f;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message.ToString());
        }
    }
    // public string FullName => Brand + " " + Colour.ToUpper();

}