using AutoMapper;
using AvaliacaoTecnicaQuestor.Api.Models.DTOs;
using AvaliacaoTecnicaQuestor.Api.Models.Entities;
using AvaliacaoTecnicaQuestor.Api.Repositories;

namespace AvaliacaoTecnicaQuestor.Api.Services
{
    public class BoletoService : IBoletoService
    {
        private readonly IMapper _mapper;
        private readonly IBoletoRepository _boletoRepository;
        private readonly IBancoService _bancoService;

        public BoletoService(
            IMapper mapper,
            IBoletoRepository boletoRepository,
            IBancoService bancoService)
        {
            _mapper = mapper;
            _boletoRepository = boletoRepository;
            _bancoService = bancoService;
        }

        public async Task<Boleto> PostBoletoAsync(BoletoDTO boletoDTO)
        {
            var boleto = _mapper.Map<Boleto>(boletoDTO);
            return await _boletoRepository.CreateBoletoAsync(boleto);
        }

        public async Task<Boleto?> GetBoletoByIdAsync(long id)
        {
            var result = await _boletoRepository.GetBoletoByIdAsync(id);

            if (result != null && result.DataVencimento < DateTime.Now)
            {
                var banco = await _bancoService.GetBancoByIdAsync(result.BancoId);
                result.Valor *= CalculateInterest(result, banco);
                result.Valor = Math.Round(result.Valor, 2);
            }

            return result;
        }

        private static double CalculateInterest(Boleto result, Banco? banco)
        {
            if (banco == null) return 1;
            return Math.Pow((1 + banco.PercentualJuros), (DateTime.Now.Date - result.DataVencimento.Date).Days);
        }
    }
}
