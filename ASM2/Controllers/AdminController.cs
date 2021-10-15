using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ASM2.Models.FPT;

public class AdminController : Controller
{
    // GET: Admin
    public ActionResult Index()
    {
        using (var bwCtx = new ASM2.EF.FPTContext())
        {
            var books = bwCtx.Person
                             .OrderBy(b => b.Id)
                             .ToList();
            return View(books);
        }
    }



    [HttpGet]
    public ActionResult CreatePerson()
    {
        return View();
    }
    [HttpPost]
    public ActionResult CreatePerson(Person newPerson)
    {
        if (!ModelState.IsValid)
        {
            return View(newPerson);
        }
        else
        {
            using (var bwCtx = new ASM2.EF.FPTContext())
            {
                bwCtx.Person.Add(newPerson);
                bwCtx.SaveChanges();
            }

            TempData["message"] = $"Successfully insert a new book with Id: {newPerson.Id}";
            return RedirectToAction("Index");
        }
    }
    [HttpGet]
    public ActionResult EditPersonAcc(int id)
    {
        using (var bwCtx = new ASM2.EF.FPTContext())
        {
            var book = bwCtx.Person.FirstOrDefault(b => b.Id == id);
            //ef method to select only one or null if not found

            if (book != null) // if a book is found, show edit view
            {
                return View(book);
            }
            else // if no book is found, back to index
            {
                return RedirectToAction("Index"); //redirect to action in the same controller
            }
        }
    }
    public ActionResult deletePerson(int id)
    {
        using (var bwCtx = new ASM2.EF.FPTContext())
        {
            var book = bwCtx.Person.FirstOrDefault(b => b.Id == id);
            if (book != null)
            {
                bwCtx.Person.Remove(book);
                bwCtx.SaveChanges();
                TempData["message"] = $"Successfully delete book with Id: {book.Id}";
            }


            return RedirectToAction("Index");
        }
    }
    [HttpPost]
    public ActionResult EditPersonAcc(int id, Person newPerson)
    {
        if (!ModelState.IsValid)
        {
            return View(newPerson);
        }
        else
        {
            using (var bwCtx = new ASM2.EF.FPTContext())
            {
                bwCtx.Entry<Person>(newPerson).State
                    = System.Data.Entity.EntityState.Modified;

                //add book to context and mark it as modified to do update, not insert

                bwCtx.SaveChanges();
            }
            TempData["message"] = $"Successfully update book with Id: {newPerson.Id}";
            return RedirectToAction("Index");
        }
    }


    [HttpGet]
    public ActionResult CreateTrainer()
    {
        return View();
    }



}
