using Client.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace Client.Services
{
    public class ShopService : IShopService
    {
        private HttpClient httpClient { get; }

        public ShopService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async void CreatePet(PetDTO petDTO)
        {
            var jsonString = JsonSerializer.Serialize(petDTO);
            var httpContent = new StringContent(jsonString, Encoding.UTF8, "application/json");
            using var response = await httpClient.PutAsync("https://localhost:44336/api/CreatePet", httpContent);
            response.EnsureSuccessStatusCode();
        }

        public async Task<IEnumerable<PetDTO>> GetPets()
        {
            using var response = await httpClient.GetAsync("https://localhost:44336/api/GetPets");
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();

            return JsonSerializer.Deserialize<IEnumerable<PetDTO>>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }

        public async Task<IEnumerable<PetDTO>> GetFreePets()
        {
            using var response = await httpClient.GetAsync("https://localhost:44336/api/GetFreePets");
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();

            return JsonSerializer.Deserialize<IEnumerable<PetDTO>>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }

        public async Task<PetDTO> GetPet(int? id)
        {
            using var response = await httpClient.GetAsync("https://localhost:44336/api/GetPet/?id=" + id.ToString());
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();

            return JsonSerializer.Deserialize<PetDTO>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }

        public async Task<OrderDTO> GetOrders(int? orderId)
        {
            using var response = await httpClient.GetAsync("https://localhost:44336/api/GetOrders/?orderId=" + orderId.ToString());
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();

            return JsonSerializer.Deserialize<OrderDTO>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }

        public async void MakeOrder(OrderDTO orderDTO)
        {
            var jsonString = JsonSerializer.Serialize(orderDTO);
            var httpContent = new StringContent(jsonString, Encoding.UTF8, "application/json");
            using var response = await httpClient.PutAsync("https://localhost:44336/api/MakeOrder", httpContent);
            response.EnsureSuccessStatusCode();
        }
    }
}
