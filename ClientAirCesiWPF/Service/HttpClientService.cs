using AirCesiModel.Dto;
using Newtonsoft.Json;
using System.Net.Http;

namespace ClientAirCesiWPF.Service;
internal class HttpClientService
{
    private const string baseAddress = "https://localhost:44373/api/";
    private static HttpClient Client { get => new() { BaseAddress = new Uri(baseAddress) }; }

    public static async Task<List<VolDto>> GetVolLights(DateTime dateJour)
    {
        string route = $"vols/search/{dateJour.ToString("yyyy-MM-dd")}";
        var response = await Client.GetAsync(route);

        if (response.IsSuccessStatusCode)
        {
            string resultat = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<VolDto>>(resultat)
                ?? throw new FormatException($"Erreur Http : {route}");
        }
        throw new Exception(response.ReasonPhrase);
    }



}
