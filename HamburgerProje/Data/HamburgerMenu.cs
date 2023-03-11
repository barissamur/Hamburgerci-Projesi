namespace HamburgerProje.Data
{
    public class HamburgerMenu
    {
        public int Id { get; set; }
        public int MenuId { get; set; }
        public int HamburgerId { get; set; }
        public Hamburger Hamburger { get; set; }
        public Menu Menu { get; set; }
    }
}
