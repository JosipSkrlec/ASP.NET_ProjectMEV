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
    [Authorize(Roles = RoleName.CanManageFoods)]
    public class AdminController : Controller
    {
        private ApplicationDbContext _context;
        public AdminController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        public ViewResult Index()
        {
            var korisnici = _context.Users.ToList();

            return View(korisnici);

        }
        public ViewResult ListUsers()
        {
            var korisnici = _context.Users.ToList();

            return View(korisnici);

        }
        public ActionResult New()
        {

            var viewModel = new UserFormViewModel
            {
            };
            return View("UserForm", viewModel);
        }
        public ActionResult UserForm()
        {

            var viewModel = new UserFormViewModel
            {
            };
            return View("UserForm", viewModel);
            //return RedirectToAction("Index", "Admin");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(ApplicationUser user)
        {
            if (user.Ime== null || user.Prezime == null  || user.JMBAG == null || user.JMBAG.Length != 10)
            {
                var viewModel = new UserFormViewModel
                {
                    User = user
                };
                return View("UserForm", viewModel);
            }

            if (user.Id == "")
                return RedirectToAction("Index", "Admin");
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
            return RedirectToAction("ListUsers", "Admin");
        }
       
        public ActionResult EditUser(string id)
        {
            var user = _context.Users.SingleOrDefault(c => c.Id == id);
            if (user == null)
                return HttpNotFound();
            var viewModel = new UserFormViewModel
            {
                User = user,

            };
            return View("UserForm", viewModel);
        }
        public ActionResult DeleteUser(string id)
        {
            var user = _context.Users.SingleOrDefault(c => c.Id == id);
             

            if (user == null)
                return HttpNotFound();

            _context.Users.Remove(user);
            _context.SaveChanges();
            return RedirectToAction("ListUsers", "Admin");
        }
    }
    }
      
