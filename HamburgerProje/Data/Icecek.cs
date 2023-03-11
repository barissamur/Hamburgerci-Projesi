namespace HamburgerProje.Data
{
    public class Icecek
    {
        public int Id { get; set; }
        public string Ad { get; set; } = null!;
        public double Fiyat { get; set; }
        public List<Menu> Menuler { get; set; } = new();
        public List<Siparis> Siparisler { get; set; } = new();
        public string? Resim { get; set; } = null!;

    }
}
