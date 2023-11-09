using Common;
using System.Net.Http.Json;

var client = new HackTheFutureClient();
var converter = new MayanNumeralsConverter();
try
{
    await client.Login("Bondogon", "86Sn5xstiZ");
    Console.WriteLine("Inloggen geslaagd!");
    await client.StartGame("b", "hard");
    string[] mayanNumbers = await client.GetPuzzle2b("b", "hard");
    foreach(string number in mayanNumbers)
    {
        Console.WriteLine(number);
    }
    int totalDecimal = mayanNumbers.Select(converter.MayanToDecimal).Sum();
    Console.WriteLine( totalDecimal);
    string mayanTotal = converter.DecimalToMayan(totalDecimal);
    string mayanTotalFormatted = converter.DecimalToMayan(totalDecimal);
    Console.WriteLine( await client.PostAsJsonAsync("api/path/b/hard/puzzle", mayanTotalFormatted));


}
catch (Exception e)
{
    Console.WriteLine($"Er is een fout opgetreden: {e.Message}");
}