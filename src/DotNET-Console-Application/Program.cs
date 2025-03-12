namespace DotNET_Console_Application;



class Program
{
    static readonly HttpClient client = new HttpClient();
    static async Task Main(string[] args)
    {
        HttpResponseMessage response = await client.GetAsync("https://randomuser.me/api/");
        response.EnsureSuccessStatusCode();

        string responseBody = await response.Content.ReadAsStringAsync();
        Console.WriteLine(responseBody);
    }

}
