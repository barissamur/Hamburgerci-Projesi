namespace HamburgerProje.Data
{
    public class Siparis
    {
        public int Id { get; set; }
        public double Toplam { get; set; }
        public List<HamburgerSiparis> HamburgerSiparisler { get; set; } = new();
        public List<IcecekSiparis> IcecekSiparisler { get; set; } = new();
        public List<SosSiparis> SosSiparisler { get; set; } = new();
        public List<EkstraSiparis> EkstraSiparisler { get; set; } = new();
        public List<MenuSiparis> MenuSiparisler { get; set; } = new();
        public bool OdendiMi { get; set; }
    }
}
