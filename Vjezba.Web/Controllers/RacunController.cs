using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Vjezba.DAL;
using Vjezba.Model;
using Vjezba.Web.Models;

namespace Vjezba.Web.Controllers
{
    public class RacunController : BaseController
    {
        //private static string filePathForDB;
        private RacunModelDbContext _dbContext;

        public RacunController(RacunModelDbContext dbContext, UserManager<AppUser> userManager) : base(userManager)
        {
            this._dbContext = dbContext;
        }

        //[AllowAnonymous]
        public IActionResult Index(ProizvodUslugaFilterModel filter)
        {
            //var ThreeDQuery = this._dbContext.threeD.Include(p => p.objAttachment).ToList();
            var ThreeDQuery = this._dbContext.korisnik.Include(p => p.IDPoduzece).ToList();

            return View("Index", model: ThreeDQuery);
        }

        public IActionResult IndexTable(ProizvodUslugaFilterModel filter)
        {
            //var ThreeDQuery = this._dbContext.threeD.Include(p => p.objAttachment).ToList();
            var ThreeDQuery = this._dbContext.proizvod.ToList();

            return View("IndexTable", model: ThreeDQuery);
        }
        
        //[Authorize(Roles = "Admin")]
        //public IActionResult Create()
        //{
        //    this.FillDropdownValues();
        //    return View();
        //}

        //[Authorize(Roles = "Admin")]
        //[HttpPost]
        //public IActionResult Create(ThreeD model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        model.CreatedBy = UserId;              

        //        OBJAttachment objatt = new OBJAttachment();
        //        //objatt.OBJFilePath = filePathForDB;
        //        model.objAttachment = objatt;

        //        model.UploadedDateTime = DateTime.Now;

        //        int categoryid = model.CategoryID;
        //        model.CategoryID = categoryid;

        //        //this._dbContext.threeD.Add(model);
        //        this._dbContext.SaveChanges();

        //        return RedirectToAction(nameof(Index));
        //    }
        //    else
        //    {
        //        this.FillDropdownValues();
        //        // modelstate se ponistava tako da prilikom load-a ne prikaze validaciju
        //        ModelState.Clear();
        //        return View();
        //        return View();
        
        //    }
        //}

        //[Authorize(Roles = "Admin,User")]
        public IActionResult Details(int? id = null)
        {
            var proizvod = this._dbContext.proizvod
            .FirstOrDefault(p => p.IDProizvod == id);

            return View("Details", proizvod);
        }

        public IActionResult Delete(int? id = null)
        {
            var proizvod = this._dbContext.proizvod
            .FirstOrDefault(p => p.IDProizvod == id);

            this._dbContext.proizvod.Remove(proizvod);
            this._dbContext.SaveChanges();

            return View("IndexTable");
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult AjaxSearch(ProizvodUslugaFilterModel filter)
        {
            //var ThreeDQuery = this._dbContext.threeD.Include(p => p.objAttachment)
            //    .Include(c => c.Category)
            //    .AsQueryable();

            filter = filter ?? new ProizvodUslugaFilterModel();

            //if (!string.IsNullOrWhiteSpace(filter.Name))
            //{
            //    ThreeDQuery = ThreeDQuery.Where(p => p.Name.ToLower().Contains(filter.Name.ToLower()));
            //}
            //if (!string.IsNullOrWhiteSpace(filter.Category))
            //{
            //    ThreeDQuery = ThreeDQuery.Where(p => p.Category.Name.ToLower().Contains(filter.Category.ToLower()));
            //}               

            //var model = ThreeDQuery.ToList();

            return PartialView("_IndexTable"/*, model: model*/);
        }

        public void UploadObjFile(IFormFile file)
        {
            var FileDic = @"wwwroot\3DModels";
            var fileName = file.FileName;
            var filePath = Path.Combine(FileDic, fileName);

            //filePathForDB = "/3DModels/" + fileName;

            using (FileStream fs = System.IO.File.Create(filePath))
            {
                file.CopyTo(fs);
            }
        }
        private void FillDropdownValues()
        {
            var selectItems = new List<SelectListItem>();

            var listItem = new SelectListItem();
            listItem.Text = "- Odaberi mjernu jedinicu -";
            selectItems.Add(listItem);

            var listItem1 = new SelectListItem();
            listItem1.Text = "kn";
            selectItems.Add(listItem1);

            var listItem2 = new SelectListItem();
            listItem2.Text = "kn/h";
            selectItems.Add(listItem2);

            var listItem3 = new SelectListItem();
            listItem3.Text = "kg";
            selectItems.Add(listItem3);

            //foreach (var category in this._dbContext.threeDCategoryes)
            //{
            //    listItem = new SelectListItem(category.Name, category.ID.ToString());
            //    selectItems.Add(listItem);
            //}
            ViewBag.PossibleCategoryes = selectItems;
        }

        // RACUN
        // RACUN
        //[Route("CustomRoute")]
        //[Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            this.FillDropdownValues();
            return View();
        }

        //[Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult Create(Proizvod model)
        {
            if (ModelState.IsValid)
            {
                Proizvod proizvod = new Proizvod();
                //objatt.OBJFilePath = filePathForDB;
                proizvod.Naziv = model.Naziv;
                proizvod.Cijena = model.Cijena;
                proizvod.MjernaJedinica = model.MjernaJedinica;

                //int categoryid = model.CategoryID;
                //model.CategoryID = categoryid;

                this._dbContext.proizvod.Add(proizvod);
                this._dbContext.SaveChanges();

                return RedirectToAction("Create", "Racun");
            }
            else
            {
                this.FillDropdownValues();
                // modelstate se ponistava tako da prilikom load-a ne prikaze validaciju
                ModelState.Clear();
                return View();
            }
        }

    }
}
