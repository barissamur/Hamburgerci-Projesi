using HamburgerProje.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
    }
}
