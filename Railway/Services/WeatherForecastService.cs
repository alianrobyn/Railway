namespace Railway.Services;

// ReSharper disable InconsistentNaming
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.

public class WeatherForecastService(HttpClient httpClient, IConfiguration configuration)
{
    private readonly string _apiKey = configuration["WeatherAPI:ApiKey"] ??
                                      throw new InvalidOperationException("WeatherAPI:ApiKey is not configured");

    private readonly string _baseUrl = configuration["WeatherAPI:BaseUrl"] ??
                                       throw new InvalidOperationException("WeatherAPI:BaseUrl is not configured");

    public async Task<ForecastRoot?> GetWeather(string city)
    {
        var url = $"{_baseUrl}/forecast?q={city}&lang=ua&appid={_apiKey}&units=metric";
        return await httpClient.GetFromJsonAsync<ForecastRoot>(url);
    }
}

public class WeatherInfo
{
    public string description { get; set; }
    public string icon { get; set; }
}

public class Main
{
    public double temp { get; set; }
    public double temp_min { get; set; }
    public double temp_max { get; set; }
}

public class ForecastItem
{
    public List<WeatherInfo> weather { get; set; }
    public Main main { get; set; }
    public string dt_txt { get; set; }
}

public class ForecastRoot
{
    public List<ForecastItem> list { get; set; }
    public CityInfo city { get; set; }
}

public class CityInfo
{
    public string name { get; set; }
    public string country { get; set; }
}