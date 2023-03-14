using System.ComponentModel.DataAnnotations.Schema;

namespace HamburgerProje.Data
{
    public class Menu
    {
        public int Id { get; set; }
        public string? Ad { get; set; } = null!;
        public double Fiyat { get; set; }
        public int Adet { get; set; }
        public List<HamburgerMenu> HamburgerMenuler { get; set; }
        public List<IcecekMenu> IcecekMenuler { get; set; }
        public List<SosMenu> SosMenuler { get; set; }
        public List<EkstraMenu> EkstraMenuler { get; set; } = new();

        public List<MenuSiparis> MenuSiparisler { get; set; } = new();

        public string? Resim { get; set; } = null!;

    }
}
