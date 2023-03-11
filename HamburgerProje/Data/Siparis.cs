namespace HamburgerProje.Data
{
    public class Siparis
    {
        public int Id { get; set; }
        public double Toplam { get; set; }
        public List<Hamburger> Hamburgerler { get; set; } = new();
        public List<Icecek> Icecekler { get; set; } = new();
        public List<Sos> Soslar { get; set; } = new();
        public List<Ekstra> Ekstralar { get; set; } = new();
        public List<Menu> Menuler { get; set; } = new();
    }
}
