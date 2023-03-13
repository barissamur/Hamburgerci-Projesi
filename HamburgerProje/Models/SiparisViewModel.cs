using HamburgerProje.Data;

namespace HamburgerProje.Models
{
    public class SiparisViewModel
    {
        public double Toplam { get; set; }
        public List<Hamburger> Hamburgerler { get; set; } = new();
        public List<Icecek> Icecekler { get; set; } = new();
        public List<Sos> Soslar { get; set; } = new();
        public List<Ekstra> Ekstralar { get; set; } = new();
        public List<Menu> Menuler { get; set; } = new();
    }
}
