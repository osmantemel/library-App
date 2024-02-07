using libapp.webui.Models;
using libData.Concrete;
using libEntity;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using static System.Reflection.Metadata.BlobBuilder;

namespace libapp.webui.Controllers
{
    public class HomeController : Controller
    {
  

        public IActionResult Index(string q)
        {
            

            var bookRepo  = new bookRepo();
            var books=new List<books>();

            books =  bookRepo.GetAll();


            if (!string.IsNullOrEmpty(q))
            {
                q = q.ToUpper();
                foreach (var book in books)
                {
                    book.kitapAdi = book.kitapAdi.ToUpper();
                    book.YazarAdi = book.YazarAdi.ToUpper();
                }
                books = books.Where((p) => (p.kitapAdi == q) || (p.YazarAdi == q)).ToList();


                ViewBag.books = books;
            }
            else
            {
                ViewBag.books = books;
            }

            return View(books);

        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(string username,string password)
        {
           loginAdmin la = new loginAdmin();
           la.password = password;
           la.usarName=username;
           loginAdminControl lac=new loginAdminControl();
          int a= lac.loginAdminYesNo(la);

            if(a == 1)
            {
                return RedirectToAction("Index", "admin");
                
            }
            else
            {
                return View();
            }

        }


    }
}