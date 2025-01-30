
HttpClient client = new();
client.BaseAddress = new Uri("https://localhost:44373/");
var cts = new CancellationTokenSource(TimeSpan.FromSeconds(5)); // Timeout de 5 secondes
var response = await client.GetAsync("api/vols", cts.Token);

if (response.IsSuccessStatusCode)
{
    string resultat = await response.Content.ReadAsStringAsync();
    Console.WriteLine(resultat);
}

Console.ReadKey();