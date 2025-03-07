namespace DotNET_Console_Application;

public class Pencil : WritingUtensil
{
    public Pencil(string brand = "Bic", double length = 100) : base(brand)
    {
        Length = length;
    }
    private double _length;
    public double Length
    {
        get
        {
            return _length;
        }
        set
        {
            if (value < 0)
            {
                throw new ArgumentOutOfRangeException("value", $"Must have some pencil left to write with.");
            }
            _length = value;
        }
    }
    public override void Write(int letters)
    {
        Length -= letters * 0.25;
    }
    public override string ToString()
    {
        return $"A {Brand} pencil with {Length:0.00}mm remaining.";
    }
}