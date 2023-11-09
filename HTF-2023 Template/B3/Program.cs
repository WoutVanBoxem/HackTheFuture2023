using Common;
using System.Net.Http.Json;

var client = new HackTheFutureClient();
try
{
    await client.Login("Bondogon", "86Sn5xstiZ");
    Console.WriteLine("Inloggen geslaagd!");
    await client.StartGame("b", "hard");
    //string[] MayaArray = await client.GetPuzzle2b("b", "medium");




}
catch (Exception e)
{
    Console.WriteLine($"Er is een fout opgetreden: {e.Message}");
}