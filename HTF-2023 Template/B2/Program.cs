using Common;
using System.Net.Http.Json;
using static System.Formats.Asn1.AsnWriter;

var client = new HackTheFutureClient();
try
{
    await client.Login("Bondogon", "86Sn5xstiZ");
    Console.WriteLine("Inloggen geslaagd!");
    await client.StartGame("b", "medium");
    string[] MayaArray = await client.GetPuzzle2b("b","medium");

    
    Console.WriteLine(RemoveCommonCharacters(MayaArray));

    Console.WriteLine(await client.PostAsJsonAsync("api/path/b/medium/puzzle", RemoveCommonCharacters(MayaArray)));


}
catch (Exception e)
{
    Console.WriteLine($"Er is een fout opgetreden: {e.Message}");
}

static string RemoveCommonCharacters(string[] array)
{
    if (array.Length == 0)
    {
        return string.Empty;
    }

    // Find the common characters in the first string
    string commonCharacters = array[0];

    foreach (string str in array)
    {
        commonCharacters = new string(commonCharacters.Intersect(str).ToArray());
    }

    // Create a string of removed characters
    string removedChars = new string(commonCharacters.Distinct().ToArray());

    return removedChars;
}





