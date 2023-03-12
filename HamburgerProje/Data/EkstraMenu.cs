namespace HamburgerProje.Data
{
    public class EkstraMenu
    {
        public int Id { get; set; }
        public int MenuId { get; set; }
        public int EkstraId { get; set; }
        public Ekstra Ekstra { get; set; }
        public Menu Menu { get; set; }
    }
}
