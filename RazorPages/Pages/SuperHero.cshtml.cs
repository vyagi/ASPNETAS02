using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RazorPages.Pages
{
    public class SuperHeroModel : PageModel
    {
        public void OnGet()
        {
            ViewData["Title"] = "Superheroes rule!";
        }

        public List<SuperHero> SuperHeroes = new List<SuperHero>
        {
            new SuperHero
            {
                Id = 1, 
                Name = "Superman",
                Age = 40,
                Powers = new List<string> {"Strength","Flying", "X-ray"}
            },
            new SuperHero
            {
                Id = 2,
                Name = "Batman",
                Age = 45,
                Powers = new List<string> {"Technology", "Money"}
            },
            new SuperHero
            {
                Id = 3,
                Name = "Spiderman",
                Age = 25,
                Powers = new List<string> {"Web", "JUmp"}
            }
        };
    }

    public class SuperHero
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public List<string> Powers { get; set; }
    }
}
