using Microsoft.AspNetCore.Mvc;
using WebAPILearnings.Models;

namespace WebAPILearnings.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperHeroController : Controller
    {
        // public IActionResult Index()
        // {      return View();  }

        public static List<SuperHero> heroes = new List<SuperHero>
            {
                new SuperHero
                {
                    Id = 1,
                    Name = "Spider Man",
                    FirstName = "Peter",
                    SecondName = "Parker",
                    Place = "New York City"
                },
                new SuperHero
                {
                    Id = 2,
                    Name = "IronMan",
                    FirstName = "Tony",
                    SecondName = "Stark",
                    Place = "USA America"
                }
            };
        private readonly DataContext _context;

        public SuperHeroController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<SuperHero>>> Get()
        {     
            return Ok(await _context.superHeroes.ToListAsync());
        }

        [HttpGet("{id}")]

        public async Task<ActionResult<SuperHero>> GetSingleHero(int id)
        {
            var hero = await _context.superHeroes.FindAsync(id);
            if (hero == null)
                return BadRequest("Hero Not Found");
            return Ok(hero);
        }

        [HttpPost]
        public async Task<ActionResult<List<SuperHero>>> AddHero(SuperHero hero)
        {
            _context.superHeroes.Add(hero);

            await _context.SaveChangesAsync();
            return Ok(await _context.superHeroes.ToListAsync());
        }

        [HttpPut]

        public async Task<ActionResult<List<SuperHero>>> UpdateHero(SuperHero request)
        {
            var dbHero = await _context.superHeroes.FindAsync(request.Id);
            if(dbHero == null)
                return BadRequest("Hero Not Found");

            dbHero.Name = request.Name;
            dbHero.FirstName = request.FirstName;
            dbHero.SecondName = request.SecondName;
            dbHero.Place = request.Place;

            await _context.SaveChangesAsync();

            return Ok(await _context.superHeroes.ToListAsync());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<SuperHero>>> RemoveHero(int id)
        {
            var dbHero = await _context.superHeroes.FindAsync(id);
            if (dbHero == null)
              return BadRequest("Hero Not Found");

            _context.superHeroes.Remove(dbHero);

            await _context.SaveChangesAsync();
            return Ok(await _context.superHeroes.ToListAsync());
        }
    }
}
