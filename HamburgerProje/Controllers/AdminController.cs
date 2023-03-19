using HamburgerProje.Data;
using HamburgerProje.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using Newtonsoft.Json;
using System;

namespace HamburgerProje.Controllers
{
    [Authorize(Roles ="admin")]
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
            TempData["GeciciMenu"] = null;
            return View();
        }

        public IActionResult MenuOlustur()
        {
            TempData["GeciciMenu"] = null;
            return View();
        }

        [HttpPost]
        public IActionResult MenuOlustur(MenuViewModel mVm)
        {
            var yeniMenu = new Menu();
            _db.Menuler.Add(yeniMenu);
            _db.SaveChanges();

            TempData["GeciciMenu"] = JsonConvert
                   .DeserializeObject<MenuViewModel>(TempData["GeciciMenu"].ToString());


            MenuViewModel menuVm = (MenuViewModel)TempData["GeciciMenu"];

            TempData["GeciciMenu"] = null;


            yeniMenu.Ad = mVm.Ad;
            yeniMenu.Fiyat = mVm.Fiyat;

            var hmList = new List<HamburgerMenu>();
            foreach (var item in menuVm.Hamburgerler)
            {
                var hm = new HamburgerMenu()
                {
                    HamburgerId = item.Id,
                    MenuId = yeniMenu.Id
                };

                hmList.Add(hm);
            }
            _db.HamburgerMenuler.AddRange(hmList);

            var icList = new List<IcecekMenu>();
            foreach (var item in menuVm.Icecekler)
            {
                var ic = new IcecekMenu()
                {
                    IcecekId = item.Id,
                    MenuId = yeniMenu.Id
                };

                icList.Add(ic);
            }
            _db.IcecekMenuler.AddRange(icList);

            var sosList = new List<SosMenu>();
            foreach (var item in menuVm.Soslar)
            {
                var sos = new SosMenu()
                {
                    SosId = item.Id,
                    MenuId = yeniMenu.Id
                };

                sosList.Add(sos);
            }
            _db.SosMenuler.AddRange(sosList);

            var ekstraList = new List<EkstraMenu>();
            foreach (var item in menuVm.Ekstralar)
            {
                var ekstra = new EkstraMenu()
                {
                    EkstraId = item.Id,
                    MenuId = yeniMenu.Id
                };

                ekstraList.Add(ekstra);
            }
            _db.EkstraMenuler.AddRange(ekstraList);

            //-----------------------------------------------------------------

            if (ModelState.IsValid)
            {
                string dosyaAd = mVm.Resim.FileName;
                string kayitYolu = Path.Combine(_env.WebRootPath, "img", dosyaAd); //  wwwroot / img // asset 16.jpg
                using (var stream = new FileStream(kayitYolu, FileMode.OpenOrCreate))
                {
                    mVm.Resim.CopyTo(stream);
                }

                yeniMenu.Resim = dosyaAd;

                _db.SaveChanges();

                return RedirectToAction("Index");
            }

            //-----------------------------------------------------------------
            _db.SaveChanges();

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

            if (TempData["GeciciMenu"] == null)
            {
                var menuVm = new MenuViewModel();

                menuVm.Hamburgerler.Add(hamburger);

                TempData["GeciciMenu"] = JsonConvert.SerializeObject(menuVm);
            }

            else
            {
                TempData["GeciciMenu"] = JsonConvert
                    .DeserializeObject<MenuViewModel>(TempData["GeciciMenu"].ToString());

                MenuViewModel menuVm2 = (MenuViewModel)TempData["GeciciMenu"];

                menuVm2.Hamburgerler.Add(hamburger);
                TempData["GeciciMenu"] = JsonConvert.SerializeObject(menuVm2);
            }

            return hmbSayisi(id);
        }


        public int MenudenHamburgerCikar(int id)
        {
            if (TempData["GeciciMenu"] != null)
            {
                TempData["GeciciMenu"] = JsonConvert
                    .DeserializeObject<MenuViewModel>(TempData["GeciciMenu"].ToString());

                MenuViewModel menuVm = (MenuViewModel)TempData["GeciciMenu"];

                var hamburger = menuVm.Hamburgerler.FirstOrDefault(x => x.Id == id);

                menuVm.Hamburgerler.Remove(hamburger);
                TempData["GeciciMenu"] = JsonConvert.SerializeObject(menuVm);
            }
            //MenuViewModel.Hamburgerler.Add(hamburger);
            return hmbSayisi(id);
        }

        public async Task<IActionResult> HamburgerleriListele()
        {
            var hamburgerler = await _db.Hamburgerler.OrderBy(x => x.Ad).ToListAsync();
            return Json(hamburgerler);
        }

        public int hmbSayisi(int id)
        {
            if (TempData["GeciciMenu"] != null)
            {

                TempData["GeciciMenu"] = JsonConvert
                    .DeserializeObject<MenuViewModel>(TempData["GeciciMenu"].ToString());


                MenuViewModel menuVm = (MenuViewModel)TempData["GeciciMenu"];

                TempData["GeciciMenu"] = JsonConvert.SerializeObject(menuVm);

                return menuVm.Hamburgerler.Count(h => h.Id == id);
            }
            return 0;
        }
        #endregion

        //----
        #region İçecek Metotları

        public int MenuyeIcecekEkle(int id)
        {
            var icecek = _db.Icecekler.Find(id);

            if (TempData["GeciciMenu"] == null)
            {
                var menuVm = new MenuViewModel();

                menuVm.Icecekler.Add(icecek);

                TempData["GeciciMenu"] = JsonConvert.SerializeObject(menuVm);
            }

            else
            {
                TempData["GeciciMenu"] = JsonConvert
                    .DeserializeObject<MenuViewModel>(TempData["GeciciMenu"].ToString());

                MenuViewModel menuVm2 = (MenuViewModel)TempData["GeciciMenu"];

                menuVm2.Icecekler.Add(icecek);

                TempData["GeciciMenu"] = JsonConvert.SerializeObject(menuVm2);
            }

            return icecekSayisi(id);
        }

        public int MenudenIcecekCikar(int id)
        {
            if (TempData["GeciciMenu"] != null)
            {
                TempData["GeciciMenu"] = JsonConvert
                    .DeserializeObject<MenuViewModel>(TempData["GeciciMenu"].ToString());

                MenuViewModel menuVm = (MenuViewModel)TempData["GeciciMenu"];

                var icecek = menuVm.Icecekler.FirstOrDefault(x => x.Id == id);

                menuVm.Icecekler.Remove(icecek);
                TempData["GeciciMenu"] = JsonConvert.SerializeObject(menuVm);
            }

            return icecekSayisi(id);
        }
        public IActionResult IcecekleriListele()
        {
            var icecekler = _db.Icecekler;
            return Json(icecekler);
        }
        public int icecekSayisi(int id)
        {
            if (TempData["GeciciMenu"] != null)
            {

                TempData["GeciciMenu"] = JsonConvert
                    .DeserializeObject<MenuViewModel>(TempData["GeciciMenu"].ToString());


                MenuViewModel menuVm = (MenuViewModel)TempData["GeciciMenu"];

                TempData["GeciciMenu"] = JsonConvert.SerializeObject(menuVm);

                return menuVm.Icecekler.Count(h => h.Id == id);
            }
            return 0;
        }
        #endregion

        //----
        #region Sos Metotları
        public int MenuyeSosEkle(int id)
        {
            var sos = _db.Soslar.Find(id);
            if (TempData["GeciciMenu"] == null)
            {
                var menuVm = new MenuViewModel();

                menuVm.Soslar.Add(sos);

                TempData["GeciciMenu"] = JsonConvert.SerializeObject(menuVm);
            }

            else
            {
                TempData["GeciciMenu"] = JsonConvert
                    .DeserializeObject<MenuViewModel>(TempData["GeciciMenu"].ToString());

                MenuViewModel menuVm2 = (MenuViewModel)TempData["GeciciMenu"];

                menuVm2.Soslar.Add(sos);
                TempData["GeciciMenu"] = JsonConvert.SerializeObject(menuVm2);
            }

            return sosSayisi(id);
        }

        public int MenudenSosCikar(int id)
        {
            if (TempData["GeciciMenu"] != null)
            {
                TempData["GeciciMenu"] = JsonConvert
                    .DeserializeObject<MenuViewModel>(TempData["GeciciMenu"].ToString());

                MenuViewModel menuVm = (MenuViewModel)TempData["GeciciMenu"];

                var sos = menuVm.Soslar.FirstOrDefault(x => x.Id == id);

                menuVm.Soslar.Remove(sos);
                TempData["GeciciMenu"] = JsonConvert.SerializeObject(menuVm);
            }

            return sosSayisi(id);
        }
        public IActionResult SoslariListele()
        {
            var soslar = _db.Soslar;
            return Json(soslar);
        }
        public int sosSayisi(int id)
        {
            if (TempData["GeciciMenu"] != null)
            {

                TempData["GeciciMenu"] = JsonConvert
                    .DeserializeObject<MenuViewModel>(TempData["GeciciMenu"].ToString());


                MenuViewModel menuVm = (MenuViewModel)TempData["GeciciMenu"];

                TempData["GeciciMenu"] = JsonConvert.SerializeObject(menuVm);

                return menuVm.Soslar.Count(h => h.Id == id);
            }
            return 0;
        }
        #endregion

        //----
        #region Ekstra Metotları
        public int MenuyeEkstraEkle(int id)
        {
            var ekstra = _db.Ekstralar.Find(id);
            if (TempData["GeciciMenu"] == null)
            {
                var menuVm = new MenuViewModel();

                menuVm.Ekstralar.Add(ekstra);

                TempData["GeciciMenu"] = JsonConvert.SerializeObject(menuVm);
            }

            else
            {
                TempData["GeciciMenu"] = JsonConvert
                    .DeserializeObject<MenuViewModel>(TempData["GeciciMenu"].ToString());

                MenuViewModel menuVm2 = (MenuViewModel)TempData["GeciciMenu"];

                menuVm2.Ekstralar.Add(ekstra);
                TempData["GeciciMenu"] = JsonConvert.SerializeObject(menuVm2);
            }

            return ekstraSayisi(id);
        }

        public int MenudenEkstraCikar(int id)
        {
            if (TempData["GeciciMenu"] != null)
            {
                TempData["GeciciMenu"] = JsonConvert
                    .DeserializeObject<MenuViewModel>(TempData["GeciciMenu"].ToString());

                MenuViewModel menuVm = (MenuViewModel)TempData["GeciciMenu"];

                var ekstra = menuVm.Ekstralar.FirstOrDefault(x => x.Id == id);

                menuVm.Ekstralar.Remove(ekstra);
                TempData["GeciciMenu"] = JsonConvert.SerializeObject(menuVm);
            }

            return ekstraSayisi(id);
        }
        public IActionResult EkstralariListele()
        {
            var ekstralar = _db.Ekstralar;
            return Json(ekstralar);
        }
        public int ekstraSayisi(int id)
        {
            if (TempData["GeciciMenu"] != null)
            {

                TempData["GeciciMenu"] = JsonConvert
                    .DeserializeObject<MenuViewModel>(TempData["GeciciMenu"].ToString());


                MenuViewModel menuVm = (MenuViewModel)TempData["GeciciMenu"];

                TempData["GeciciMenu"] = JsonConvert.SerializeObject(menuVm);

                return menuVm.Ekstralar.Count(h => h.Id == id);
            }
            return 0;
        }
        #endregion
    }
}
