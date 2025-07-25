using BlazorUserManagement.Models;
using System.Text;
using System.Text.Json;

namespace BlazorUserManagement.Services
{
    public class AuthService
    {
        private readonly HttpClient _httpClient;
        private readonly string _baseUrl = "http://localhost:5111/api/Auth";

        public AuthService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<LoginResponse> LoginAsync(LoginRequest loginRequest)
        {
            try
            {
                var json = JsonSerializer.Serialize(loginRequest);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                
                var response = await _httpClient.PostAsync($"{_baseUrl}/login", content);
                
                if (response.IsSuccessStatusCode)
                {
                    var responseContent = await response.Content.ReadAsStringAsync();
                    var loginResponse = JsonSerializer.Deserialize<LoginResponse>(responseContent, new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    });
                    
                    return loginResponse ?? new LoginResponse { Success = false, Message = "Error en la respuesta del servidor" };
                }
                else
                {
                    return new LoginResponse 
                    { 
                        Success = false, 
                        Message = "Credenciales inválidas o error del servidor" 
                    };
                }
            }
            catch (Exception ex)
            {
                return new LoginResponse 
                { 
                    Success = false, 
                    Message = $"Error de conexión: {ex.Message}" 
                };
            }
        }
    }
}