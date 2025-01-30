using AirCesiFrontWeb.Components;
using AirCesiFrontWeb.ModelDtos;
using Azure;
using Microsoft.AspNetCore.Routing;
using Newtonsoft.Json;
using System;
using System.Diagnostics;
using System.Net;
using System.Text;

namespace AirCesiFrontWeb.Services;

public class ApiService
{
    private readonly HttpClient _httpClient;
    private  CookieContainer _cookieContainer = new();

    public ApiService(string baseAddress)
    {
        var handler = new HttpClientHandler() { CookieContainer = _cookieContainer };
        _httpClient = new(handler) { BaseAddress = new Uri(baseAddress) };
    }

    public async Task<bool> Login(string username, string password)
    {
        string route = "login?useCookies=true&useSessionCookies=true";
        var jsonString = "{ \"email\": \"" + username + "\", \"password\": \"" + password + "\" }";

        var httpContent = new StringContent(jsonString, Encoding.UTF8, "application/json");
        var response = await _httpClient.PostAsync(route, httpContent);

        return response.IsSuccessStatusCode ? true : throw new Exception(response.ReasonPhrase);
    }

    public async Task<List<VolDto>> GetVols()
    {
        var cts = new CancellationTokenSource(TimeSpan.FromSeconds(5)); // Timeout de 5 secondes
        var response = await _httpClient.GetAsync("api/vols", cts.Token);

        if (response.IsSuccessStatusCode)
        {
            string resultat = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<VolDto>>(resultat)
                ?? throw new FormatException($"Erreur Http : api/vols");
        }

        return new List<VolDto>();
    }

    public async Task<List<VolDto>> SearchVols(DateTime dateJour)
    {
        var cts = new CancellationTokenSource(TimeSpan.FromSeconds(5)); // Timeout de 5 secondes
        string route = $"api/vols/search/{dateJour.ToString("yyyy-MM-dd")}";
        var response = await _httpClient.GetAsync(route, cts.Token);

        if (response.IsSuccessStatusCode)
        {
            string resultat = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<VolDto>>(resultat)
                ?? throw new FormatException($"Erreur Http : api/vols");
        }

        return new List<VolDto>();
    }
}
