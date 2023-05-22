using Refit;

namespace WebAppTailwin.Host.Services;

public interface IWeatherApi
{
    [Get("/data/2.5/weather?appid={appId}&lat={lat}&lon={lon}&lang=fr&units=metric")]
    public Task<GetWeatherResult> GetWeather([AliasAs("appId")] string appId, [AliasAs("lat")] double lat, [AliasAs("lon")] double lon);
}