using GestaoOcorrencias.WebApi.Entities;
using Microsoft.EntityFrameworkCore;

namespace GestaoOcorrencias.WebApi.Services
{
    public class ClienteService : IClienteService
    {
        private readonly GestaoOcorrenciasDbContext gestaoOcorrenciasDbContext;
        private DbSet<Cliente> Clientes => gestaoOcorrenciasDbContext.Clientes;

        public ClienteService(GestaoOcorrenciasDbContext gestaoOcorrenciasDbContext)
        {
            this.gestaoOcorrenciasDbContext = gestaoOcorrenciasDbContext;
        }
        public async Task Create(Cliente cliente)
        {
            await Clientes.AddAsync(cliente);
            await gestaoOcorrenciasDbContext.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var cliente = await Get(id);
            Clientes.Remove(cliente);
            await gestaoOcorrenciasDbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Cliente>> Get()
        {
            return await Clientes.ToListAsync();
        }

        public async Task<Cliente> Get(int id)
        {
            return await Clientes.FirstOrDefaultAsync(cliente => cliente.Id == id);
        }

        public async Task<IEnumerable<Cliente>> Search(string searchTerm)
        {
            return await Clientes.Where(cliente => cliente.Nome == searchTerm || cliente.Codigo == searchTerm).ToListAsync();
        }

        public async Task Update(int id, Cliente cliente)
        {
            var existingCliente = await Get(id);
            if (existingCliente != null) 
            {
                existingCliente.Codigo = cliente.Codigo;
                existingCliente.Nome = cliente.Nome;
                existingCliente.Telefone1 = cliente.Telefone1;
                existingCliente.Telefone2 = cliente.Telefone2;
                existingCliente.Email1 = cliente.Email1;
                existingCliente.Email2 = cliente.Email2;
                existingCliente.Endereco = cliente.Endereco;
            }
            Clientes.Update(existingCliente);
            await gestaoOcorrenciasDbContext.SaveChangesAsync();
        }
    }
}
