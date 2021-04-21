using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using harbour.model__views;
using Newtonsoft.Json;

namespace harbour.integration
{
    public class OpenWeather : IOpenWeather
    {
        private const string ApiKey = "f3928211f8bf8f72f33ad3c5031a4c1b";

        private static async Task<WeatherViewModel> GetGeographic()
        {
            //define api key
            const string path = "http://ip-api.com/json/";
            using var httpClient = new HttpClient();
            using var response = await httpClient.GetAsync(path);
            var apiResponse = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<WeatherViewModel>(apiResponse);
        }

        private static async Task<WeatherViewModelService> OpenWeatherService(string weatherApiUrl)
        {
            using var httpClient = new HttpClient();
            using var response = await httpClient.GetAsync(weatherApiUrl);
            var apiResponse = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<WeatherViewModelService>(apiResponse);
        }

        public double GetWindSpeed()
        {
            var geo = GetGeographic();
            //define weather url
            var weatherApiUrl = $"https://api.openweathermap.org/data/2.5/weather?q={geo.Result.City},{geo.Result.CountryCode}&appid={ApiKey}";

            var results = OpenWeatherService(weatherApiUrl);
            return Math.Round((results.Result.Wind.Speed * 3600) / 1000,0);
         
        }
    }
}