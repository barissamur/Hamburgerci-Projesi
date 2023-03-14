using HamburgerProje.Data;
using HamburgerProje.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace HamburgerProje.Controllers
{
    public class SepetController : Controller
    {
        private readonly UygulamaDbContext _db;

        public SepetController(UygulamaDbContext db)
        {
            _db=db;
        }
        public IActionResult Index()
        {
            if (TempData["GeciciSiparis"] != null)
            {

                TempData["GeciciSiparis"] = JsonConvert
                                    .DeserializeObject<SiparisViewModel>(TempData["GeciciSiparis"].ToString());

                SiparisViewModel siparisVm = (SiparisViewModel)TempData["GeciciSiparis"];
                TempData["GeciciSiparis"] = JsonConvert.SerializeObject(siparisVm);

            }

            return View();

            #region sipariş new'leme
            //if (siparisId != 0)
            //{
            //    var siparis = _db.Siparisler
            //          .Include(s => s.HamburgerSiparisler)
            //            .ThenInclude(x => x.Hamburger)
            //          .Include(s => s.IcecekSiparisler)
            //            .ThenInclude(x => x.Icecek)
            //          .Include(s => s.SosSiparisler)
            //            .ThenInclude(x => x.Sos)
            //          .Include(s => s.EkstraSiparisler)
            //            .ThenInclude(x => x.Ekstra)
            //          .Include(s => s.MenuSiparisler)
            //            .ThenInclude(x => x.Menu)
            //          .FirstOrDefault(s => s.Id == siparisId);

            //    return View(siparis);
            //}

            //var bekleyenSiparis = _db.Siparisler
            //     .Include(s => s.HamburgerSiparisler)
            //            .ThenInclude(x => x.Hamburger)
            //          .Include(s => s.IcecekSiparisler)
            //            .ThenInclude(x => x.Icecek)
            //          .Include(s => s.SosSiparisler)
            //            .ThenInclude(x => x.Sos)
            //          .Include(s => s.EkstraSiparisler)
            //            .ThenInclude(x => x.Ekstra)
            //          .Include(s => s.MenuSiparisler)
            //            .ThenInclude(x => x.Menu)
            //          .FirstOrDefault(x => x.OdendiMi == false);

            //if (bekleyenSiparis != null)
            //    return View(bekleyenSiparis);

            //return View();
            #endregion
        }


        public async Task<Dictionary<string, int>> SepettekiMenuler()
        {
            if (TempData["GeciciSiparis"] != null)
            {
                TempData["GeciciSiparis"] = JsonConvert
                                    .DeserializeObject<SiparisViewModel>(TempData["GeciciSiparis"].ToString());

                SiparisViewModel siparisVm = (SiparisViewModel)TempData["GeciciSiparis"];
                TempData["GeciciSiparis"] = JsonConvert.SerializeObject(siparisVm);

                List<string> menuAdlar = new();


                foreach (var item in siparisVm.Menuler)
                {
                    menuAdlar.Add(item.Ad);
                }

                Dictionary<string, int> menuGrupSayisi;

                menuGrupSayisi = menuAdlar
                 .GroupBy(x => x)
                 .ToDictionary(g => g.Key, g => g.Count());

                return menuGrupSayisi;
            }
            return null;
        }

        public async Task<Dictionary<string, int>> SepettekiHamburgerler()
        {
            if (TempData["GeciciSiparis"] != null)
            {
                TempData["GeciciSiparis"] = JsonConvert
                                    .DeserializeObject<SiparisViewModel>(TempData["GeciciSiparis"].ToString());

                SiparisViewModel siparisVm = (SiparisViewModel)TempData["GeciciSiparis"];
                TempData["GeciciSiparis"] = JsonConvert.SerializeObject(siparisVm);

                List<string> hamburgerAdlar = new();


                foreach (var item in siparisVm.Hamburgerler)
                {
                    hamburgerAdlar.Add(item.Ad);
                }

                Dictionary<string, int> hamburgerGrupSayisi;

                hamburgerGrupSayisi = hamburgerAdlar
                 .GroupBy(x => x)
                 .ToDictionary(g => g.Key, g => g.Count());

                return hamburgerGrupSayisi;
            }
            return null;
        }

        public async Task<Dictionary<string, int>> SepettekiIcecekler()
        {
            if (TempData["GeciciSiparis"] != null)
            {
                TempData["GeciciSiparis"] = JsonConvert
                                    .DeserializeObject<SiparisViewModel>(TempData["GeciciSiparis"].ToString());

                SiparisViewModel siparisVm = (SiparisViewModel)TempData["GeciciSiparis"];
                TempData["GeciciSiparis"] = JsonConvert.SerializeObject(siparisVm);

                List<string> icecekAdlar = new();


                foreach (var item in siparisVm.Icecekler)
                {
                    icecekAdlar.Add(item.Ad);
                }

                Dictionary<string, int> icecekGrupSayisi;

                icecekGrupSayisi = icecekAdlar
                 .GroupBy(x => x)
                 .ToDictionary(g => g.Key, g => g.Count());

                return icecekGrupSayisi;
            }
            return null;
        }

        public async Task<Dictionary<string, int>> SepettekiSoslar()
        {
            if (TempData["GeciciSiparis"] != null)
            {
                TempData["GeciciSiparis"] = JsonConvert
                                    .DeserializeObject<SiparisViewModel>(TempData["GeciciSiparis"].ToString());

                SiparisViewModel siparisVm = (SiparisViewModel)TempData["GeciciSiparis"];
                TempData["GeciciSiparis"] = JsonConvert.SerializeObject(siparisVm);

                List<string> sosAdlar = new();


                foreach (var item in siparisVm.Soslar)
                {
                    sosAdlar.Add(item.Ad);
                }

                Dictionary<string, int> sosGrupSayisi;

                sosGrupSayisi = sosAdlar
                 .GroupBy(x => x)
                 .ToDictionary(g => g.Key, g => g.Count());

                return sosGrupSayisi;
            }
            return null;
        }

        public async Task<Dictionary<string, int>> SepettekiEkstralar()
        {
            if (TempData["GeciciSiparis"] != null)
            {
                TempData["GeciciSiparis"] = JsonConvert
                                    .DeserializeObject<SiparisViewModel>(TempData["GeciciSiparis"].ToString());

                SiparisViewModel siparisVm = (SiparisViewModel)TempData["GeciciSiparis"];
                TempData["GeciciSiparis"] = JsonConvert.SerializeObject(siparisVm);

                List<string> ekstraAdlar = new();


                foreach (var item in siparisVm.Ekstralar)
                {
                    ekstraAdlar.Add(item.Ad);
                }

                Dictionary<string, int> ekstraGrupSayisi;

                ekstraGrupSayisi = ekstraAdlar
                 .GroupBy(x => x)
                 .ToDictionary(g => g.Key, g => g.Count());

                return ekstraGrupSayisi;
            }
            return null;
        }
    }
}
