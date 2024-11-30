using JT_webBurguer2.Models;
using System.ComponentModel.DataAnnotations;

namespace JT_webBurguer2.Models
{
    public class Burguer
    {
        public int BurguerId { get; set; }
        [Required]
        public string? BurguerName { get; set; }
        public bool withCheese { get; set; }
        
        public decimal price { get; set; }
        [Range(0.01, 99.99)]
        public decimal priceCeiling { get; set; }
        public List<Promos>? Promos { get; set; }



    }
}
