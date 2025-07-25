using BlazorUserManagement.Models;
using System.Text;
using System.Text.Json;

namespace BlazorUserManagement.Services
{
    public class CartService
    {
        private readonly HttpClient _httpClient;
        private readonly string _baseUrl = "http://localhost:5111/api/Cart";

        public CartService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<bool> AddItemToCartAsync(CartItem cartItem)
        {
            try
            {
                var json = JsonSerializer.Serialize(cartItem);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                
                var response = await _httpClient.PostAsync($"{_baseUrl}/AddItemsCart", content);
                return response.IsSuccessStatusCode;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<List<CartProduct>> GetCartProductsAsync(string userId)
        {
            try
            {
                var response = await _httpClient.GetAsync($"{_baseUrl}/GetCartProduct/{userId}");
                
                if (response.IsSuccessStatusCode)
                {
                    var jsonContent = await response.Content.ReadAsStringAsync();
                    var products = JsonSerializer.Deserialize<List<CartProduct>>(jsonContent, new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    });
                    
                    return products ?? new List<CartProduct>();
                }
                else
                {
                    return new List<CartProduct>();
                }
            }
            catch (Exception)
            {
                return new List<CartProduct>();
            }
        }

        public async Task<bool> RemoveProductFromCartAsync(string userId, string productId)
        {
            try
            {
                var requestData = new
                {
                    userId = int.Parse(userId),
                    productId = int.Parse(productId),
                    active = false
                };

                var json = JsonSerializer.Serialize(requestData);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                
                var response = await _httpClient.PostAsync($"{_baseUrl}/ActiveProductCart", content);
                return response.IsSuccessStatusCode;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}