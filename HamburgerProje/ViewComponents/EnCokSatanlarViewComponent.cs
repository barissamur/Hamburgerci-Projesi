using HamburgerProje.Data;
using Microsoft.AspNetCore.Mvc;

namespace HamburgerProje.ViewComponents
{
    public class EnCokSatanlarViewComponent : ViewComponent
    {
        private readonly UygulamaDbContext _db;

        public EnCokSatanlarViewComponent(UygulamaDbContext db)
        {
            _db=db;
        }
        public IViewComponentResult Invoke()
        {
            var enCokSatanlar = _db.Menuler.OrderByDescending(x => x.Adet).Take(4).ToList();
            return View(enCokSatanlar);
        }

    }
}
