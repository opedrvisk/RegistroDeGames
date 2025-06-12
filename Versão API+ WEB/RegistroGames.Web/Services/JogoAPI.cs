using RegistroGames.Web.Response;
using System.Net.Http.Json;

namespace RegistroGames.Web.Services;

public class JogoAPI
{
    private readonly HttpClient _httpClient;
    public JogoAPI(IHttpClientFactory factory)
    {
        _httpClient = factory.CreateClient("API");
    }

    public async Task<ICollection<JogoResponse>?> GetJogosAsync()
    {
        return await _httpClient.GetFromJsonAsync<ICollection<JogoResponse>>("jogos");
    }
}