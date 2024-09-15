using AvaliacaoTecnicaQuestor.Api.Models.DTOs;
using AvaliacaoTecnicaQuestor.Api.Models.Entities;
using AvaliacaoTecnicaQuestor.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace AvaliacaoTecnicaQuestor.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BoletosController : Controller
    {
        private readonly IBoletoService _boletoService;
        private readonly ILogger<BoletosController> _logger;

        public BoletosController(
            IBoletoService boletoService,
            ILogger<BoletosController> logger)
        {
            _boletoService = boletoService;
            _logger = logger;
        }

        /// <summary>
        /// Busca um boleto pelo Id
        /// </summary>
        /// <param name="id">Id do boleto a ser buscado</param>
        /// <returns>O boleto cadastrado, se existir</returns>
        /// <response code="200">Retorna o boleto cadastrado</response>
        /// <response code="404">Se o boleto não foi encontrado</response>
        /// <response code="500">Erro inesperado ao buscar o boleto</response>
        [HttpGet("{id}")]
        public async Task<ActionResult<List<Boleto>>> GetBoletoByCodigo([FromRoute] long id)
        {
            try
            {
                var result = await _boletoService.GetBoletoByIdAsync(id);

                if (result == null)
                {
                    return NotFound($"Boleto com Id {id} não encontrado");
                }
                else
                {
                    return Ok(result);
                }
            }
            catch (Exception e)
            {
                _logger.LogError($"Erro ao buscar banco: {e.Message}");
                return StatusCode(500, new { error = "Não foi possível buscar o banco" });
            }
        }

        /// <summary>
        /// Cria um novo boleto
        /// </summary>
        /// <param name="boleto">Objeto do boleto para ser criado</param>
        /// <returns>O boleto criado junto com o seu ID no banco de dados</returns>
        /// <response code="200">Retorna o novo boleto cadastrado</response>
        /// <response code="400">Ocorreu um erro de validação dos dados</response>
        /// <response code="500">Erro inesperado ao criar o boleto</response>
        [HttpPost]
        public async Task<ActionResult<Boleto>> CreateBoleto([FromBody] BoletoDTO boleto)
        {
            try
            {
                return Ok(await _boletoService.PostBoletoAsync(boleto));
            }
            catch (Exception e)
            {
                _logger.LogError($"Erro ao criar banco: {e.Message}");
                return StatusCode(500, new { error = "Não foi possível criar o banco" });
            }
        }
    }
}
