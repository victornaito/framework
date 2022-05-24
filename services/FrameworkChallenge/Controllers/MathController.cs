using Microsoft.AspNetCore.Mvc;
using System.Collections;
using System.Collections.ObjectModel;
using System.Linq;

namespace FrameworkChallenge.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MathController : ControllerBase
    {

        private readonly ILogger<MathController> _logger;

        public MathController(ILogger<MathController> logger)
        {
            _logger = logger;
        }

        [HttpGet("divisors/{number}")]
        [ResponseCache(VaryByHeader = "User-Agent", Duration = 60 * 60 * 2)]
        public IActionResult GetDivisors(int number)
        {
            if (number < 0) return BadRequest("Por favor, insira um numero natural (Maior ou igual a zero)");

            var divisors = new List<int>();
            var primes = new List<int>();

            for (int i = 0; i <= number; i++)
            {
                if (IsDivisorNumber(number, i)) divisors.Add(i);
                if (IsPrimeNumber(i)) primes.Add(i);
            }

            var dec = GetDecompositionNumber(number);

            return Ok(new
            {
                Divisors = divisors,
                Primes = primes,
                DecompositionNumber = dec,
                PrimesDivisors = dec.Distinct()
            });
        }

        private ICollection<int> GetDecompositionNumber(int number)
        {
            var decompositionNumber = new Collection<int>();
            var actualResult = number;

            while (actualResult > 1)
            {
                if (actualResult % 2 == 0)
                {
                    UpdateResult(decompositionNumber, ref actualResult, 2);
                    continue;
                }

                var sum = actualResult.ToString().ToArray().Select(_ => _.ToString()).Select(_ => int.Parse(_)).Sum();
                
                if (sum % 3 == 0)
                {
                    UpdateResult(decompositionNumber, ref actualResult, 3);
                    continue;
                }

                if (actualResult % 5 == 0)
                {
                    UpdateResult(decompositionNumber, ref actualResult, 5);
                    continue;
                }

                if (actualResult % 7 == 0)
                {
                    UpdateResult(decompositionNumber, ref actualResult, 7);
                    continue;
                }
            }

            return decompositionNumber.OrderBy(_ => _).ToArray();
        }

        private static void UpdateResult(Collection<int> decompositionNumber, ref int actualResult, int primeNumber)
        {
            actualResult = actualResult / primeNumber;
            decompositionNumber.Add(primeNumber);
        }

        private bool IsPrimeNumber(int number)
        {
            if (number == 0 || number == 1) return false;
            if (number != 2 && number % 2 == 0) return false;
            if (number != 3 && number % 3 == 0) return false;
            if (number != 5 && number % 5 == 0) return false;
            if (number != 7 &&  number % 7 == 0) return false;

            return true;
        }

        private static bool IsDivisorNumber(int number, int i) => i == 0 ? false : number % i == 0;
    }
}