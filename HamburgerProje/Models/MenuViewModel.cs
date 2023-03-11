using HamburgerProje.Data;
using Microsoft.Build.Framework;

namespace HamburgerProje.Models
{
    public class MenuViewModel
    {
        [Required]
        public string? Ad { get; set; } = null!;
        public double Fiyat { get; set; }
        public int Adet { get; set; }
        public static List<Hamburger> Hamburgerler { get; set; } = new();
        public static List<Icecek> Icecekler { get; set; } = new();
        public static List<Sos> Soslar { get; set; } = new();
        public static List<Ekstra> Ekstralar { get; set; } = new();
        public static List<Siparis> Siparisler { get; set; } = new();
        public IFormFile Resim { get; set; } = null!;
        public int VarMi { get; set; } = 0;
       
    }
}
