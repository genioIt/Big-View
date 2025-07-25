using BlazorUserManagement.Models;
using System.Text.Json;

namespace BlazorUserManagement.Services
{
    public class CategoryService
    {
        private readonly HttpClient _httpClient;
        private readonly string _baseUrl = "http://localhost:5111/api/ProductCategories";

        public CategoryService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<ProductCategory>> GetAllActiveCategoriesAsync()
        {
            try
            {
                var response = await _httpClient.GetAsync($"{_baseUrl}/GetAllActiveCategories");
                
                if (response.IsSuccessStatusCode)
                {
                    var jsonContent = await response.Content.ReadAsStringAsync();
                    var categories = JsonSerializer.Deserialize<List<ProductCategory>>(jsonContent, new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    });
                    
                    return categories ?? new List<ProductCategory>();
                }
                else
                {
                    return new List<ProductCategory>();
                }
            }
            catch (Exception)
            {
                return new List<ProductCategory>();
            }
        }
    }
}