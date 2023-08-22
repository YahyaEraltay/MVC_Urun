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
    public class UrunController : Controller
    {
        // GET: Urun
        Stok_DBEntities db = new Stok_DBEntities();
        public ActionResult Index()
        {
            var degerler = db.TBL_URUN.ToList();
            return View(degerler);
        }

        [HttpGet]
        public ActionResult YeniUrun()
        {
            List<SelectListItem> degerler = (from i in db.TBL_KATEGORI.ToList() select new SelectListItem { Text = i.kategoriad, Value = i.kategoriid.ToString() }).ToList();
            ViewBag.dgr = degerler;

            return View();
        }

        [HttpPost]
        public ActionResult YeniUrun(TBL_URUN p1)
        {
            if (!ModelState.IsValid)
            {
                return View("YeniUrun");
            }
            var ktg = db.TBL_KATEGORI.Where(m => m.kategoriid == p1.TBL_KATEGORI.kategoriid).FirstOrDefault();
            p1.TBL_KATEGORI = ktg;
            db.TBL_URUN.Add(p1);
            db.SaveChanges();

            return RedirectToAction("Index");
        }
        public ActionResult Sil(int id)
        {
            var urun = db.TBL_URUN.Find(id);
            db.TBL_URUN.Remove(urun);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult UrunGetir(int id)
        {
            List<SelectListItem> degerler = (from i in db.TBL_KATEGORI.ToList() select new SelectListItem { Text = i.kategoriad, Value = i.kategoriid.ToString() }).ToList();
            ViewBag.dgr = degerler;
            var urun = db.TBL_URUN.Find(id);

            return View("UrunGetir", urun);
        }

        public ActionResult Guncelle(TBL_URUN p1)
        {
            var urun = db.TBL_URUN.Find(p1.urunid);
            urun.urunad = p1.urunad;
            urun.marka = p1.marka;
            urun.fiyat = p1.fiyat;
            urun.stok = p1.stok;
            var ktg = db.TBL_KATEGORI.Where(m => m.kategoriid == p1.TBL_KATEGORI.kategoriid).FirstOrDefault();
            urun.urunkategori = ktg.kategoriid;
            db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}