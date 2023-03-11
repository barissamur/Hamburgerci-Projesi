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

        public int MenuyeHamburgerEkle(int id)
        {
            var hamburger = _db.Hamburgerler.Find(id);
            MenuViewModel.Hamburgerler.Add(hamburger);

            
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

        public IActionResult MenuyeSosEkle(int menuId, int id)
        {
            var sos = _db.Soslar.Find(id);

            var menu = _db.Menuler.Find(menuId);
            menu.Soslar.Add(sos);
            _db.SaveChanges();


            return RedirectToAction("MenuOlustur", menu);
        }

        public IActionResult MenuyeIcecekEkle(int id, int menuId)
        {
            var icecek = _db.Icecekler.Find(id);

            var menu = _db.Menuler.Find(menuId);
            menu.Icecekler.Add(icecek);
            _db.SaveChanges();


            return RedirectToAction("MenuOlustur", menu);
        }

        public IActionResult MenuyeEkstraEkle(int id, int menuId)
        {
            var ekstra = _db.Ekstralar.Find(id);

            var menu = _db.Menuler.Find(menuId);
            menu.Ekstralar.Add(ekstra);
            _db.SaveChanges();


            return RedirectToAction("MenuOlustur", menu);
        }


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