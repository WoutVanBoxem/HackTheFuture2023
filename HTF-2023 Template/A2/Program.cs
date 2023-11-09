using Common;

var client = new HackTheFutureClient();
try
{
    await client.Login("Bondogon", "86Sn5xstiZ");
    Console.WriteLine("Inloggen geslaagd!");
    await client.StartGame("a", "medium");
    var puzzle = await client.GetVineDto("a", "medium");
    Console.WriteLine(puzzle.AmountOfVines);



}
catch (Exception e)
{
    Console.WriteLine($"Er is een fout opgetreden: {e.Message}");
}

