namespace HamburgerProje.Data
{
    public class HamburgerSiparis
    {
        public int Id { get; set; }
        public int HamburgerId { get; set; }
        public int SiparisId { get; set; }
        public Siparis Siparis { get; set; }
        public Hamburger Hamburger { get; set; }
    }
}
