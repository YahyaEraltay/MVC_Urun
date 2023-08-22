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
    public class MusteriController : Controller
    {
        // GET: Musteri
        Stok_DBEntities db = new Stok_DBEntities();

        public ActionResult Index()
        {
            var degerler = db.TBL_MUSTERI.ToList();

            return View(degerler);
        }

        [HttpGet]
        public ActionResult YeniMusteri()
        {
            return View();
        }

        [HttpPost]
        public ActionResult YeniMusteri(TBL_MUSTERI p1)
        {
            if (!ModelState.IsValid)
            {
                return View("YeniMusteri");
            }
            db.TBL_MUSTERI.Add(p1);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult Sil(int id)
        {
            var musteri = db.TBL_MUSTERI.Find(id);
            db.TBL_MUSTERI.Remove(musteri);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult MusteriGetir(int id)
        {
            var mus = db.TBL_MUSTERI.Find(id);

            return View("MusteriGetir", mus);
        }

        public ActionResult Guncelle(TBL_MUSTERI p1)
        {
            var mus = db.TBL_MUSTERI.Find(p1.musteriid);
            mus.musteriad = p1.musteriad;
            mus.musterisoyad = p1.musterisoyad;
            db.SaveChanges();

            return RedirectToAction("Index");

        }
    }
}