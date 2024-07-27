using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

public static class ApiClient
{
    private static readonly HttpClient client = new HttpClient
    {
        BaseAddress = new System.Uri("https://localhost:7261/api/") 
    };

    public static async Task<T> GetAsync<T>(string url)
    {
        var response = await client.GetAsync(url);
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadFromJsonAsync<T>();
    }

    public static async Task PostAsync<T>(string url, T item)
    {
        var response = await client.PostAsJsonAsync(url, item);
        response.EnsureSuccessStatusCode();
    }

    public static async Task PutAsync<T>(string url, T item)
    {
        var response = await client.PutAsJsonAsync(url, item);
        response.EnsureSuccessStatusCode();
    }

    public static async Task DeleteAsync(string url)
    {
        var response = await client.DeleteAsync(url);
        response.EnsureSuccessStatusCode();
    }
}
