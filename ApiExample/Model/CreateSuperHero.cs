using System.ComponentModel.DataAnnotations;

namespace ApiExample.Model
{
    public class CreateSuperHero
    {
        [Required(ErrorMessage = "Hero needs a name")]
        public string Name { get; set; }
        
        [Range(18,99, ErrorMessage = "Hero needs to be adult but not too old")]
        public int Age { get; set; }

        [Required(ErrorMessage = "Hero needs powers")]
        [RegularExpression("[a-zA-Z]*(,[a-zA-Z]*)+", ErrorMessage = "Powers need to be comma separated string")]
        public string Powers { get; set; }
    }
}
