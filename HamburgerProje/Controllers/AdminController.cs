using HamburgerProje.Data;
using HamburgerProje.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using Newtonsoft.Json;
using System;

namespace HamburgerProje.Controllers
{
    public class AdminController : Controller
    {
        private readonly UygulamaDbContext _db;
        private readonly IWebHostEnvironment _env;

        public AdminController(UygulamaDbContext db, IWebHostEnvironment env)
        {
            _db=db;
            _env=env;
        }
        public IActionResult Index()
        {

            return View();
        }

        public IActionResult MenuOlustur()
        {
            return View();
        }

        [HttpPost]
        public IActionResult MenuOlustur(int id)
        {

            return View();
        }


        [HttpPost]
        public IActionResult MenuEkle(DbViewModel vm, int id)
        {
            return View();
        }

        [HttpPost]
        public IActionResult HamburgerEkle(DbViewModel vm)
        {
            if (ModelState.IsValid)
            {
                string dosyaAd = vm.HamburgerViewModel!.Resim.FileName;
                string kayitYolu = Path.Combine(_env.WebRootPath, "img", dosyaAd); //  wwwroot / img // asset 16.jpg
                using (var stream = new FileStream(kayitYolu, FileMode.OpenOrCreate))
                {
                    vm.HamburgerViewModel.Resim.CopyTo(stream);
                }

                _db.Hamburgerler.Add(new Hamburger()
                {
                    Ad = vm.HamburgerViewModel.Ad,
                    Fiyat = vm.HamburgerViewModel.Fiyat,
                    Resim = dosyaAd
                });

                _db.SaveChanges();

                return RedirectToAction("Index");
            }
            return View(vm);
        }

        [HttpPost]
        public IActionResult SosEkle(DbViewModel vm)
        {
            if (ModelState.IsValid)
            {
                string dosyaAd = vm.SosViewModel!.Resim.FileName;
                string kayitYolu = Path.Combine(_env.WebRootPath, "img", dosyaAd); //  wwwroot / img // asset 16.jpg
                using (var stream = new FileStream(kayitYolu, FileMode.OpenOrCreate))
                {
                    vm.SosViewModel.Resim.CopyTo(stream);
                }

                _db.Soslar.Add(new Sos()
                {
                    Ad = vm.SosViewModel.Ad,
                    Fiyat = vm.SosViewModel.Fiyat,
                    Resim = dosyaAd
                });

                _db.SaveChanges();

                return RedirectToAction("Index");
            }
            return View(vm);
        }

        [HttpPost]
        public IActionResult EkstraEkle(DbViewModel vm)
        {
            if (ModelState.IsValid)
            {
                string dosyaAd = vm.EkstraViewModel!.Resim.FileName;
                string kayitYolu = Path.Combine(_env.WebRootPath, "img", dosyaAd); //  wwwroot / img // asset 16.jpg
                using (var stream = new FileStream(kayitYolu, FileMode.OpenOrCreate))
                {
                    vm.EkstraViewModel.Resim.CopyTo(stream);
                }

                _db.Ekstralar.Add(new Ekstra()
                {
                    Ad = vm.EkstraViewModel.Ad,
                    Fiyat = vm.EkstraViewModel.Fiyat,
                    Resim = dosyaAd
                });

                _db.SaveChanges();

                return RedirectToAction("Index");
            }
            return View(vm);
        }

        [HttpPost]
        public IActionResult IcecekEkle(DbViewModel vm)
        {
            if (ModelState.IsValid)
            {
                string dosyaAd = vm.IcecekViewModel!.Resim.FileName;
                string kayitYolu = Path.Combine(_env.WebRootPath, "img", dosyaAd); //  wwwroot / img // asset 16.jpg
                using (var stream = new FileStream(kayitYolu, FileMode.OpenOrCreate))
                {
                    vm.IcecekViewModel.Resim.CopyTo(stream);
                }

                _db.Icecekler.Add(new Icecek()
                {
                    Ad = vm.IcecekViewModel.Ad,
                    Fiyat = vm.IcecekViewModel.Fiyat,
                    Resim = dosyaAd
                });

                _db.SaveChanges();

                return RedirectToAction("Index");
            }
            return View(vm);
        }

        //----
        #region Hamburger Metotları
        public int MenuyeHamburgerEkle(int id)
        {
            var hamburger = _db.Hamburgerler.Find(id);
            MenuViewModel.Hamburgerler.Add(hamburger);


            return hmbSayisi(id);
        }

        public int MenudenHamburgerCikar(int id)
        {
            var hamburger = _db.Hamburgerler.Find(id);
            var index = MenuViewModel.Hamburgerler.FirstOrDefault(x => x.Id == id);
            MenuViewModel.Hamburgerler.Remove(index);

            return hmbSayisi(id);
        }

        public IActionResult HamburgerleriListele()
        {
            var hamburgerler = _db.Hamburgerler;
            return Json(hamburgerler);
        }

        public int hmbSayisi(int id)
        {
            var sayi = MenuViewModel.Hamburgerler.Count(h => h.Id == id);
            return sayi;
        }
        #endregion
        //----
        #region İçecek Metotları

        public int MenuyeIcecekEkle(int id)
        {
            var icecek = _db.Icecekler.Find(id);
            MenuViewModel.Icecekler.Add(icecek);

            return icecekSayisi(id);
        }

        public int MenudenIcecekCikar(int id)
        {
            var icecek = _db.Icecekler.Find(id);
            var index = MenuViewModel.Icecekler.FirstOrDefault(x => x.Id == id);
            MenuViewModel.Icecekler.Remove(index);

            return icecekSayisi(id);
        }
        public IActionResult IcecekleriListele()
        {
            var icecekler = _db.Icecekler;
            return Json(icecekler);
        }
        public int icecekSayisi(int id)
        {
            var sayi = MenuViewModel.Icecekler.Count(h => h.Id == id);
            return sayi;
        }
        #endregion

        //----
        #region Sos Metotları
        public int MenuyeSosEkle(int id)
        {
            var sos = _db.Soslar.Find(id);
            MenuViewModel.Soslar.Add(sos);

            return sosSayisi(id);
        }

        public int MenudenSosCikar(int id)
        {
            var sos = _db.Soslar.Find(id);
            var index = MenuViewModel.Soslar.FirstOrDefault(x => x.Id == id);
            MenuViewModel.Soslar.Remove(index);

            return sosSayisi(id);
        }
        public IActionResult SoslariListele()
        {
            var soslar = _db.Soslar;
            return Json(soslar);
        }
        public int sosSayisi(int id)
        {
            var sayi = MenuViewModel.Soslar.Count(h => h.Id == id);
            return sayi;
        }
        #endregion

        #region Ekstra Metotları
        public int MenuyeEkstraEkle(int id)
        {
            var ekstra = _db.Ekstralar.Find(id);
            MenuViewModel.Ekstralar.Add(ekstra);

            return ekstraSayisi(id);
        }

        public int MenudenEkstraCikar(int id)
        {
            var ekstra = _db.Ekstralar.Find(id);
            var index = MenuViewModel.Ekstralar.FirstOrDefault(x => x.Id == id);
            MenuViewModel.Ekstralar.Remove(index);

            return ekstraSayisi(id);
        }
        public IActionResult EkstralariListele()
        {
            var ekstralar = _db.Ekstralar;
            return Json(ekstralar);
        }
        public int ekstraSayisi(int id)
        {
            var sayi = MenuViewModel.Ekstralar.Count(h => h.Id == id);
            return sayi;
        }
        #endregion



        // action'a ek olarak menü id istiyecez. eğer menü id varsa o menüyü bulup içine ekle. menü id yoksa yeni menü oluştur
    }
}
//var menu = new Menu();

//foreach (var item in menuVm.Hamburgerler)
//{
//    var hm = new HamburgerMenu()
//    {
//        HamburgerId = item.Id,
//        MenuId = menu.Id
//    };
//}