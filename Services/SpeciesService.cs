using System.Text.Json;
public class SpeciesService
{
    public async Task<SpeciesResponse> ObtenerSpecies(string url)
    {
        HttpClient cliente = new HttpClient();

        HttpResponseMessage response = await cliente.GetAsync(url);

        if(response.IsSuccessStatusCode)
        {
            string json = await response.Content.ReadAsStringAsync();

            SpeciesResponse speciesResponse =
                JsonSerializer.Deserialize<SpeciesResponse>(json);

            return speciesResponse;
        }
        else
        {
            return new SpeciesResponse();
        }
    }
}