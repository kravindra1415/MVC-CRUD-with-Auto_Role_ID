using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Data.Models
{
    public class Nationality
    {
        public int Id { get; set; }

        [Unicode(false)]
        [StringLength(50)]
        public string Text { get; set; } = null!;


        [Unicode(false)]
        [StringLength(50)]
        public string Continent { get; set; } = null!;

        public int CountryPopulation { get; set; }
    }
}
