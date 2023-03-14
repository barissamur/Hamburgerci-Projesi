namespace HamburgerProje.Data
{
    public class IcecekSiparis
    {
        public int Id { get; set; }
        public int IcecekId { get; set; }
        public int SiparisId { get; set; }
        public Siparis Siparis { get; set; }
        public Icecek Icecek { get; set; }
    }
}
