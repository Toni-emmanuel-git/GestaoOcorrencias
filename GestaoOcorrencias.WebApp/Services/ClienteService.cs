using GestaoOcorrencias.WebApp.Models;
using System.Text;
using System.Text.Json;
using static System.Net.Mime.MediaTypeNames;

namespace GestaoOcorrencias.WebApp.Services
{
    public class ClienteService : IClienteService
    {
        private readonly HttpClient httpClient;
        JsonSerializerOptions jsonOptions = new JsonSerializerOptions()
        {
            PropertyNameCaseInsensitive = true,
        };

        public ClienteService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task Create(ClienteViewModel cliente)
        {
            HttpContent content = new StringContent(JsonSerializer.Serialize(cliente), Encoding.UTF8, Application.Json);
            HttpResponseMessage response = await httpClient.PostAsync("/cliente", content);
            if (response.IsSuccessStatusCode == false)
                throw new Exception(await response.Content.ReadAsStringAsync());
        }

        public async Task Delete(int id)
        {
            HttpResponseMessage response = await httpClient.DeleteAsync($"/cliente/{id}");
            if (response.IsSuccessStatusCode == false)
                throw new Exception(await response.Content.ReadAsStringAsync());
        }

        public async Task<IEnumerable<ClienteViewModel>> Get()
        {
            HttpResponseMessage response = await httpClient.GetAsync($"/cliente");
            if (response.IsSuccessStatusCode == false)
                throw new Exception(await response.Content.ReadAsStringAsync());
            var stringResponse = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<IEnumerable<ClienteViewModel>>(stringResponse, jsonOptions);
        }

        public async Task<ClienteViewModel> Get(int id)
        {
            HttpResponseMessage response = await httpClient.GetAsync($"/cliente/{id}");
            if (response.IsSuccessStatusCode == false)
                throw new Exception(await response.Content.ReadAsStringAsync());
            var stringResponse = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<ClienteViewModel>(stringResponse, jsonOptions);
        }

        public async Task<IEnumerable<ClienteViewModel>> Search(string searchTerm)
        {
            HttpResponseMessage response = await httpClient.GetAsync($"/cliente/search/{searchTerm}");
            if (response.IsSuccessStatusCode == false)
                throw new Exception(await response.Content.ReadAsStringAsync());
            var stringResponse = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<IEnumerable<ClienteViewModel>>(stringResponse, jsonOptions);
        }

        public async Task Update(int id, ClienteViewModel cliente)
        {
            HttpContent content = new StringContent(JsonSerializer.Serialize(cliente, jsonOptions), Encoding.UTF8, Application.Json);
            HttpResponseMessage response = await httpClient.PutAsync($"/cliente/{id}", content);
            if (response.IsSuccessStatusCode == false)
                throw new Exception(await response.Content.ReadAsStringAsync());
        }
    }
}
