using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_Urun_Takip.Models.Entity;
using PagedList;
using PagedList.Mvc;

namespace MVC_Urun_Takip.Controllers
{
    public class KategoriController : Controller
    {
        // GET: Kategori
        Stok_DBEntities db = new Stok_DBEntities();
        public ActionResult Index()
        {
            var degerler = db.TBL_KATEGORI.ToList();
            return View(degerler);
        }

        [HttpGet]
        public ActionResult YeniKategori()
        {
            return View();
        }

        [HttpPost]
        public ActionResult YeniKategori(TBL_KATEGORI p1)
        {
            if (!ModelState.IsValid)
            {
                return View("YeniKategori");
            }
            db.TBL_KATEGORI.Add(p1);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult Sil(int id)
        {
            var ktgr = db.TBL_KATEGORI.Find(id);
            db.TBL_KATEGORI.Remove(ktgr);
            db.SaveChanges();

            return RedirectToAction("Index");
        }
        
        public ActionResult KategoriGetir(int id)
        {
            var ktgr = db.TBL_KATEGORI.Find(id);

            return View("KategoriGetir", ktgr);
        }

        public ActionResult Guncelle(TBL_KATEGORI p1)
        {
            var ktg = db.TBL_KATEGORI.Find(p1.kategoriid);
            ktg.kategoriad = p1.kategoriad;
            db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}