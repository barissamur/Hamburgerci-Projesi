using HamburgerProje.Data;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Build.Framework;

namespace HamburgerProje.Models
{
    public class MenuViewModel
    {
        [Required]
        public string? Ad { get; set; } = null!;
        public double Fiyat { get; set; }
        public int Adet { get; set; }
        public List<Hamburger> Hamburgerler { get; set; } = new();
        public List<Icecek> Icecekler { get; set; } = new();
        public List<Sos> Soslar { get; set; } = new();
        public List<Ekstra> Ekstralar { get; set; } = new();
        public List<Siparis> Siparisler { get; set; } = new();
        public IFormFile Resim { get; set; } = null!;
    }
}
