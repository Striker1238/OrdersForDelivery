using System.Net.Http;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using AcceptingOrdersForDeliveryMVC.Models;

namespace AcceptingOrdersForDeliveryMVC.Services
{
    public class OrderService
    {
        private readonly HttpClient httpClient;
        private readonly string apiUrl = "https://localhost:7210/api/";
        

        public OrderService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<List<Order>> GetOrdersAsync()
        {
            var response = await httpClient.GetAsync($"{apiUrl}orders");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<List<Order>>();
        }

        public async Task<Order> GetOrderAsync(int id)
        {
            var response = await httpClient.GetAsync($"{apiUrl}orders/{id}");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<Order>();
        }

        public async Task<Order> CreateOrderAsync(Order order)
        {
            var response = await httpClient.PostAsJsonAsync($"{apiUrl}orders", order);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<Order>();
        }
    }
}