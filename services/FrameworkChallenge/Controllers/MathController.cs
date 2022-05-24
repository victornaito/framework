using FrameworkChallenge.API.Application.Queries;
using Microsoft.AspNetCore.Mvc;

namespace FrameworkChallenge.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MathController : ControllerBase
    {

        private readonly ILogger<MathController> _logger;
        private readonly ICalculatePrimeNumbers _calculatePrimeNumbers;

        public MathController(ILogger<MathController> logger, ICalculatePrimeNumbers calcularNumerosPrimos)
        {
            _logger = logger;
            this._calculatePrimeNumbers = calcularNumerosPrimos;
        }

        [HttpGet("dividers/{number}")]
        [ResponseCache(VaryByHeader = "User-Agent", Duration = 60 * 60 * 2)]
        public IActionResult GetDividerNumbers(int number)
        {
            if (number < 0) return BadRequest("Por favor, insira um numero natural (Maior ou igual a zero)");

            var primeNumbers =_calculatePrimeNumbers.Calculate(number);
            if (primeNumbers == null) return BadRequest("Por favor, insira um numero natural (Primo)");
            return Ok(primeNumbers);
        }
    }
}