namespace HamburgerProje.Data
{
    public class SosMenu
    {
        public int Id { get; set; }
        public int MenuId { get; set; }
        public int SosId { get; set; }
        public Sos Sos { get; set; }
        public Menu Menu { get; set; }
    }
}
