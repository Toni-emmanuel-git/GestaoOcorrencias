using GestaoOcorrencias.WebApp.Models;

namespace GestaoOcorrencias.WebApp.Services
{
    public interface IClienteService
    {
        Task Create(ClienteViewModel cliente);
        Task<IEnumerable<ClienteViewModel>> Get();
        Task<ClienteViewModel> Get(int id);
        Task<IEnumerable<ClienteViewModel>> Search(string searchTerm);
        Task Update(int id, ClienteViewModel cliente);
        Task Delete(int id);
    }
}
