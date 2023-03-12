using HamburgerProje.Data;

namespace HamburgerProje.Models
{
    public class listDbViewModel
    {
        public List<EkstraMenu> EkstraMenuler { get; set; }
        public List<HamburgerMenu> HamburgerMenuler { get; set; }
        public List<IcecekMenu> IcecekMenuler { get; set; }
        public List<SosMenu> SosMneuler { get; set; }
    }
}
