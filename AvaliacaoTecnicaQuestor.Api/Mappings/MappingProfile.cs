using AutoMapper;
using AvaliacaoTecnicaQuestor.Api.Models.DTOs;
using AvaliacaoTecnicaQuestor.Api.Models.Entities;

namespace AvaliacaoTecnicaQuestor.Api.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Banco, BancoDTO>();
            CreateMap<BancoDTO, Banco>();

            CreateMap<Boleto, BoletoDTO>();
            CreateMap<BoletoDTO, Boleto>();
        }
    }
}
