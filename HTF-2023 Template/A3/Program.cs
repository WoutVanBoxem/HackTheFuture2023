using Common;
using System.Net;
using System.Net.Http.Json;
using System.Transactions;

var client = new HackTheFutureClient();
try
{
    await client.Login("Bondogon", "86Sn5xstiZ");
    Console.WriteLine("Inloggen geslaagd!");
    await client.StartGame("a", "hard");
    var puzzle = await client.GetAnimals("a", "hard");
    Console.WriteLine("Niet gesorteerd: ");
    foreach (Animal animal in puzzle)
    {
        Console.WriteLine(animal.Name);
    }
    AnimalChainBuilder builder = new AnimalChainBuilder(puzzle);
    List<Animal> animalChain = builder.BuildChain();
    Animal[] answerChain = animalChain.ToArray();
    Console.WriteLine();
    Console.WriteLine("Wel gesorteerd: ");
    string[] animalNames = animalChain.Select(animal => animal.Name).ToArray();
    foreach (string name in animalNames)
    {
        Console.WriteLine(name);
    }
    Console.WriteLine(await client.PostAsJsonAsync("api/path/a/hard/puzzle", animalNames));
    
}
catch (Exception e)
{
    Console.WriteLine($"Er is een fout opgetreden: {e.Message}");
}
