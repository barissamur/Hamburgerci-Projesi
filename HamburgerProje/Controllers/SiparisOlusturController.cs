using HamburgerProje.Data;
using HamburgerProje.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;

namespace HamburgerProje.Controllers
{
    public class SiparisOlusturController : Controller
    {
        private readonly UygulamaDbContext _db;

        public SiparisOlusturController(UygulamaDbContext db)
        {
            _db=db;
        }
        // GET: SiparisOlusturController
        public ActionResult Index()
        {
            _db.HamburgerMenuler
              .Include(x => x.Hamburger)
              .Include(x => x.Menu);
            return View(_db);
        }

        // GET: SiparisOlusturController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: SiparisOlusturController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SiparisOlusturController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: SiparisOlusturController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: SiparisOlusturController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: SiparisOlusturController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: SiparisOlusturController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public IActionResult TumMenuler()
        {
            var menuler = _db.Menuler;

            return Json(menuler);
        }

        // menülerin hamburger içerikleri
        public async Task<Dictionary<string, int>> Hmler(int id)
        {
            List<string> hmbAdlar = new();
            List<Hamburger> hmblerList = new();

            var tumHmbler = _db.Hamburgerler;
            var hmbler = await _db.HamburgerMenuler
                .Include(x => x.Hamburger)
                .Include(x => x.Menu)
                .Where(m => m.MenuId == id).ToListAsync();

            foreach (var item in hmbler)
            {
                var hmbrgr = await tumHmbler.FirstOrDefaultAsync(x => x.Id == item.HamburgerId);
                hmblerList.Add(hmbrgr);
            }

            foreach (var item in hmblerList)
            {
                hmbAdlar.Add(item.Ad);
            }

            Dictionary<string, int> hmGrupSayisi;

            hmGrupSayisi = hmbAdlar
             .GroupBy(x => x)
             .ToDictionary(g => g.Key, g => g.Count());

            return hmGrupSayisi;
        }

        // menülerin sos içerikleri
        public async Task<Dictionary<string, int>> Soslar(int id)
        {
            List<string> sosAdlar = new();
            List<Sos> soslarList = new();

            var tumSoslar = _db.Soslar;
            var soslar = await _db.SosMenuler
                .Include(x => x.Sos)
                .Include(x => x.Menu)
                .Where(m => m.MenuId == id).ToListAsync();

            foreach (var item in soslar)
            {
                var hmbrgr = await tumSoslar.FirstOrDefaultAsync(x => x.Id == item.SosId);
                soslarList.Add(hmbrgr);
            }

            foreach (var item in soslarList)
            {
                sosAdlar.Add(item.Ad);
            }

            Dictionary<string, int> sosGrupSayisi;

            sosGrupSayisi = sosAdlar
             .GroupBy(x => x)
             .ToDictionary(g => g.Key, g => g.Count());

            return sosGrupSayisi;
        }

        // menülerin içecek içerikleri
        public async Task<Dictionary<string, int>> Icecekler(int id)
        {
            List<string> icecekAdlar = new();
            List<Icecek> iceceklerList = new();

            var tumIcecekler = _db.Icecekler;
            var icecekler = await _db.IcecekMenuler
                .Include(x => x.Icecek)
                .Include(x => x.Menu)
                .Where(m => m.MenuId == id).ToListAsync();

            foreach (var item in icecekler)
            {
                var icecek = await tumIcecekler.FirstOrDefaultAsync(x => x.Id == item.IcecekId);
                iceceklerList.Add(icecek);
            }

            foreach (var item in iceceklerList)
            {
                icecekAdlar.Add(item.Ad);
            }

            Dictionary<string, int> icecekGrupSayisi;

            icecekGrupSayisi = icecekAdlar
             .GroupBy(x => x)
             .ToDictionary(g => g.Key, g => g.Count());

            return icecekGrupSayisi;
        }

        // menülerin ekstra içerikleri
        public async Task<Dictionary<string, int>> Ekstralar(int id)
        {
            List<string> ekstraAdlar = new();
            List<Ekstra> ekstralarList = new();

            var tumEkstralar = _db.Ekstralar;
            var ekstralar = await _db.EkstraMenuler
                .Include(x => x.Ekstra)
                .Include(x => x.Menu)
                .Where(m => m.MenuId == id).ToListAsync();

            foreach (var item in ekstralar)
            {
                var ekstra = await tumEkstralar.FirstOrDefaultAsync(x => x.Id == item.EkstraId);
                ekstralarList.Add(ekstra);
            }

            foreach (var item in ekstralarList)
            {
                ekstraAdlar.Add(item.Ad);
            }

            Dictionary<string, int> ekstraGrupSayisi;

            ekstraGrupSayisi = ekstraAdlar
             .GroupBy(x => x)
             .ToDictionary(g => g.Key, g => g.Count());

            return ekstraGrupSayisi;
        }

        public IActionResult HamburgerListesi()
        {
            return Json(_db.Hamburgerler);
        }

        public IActionResult IcecekListesi()
        {
            return Json(_db.Icecekler);
        }

        public IActionResult SosListesi()
        {
            return Json(_db.Soslar);
        }

        public IActionResult EkstraListesi()
        {
            return Json(_db.Ekstralar);
        }
    }
}
