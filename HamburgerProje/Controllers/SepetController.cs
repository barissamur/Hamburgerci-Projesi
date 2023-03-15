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

        public void SepetiOnayla()
        {

            if (TempData["GeciciSiparis"] != null)
            {

                TempData["GeciciSiparis"] = JsonConvert
                                        .DeserializeObject<SiparisViewModel>(TempData["GeciciSiparis"].ToString());

                SiparisViewModel siparisVm = (SiparisViewModel)TempData["GeciciSiparis"];
                TempData["GeciciSiparis"] = null;

                #region sipariş new'ledik

                var siparis = new Siparis();
                _db.Siparisler.Add(siparis);
                _db.SaveChanges();

                var ekstraList = new List<EkstraSiparis>();
                foreach (var item in siparisVm.Ekstralar)
                {
                    var ekstra = new EkstraSiparis()
                    {
                        EkstraId = item.Id,
                        SiparisId = siparis.Id
                    };

                    ekstraList.Add(ekstra);
                }
                _db.EkstraSiparisler.AddRange(ekstraList);

                var hamburgerList = new List<HamburgerSiparis>();
                foreach (var item in siparisVm.Hamburgerler)
                {
                    var hamburger = new HamburgerSiparis()
                    {
                        HamburgerId = item.Id,
                        SiparisId = siparis.Id
                    };

                    hamburgerList.Add(hamburger);
                }
                _db.HamburgerSiparisler.AddRange(hamburgerList);

                var sosList = new List<SosSiparis>();
                foreach (var item in siparisVm.Soslar)
                {
                    var sos = new SosSiparis()
                    {
                        SosId = item.Id,
                        SiparisId = siparis.Id
                    };

                    sosList.Add(sos);
                }
                _db.SosSiparisler.AddRange(sosList);

                var icecekList = new List<IcecekSiparis>();
                foreach (var item in siparisVm.Icecekler)
                {
                    var icecek = new IcecekSiparis()
                    {
                        IcecekId = item.Id,
                        SiparisId = siparis.Id
                    };

                    icecekList.Add(icecek);
                }
                _db.IcecekSiparisler.AddRange(icecekList);

                var menuList = new List<MenuSiparis>();
                foreach (var item in siparisVm.Menuler)
                {
                    var gercekMenu = _db.Menuler.Find(item.Id);
                    gercekMenu.Adet++;

                    var menu = new MenuSiparis()
                    {
                        MenuId = item.Id,
                        SiparisId = siparis.Id
                    };

                    menuList.Add(menu);
                }
                _db.MenuSiparisler.AddRange(menuList);


                var hmblerToplamFiyat = siparisVm.Hamburgerler.Sum(x => x.Fiyat);
                var menulerToplamFiyat = siparisVm.Menuler.Sum(x => x.Fiyat);
                var soslarToplamFiyat = siparisVm.Soslar.Sum(x => x.Fiyat);
                var ekstralarToplamFiyat = siparisVm.Ekstralar.Sum(x => x.Fiyat);
                var iceceklerToplamFiyat = siparisVm.Icecekler.Sum(x => x.Fiyat);

                var siparisToplamFiyat = hmblerToplamFiyat + menulerToplamFiyat + soslarToplamFiyat + ekstralarToplamFiyat + iceceklerToplamFiyat;
                siparis.Toplam = siparisToplamFiyat;

                _db.SaveChanges();

                var siparisId = siparis.Id;
            }

        }

        #endregion


    }
}

