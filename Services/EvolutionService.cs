using System.Net.Http;
using System.Text.Json;
public class EvolutionService
{
    public async Task<EvolutionResponse> ObtenerCadena(string url)
    {
        HttpClient cliente = new HttpClient();
        HttpResponseMessage response = await cliente.GetAsync(url);

        

        if (response.IsSuccessStatusCode)
        {
            string json = await response.Content.ReadAsStringAsync();
            EvolutionResponse evolutionResponse =
                JsonSerializer.Deserialize<EvolutionResponse>(json);

            return evolutionResponse;
        }
        else
        {
            return new EvolutionResponse();
        }
    }
}