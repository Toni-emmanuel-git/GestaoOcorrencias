using GestaoOcorrencias.WebApi.Entities;

namespace GestaoOcorrencias.WebApi.Services;

public interface IClienteService
{
    Task Create(Cliente cliente);
    Task<IEnumerable<Cliente>> Get();
    Task<Cliente> Get(int id);
    Task<IEnumerable<Cliente>> Search(string searchTerm);
    Task Update(int id, Cliente cliente);
    Task Delete(int id);
}
