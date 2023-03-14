namespace HamburgerProje.Data
{
    public class MenuSiparis
    {
        public int Id { get; set; }
        public int MenuId { get; set; }
        public int SiparisId { get; set; }
        public Siparis Siparis { get; set; }
        public Menu Menu { get; set; }
    }
}
