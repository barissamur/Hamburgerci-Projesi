namespace HamburgerProje.Data
{
    public class Sos
    {
        public int Id { get; set; }
        public string Ad { get; set; } = null!;
        public int Adet { get; set; }
        public double Fiyat { get; set; }
        public ICollection<SosMenu> SosMenuler { get; set; }
        public List<Siparis> Siparisler { get; set; } = new();
        public string? Resim { get; set; } = null!;
    }
}
