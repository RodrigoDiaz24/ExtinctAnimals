using ExtinctAnimals.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ExtinctAnimals.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AnimalsController : Controller
    {
        private readonly IAnimalService _animalService;

        public AnimalsController(IAnimalService animalService)
        {
            _animalService = animalService;
        }

        [HttpGet("random")]
        public async Task<IActionResult> GetRandom(CancellationToken ct)
        {
            return Ok(await _animalService.GetRandomAsync(ct));
        }

        [HttpGet]
        public async Task<IActionResult> GetMany(
            [FromQuery] int count = 10,
            CancellationToken ct = default)
        {
            return Ok(await _animalService.GetManyAsync(count, ct));
        }
    }
}
