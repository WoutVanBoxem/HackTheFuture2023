using Common;
using System.Net.Http.Json;
using System.Transactions;

var client = new HackTheFutureClient();
try
{
    await client.Login("Bondogon", "86Sn5xstiZ");
    Console.WriteLine("Inloggen geslaagd!");
    await client.StartGame("b", "easy");
    MayanCalendarChallengeDto puzzle = await client.GetPuzzle1b("b", "easy");

    Console.WriteLine(CountDayBetweenDates(puzzle.StartDate, puzzle.EndDate, puzzle.Day));
    Console.WriteLine(await client.PostAsJsonAsync("api/path/b/easy/puzzle", CountDayBetweenDates(puzzle.StartDate, puzzle.EndDate, puzzle.Day)));

}
catch (Exception e)
{
    Console.WriteLine($"Er is een fout opgetreden: {e.Message}");
}

static int CountDayBetweenDates(DateOnly startDate, DateOnly endDate, string targetDay)
{
    if (Enum.TryParse(targetDay, true, out DayOfWeek targetDayEnum))
    {
        int count = 0;
        while (startDate <= endDate)
        {
            if (startDate.DayOfWeek == targetDayEnum)
            {
                count++;
            }
            startDate = startDate.AddDays(1);
        }
        return count;
    }
    else
    {
        throw new ArgumentException("Invalid target day string.");
    }
}




