using RegistroGames.Web.Requests;
using RegistroGames.Web.Response;
using System.Net.Http.Json;

namespace RegistroGames.Web.Services;

public class DesenvolvedoraAPI
{
    private readonly HttpClient _httpClient;

    public DesenvolvedoraAPI(IHttpClientFactory factory)
    {
        _httpClient = factory.CreateClient("API");
    }

    public async Task<ICollection<DesenvolvedoraResponse>?> GetDesenvolvedorasAsync()
    {
        return await _httpClient.GetFromJsonAsync<ICollection<DesenvolvedoraResponse>>("desenvolvedoras");
    }

    public async Task AddDesenvolvedoraAsync(DesenvolvedoraRequest desenvolvedora)
    {
        await _httpClient.PostAsJsonAsync("desenvolvedoras", desenvolvedora);
    }

    public async Task<DesenvolvedoraResponse?> GetDesenvolvedoraPorNomeAsync(string nome)
    {
        return await _httpClient.GetFromJsonAsync<DesenvolvedoraResponse>($"desenvolvedoras/{nome}");
    }

    public async Task DeleteDesenvolvedoraAsync(int id)
    {
        await _httpClient.DeleteAsync($"desenvolvedoras/{id}");
    }

    public async Task UpdateDesenvolvedoraAsync(DesenvolvedoraRequestEdit desenvolvedora)
    {
        await _httpClient.PutAsJsonAsync("desenvolvedoras", desenvolvedora);
    }

    public async Task AvaliaDesenvolvedoraAsync(int desenvolvedoraId, double nota)
    {
        await _httpClient.PostAsJsonAsync("desenvolvedoras/avaliacao", new { desenvolvedoraId, nota });
    }

    public async Task<AvaliacaoDaDesenvolvedoraResponse?> GetAvaliacaoDaPessoaLogadaAsync(int desenvolvedoraId)
    {
        return await _httpClient
            .GetFromJsonAsync<AvaliacaoDaDesenvolvedoraResponse?>($"desenvolvedoras/{desenvolvedoraId}/avaliacao");
    }
}
