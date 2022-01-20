using System.Linq;
using Microsoft.AspNetCore.Mvc;
using MvcApp.Models;

namespace MvcApp.Controllers
{
    public class SuperHeroController : Controller
    {
        public IActionResult Index()
        {
            return View(SuperHero.SuperHeroes);
        }

        public IActionResult Details(int id)
        {
            var superhero = SuperHero
                .SuperHeroes
                .First(x => x.Id == id);
            
            return View(superhero);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(CreateSuperHero newHero)
        {
            if (!ModelState.IsValid)
            {
                return View(newHero);
            }
            
            var hero = new SuperHero
            {
                Id = SuperHero.SuperHeroes.Max(x=>x.Id) + 1,
                Name = newHero.Name,
                Age = newHero.Age,
                Powers = newHero.Powers.Split(",").ToList()
            };
            
            SuperHero.SuperHeroes.Add(hero);
            
            return RedirectToAction("Index");
        }
    }
}
