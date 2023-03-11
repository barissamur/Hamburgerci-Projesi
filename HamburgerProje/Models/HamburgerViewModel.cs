using HamburgerProje.Data;

namespace HamburgerProje.Models
{
    public class HamburgerViewModel
    {
        public int Id { get; set; }
        public string Ad { get; set; } = null!;
        public double Fiyat { get; set; }
        public List<Menu> Menuler { get; set; } = new();
        public List<Siparis> Siparisler { get; set; } = new();
        public IFormFile? Resim { get; set; } = null!;
    }
}
