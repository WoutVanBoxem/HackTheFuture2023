using Common;

var client = new HackTheFutureClient();
try
{
    await client.Login("Bondogon", "86Sn5xstiZ");
    Console.WriteLine("Inloggen geslaagd!");
    await client.StartGame("b", "easy");
    var puzzle = await client.GetPuzzle("b", "easy");


}
catch (Exception e)
{
    Console.WriteLine($"Er is een fout opgetreden: {e.Message}");
}




