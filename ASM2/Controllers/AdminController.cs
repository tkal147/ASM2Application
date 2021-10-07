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
            var books = bwCtx.TrainingStaff
                             .OrderBy(b => b.Id)
                             .ToList();
            return View(books);
        }
    }
    public ActionResult ViewAllTrainer()
    {
        using (var bwCtx = new ASM2.EF.FPTContext())
        {
            var books = bwCtx.Trainer
                             .OrderBy(b => b.Id)
                             .ToList();
            return View(books);
        }
    }
    [HttpGet]
    public ActionResult CreateTrainer()
    {
        return View();
    }
    [HttpPost]
    public ActionResult CreateTrainer(Trainer newTrainer)
    {
        if (!ModelState.IsValid)
        {
            return View(newTrainer);
        }
        else
        {
            using (var bwCtx = new ASM2.EF.FPTContext())
            {
                bwCtx.Trainer.Add(newTrainer);
                bwCtx.SaveChanges();
            }

            TempData["message"] = $"Successfully insert a new book with Id: {newTrainer.Id}";
            return RedirectToAction("ViewAllTrainer");
        }
    }
    [HttpGet]
    public ActionResult EditTrainer(int id)
    {
        using (var bwCtx = new ASM2.EF.FPTContext())
        {
            var book = bwCtx.Trainer.FirstOrDefault(b => b.Id == id);
            //ef method to select only one or null if not found

            if (book != null) // if a book is found, show edit view
            {
                return View(book);
            }
            else // if no book is found, back to index
            {
                return RedirectToAction("ViewAllTrainer"); //redirect to action in the same controller
            }
        }
    }
    [HttpPost]
    public ActionResult EditTrainer(int id, Trainer newTrainer)
    {
        if (!ModelState.IsValid)
        {
            return View(newTrainer);
        }
        else
        {
            using (var bwCtx = new ASM2.EF.FPTContext())
            {
                bwCtx.Entry<Trainer>(newTrainer).State
                    = System.Data.Entity.EntityState.Modified;

                //add book to context and mark it as modified to do update, not insert

                bwCtx.SaveChanges();
            }
            TempData["message"] = $"Successfully update book with Id: {newTrainer.Id}";
            return RedirectToAction("ViewAllTrainer");
        }
    }
    
    public ActionResult DeleteTrainer(int id)
    {
        using (var bwCtx = new ASM2.EF.FPTContext())
        {
            var book = bwCtx.Trainer.FirstOrDefault(b => b.Id == id);
            if (book != null)
            {
                bwCtx.Trainer.Remove(book);
                bwCtx.SaveChanges();
                TempData["message"] = $"Successfully delete book with Id: {book.Id}";
            }


            return RedirectToAction("ViewAllTrainer");
        }
    }

    [HttpGet]
    public ActionResult CreateStaff()
    {
        return View();
    }
    [HttpPost]
    public ActionResult CreateStaff(TrainingStaff newTrainer)
    {
        if (!ModelState.IsValid)
        {
            return View(newTrainer);
        }
        else
        {
            using (var bwCtx = new ASM2.EF.FPTContext())
            {
                bwCtx.TrainingStaff.Add(newTrainer);
                bwCtx.SaveChanges();
            }

            TempData["message"] = $"Successfully insert a new book with Id: {newTrainer.Id}";
            return RedirectToAction("Index");
        }
    }
    [HttpGet]
    public ActionResult EditStaff(int id)
    {
        using (var bwCtx = new ASM2.EF.FPTContext())
        {
            var book = bwCtx.TrainingStaff.FirstOrDefault(b => b.Id == id);
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
    [HttpPost]
    public ActionResult EditStaff(int id, TrainingStaff newStaff)
    {
        if (!ModelState.IsValid)
        {
            return View(newStaff);
        }
        else
        {
            using (var bwCtx = new ASM2.EF.FPTContext())
            {
                bwCtx.Entry<TrainingStaff>(newStaff).State
                    = System.Data.Entity.EntityState.Modified;

                //add book to context and mark it as modified to do update, not insert

                bwCtx.SaveChanges();
            }
            TempData["message"] = $"Successfully update book with Id: {newStaff.Id}";
            return RedirectToAction("Index");
        }
    }
    public ActionResult DeleteStaff(int id)
    {
        using (var bwCtx = new ASM2.EF.FPTContext())
        {
            var book = bwCtx.TrainingStaff.FirstOrDefault(b => b.Id == id);
            if (book != null)
            {
                bwCtx.TrainingStaff.Remove(book);
                bwCtx.SaveChanges();
                TempData["message"] = $"Successfully delete book with Id: {book.Id}";
            }


            return RedirectToAction("Index");
        }
    }

    
}
