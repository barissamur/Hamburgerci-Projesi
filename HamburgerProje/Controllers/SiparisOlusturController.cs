using HamburgerProje.Data;
using HamburgerProje.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
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
            if (TempData["GeciciSiparis"] == null)
                return View(_db);


            TempData["GeciciSiparis"] = JsonConvert
                  .DeserializeObject<SiparisViewModel>(TempData["GeciciSiparis"].ToString());


            SiparisViewModel siparisVm = (SiparisViewModel)TempData["GeciciSiparis"];

            TempData["GeciciSiparis"] = JsonConvert.SerializeObject(siparisVm);



            return View();
        }
        #region Sipariş Menu Metotları

        public int SipariseMenuEkle(int id)
        {
            var menu = _db.Menuler.Find(id);

            if (TempData["GeciciSiparis"] == null)
            {
                var siparisVm = new SiparisViewModel();

                siparisVm.Menuler.Add(menu);

                TempData["GeciciSiparis"] = JsonConvert.SerializeObject(siparisVm);
            }

            else
            {
                TempData["GeciciSiparis"] = JsonConvert
                    .DeserializeObject<SiparisViewModel>(TempData["GeciciSiparis"].ToString());

                SiparisViewModel siparisVm2 = (SiparisViewModel)TempData["GeciciSiparis"];

                siparisVm2.Menuler.Add(menu);
                TempData["GeciciSiparis"] = JsonConvert.SerializeObject(siparisVm2);
            }

            return menuSayisi(id);
        }

        public int SiparistenMenuCikar(int id)
        {

            if (TempData["GeciciSiparis"] != null)
            {
                TempData["GeciciSiparis"] = JsonConvert
                    .DeserializeObject<SiparisViewModel>(TempData["GeciciSiparis"].ToString());

                SiparisViewModel siparisVm = (SiparisViewModel)TempData["GeciciSiparis"];

                var menu = siparisVm.Menuler.FirstOrDefault(x => x.Id == id);

                siparisVm.Menuler.Remove(menu);
                TempData["GeciciSiparis"] = JsonConvert.SerializeObject(siparisVm);
            }
            return menuSayisi(id);
        }

        public int menuSayisi(int id)
        {
            if (TempData["GeciciSiparis"] != null)
            {

                TempData["GeciciSiparis"] = JsonConvert
                    .DeserializeObject<SiparisViewModel>(TempData["GeciciSiparis"].ToString());


                SiparisViewModel siparisVm = (SiparisViewModel)TempData["GeciciSiparis"];

                TempData["GeciciSiparis"] = JsonConvert.SerializeObject(siparisVm);

                return siparisVm.Menuler.Count(h => h.Id == id);
            }
            return 0;
        }
        #endregion

        #region Sipariş Hamburger Metotları
        public int SipariseHmbEkle(int id)
        {
            var hamburger = _db.Hamburgerler.Find(id);

            if (TempData["GeciciSiparis"] == null)
            {
                var siparisVm = new SiparisViewModel();

                siparisVm.Hamburgerler.Add(hamburger);

                TempData["GeciciSiparis"] = JsonConvert.SerializeObject(siparisVm);
            }

            else
            {
                TempData["GeciciSiparis"] = JsonConvert
                    .DeserializeObject<SiparisViewModel>(TempData["GeciciSiparis"].ToString());

                SiparisViewModel siparisVm2 = (SiparisViewModel)TempData["GeciciSiparis"];

                siparisVm2.Hamburgerler.Add(hamburger);
                TempData["GeciciSiparis"] = JsonConvert.SerializeObject(siparisVm2);
            }

            return hmbSayisi(id);
        }

        public int SiparistenHmbCikar(int id)
        {

            if (TempData["GeciciSiparis"] != null)
            {
                TempData["GeciciSiparis"] = JsonConvert
                    .DeserializeObject<SiparisViewModel>(TempData["GeciciSiparis"].ToString());

                SiparisViewModel siparisVm = (SiparisViewModel)TempData["GeciciSiparis"];

                var hamburger = siparisVm.Hamburgerler.FirstOrDefault(x => x.Id == id);

                siparisVm.Hamburgerler.Remove(hamburger);
                TempData["GeciciSiparis"] = JsonConvert.SerializeObject(siparisVm);
            }
            return hmbSayisi(id);
        }


        public int hmbSayisi(int id)
        {
            if (TempData["GeciciSiparis"] != null)
            {

                TempData["GeciciSiparis"] = JsonConvert
                    .DeserializeObject<SiparisViewModel>(TempData["GeciciSiparis"].ToString());


                SiparisViewModel siparisVm = (SiparisViewModel)TempData["GeciciSiparis"];

                TempData["GeciciSiparis"] = JsonConvert.SerializeObject(siparisVm);

                return siparisVm.Hamburgerler.Count(h => h.Id == id);
            }
            return 0;
        }
        #endregion

        #region Sipariş İçecek Metotları
        public int SipariseIcecekEkle(int id)
        {
            var icecek = _db.Icecekler.Find(id);

            if (TempData["GeciciSiparis"] == null)
            {
                var siparisVm = new SiparisViewModel();

                siparisVm.Icecekler.Add(icecek);

                TempData["GeciciSiparis"] = JsonConvert.SerializeObject(siparisVm);
            }

            else
            {
                TempData["GeciciSiparis"] = JsonConvert
                    .DeserializeObject<SiparisViewModel>(TempData["GeciciSiparis"].ToString());

                SiparisViewModel siparisVm2 = (SiparisViewModel)TempData["GeciciSiparis"];

                siparisVm2.Icecekler.Add(icecek);
                TempData["GeciciSiparis"] = JsonConvert.SerializeObject(siparisVm2);
            }

            return icecekSayisi(id);
        }

        public int SiparistenIcecekCikar(int id)
        {

            if (TempData["GeciciSiparis"] != null)
            {
                TempData["GeciciSiparis"] = JsonConvert
                    .DeserializeObject<SiparisViewModel>(TempData["GeciciSiparis"].ToString());

                SiparisViewModel siparisVm = (SiparisViewModel)TempData["GeciciSiparis"];

                var icecek = siparisVm.Icecekler.FirstOrDefault(x => x.Id == id);

                siparisVm.Icecekler.Remove(icecek);
                TempData["GeciciSiparis"] = JsonConvert.SerializeObject(siparisVm);
            }
            return icecekSayisi(id);
        }


        public int icecekSayisi(int id)
        {
            if (TempData["GeciciSiparis"] != null)
            {

                TempData["GeciciSiparis"] = JsonConvert
                    .DeserializeObject<SiparisViewModel>(TempData["GeciciSiparis"].ToString());


                SiparisViewModel siparisVm = (SiparisViewModel)TempData["GeciciSiparis"];

                TempData["GeciciSiparis"] = JsonConvert.SerializeObject(siparisVm);

                return siparisVm.Icecekler.Count(h => h.Id == id);
            }
            return 0;
        }
        #endregion

        #region Sipariş Sos Metotları
        public int SipariseSosEkle(int id)
        {
            var sos = _db.Soslar.Find(id);

            if (TempData["GeciciSiparis"] == null)
            {
                var siparisVm = new SiparisViewModel();

                siparisVm.Soslar.Add(sos);

                TempData["GeciciSiparis"] = JsonConvert.SerializeObject(siparisVm);
            }

            else
            {
                TempData["GeciciSiparis"] = JsonConvert
                    .DeserializeObject<SiparisViewModel>(TempData["GeciciSiparis"].ToString());

                SiparisViewModel siparisVm2 = (SiparisViewModel)TempData["GeciciSiparis"];

                siparisVm2.Soslar.Add(sos);
                TempData["GeciciSiparis"] = JsonConvert.SerializeObject(siparisVm2);
            }

            return sosSayisi(id);
        }

        public int SiparistenSosCikar(int id)
        {

            if (TempData["GeciciSiparis"] != null)
            {
                TempData["GeciciSiparis"] = JsonConvert
                    .DeserializeObject<SiparisViewModel>(TempData["GeciciSiparis"].ToString());

                SiparisViewModel siparisVm = (SiparisViewModel)TempData["GeciciSiparis"];

                var sos = siparisVm.Soslar.FirstOrDefault(x => x.Id == id);

                siparisVm.Soslar.Remove(sos);
                TempData["GeciciSiparis"] = JsonConvert.SerializeObject(siparisVm);
            }
            return sosSayisi(id);
        }


        public int sosSayisi(int id)
        {
            if (TempData["GeciciSiparis"] != null)
            {

                TempData["GeciciSiparis"] = JsonConvert
                    .DeserializeObject<SiparisViewModel>(TempData["GeciciSiparis"].ToString());


                SiparisViewModel siparisVm = (SiparisViewModel)TempData["GeciciSiparis"];

                TempData["GeciciSiparis"] = JsonConvert.SerializeObject(siparisVm);

                return siparisVm.Soslar.Count(h => h.Id == id);
            }
            return 0;
        }
        #endregion

        #region Sipariş Ekstra Metotları
        public int SipariseEkstraEkle(int id)
        {
            var ekstra = _db.Ekstralar.Find(id);

            if (TempData["GeciciSiparis"] == null)
            {
                var siparisVm = new SiparisViewModel();

                siparisVm.Ekstralar.Add(ekstra);

                TempData["GeciciSiparis"] = JsonConvert.SerializeObject(siparisVm);
            }

            else
            {
                TempData["GeciciSiparis"] = JsonConvert
                    .DeserializeObject<SiparisViewModel>(TempData["GeciciSiparis"].ToString());

                SiparisViewModel siparisVm2 = (SiparisViewModel)TempData["GeciciSiparis"];

                siparisVm2.Ekstralar.Add(ekstra);
                TempData["GeciciSiparis"] = JsonConvert.SerializeObject(siparisVm2);
            }

            return ekstraSayisi(id);
        }

        public int SiparistenEkstraCikar(int id)
        {

            if (TempData["GeciciSiparis"] != null)
            {
                TempData["GeciciSiparis"] = JsonConvert
                    .DeserializeObject<SiparisViewModel>(TempData["GeciciSiparis"].ToString());

                SiparisViewModel siparisVm = (SiparisViewModel)TempData["GeciciSiparis"];

                var ekstra = siparisVm.Ekstralar.FirstOrDefault(x => x.Id == id);

                siparisVm.Ekstralar.Remove(ekstra);
                TempData["GeciciSiparis"] = JsonConvert.SerializeObject(siparisVm);
            }
            return ekstraSayisi(id);
        }


        public int ekstraSayisi(int id)
        {
            if (TempData["GeciciSiparis"] != null)
            {

                TempData["GeciciSiparis"] = JsonConvert
                    .DeserializeObject<SiparisViewModel>(TempData["GeciciSiparis"].ToString());


                SiparisViewModel siparisVm = (SiparisViewModel)TempData["GeciciSiparis"];

                TempData["GeciciSiparis"] = JsonConvert.SerializeObject(siparisVm);

                return siparisVm.Ekstralar.Count(h => h.Id == id);
            }
            return 0;
        }
        #endregion


        #region Sipariş Listesi

        public IActionResult SiparisListesi()
        {
            TempData["GeciciSiparis"] = JsonConvert
                  .DeserializeObject<SiparisViewModel>(TempData["GeciciSiparis"].ToString());

            SiparisViewModel siparisVm = (SiparisViewModel)TempData["GeciciSiparis"];

            TempData["GeciciSiparis"] = JsonConvert.SerializeObject(siparisVm);

            return Json(siparisVm);
        }

        #endregion

































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
