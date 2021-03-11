using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using googlemapMVC.Models;

namespace googlemapMVC.Controllers
{
    public class HomeController : Controller
    {
        haritaCONTEXT db = new haritaCONTEXT();

        public ActionResult Index()
        {


            var sehirlerim = db.sehirler.ToList();
            ViewBag.sehir = new SelectList(sehirlerim, "id", "sehiradi");
            //string markers = "[";
            //foreach (var item in konumlarım)
            //{

            //    string enlem1 = item.enlem.ToString();
            //    string boylam = item.boylam.ToString();
            //    enlem1 = enlem1.Replace(",", ".");
            //    boylam = boylam.Replace(",", ".");
            //    markers += "{";
            //    markers += string.Format("'title': '{0}',", item.baslik);
            //    markers += string.Format("'lat': '{0}',", enlem1);
            //    markers += string.Format("'lng': '{0}',", boylam);
            //    markers += string.Format("'description': '{0}'", item.aciklama);
            //    markers += "},";
            //}
            //markers += "];";
            //ViewBag.Markers = markers;

            return View();
        }
        [HttpPost]
        public ActionResult Index(string dropdanveri)
        {
            var sehirlerim = db.sehirler.ToList();
            ViewBag.sehir = new SelectList(sehirlerim, "id", "sehiradi");

            int sehirid = Convert.ToInt32(dropdanveri);
            string gelensehir = (from veri in db.sehirler
                                 where veri.id == sehirid
                                 select veri.sehiradi).FirstOrDefault();
            var listkonumları = (from gidecekler in db.konumlar
                                 where gidecekler.sehir == gelensehir
                                 select gidecekler).ToList();

            string markers = "[";
            foreach (var item in listkonumları)
            {

                string enlem1 = item.enlem.ToString();
                string boylam = item.boylam.ToString();
                enlem1 = enlem1.Replace(",", ".");
                boylam = boylam.Replace(",", ".");
                markers += "{";
                markers += string.Format("'title': '{0}',", item.baslik);
                markers += string.Format("'lat': '{0}',", enlem1);
                markers += string.Format("'lng': '{0}',", boylam);
                markers += string.Format("'description': '{0}'", item.aciklama);
                markers += "},";
            }
            markers += "];";
            ViewBag.Markers = markers;




            return View();
        }
    }
}