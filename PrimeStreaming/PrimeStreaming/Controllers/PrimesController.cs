using PrimeStreaming;
using Microsoft.AspNetCore.Mvc;
using System.Numerics;

namespace PrimeStreaming.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PrimesController : ControllerBase
    {
        [HttpGet("{bottom}/{qty}")]
        public int[] GetPrimes(int bottom, int qty)
        {
            var streamed = Primes.Stream();
            return streamed.Skip(bottom).Take(qty).ToArray();
        }
    }
}
