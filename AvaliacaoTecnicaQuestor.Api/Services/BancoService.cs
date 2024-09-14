using AutoMapper;
using AvaliacaoTecnicaQuestor.Api.Models.DTOs;
using AvaliacaoTecnicaQuestor.Api.Models.Entities;
using AvaliacaoTecnicaQuestor.Api.Repositories;

namespace AvaliacaoTecnicaQuestor.Api.Services
{
    public class BancoService : IBancoService
    {
        private readonly IBancoRepository _bancoRepository;
        private readonly IMapper _mapper;

        public BancoService(
            IBancoRepository bancoRepository,
            IMapper mapper)
        {
            _bancoRepository = bancoRepository;
            _mapper = mapper;
        }

        public async Task<List<Banco>> GetBancosAsync()
        {
            return await _bancoRepository.GetBancosAsync();
        }

        public async Task<Banco?> GetBancoByCodigoAsync(string codigo)
        {
            return await _bancoRepository.GetBancoByCodigoAsync(codigo);
        }

        public async Task<Banco> PostBancoAsync(BancoDTO bancoDTO)
        {
            var banco = _mapper.Map<Banco>(bancoDTO);
            return await _bancoRepository.CreateBancoAsync(banco);
        }
    }
}
