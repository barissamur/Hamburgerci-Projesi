namespace HamburgerProje.Data
{
    public class EkstraSiparis
    {
        public int Id { get; set; }
        public int EkstraId { get; set; }
        public int SiparisId { get; set; }
        public Siparis Siparis { get; set; }
        public Ekstra Ekstra { get; set; }
    }
}
