using HamburgerProje.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Diagnostics;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Metrics;
using System.Reflection.Metadata;
using System;
using NuGet.Packaging;

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
            return View(GrupSayi());
        }

        public Dictionary<Menu, Dictionary<string, int>> GrupSayi()
        {
            var enCokSatanlar = _db.Menuler
                .Include(x => x.HamburgerMenuler)
                    .ThenInclude(x => x.Hamburger)
                .Include(x => x.EkstraMenuler)
                    .ThenInclude(x => x.Ekstra)
                .Include(x => x.SosMenuler)
                    .ThenInclude(x => x.Sos)
                .Include(x => x.IcecekMenuler)
                    .ThenInclude(x => x.Icecek)
                .OrderByDescending(x => x.Adet).Take(4).ToList();

            List<Hamburger> hamburgerler = new();

            var gruplamalar = new Dictionary<Menu, Dictionary<string, int>>();


            foreach (var item in enCokSatanlar)
            {
                gruplamalar[item] = item.HamburgerMenuler
                   .GroupBy(x => x.Hamburger.Ad)
                   .ToDictionary(g => g.Key, g => g.Count());

                var ekstraDict = item.EkstraMenuler
                   .GroupBy(x => x.Ekstra.Ad)
                   .ToDictionary(g => g.Key, g => g.Count());

                var sosDict = item.SosMenuler
                  .GroupBy(x => x.Sos.Ad)
                  .ToDictionary(g => g.Key, g => g.Count());

                var icecekDict = item.IcecekMenuler
                   .GroupBy(x => x.Icecek.Ad)
                   .ToDictionary(g => g.Key, g => g.Count());

                foreach (var eks in ekstraDict)
                    gruplamalar[item].Add(eks.Key, eks.Value);

                foreach (var sos in sosDict)
                    gruplamalar[item].Add(sos.Key, sos.Value);

                foreach (var icecek in icecekDict)
                    gruplamalar[item].Add(icecek.Key, icecek.Value);

            }

            return gruplamalar;
        }

    }
}
