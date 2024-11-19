using AutoMapper;
using GestaoOcorrencias.Common.Dtos;
using GestaoOcorrencias.WebApi.Dtos;
using GestaoOcorrencias.WebApi.Entities;

namespace GestaoOcorrencias.WebApi.Mappers
{
    public class OcorrenciaMapper : Profile
    {
        public OcorrenciaMapper()
        {
            CreateMap<Ocorrencia, OcorrenciaDto>().ReverseMap();
        }
    }
}
