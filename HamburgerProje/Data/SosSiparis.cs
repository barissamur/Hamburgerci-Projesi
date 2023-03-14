namespace HamburgerProje.Data
{
    public class SosSiparis
    {
        public int Id { get; set; }
        public int SosId { get; set; }
        public int SiparisId { get; set; }
        public Siparis Siparis { get; set; }
        public Sos Sos { get; set; }
    }
}
