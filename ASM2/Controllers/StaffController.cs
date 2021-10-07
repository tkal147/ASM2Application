using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ASM2.Models.FPT;

namespace ASM2.Controllers
{
    public class StaffController : Controller
    {
        // GET: Staff
        public ActionResult Index()
        {
            using (var bwCtx = new ASM2.EF.FPTContext())
            {
                var books = bwCtx.Trainee
                                 .OrderBy(b => b.Id)
                                 .ToList();
                return View(books);
            }
        }
        public ActionResult ViewAllCat()
        {
            return View();
        }
        [HttpGet]
        public ActionResult CreateTrainee()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateTrainee(Trainee newTrainee)
        {
            if (!ModelState.IsValid)
            {
                return View(newTrainee);
            }
            else
            {
                using (var bwCtx = new ASM2.EF.FPTContext())
                {
                    bwCtx.Trainee.Add(newTrainee);
                    bwCtx.SaveChanges();
                }

                TempData["message"] = $"Successfully insert a new book with Id: {newTrainee.Id}";
                return RedirectToAction("Index");
            }

        }
        [HttpGet]
        public ActionResult EditTrainee(int id)
        {
            using (var bwCtx = new ASM2.EF.FPTContext())
            {
                var book = bwCtx.Trainee.FirstOrDefault(b => b.Id == id);
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
        public ActionResult deleteTrainee(int id)
        {
            using (var bwCtx = new EF.FPTContext())
            {
                var book = bwCtx.Trainee.FirstOrDefault(b => b.Id == id);
                if (book != null)
                {
                    bwCtx.Trainee.Remove(book);
                    bwCtx.SaveChanges();
                    TempData["message"] = $"Successfully delete book with Id: {book.Id}";
                }

                
                return RedirectToAction("Index");
            }
        }
        [HttpPost]
        public ActionResult EditTrainee(int id, Trainee newTrainee)
        {
            if (!ModelState.IsValid)
            {
                return View(newTrainee);
            }
            else
            {
                using (var bwCtx = new ASM2.EF.FPTContext())
                {
                    bwCtx.Entry<Trainee>(newTrainee).State
                        = System.Data.Entity.EntityState.Modified;

                    //add book to context and mark it as modified to do update, not insert

                    bwCtx.SaveChanges();
                }
                TempData["message"] = $"Successfully update book with Id: {newTrainee.Id}";
                return RedirectToAction("Index");
            }
        }
        //[HttpPost]
        //public ActionResult DeleteTrainee(int id)
        //{
        //    using (var bwCtx = new EF.FPTContext())
        //    {
        //        var book = bwCtx.Trainee.FirstOrDefault(b => b.Id == id);
        //        if (book != null) 
        //        {
        //            TempData["message"] = $"Successfully delete book with Id: {book.Id}";
        //            bwCtx.Trainee.Remove(book);
        //            bwCtx.SaveChanges();
                    
        //        }

                
        //        return RedirectToAction("Index");
        //    }
        //}
       
        

        [HttpGet]
        public ActionResult CreateCategories()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateCategories(Categories newCategories)
        {
            if (!ModelState.IsValid)
            {
                return View(newCategories);
            }
            else
            {
                using (var bwCtx = new ASM2.EF.FPTContext())
                {
                    bwCtx.Categories.Add(newCategories);
                    bwCtx.SaveChanges();
                }

                TempData["message"] = $"Successfully insert a new book with Id: {newCategories.Id}";
                return RedirectToAction("Index");
            }
        }
        [HttpGet]
        public ActionResult EditCategories(int id)
        {
            using (var bwCtx = new ASM2.EF.FPTContext())
            {
                var book = bwCtx.Categories.FirstOrDefault(b => b.Id == id);
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
        public ActionResult EditCategories(int id, Categories newCategories)
        {
            if (!ModelState.IsValid)
            {
                return View(newCategories);
            }
            else
            {
                using (var bwCtx = new ASM2.EF.FPTContext())
                {
                    bwCtx.Entry<Categories>(newCategories).State
                        = System.Data.Entity.EntityState.Modified;

                    //add book to context and mark it as modified to do update, not insert

                    bwCtx.SaveChanges();
                }
                TempData["message"] = $"Successfully update book with Id: {newCategories.Id}";
                return RedirectToAction("Index");
            }
        }
       
        public ActionResult DeleteCategories(int id)
        {
            using (var bwCtx = new EF.FPTContext())
            {
                var book = bwCtx.Categories.FirstOrDefault(b => b.Id == id);
                if (book != null)
                {
                    bwCtx.Categories.Remove(book);
                    bwCtx.SaveChanges();
                    TempData["message"] = $"Successfully delete book with Id: {book.Id}";
                }


                return RedirectToAction("Index");
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
        private void PrepareViewBag()
        {
            using (var bwCtx = new ASM2.EF.FPTContext())
            {
                ViewBag.Class = bwCtx.Trainer
                                      .Select(p => new SelectListItem
                                      {
                                          Text = p.Name,
                                          Value = p.Id.ToString()
                                      })
                                      .ToList();

                ViewBag.Course = bwCtx.Course.ToList();
            }
        }
        [HttpGet]
        public ActionResult CreateCourse()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateCourse(Course newCourse)
        {
            return View();
        }
        [HttpGet]
        public ActionResult EditCourse(int id)
        {
            return View();
        }
        [HttpPost]
        public ActionResult EditCourse(int id, Course newCourse)
        {
            return View();
        }
        [HttpPost]
        public ActionResult DeleteCourse(int id)
        {
            return View();
        }
    }
}