using Microsoft.EntityFrameworkCore;

namespace HamburgerProje.Data
{
    public class UygulamaDbContext : DbContext
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
    }
}
