using BlazorUserManagement.Models;
using System.Text.Json;

namespace BlazorUserManagement.Services
{
    public class ProductService
    {
        private readonly HttpClient _httpClient;
        private readonly string _baseUrl = "http://localhost:5111/api/Product";

        public ProductService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Product>> GetByCategoryActiveAsync(int categoryId)
        {
            try
            {
                var response = await _httpClient.GetAsync($"{_baseUrl}/GetByCategoryActive/{categoryId}");
                
                if (response.IsSuccessStatusCode)
                {
                    var jsonContent = await response.Content.ReadAsStringAsync();
                    var products = JsonSerializer.Deserialize<List<Product>>(jsonContent, new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    });
                    
                    return products ?? new List<Product>();
                }
                else
                {
                    return new List<Product>();
                }
            }
            catch (Exception)
            {
                return new List<Product>();
            }
        }
    }
}