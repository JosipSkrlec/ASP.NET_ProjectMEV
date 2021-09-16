using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using Vjezba.DAL;
using Vjezba.Model;
using Vjezba.Web.Models;

// serija na serveru
// cookies in browser
namespace Vjezba.Web.Controllers
{
    public class RacunController : BaseController
    {
        //private static string filePathForDB;
        private RacunModelDbContext _dbContext;

        public static int pdfCounterHelperIndex = 0;

        public RacunController(RacunModelDbContext dbContext, UserManager<AppUser> userManager) : base(userManager)
        {
            this._dbContext = dbContext;
        }

        //[AllowAnonymous]
        public IActionResult Index(ProizvodUslugaFilterModel filter)
        {
            //var ThreeDQuery = this._dbContext.threeD.Include(p => p.objAttachment).ToList();
            var proizvodList = this._dbContext.korisnik.Include(p => p.IDPoduzece).ToList();

            return View("Index", model: proizvodList);
        }

        public IActionResult IndexTable(ProizvodUslugaFilterModel filter)
        {
            //var ThreeDQuery = this._dbContext.threeD.Include(p => p.objAttachment).ToList();
            var proizvodList = this._dbContext.proizvod.ToList();

            return View("IndexTable", model: proizvodList);
        }

        public IActionResult ShoppingCart()
        {
            //var ThreeDQuery = this._dbContext.threeD.Include(p => p.objAttachment).ToList();
            //var proizvodList = this._dbContext.proizvod.ToList();

            string cart = HttpContext.Session.GetString("cart");

            if (cart == null)
            {
                return RedirectToAction("ShoppingCart");
            }

            string[] separated = cart.Split(",");

            List<Proizvod> proizvodList = new List<Proizvod>(); /*this._dbContext.proizvod.Where(p => p.IDProizvod ==);*/

            foreach (var item in separated)
            {
                proizvodList.Add(this._dbContext.proizvod.Find(int.Parse(item)));
            }


            return View("ShoppingCart", proizvodList);
        }

        public IActionResult AddToShopingCart(int? id = null)
        {
            //var ThreeDQuery = this._dbContext.threeD.Include(p => p.objAttachment).ToList();
            //var proizvodList = this._dbContext.proizvod.ToList();

            if (HttpContext.Session.GetString("cart") == null)
            {
                HttpContext.Session.SetString("cart", id.ToString());

                //return View("IndexTable"/*, model: proizvodList*/);
                return RedirectToAction("IndexTable"); // u slucaju kada trebamo samo view!
            }
            else
            {                
                string cart = HttpContext.Session.GetString("cart");

                cart += "," + id;

                //1,4,3,2,1,78,

                HttpContext.Session.SetString("cart", cart);
            }

            //return View("IndexTable",null/*, model: proizvodList*/);
            return RedirectToAction("IndexTable");
        }  

        public IActionResult CreatePDF(List<Proizvod> proizvodList)
        {
            string cart = HttpContext.Session.GetString("cart");

            if (cart == null)
            {
                return RedirectToAction("ShoppingCart");
            }

            string[] separated = cart.Split(",");

            proizvodList = new List<Proizvod>(); /*this._dbContext.proizvod.Where(p => p.IDProizvod ==);*/

            foreach (var item in separated)
            {
                proizvodList.Add(this._dbContext.proizvod.Find(int.Parse(item)));
            }

            RacuniPDF pdf = new RacuniPDF(_dbContext);

            pdf.GenerirajPDF(proizvodList);

            pdfCounterHelperIndex++;
            var pdfPodaciByteArray = pdf.Podaci;
            System.IO.File.WriteAllBytes(@"wwwroot\PDFs\Racunstavka" + pdfCounterHelperIndex + ".pdf", pdfPodaciByteArray);

            //FileStream fileStream = new FileStream("RacunStavke", FileMode.Create, FileAccess.ReadWrite);
            //fileStream.Write(pdfPodaciByteArray, 0, pdfPodaciByteArray.Length);
            //fileStream.Close();

            return File(pdf.Podaci, System.Net.Mime.MediaTypeNames.Application.Pdf, "RacunStavke.pdf");
        }


        [Authorize(Roles = "Admin")]
        public IActionResult PDFList()
        {
            string[] filePaths = Directory.GetFiles(@"wwwroot\PDFs\", "", SearchOption.AllDirectories);

            return View("PDFList", filePaths);
        }

        [Authorize(Roles = "Admin")]
        public IActionResult ShowPDF(string pdfPath)
        {
            if (pdfPath == null)
            {
                return RedirectToAction();
            }
            else
            {

                //var folderPath = Path.Combine(pdfPath);

                //if (Directory.Exists(folderPath))
                //{
                //    var fileCount = Directory.GetFiles(@folderPath, "*.pdf");
                //    if (fileCount.Length > 1) // more than 1 file
                //    {
                //        Process.Start(folderPath);
                //    }
                //    else if (fileCount.Length == 1) // exactly only 1 file
                //    {
                //        //if(TempData["SingleFileName"] != null)
                //        //{
                //        //    string name = TempData["SingleFileName"] as string;

                //        return File(folderPath + "\\" + pdfPath, "application/pdf");
                //        //}
                //    }
                //    else // no files 
                //    {
                //        // maybe make alert message says apparently has no files ?!@ ?! !?!?? ??
                //        Process.Start(folderPath);
                //    }

                //}

                //Stream stream = null;
                //FileStream fstream = null;
                //if (System.IO.File.Exists(pdfPath) == false)
                //{
                //    HttpWebRequest request = (HttpWebRequest)WebRequest.Create(pdfPath);
                //    HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                //    stream = response.GetResponseStream();

                //    //byte[] inBuffer = ReadFully(stream);
                //    byte[] FileBytes = System.IO.File.ReadAllBytes(pdfPath);
                //    fstream = new FileStream(pdfPath, FileMode.OpenOrCreate, FileAccess.Write);
                //    fstream.Write(FileBytes, 0, FileBytes.Length - 1);


                //    fstream.Close();
                //    stream.Close();
                //}


                //string fullPath = Path.Combine(@"", pdfPath);

                //return the file for download, this is an Excel 
                //so I set the file content type to "application/vnd.ms-excel"
                //return File(fullPath, "DownloadedPDF", pdfPath);


                //Read the File data into Byte Array.
                byte[] bytes = System.IO.File.ReadAllBytes(pdfPath);

                //Send the File to Download.
                return File(bytes, "application/octet-stream", "RacunPregledPDF.pdf");

                //return RedirectToAction();
            }
        }


        //[Authorize(Roles = "Admin,User")]
        public IActionResult Details(int? id = null)
        {
            var proizvod = this._dbContext.proizvod
            .FirstOrDefault(p => p.IDProizvod == id);

            return View("Details", proizvod);
        }

        [Authorize(Roles = "Admin")]/*,User*/
        public IActionResult Delete(int? id = null)
        {
            var proizvod = this._dbContext.proizvod.FirstOrDefault(p => p.IDProizvod == id);

            this._dbContext.proizvod.Remove(proizvod);
            this._dbContext.SaveChanges();


            return View("IndexTable", this._dbContext.proizvod.ToList());
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

        //public void UploadObjFile(IFormFile file)
        //{
        //    var FileDic = @"wwwroot\3DModels";
        //    var fileName = file.FileName;
        //    var filePath = Path.Combine(FileDic, fileName);

        //    //filePathForDB = "/3DModels/" + fileName;

        //    using (FileStream fs = System.IO.File.Create(filePath))
        //    {
        //        file.CopyTo(fs);
        //    }
        //}
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
        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            this.FillDropdownValues();
            return View();
        }

        [Authorize(Roles = "Admin")]
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
