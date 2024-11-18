using AutoMapper;
using GestaoOcorrencias.Common.Dtos;
using GestaoOcorrencias.WebApi.Entities;

namespace GestaoOcorrencias.WebApi.Mappers
{
    public class ClienteMapper : Profile
    {
        public ClienteMapper()
        {
            CreateMap<Cliente, ClienteDto>()
                .ForMember(tgt => tgt.TelefonePrincipal, opt => opt.MapFrom(src => src.Telefone1))
                .ForMember(tgt => tgt.TelefoneSecundario, opt => opt.MapFrom(src => src.Telefone2))
                .ForMember(tgt => tgt.EmailPrincipal, opt => opt.MapFrom(src => src.Email1))
                .ForMember(tgt => tgt.EmailSecundario, opt => opt.MapFrom(src => src.Email2))

                .ReverseMap()

                .ForMember(tgt => tgt.Telefone1, opt => opt.MapFrom(src => src.TelefonePrincipal))
                .ForMember(tgt => tgt.Telefone2, opt => opt.MapFrom(src => src.TelefoneSecundario))
                .ForMember(tgt => tgt.Email1, opt => opt.MapFrom(src => src.EmailPrincipal))
                .ForMember(tgt => tgt.Email2, opt => opt.MapFrom(src => src.EmailSecundario));
        }
    }
}
