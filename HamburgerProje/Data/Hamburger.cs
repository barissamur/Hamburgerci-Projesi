namespace HamburgerProje.Data
{
    public class Hamburger
    {
        public int Id { get; set; }
        public string Ad { get; set; } = null!;
        public int Adet { get; set; }
        public double Fiyat { get; set; }
        public ICollection<HamburgerMenu> HamburgerMenuler { get; set; }
        public List<HamburgerSiparis> HamburgerSiparisler { get; set; } = new();
        public string? Resim { get; set; } = null!;

    }
}
