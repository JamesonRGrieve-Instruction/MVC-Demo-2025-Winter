namespace DotNET_Console_Application;

class Person
{
    public Person()
    {
        FirstName = "John";
        LastName = "Doe";
    }
    public Person(string firstName, string lastName)
    {
        FirstName = firstName;
        LastName = lastName;
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
    public string FullName => FirstName + " " + LastName.ToUpper();

}