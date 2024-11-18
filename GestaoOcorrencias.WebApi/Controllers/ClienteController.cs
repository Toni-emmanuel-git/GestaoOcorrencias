using AutoMapper;
using GestaoOcorrencias.Common.Dtos;
using GestaoOcorrencias.WebApi.Entities;
using GestaoOcorrencias.WebApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace GestaoOcorrencias.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteService clienteService;
        private readonly IMapper mapper;

        public ClienteController(IClienteService clienteService, IMapper mapper)
        {
            this.clienteService = clienteService;
            this.mapper = mapper;
        }

        [HttpPost]
        public Task Create([FromBody]ClienteDto cliente)
        {
            var mappedCliente = mapper.Map<Cliente>(cliente);
            return clienteService.Create(mappedCliente);
        }

        [HttpGet]
        public async Task<IEnumerable<ClienteDto>> Get()
        {
            var clientes = await clienteService.Get();
            return mapper.Map<IEnumerable<ClienteDto>>(clientes);
        }

        [HttpGet($"{{id}}")]
        public async Task<ClienteDto> Get([FromRoute]int id)
        {
            var cliente = await clienteService.Get(id);
            return mapper.Map<ClienteDto>(cliente);
        }

        [HttpGet($"search/{{searchTerm}}")]
        public async Task<IEnumerable<ClienteDto>> Get([FromRoute]string searchTerm)
        {
            var clientes = await clienteService.Search(searchTerm);
            return mapper.Map<IEnumerable<ClienteDto>>(clientes);
        }

        [HttpPut($"{{id}}")]
        public Task Update([FromRoute] int id, [FromBody]ClienteDto cliente)
        {
            var mappedCliente = mapper.Map<Cliente>(cliente);
            return clienteService.Update(id, mappedCliente);
        }

        [HttpDelete($"{{id}}")]
        public Task Delete([FromRoute]int id)
        {
            return clienteService.Delete(id);
        }

    }
}
