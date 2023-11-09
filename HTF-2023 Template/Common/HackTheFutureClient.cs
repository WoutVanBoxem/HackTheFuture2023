using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;

namespace Common;

public class HackTheFutureClient : HttpClient
{
   
    public HackTheFutureClient()
    { 
        BaseAddress = new Uri("https://app-involved-htf-api.azurewebsites.net");
    }

    //Use this method after creating a HackTheFutureClient instance to authenticate yourself with the server
    public async Task Login(string teamName, string password)
    {
        var response = await GetAsync($"/api/team/token?teamname={teamName}&password={password}");
        if (!response.IsSuccessStatusCode)
            throw new Exception("You weren't able to log in, did you provide the correct credentials?");
        var token = await response.Content.ReadAsStringAsync();
        DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
    }

    public async Task StartGame(string path,string difficulty)
    {
        var response = await GetAsync($"/api/path/{path}/{difficulty}/start");
        if (!response.IsSuccessStatusCode)
            throw new Exception("Request not succeeded");
    }

    public async Task<string> GetPuzzle(string path, string difficulty)
    {
        var response = await GetAsync($"/api/path/{path}/{difficulty}/puzzle");

        if (!response.IsSuccessStatusCode)
        {
            throw new Exception($"Request not succeeded: {response.StatusCode}");
        }
        var content = await response.Content.ReadAsStringAsync();
        return content;
    }

    public async Task<string> GetPuzzleSample(string path, string difficulty)
    {
        var response = await GetAsync($"/api/path/{path}/{difficulty}/sample");

        if (!response.IsSuccessStatusCode)
        {
            throw new Exception($"Request not succeeded: {response.StatusCode}");
        }
        var content = await response.Content.ReadAsStringAsync();
        return content;
    }


    public async Task<MayanCalendarChallengeDto> GetMayanCalendar(string path, string difficulty)
    {
        var response = await GetAsync($"/api/path/{path}/{difficulty}/sample");

        if (!response.IsSuccessStatusCode)
        {
            throw new Exception($"Request not succeeded: {response.StatusCode}");
        }
        var content = await response.Content.ReadFromJsonAsync<MayanCalendarChallengeDto>();

        return content;
    }




    public async Task<VineNavigationChallengeDto> GetVineDto(string path, string difficulty)
    {
        var response = await GetAsync($"/api/path/{path}/{difficulty}/sample");

        if (!response.IsSuccessStatusCode)
        {
            throw new Exception($"Request not succeeded: {response.StatusCode}");
        }

        VineNavigationChallengeDto content = await response.Content.ReadFromJsonAsync<VineNavigationChallengeDto>();
        if (content is null)
        {
            throw new InvalidOperationException("Received null content from API.");
        }

        return content;
    }

}