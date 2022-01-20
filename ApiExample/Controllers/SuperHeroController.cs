using System;
using System.Collections.Generic;
using System.Linq;
using ApiExample.Model;
using Microsoft.AspNetCore.Mvc;

namespace ApiExample.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SuperHeroController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<SuperHero> Get()
        {
            return SuperHero.SuperHeroes;
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult Get(int id)
        {
            var hero = SuperHero.SuperHeroes
                .FirstOrDefault(x=>x.Id == id);

            if (hero == null)
            {
                return NotFound();
            }

            return Ok(hero);
        }

        [HttpPost]
        public IActionResult Post(CreateSuperHero newHero)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var hero = new SuperHero
            {
                Id = SuperHero.SuperHeroes.Max(x => x.Id) + 1,
                Name = newHero.Name,
                Age = newHero.Age,
                Powers = newHero.Powers.Split(",").ToList()
            };

            SuperHero.SuperHeroes.Add(hero);
            return Ok();
        }

        [HttpPut]
        public IActionResult Put(UpdateSuperHero updatedHero)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var hero = SuperHero.SuperHeroes
                .FirstOrDefault(x => x.Id == updatedHero.Id);

            if (hero == null)
            {
                return BadRequest();
            }

            hero.Name = updatedHero.Name;
            hero.Age = updatedHero.Age;
            hero.Powers = updatedHero.Powers.Split(",").ToList();

            return Ok();
        }
    }
}
