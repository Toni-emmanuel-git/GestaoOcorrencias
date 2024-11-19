using AutoMapper;
using GestaoOcorrencias.Common.Dtos;
using GestaoOcorrencias.WebApi.Dtos;
using GestaoOcorrencias.WebApi.Entities;
using GestaoOcorrencias.WebApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace GestaoOcorrencias.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OcorrenciaController : ControllerBase
    {
        private readonly IOcorrenciaService ocorrenciaService;
        private readonly IMapper mapper;

        public OcorrenciaController(IOcorrenciaService ocorrenciaService, IMapper mapper)
        {
            this.ocorrenciaService = ocorrenciaService;
            this.mapper = mapper;
        }

        [HttpPost]
        public Task Create([FromBody] OcorrenciaDto ocorrencia)
        {
            var mappedCliente = mapper.Map<Ocorrencia>(ocorrencia);
            return ocorrenciaService.Create(mappedCliente);
        }

        [HttpGet]
        public async Task<IEnumerable<OcorrenciaDto>> Get()
        {
            var ocorrencias = await ocorrenciaService.Get();
            return mapper.Map<IEnumerable<OcorrenciaDto>>(ocorrencias);
        }

        [HttpGet($"{{id}}")]
        public async Task<OcorrenciaDto> Get([FromRoute] int id)
        {
            var ocorrencia = await ocorrenciaService.Get(id);
            return mapper.Map<OcorrenciaDto>(ocorrencia);
        }

        [HttpPut($"{{id}}")]
        public Task Update([FromRoute] int id, [FromBody] OcorrenciaDto ocorrencia)
        {
            var mappedOcorrencia = mapper.Map<Ocorrencia>(ocorrencia);
            return ocorrenciaService.Update(id, mappedOcorrencia);
        }

        [HttpDelete($"{{id}}")]
        public Task Delete([FromRoute] int id)
        {
            return ocorrenciaService.Delete(id);
        }

    }
}
