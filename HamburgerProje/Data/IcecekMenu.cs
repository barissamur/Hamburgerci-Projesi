namespace HamburgerProje.Data
{
    public class IcecekMenu
    {
        public int Id { get; set; }
        public int MenuId { get; set; }
        public int IcecekId { get; set; }
        public Icecek Icecek { get; set; }
        public Menu Menu { get; set; }
    }
}
