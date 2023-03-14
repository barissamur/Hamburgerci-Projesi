namespace HamburgerProje.Data
{
    public class Ekstra
    {
        public int Id { get; set; }
        public string Ad { get; set; } = null!;
        public double Fiyat { get; set; }

        public int Adet { get; set; }
        public ICollection<EkstraMenu> EkstraMenuler { get; set; }
        public List<EkstraSiparis> EkstraSiparisler { get; set; } = new();
        public string? Resim { get; set; } = null!;


    }
}
