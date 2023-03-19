using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HamburgerProje.Data
{
    public class UygulamaDbContext : IdentityDbContext<Kullanici>
    {
        public UygulamaDbContext(DbContextOptions<UygulamaDbContext> options) : base(options)
        {

        }

        public DbSet<Hamburger> Hamburgerler => Set<Hamburger>();
        public DbSet<Icecek> Icecekler => Set<Icecek>();
        public DbSet<Ekstra> Ekstralar => Set<Ekstra>();
        public DbSet<Menu> Menuler => Set<Menu>();
        public DbSet<Sos> Soslar => Set<Sos>();
        public DbSet<Siparis> Siparisler => Set<Siparis>();
        public DbSet<HamburgerMenu> HamburgerMenuler => Set<HamburgerMenu>();
        public DbSet<SosMenu> SosMenuler => Set<SosMenu>();
        public DbSet<EkstraMenu> EkstraMenuler => Set<EkstraMenu>();
        public DbSet<IcecekMenu> IcecekMenuler => Set<IcecekMenu>();
        public DbSet<MenuSiparis> MenuSiparisler => Set<MenuSiparis>();
        public DbSet<HamburgerSiparis> HamburgerSiparisler => Set<HamburgerSiparis>();
        public DbSet<IcecekSiparis> IcecekSiparisler => Set<IcecekSiparis>();
        public DbSet<SosSiparis> SosSiparisler => Set<SosSiparis>();
        public  DbSet<EkstraSiparis> EkstraSiparisler => Set<EkstraSiparis>();
    }
}
