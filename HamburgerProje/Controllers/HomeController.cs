using HamburgerProje.Data;
using HamburgerProje.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;

namespace HamburgerProje.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly UygulamaDbContext _db;

        public HomeController(ILogger<HomeController> logger, UygulamaDbContext db)
        {
            _logger = logger;
            _db=db;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Firsatlar()
        {
            return View(_db.Menuler.ToList());
        }
        public IActionResult Hakkimizda()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult EnCokSatanlar()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult EnCokListesindenSepeteEkle(int id)
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

            return RedirectToAction("Index");
        }

        public IActionResult FirsatlardanSepeteEkle(int id)
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

            return RedirectToAction("Firsatlar");
        }

    }
}