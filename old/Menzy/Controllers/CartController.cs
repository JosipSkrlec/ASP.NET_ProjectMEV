using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Menzy.Models;
using Menzy.Reports;
using Newtonsoft.Json.Linq;

namespace Menzy.Controllers
{
    public class CartController : Controller
    {
        private ApplicationDbContext _context;
        public CartController()
        {
            _context = new ApplicationDbContext();

        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        // GET: Cart
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult RacunPDF(List<Stavka> stavke)
        {
            RacuniPDF racuniPDF = new RacuniPDF();
            racuniPDF.GenerirajPDF(stavke);

            return File(racuniPDF.Podaci, System.Net.Mime.MediaTypeNames.Application.Pdf, "PopisStudenata.pdf");
        }
        public ActionResult IzradaRacuna()
        {

            var cook = "";
            var lol = "";
            int idfood = 0;
            string idfood1 = "";
            int brojfood = 0;
            int ukupnacijena = 0;
            //List<Stavka> stav = new List<Stavka>();
            JArray o = new JArray();

            List<Stavka> stavke = new List<Stavka>();
            if (HttpContext.Request.Cookies["kosarica"] != null)
            {
                cook = HttpContext.Request.Cookies["kosarica"].Value;
                lol = System.Uri.UnescapeDataString(cook);
                o = JArray.Parse(lol);


                Racun racun = new Racun();
                racun.User = _context.Users.FirstOrDefault(u => u.Email == System.Web.HttpContext.Current.User.Identity.Name);

               


                foreach (JObject item in o)
                {
                    idfood1 = item["food_id"].ToString();
                    idfood = Int32.Parse(idfood1);
                    brojfood = Int32.Parse(item["kolicina"].ToString());
                    Food food = _context.Foods.SingleOrDefault(f => f.Id == idfood);
                    ukupnacijena += (int)food.Price * brojfood;
                    Stavka stavka = new Stavka() { Quantity = brojfood, Food = food, Racun = racun };
                    stavke.Add(stavka);
                    _context.Stavkas.Add(stavka);
                }

                racun.Price=(double)ukupnacijena;

                _context.Racuns.Add(racun);

                _context.SaveChanges();


                //RacunPDF(stavke);


            }

            RacuniPDF racuniPDF = new RacuniPDF();
            racuniPDF.GenerirajPDF(stavke);

            Response.Cookies["kosarica"].Expires = DateTime.Now.AddDays(-1);

            return File(racuniPDF.Podaci, System.Net.Mime.MediaTypeNames.Application.Pdf, "Racun.pdf");
           // return View("IzradaRacuna");
        }
    }
}