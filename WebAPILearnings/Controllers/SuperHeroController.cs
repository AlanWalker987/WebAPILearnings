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

        [HttpGet]
        public async Task<ActionResult<List<SuperHero>>> Get()
        {     
            return Ok(heroes);
        }

        [HttpGet("{id}")]

        public async Task<ActionResult<SuperHero>> GetSingleHero(int id)
        {
            var hero = heroes.Find(h => h.Id == id);
            if (hero == null)
                return BadRequest("Hero Not Found");
            return Ok(hero);
        }

        [HttpPost]
        public async Task<ActionResult<List<SuperHero>>> AddHero(SuperHero hero)
        {
            heroes.Add(hero);
            return Ok(heroes);
        }

        [HttpPut]

        public async Task<ActionResult<List<SuperHero>>> UpdateHero(SuperHero request)
        {
            var hero = heroes.Find(h => h.Id == request.Id);
            if(hero == null)
                return BadRequest("Hero Not Found");

            hero.Name = request.Name;
            hero.FirstName = request.FirstName;
            hero.SecondName = request.SecondName;
            hero.Place = request.Place;

            return Ok(heroes);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<SuperHero>>> RemoveHero(int id)
        {
            var hero = heroes.Find(h => h.Id == id);
            if (hero == null)
              return BadRequest("Hero Not Found");

            heroes.Remove(hero);
            return Ok(heroes);
        }
    }
}
