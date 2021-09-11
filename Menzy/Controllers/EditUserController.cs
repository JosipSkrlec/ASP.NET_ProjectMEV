using Menzy.Models;
using Menzy.ViewModels;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Menzy.Controllers
{
    public class EditUserController : Controller
    {
        // GET: EditUser

        private ApplicationDbContext _context;
        public EditUserController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ActionResult Index(string id)
        {

            string testID = Request.Url.ToString();
            Console.WriteLine(testID);

            var user = _context.Users.SingleOrDefault(c => c.Id == id);
            string lol = "https://localhost:44320/EditUser/Index/" + user.Id.ToString();
            Console.WriteLine(lol);
            if (testID != lol)
                return HttpNotFound();
            else
            {
                var viewModel = new UserFormViewModel
                {
                    User = user,

                };
                return View("Index", viewModel);
            }



        }
        [HttpPost]
        public ActionResult Save(ApplicationUser user)
        {
            if (user.Ime == null || user.Prezime == null || user.JMBAG == null || user.JMBAG.Length != 10)
            {
                var viewModel = new UserFormViewModel
                {
                    User = user
                };
                return View("Index", viewModel);
            }

            if (user.Id == "")
                return RedirectToAction("Index", "Manage");
            else
            {
                var userInDb = _context.Users.Single(c => c.Id == user.Id);

                userInDb.Ime = user.Ime;
                userInDb.Prezime = user.Prezime;
                userInDb.Redovni = user.Redovni;
                userInDb.JMBAG = user.JMBAG;
                userInDb.Email = user.Email;
                userInDb.KojiFaks = user.KojiFaks;

            }
            _context.SaveChanges();
            return RedirectToAction("Index", "Manage");
        }

    }
}