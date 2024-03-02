using System;
using System.Net.Http;
using System.Threading.Tasks;

public class WorldTimeApi
{
    private static readonly HttpClient client = new HttpClient();

    public static async Task<DateTime> GetCurrentDateTimeAsync(string timeZone)
    {
        string apiUrl = $"http://worldtimeapi.org/api/timezone/{timeZone}";
        HttpResponseMessage response = await client.GetAsync(apiUrl);

        if (response.IsSuccessStatusCode)
        {
            string jsonString = await response.Content.ReadAsStringAsync();
            dynamic result = Newtonsoft.Json.JsonConvert.DeserializeObject(jsonString);
            string dateTimeString = result.datetime;
            DateTime dateTime = DateTime.Parse(dateTimeString);
            return dateTime;
        }
        else
        {
            throw new Exception("Failed to retrieve data from the API.");
        }
    }
}
