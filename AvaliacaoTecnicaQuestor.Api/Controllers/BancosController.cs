using AvaliacaoTecnicaQuestor.Api.Models.DTOs;
using AvaliacaoTecnicaQuestor.Api.Models.Entities;
using AvaliacaoTecnicaQuestor.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace AvaliacaoTecnicaQuestor.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BancosController : Controller
    {
        private readonly IBancoService _bancoService;
        private readonly ILogger<BancosController> _logger;

        public BancosController(
            IBancoService bancoService,
            ILogger<BancosController> logger)
        {
            _bancoService = bancoService;
            _logger = logger;
        }

        /// <summary>
        /// Lista os bancos cadastrados no sistema
        /// </summary>
        /// <returns>Todos os bancos cadastrados</returns>
        /// <response code="200">Retorna a lista de bancos cadastrados</response>
        /// <response code="500">Erro inesperado ao buscar os bancos</response>
        [HttpGet]
        public async Task<ActionResult<List<Banco>>> GetBancos()
        {
            try
            {
                return Ok(await _bancoService.GetBancosAsync());
            }
            catch (Exception e)
            {
                _logger.LogError($"Erro ao buscar bancos: {e.Message}");
                return StatusCode(500, new { error = "Não foi possível buscar os bancos" });
            }
        }

        /// <summary>
        /// Busca um banco pelo código
        /// </summary>
        /// <param name="codigo">Código do banco a ser buscado</param>
        /// <returns>O banco cadastrado, se existir</returns>
        /// <response code="200">Retorna o banco cadastrado</response>
        /// <response code="404">Se o banco não foi encontrado</response>
        /// <response code="500">Erro inesperado ao buscar os bancos</response>

        [HttpGet("{codigo}")]
        public async Task<ActionResult<List<Banco>>> GetBancoByCodigo([FromRoute] string codigo)
        {
            try
            {
                var result = await _bancoService.GetBancoByCodigoAsync(codigo);

                if (result == null)
                {
                    return NotFound($"Banco com código {codigo} não encontrado");
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
        /// Cria um novo banco
        /// </summary>
        /// <param name="banco">Objeto do banco para ser criado</param>
        /// <returns>O banco criado junto com o seu ID no banco</returns>
        /// <response code="200">Retorna o novo banco cadastrado</response>
        /// <response code="400">Ocorreu um erro de validação dos dados</response>
        /// <response code="500">Erro inesperado ao criar o banco</response>
        [HttpPost]
        public async Task<ActionResult<Banco>> CreateBanco([FromBody] BancoDTO banco)
        {
            try
            {
                return Ok(await _bancoService.PostBancoAsync(banco));
            }
            catch (Exception e)
            {
                _logger.LogError($"Erro ao criar banco: {e.Message}");
                return StatusCode(500, new { error = "Não foi possível criar o banco" });
            }
        }
    }
}
