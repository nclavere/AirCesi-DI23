using AirCesiModel.Dto;
using AirCesiModel.Entities;
using Microsoft.AspNetCore.Identity;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Net;
using System.Net.Http;
using System.Text;

namespace ClientAirCesiWPF.Service;
internal class HttpClientService
{
    private const string baseAddress = "https://localhost:44373/";
    private static HttpClient? client;
    private static CookieContainer cookieContainer = new();

    private static HttpClient Client
    {
        get
        {
            if (client == null)
            {
                var handler = new HttpClientHandler() { CookieContainer = cookieContainer };
                client = new(handler) { BaseAddress = new Uri(baseAddress) };
            }
            return client;
        }
    }

    public static async Task<bool> Login(string username, string password)
    {
        string route = "login?useCookies=true&useSessionCookies=true";
        var jsonString = "{ \"email\": \"" + username + "\", \"password\": \"" + password + "\" }";

        var httpContent = new StringContent(jsonString, Encoding.UTF8, "application/json");
        var response = await Client.PostAsync(route, httpContent);

        var cookies = cookieContainer.GetCookies(new Uri(baseAddress));
        Debug.WriteLine(cookies);

        return response.IsSuccessStatusCode ? true :
            throw new Exception(response.ReasonPhrase);
    }

    public static async Task<List<VolDto>> GetVolLights(DateTime dateJour)
    {
        string route = $"api/vols/search/{dateJour.ToString("yyyy-MM-dd")}";
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
