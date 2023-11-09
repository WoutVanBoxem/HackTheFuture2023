using Common;
using System.Net;
using System.Net.Http.Json;
using System.Transactions;

var client = new HackTheFutureClient();
VineCalculator calculator = new VineCalculator();
try
{
    await client.Login("Bondogon", "86Sn5xstiZ");
    Console.WriteLine("Inloggen geslaagd!");
    await client.StartGame("a", "medium");
    var puzzle = await client.GetVineDto("a", "medium");
    Console.WriteLine(puzzle.Start);
    var endPosition = calculator.CalculateEndPosition(puzzle.AmountOfVines, puzzle.Start, puzzle.Directions);
    Console.WriteLine(endPosition);
    string endPositionFormatted = $"{endPosition.x},{endPosition.y}";
    Console.WriteLine(await client.PostAsJsonAsync("api/path/a/medium/puzzle", endPositionFormatted));
    
}
catch (Exception e)
{
    Console.WriteLine($"Er is een fout opgetreden: {e.Message}");
}

