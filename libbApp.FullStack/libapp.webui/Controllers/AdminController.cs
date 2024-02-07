using libapp.webui.Models;
using libData.Concrete;
using libEntity;
using Microsoft.AspNetCore.Mvc;

namespace libapp.webui.Controllers
{
    public class AdminController: Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult bookList(string q)
        {
            var bookRepo = new bookRepo();
            var books = new List<books>();

            books = bookRepo.GetAll();


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
        [HttpPost]
        public IActionResult booksAdd(bookModels bm)
        { 
            var b = new books();
            b.kitapAdi=bm.kitapAdi;
            b.YazarAdi = bm.YazarAdi;
            b.konum=bm.konum;   

            bookRepo bookRepo = new bookRepo();
            bookRepo.Create(b);

            return RedirectToAction("bookList");
        }
        [HttpGet]
        public IActionResult booksAdd()
        {
            return View();
        }
        
        public IActionResult bookUpdate()
        {
            return View();
        }
    
        public IActionResult bookEdit(string q ,int d)
        {
           Console.WriteLine(q); Console.WriteLine(d);
            var bookRepo = new bookRepo();
            var books = new List<books>();

            books = bookRepo.GetAll();


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
            return View();
        }

        [HttpPost]
        public IActionResult Delete(int bookId)
        {
            bookRepo bookRepo= new bookRepo();
            bookRepo.Delete(bookId);
            Console.WriteLine(bookId);
            return RedirectToAction("bookList");
        }

        [HttpGet]
        public IActionResult Update(int BookId)
        {

            bookRepo bookRepo = new bookRepo();
            books books=  bookRepo.GetByIdAsync(BookId);
            return View(books);
        }

        [HttpPost]
        public IActionResult Update(bookModels bm)
        {
            bookRepo bookRepo=new bookRepo();
            books b = new books();
            b.BookId = bm.BookId;
            b.konum=bm.konum;
            b.kitapAdi= bm.kitapAdi;
            b.YazarAdi= bm.YazarAdi;
            bookRepo.Update(b);
              
            return RedirectToAction("bookList");
        }
    }
}
