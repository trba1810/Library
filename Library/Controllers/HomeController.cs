using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Entity;
using Library.Models;

namespace Library.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index(string Id)
        {

            Books model = new Books();

            model.FillBooks();
            model.getGenres();
                    
            return View("Library",model);
        }

       

        public ActionResult GetAllBooks()
        {
            Books model = new Books();

            model.FillBooks();
            
            return View("Library",model);
        }

        public ActionResult DeleteBook(int id)
        {
            Books oneBook = new Books(id);

            oneBook.DeleteBook();
            oneBook.FillBooks();

            return RedirectToAction("GetAllBooks", "Home");
        }

        public ActionResult UpdateBook(Books model)
        {
            if (ModelState.IsValid)
            {
                model.SaveBook();
            }

            return RedirectToAction("GetAllBooks"); 
        }

        public ActionResult EditBook(int idBook)
        {

            Books model = new Books(idBook);

            model.loadBook();
            return View("EditBook", model);

        }

        public ActionResult SortByGenres(int idGenre)
        {
            Books model = new Books();

            model.getGenres();

            return View("Library", model);
        }
    }
}