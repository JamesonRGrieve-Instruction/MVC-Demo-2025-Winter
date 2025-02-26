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
    public string FirstName { get; set; }
    public string LastName { get; set; }

}