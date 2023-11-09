using Common;
using System.Net.Http.Json;

var client = new HackTheFutureClient();
try
{
    await client.Login("Bondogon", "86Sn5xstiZ");
    Console.WriteLine("Inloggen geslaagd!");
    await client.StartGame("a","easy");
    var puzzle = await client.GetPuzzle("a","easy");
    var translation = HieroglyphTranslator.TranslateHieroglyphs(puzzle);
    Console.WriteLine(await client.PostAsJsonAsync("api/path/a/easy/puzzle", translation));  
}
catch (Exception e)
{
    Console.WriteLine($"Er is een fout opgetreden: {e.Message}");
}




