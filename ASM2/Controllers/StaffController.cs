using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ASM2.Models.FPT;
using System.Data.Entity;

namespace ASM2.Controllers
{
    public class StaffController : Controller
    {
        public ActionResult ViewAllPerson()
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
                return RedirectToAction("viewallperson");
            }

        }
        [HttpGet]
        public ActionResult EditPerson(int id)
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
            using (var bwCtx = new EF.FPTContext())
            {
                var book = bwCtx.Person.FirstOrDefault(b => b.Id == id);
                if (book != null)
                {
                    bwCtx.Person.Remove(book);
                    bwCtx.SaveChanges();
                    TempData["message"] = $"Successfully delete book with Id: {book.Id}";
                }


                return RedirectToAction("viewallperson");
            }
        }
        [HttpPost]
        public ActionResult EditPerson(int id, Person newPerson)
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
        public ActionResult ViewAllCategories()
        {
            using (var bwCtx = new ASM2.EF.FPTContext())
            {
                var books = bwCtx.Categories
                                 .OrderBy(b => b.Id)
                                 .ToList();
                return View(books);
            }
        }
        // GET: Staff

        public ActionResult ViewAllCat()
        {
            return View();
        }
        //[HttpGet]
        //public ActionResult CreateTrainee()
        //{
        //    return View();
        //}
        //[HttpPost]
        //public ActionResult CreateTrainee(Trainee newTrainee)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return View(newTrainee);
        //    }
        //    else
        //    {
        //        using (var bwCtx = new ASM2.EF.FPTContext())
        //        {
        //            bwCtx.Trainee.Add(newTrainee);
        //            bwCtx.SaveChanges();
        //        }

        //        TempData["message"] = $"Successfully insert a new book with Id: {newTrainee.Id}";
        //        return RedirectToAction("Index");
        //    }

        //}
        //[HttpGet]
        //public ActionResult EditTrainee(int id)
        //{
        //    using (var bwCtx = new ASM2.EF.FPTContext())
        //    {
        //        var book = bwCtx.Trainee.FirstOrDefault(b => b.Id == id);
        //        //ef method to select only one or null if not found

        //        if (book != null) // if a book is found, show edit view
        //        {
        //            return View(book);
        //        }
        //        else // if no book is found, back to index
        //        {
        //            return RedirectToAction("Index"); //redirect to action in the same controller
        //        }
        //    }
        //}
        //public ActionResult deleteTrainee(int id)
        //{
        //    using (var bwCtx = new EF.FPTContext())
        //    {
        //        var book = bwCtx.Trainee.FirstOrDefault(b => b.Id == id);
        //        if (book != null)
        //        {
        //            bwCtx.Trainee.Remove(book);
        //            bwCtx.SaveChanges();
        //            TempData["message"] = $"Successfully delete book with Id: {book.Id}";
        //        }


        //        return RedirectToAction("Index");
        //    }
        //}
        //[HttpPost]
        //public ActionResult EditTrainee(int id, Trainee newTrainee)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return View(newTrainee);
        //    }
        //    else
        //    {
        //        using (var bwCtx = new ASM2.EF.FPTContext())
        //        {
        //            bwCtx.Entry<Trainee>(newTrainee).State
        //                = System.Data.Entity.EntityState.Modified;

        //            //add book to context and mark it as modified to do update, not insert

        //            bwCtx.SaveChanges();
        //        }
        //        TempData["message"] = $"Successfully update book with Id: {newTrainee.Id}";
        //        return RedirectToAction("Index");
        //    }
        //}
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
                return RedirectToAction("ViewAllCategories");
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
                    return RedirectToAction("ViewAllCategories"); //redirect to action in the same controller
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
                return RedirectToAction("ViewAllCategories");
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


                return RedirectToAction("ViewAllCategories");
            }
        }
        //public ActionResult ViewAllTrainer()
        //{
        //    using (var bwCtx = new ASM2.EF.FPTContext())
        //    {
        //        var books = bwCtx.Trainer
        //                         .OrderBy(b => b.Id)
        //                         .ToList();
        //        return View(books);
        //    }
        //}
        //[HttpGet]
        //public ActionResult CreateTrainer()
        //{
        //    return View();
        //}
        //[HttpPost]
        //public ActionResult CreateTrainer(Trainer newTrainer)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return View(newTrainer);
        //    }
        //    else
        //    {
        //        using (var bwCtx = new ASM2.EF.FPTContext())
        //        {
        //            bwCtx.Trainer.Add(newTrainer);
        //            bwCtx.SaveChanges();
        //        }

        //        TempData["message"] = $"Successfully insert a new book with Id: {newTrainer.Id}";
        //        return RedirectToAction("ViewAllTrainer");
        //    }
        //}
        //[HttpGet]
        //public ActionResult EditTrainer(int id)
        //{
        //    using (var bwCtx = new ASM2.EF.FPTContext())
        //    {
        //        var book = bwCtx.Trainer.FirstOrDefault(b => b.Id == id);
        //        //ef method to select only one or null if not found

        //        if (book != null) // if a book is found, show edit view
        //        {
        //            return View(book);
        //        }
        //        else // if no book is found, back to index
        //        {
        //            return RedirectToAction("ViewAllTrainer"); //redirect to action in the same controller
        //        }
        //    }
        //}
        //[HttpPost]
        //public ActionResult EditTrainer(int id, Trainer newTrainer)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return View(newTrainer);
        //    }
        //    else
        //    {
        //        using (var bwCtx = new ASM2.EF.FPTContext())
        //        {
        //            bwCtx.Entry<Trainer>(newTrainer).State
        //                = System.Data.Entity.EntityState.Modified;
        //            bwCtx.SaveChanges();
        //        }
        //        TempData["message"] = $"Successfully update book with Id: {newTrainer.Id}";
        //        return RedirectToAction("ViewAllTrainer");
        //    }
        //}

        //public ActionResult DeleteTrainer(int id)
        //{
        //    using (var bwCtx = new ASM2.EF.FPTContext())
        //    {
        //        var book = bwCtx.Trainer.FirstOrDefault(b => b.Id == id);
        //        if (book != null)
        //        {
        //            bwCtx.Trainer.Remove(book);
        //            bwCtx.SaveChanges();
        //            TempData["message"] = $"Successfully delete book with Id: {book.Id}";
        //        }


        //        return RedirectToAction("ViewAllTrainer");
        //    }
        //}

        public ActionResult ViewAllCourse()
        {

            using (var bwCtx = new ASM2.EF.FPTContext())
            {
                var books = bwCtx.Course
                                 .OrderBy(b => b.Id)
                                 .ToList();
                return View(books);
            }

        }
        private void PrepareViewBagS()
        {
            using (var bwCtx = new ASM2.EF.FPTContext())
            {
                //ViewBag.Class = bwCtx.Course
                //                      .Select(p => new SelectListItem
                //                      {
                //                          Text = p.Name,
                //                          Value = p.Id.ToString()
                //                      })
                //                      .ToList();

                ViewBag.Person = bwCtx.Person.ToList();
            }
        }
        private List<SelectListItem> GetCategoryDropDown()
        {
            using (var bwCtx = new ASM2.EF.FPTContext())
            {
                var categories = bwCtx.Categories
                                 .Select(p => new SelectListItem
                                 {
                                     Text = p.Name,
                                     Value = p.Id.ToString()
                                 }).ToList();
                return categories;
            }
        }

        private List<Person> LoadFormatsS(ASM2.EF.FPTContext bwCtx, string formatIds)
        {
            var selectedSIds = formatIds.Split(',')
                                        .Select(id => Int32.Parse(id))
                                        .ToArray();
            return bwCtx.Person.Where(f => selectedSIds.Contains(f.Id)).ToList();

        }
        [HttpGet]
        public ActionResult CreateCourse()
        {

            PrepareViewBagS();
            ViewBag.Categories = GetCategoryDropDown();
            return View();
        }
        [HttpPost]
        public ActionResult CreateCourse(Course newCourse, FormCollection fs)
        {
            ViewBag.Categories = GetCategoryDropDown();
            if (!ModelState.IsValid)
            {


                TempData["traineeIds"] = fs["traineeIds[]"];
                PrepareViewBagS();

                return View(newCourse);
            }
            else
            {
                using (var bwCtx = new ASM2.EF.FPTContext())
                {
                    if (fs["traineeIds[]"] != null)
                    {

                        newCourse.Person = LoadFormatsS(bwCtx, fs["traineeIds[]"]);
                    }

                    bwCtx.Course.Add(newCourse);
                    bwCtx.SaveChanges();
                }

                TempData["message"] = $"Successfully insert a new book with Id: {newCourse.Id}";
                return RedirectToAction("ViewAllCourse");
            }
        }
        [HttpGet]
        public ActionResult EditCourse(int id)
        {
            using (var bwCtx = new ASM2.EF.FPTContext())
            {
                ViewBag.Categories = GetCategoryDropDown();



                var person = bwCtx.Course
                    .Include(b => b.Person)
                    .FirstOrDefault(b => b.Id == id);

                if (person != null) // if a book is found, show edit view
                {

                    PrepareViewBagS();
                    return View(person);
                }
                else // if no book is found, back to index
                {
                    return RedirectToAction("ViewAllCourse"); //redirect to action in the same controller
                }
            }
        }
        [HttpPost]
        public ActionResult EditCourse(int id, Course newCourse, FormCollection fc)
        {
            ViewBag.Categories = GetCategoryDropDown();
            if (!ModelState.IsValid)
            {

                TempData["traineeIds"] = fc["traineeIds[]"];
                PrepareViewBagS();

                return View(newCourse);
            }
            else
            {

                using (var bwCtx = new ASM2.EF.FPTContext())
                {
                    bwCtx.Entry<Course>(newCourse).State
                        = System.Data.Entity.EntityState.Modified;

                    bwCtx.Entry<Course>(newCourse).Collection(b => b.Person).Load();


                    newCourse.Person = LoadFormatsS(bwCtx, fc["traineeIds[]"]);
                    //add book to context and mark it as modified to do update, not insert

                    bwCtx.SaveChanges();
                }
                TempData["message"] = $"Successfully update book with Id: {newCourse.Id}";

                return RedirectToAction("ViewAllCourse");
            }
        }

        public ActionResult DeleteCourse(int id)
        {
            using (var bwCtx = new ASM2.EF.FPTContext())
            {
                var book = bwCtx.Course.FirstOrDefault(b => b.Id == id);
                if (book != null)
                {
                    bwCtx.Course.Remove(book);
                    bwCtx.SaveChanges();
                    TempData["message"] = $"Successfully delete book with Id: {book.Id}";
                }


                return RedirectToAction("ViewAllCourse");
            }
        }
        [HttpGet]
        public ActionResult AssignTrainerToCourse(int id)
        {

            using (var bwCtx = new ASM2.EF.FPTContext())
            {
                ViewBag.Categories = GetCategoryDropDown();

                var Person = bwCtx.Course
                    .Include(b => b.Person)
                    .FirstOrDefault(b => b.Id == id);

                if (Person != null) // if a book is found, show edit view
                {

                    PrepareViewBagS();
                    return View(Person);
                }
                else // if no book is found, back to index
                {
                    return RedirectToAction("ViewAllCourse"); //redirect to action in the same controller
                }
            }
        }
        [HttpPost]
        public ActionResult AssignTrainerToCourse(int id, Course newCourse, FormCollection fc)
        {
            ViewBag.Categories = GetCategoryDropDown();
            if (!ModelState.IsValid)
            {

                TempData["traineeIds"] = fc["traineeIds[]"];
                PrepareViewBagS();

                return View(newCourse);
            }
            else
            {

                using (var bwCtx = new ASM2.EF.FPTContext())
                {
                    bwCtx.Entry<Course>(newCourse).State
                        = System.Data.Entity.EntityState.Modified;

                    bwCtx.Entry<Course>(newCourse).Collection(b => b.Person).Load();

                    if (fc["traineeIds[]"] != null)
                    {
                        newCourse.Person = LoadFormatsS(bwCtx, fc["traineeIds[]"]);
                        bwCtx.SaveChanges();
                    }

                    //add book to context and mark it as modified to do update, not insert


                }
                TempData["message"] = $"Successfully update book with Id: {newCourse.Id}";

                return RedirectToAction("ViewAllCourse");
            }
        }
        [HttpGet]
        public ActionResult AssignTraineeToCourse(int id)
        {

            using (var bwCtx = new ASM2.EF.FPTContext())
            {
                ViewBag.Categories = GetCategoryDropDown();

                var Person = bwCtx.Course
                    .Include(b => b.Person)
                    .FirstOrDefault(b => b.Id == id);

                if (Person != null) // if a book is found, show edit view
                {

                    PrepareViewBagS();
                    return View(Person);
                }
                else // if no book is found, back to index
                {
                    return RedirectToAction("ViewAllCourse"); //redirect to action in the same controller
                }
            }
        }
        [HttpPost]
        public ActionResult AssignTraineeToCourse(int id, Course newCourse, FormCollection fc)
        {
            ViewBag.Categories = GetCategoryDropDown();
            if (!ModelState.IsValid)
            {

                TempData["traineeIds"] = fc["traineeIds[]"];
                PrepareViewBagS();

                return View(newCourse);
            }
            else
            {

                using (var bwCtx = new ASM2.EF.FPTContext())
                {
                    bwCtx.Entry<Course>(newCourse).State
                        = System.Data.Entity.EntityState.Modified;

                    bwCtx.Entry<Course>(newCourse).Collection(b => b.Person).Load();


                    if (fc["traineeIds[]"] != null)
                    {
                        newCourse.Person = LoadFormatsS(bwCtx, fc["traineeIds[]"]);
                        bwCtx.SaveChanges();
                    }
                    //add book to context and mark it as modified to do update, not insert


                }
                TempData["message"] = $"Successfully update book with Id: {newCourse.Id}";

                return RedirectToAction("ViewAllCourse");
            }
        }
    }
}