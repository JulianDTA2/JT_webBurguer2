using JT_webBurguer2.Models;
using System.ComponentModel.DataAnnotations;

namespace JT_webBurguer2.Models
{
    public class Promos
    {
        public int PromosId { get; set; }
        
        public string? Description { get; set; }
        public DateTime FechaPromo { get; set; }
        
        public int BurguerId { get; set; }
        public  Burguer? Burguer { get; set; }


    }
}
