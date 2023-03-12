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

        public async Task<Dictionary<string, int>> Hm(int id)
        {
            List<string> hmbAdlar = new();
            List<Hamburger> hmbler = new();

            var tumHmbler = _db.Hamburgerler;
            var hmler = await _db.HamburgerMenuler
                .Include(x => x.Hamburger)
                .Include(x => x.Menu)
                .Where(m => m.MenuId == id).ToListAsync();



            foreach (var item in hmler)
            {
                var hmbrgr = await tumHmbler.FirstOrDefaultAsync(x => x.Id == item.HamburgerId);
                hmbler.Add(hmbrgr);
            }

            foreach (var item in hmbler)
            {
                hmbAdlar.Add(item.Ad);
            }

            Dictionary<string, int> grupSayisi;

            grupSayisi = hmbAdlar
             .GroupBy(x => x)
             .ToDictionary(g => g.Key, g => g.Count());

            return grupSayisi;
        }
    }
}
