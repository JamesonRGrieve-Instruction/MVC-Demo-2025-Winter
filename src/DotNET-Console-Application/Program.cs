namespace DotNET_Console_Application;



class Program
{
    static void Main(string[] args)
    {
        string userName = Environment.UserName;
        string machineName = Environment.MachineName;
        string osVersion = Environment.OSVersion.ToString();
        string userFolder = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
        string documentsFolder = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

        Console.WriteLine($"User Name: {userName}");
        Console.WriteLine($"Machine Name: {machineName}");
        Console.WriteLine($"Operating System: {osVersion}");
        Console.WriteLine($"User Folder: {userFolder}");
        Console.WriteLine($"Documents Folder: {documentsFolder}");


    }

}
