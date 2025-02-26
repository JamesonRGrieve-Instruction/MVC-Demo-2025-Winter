namespace DotNET_Console_Application;

class Person
{
    public Person()
    {
        FirstName = "John";
        LastName = "Doe";
        HungerLevel = 50f;
    }
    public Person(string firstName, string lastName)
    {
        FirstName = firstName;
        LastName = lastName;
        HungerLevel = 50f;
    }
    private string _firstName = "";
    public string FirstName
    {
        get
        {
            return _firstName.ToUpper();
        }
        set
        {
            _firstName = value.Trim();
        }
    }
    public string LastName { get; set; }
    private float _hungerLevel = 0;
    public float HungerLevel
    {
        get
        {
            return _hungerLevel;
        }
        set
        {
            if (_hungerLevel < 0 || _hungerLevel > 100)
            {
                throw new ArgumentOutOfRangeException("value", "Hunger level must be between 0 and 100");
            }
            _hungerLevel = value;
        }

    }
    public void Eat(float amount)
    {
        HungerLevel -= amount;
    }
    public string FullName => FirstName + " " + LastName.ToUpper();

}