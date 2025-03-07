namespace DotNET_Console_Application;

public class Pen : WritingUtensil
{
    public Pen(string brand = "Bic", string colour = "Black", double inkLevelML = 50) : base(brand)
    {
        Colour = colour;
        _inkLevelMLMax = inkLevelML;
        InkLevelML = inkLevelML;
    }
    public string Colour { get; set; }
    private double _inkLevelML = 0;
    private double _inkLevelMLMax = 0;
    public double InkLevelML
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
    public override void Write(int letters)
    {
        InkLevelML -= letters * 0.1;
    }
    public override string ToString()
    {
        return $"A {Colour} {Brand} pen with {InkLevelML:0.00}mL ink remaining.";
    }

}