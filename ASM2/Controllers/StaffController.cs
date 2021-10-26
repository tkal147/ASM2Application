using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ASM2.Models.FPT;
using System.Data.Entity;
using ASM2.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;

namespace ASM2.Controllers
{
    [HandleError]
    [Authorize(Roles = "Staff")]
    public class StaffController : Controller
    {
        public ActionResult ViewAllPerson()
        {
            using (var bwCtx = new ApplicationDbContext())
            {
                var books = bwCtx.Users
                                 .OrderBy(b => b.Id)
                                 .ToList();
                return View(books);
            }
        }
        private void CustomValid(ApplicationUser trainee)
        {
            if (trainee.Role == "Trainer")
            {
                if (trainee.Telephone != null)
                {

                    if ((Int32.Parse(trainee.Telephone) / 1000000000) != 0)
                    {
                        ModelState.AddModelError("Contact", "Contact must start with 0");
                    }
                    if (Int32.Parse(trainee.Telephone) < 100000000)
                    {
                        ModelState.AddModelError("Contact", "Contact must be longer than 10 number");
                    }

                }
            }
            if (trainee.Role == "Trainee")
            {
                if (trainee.Contact != null)
                {
                    ModelState.AddModelError("Contact", "Contact can not be null");
                }
                if (trainee.DOB == null)
                {
                    ModelState.AddModelError("DOB", "DOB can not be null");
                }
                if (trainee.TOEIC == null)
                {
                    ModelState.AddModelError("TOEIC", "TOEIC can not be null");
                }
                if (trainee.Age == null)
                {
                    ModelState.AddModelError("Age", "Age can not be null");
                }
                if (trainee.Education == null)
                {
                    ModelState.AddModelError("Education", "Education can not be null");
                }
                if (trainee.Department == null)
                {
                    ModelState.AddModelError("Department", "Department can not be null");
                }
                if (trainee.Location == null)
                {
                    ModelState.AddModelError("Location", "Location can not be null");
                }
                if (trainee.Contact != null)
                {

                    if ((Int32.Parse(trainee.Contact) / 1000000000) != 0)
                    {
                        ModelState.AddModelError("Contact", "Contact must start with 0");
                    }
                    if (Int32.Parse(trainee.Contact) < 100000000)
                    {
                        ModelState.AddModelError("Contact", "Contact must be longer than 10 number");
                    }

                }

                if (trainee.TOEIC != null)
                {
                    if (Int32.Parse(trainee.TOEIC) < 0 || Int32.Parse(trainee.TOEIC) > 950)
                    {
                        ModelState.AddModelError("TOEIC", "Toeic must be greater than 0 and less than 950");
                    }
                }
                if (trainee.DOB != null && trainee.Age != null)
                {
                    int year = Int32.Parse(trainee.DOB.Split('-')[0]);
                    int now = DateTime.Now.Year;
                    int age = now - year;
                    if (age < Int32.Parse(trainee.Age) || age > Int32.Parse(trainee.Age))
                    {
                        ModelState.AddModelError("DOB", "Age must match the Date of birth");
                    }
                    if (year > 2003)
                    {
                        ModelState.AddModelError("DOB", "The date of birth must be from 2003 back");
                    }
                }

            }

        }
        [HttpGet]
        public ActionResult CreatePerson()
        {
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> CreatePerson(ApplicationUser newUser)
        {
            CustomValid(newUser);
            ApplicationDbContext context = new ApplicationDbContext();
            var roleManager = new Microsoft.AspNet.Identity.RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var userManager = new Microsoft.AspNet.Identity.UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            if (!ModelState.IsValid)
            {
                return View(newUser);
            }
            else
            {
                var user = new ApplicationUser
                {
                    UserName = newUser.Email,
                    Email = newUser.Email,
                    Age = newUser.Age,
                    Name = newUser.Name,
                    WorkingPlace = newUser.WorkingPlace,
                    Type = newUser.Type,
                    Location = newUser.Location,
                    Telephone = newUser.Telephone,
                    TOEIC = newUser.TOEIC,
                    Department = newUser.Department,
                    Education = newUser.Education,
                    DOB = newUser.DOB,
                    Role = newUser.Role
                };
                if (user.Email == null)
                {
                    ModelState.AddModelError("Gmail", "Email cannot be null ");
                    return View(newUser);
                }
                else
                {
                    var bwCtx = new ApplicationDbContext();
                    var gmail = bwCtx.Users.FirstOrDefault(b => b.Email == user.Email);
                    if (gmail == null)
                    {
                        var result = await userManager.CreateAsync(user, "Xyz@12345");
                        if (result.Succeeded)
                        {
                            userManager.AddToRole(user.Id, newUser.Role);

                        }
                        TempData["message"] = $"Successfully insert a new book with Id: {newUser.Id}";
                        return RedirectToAction("viewallperson");
                    }
                    else
                    {
                        ModelState.AddModelError("Gmail", "This Gmail already exists");
                        return View(newUser);
                    }
                }
            }
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult EditPerson(string id)
        {
            using (var bwCtx = new ApplicationDbContext())
            {
                var book = bwCtx.Users.FirstOrDefault(b => b.Id == id);
                //ef method to select only one or null if not found

                if (book != null) // if a book is found, show edit view
                {
                    return View(book);
                }
                else // if no book is found, back to index
                {
                    return RedirectToAction("viewallperson"); //redirect to action in the same controller
                }
            }
        }
        public ActionResult deletePerson(string id)
        {
            using (var bwCtx = new ApplicationDbContext())
            {
                var book = bwCtx.Users.FirstOrDefault(b => b.Id == id);
                if (book != null)
                {
                    bwCtx.Users.Remove(book);
                    bwCtx.SaveChanges();
                    TempData["message"] = $"Successfully delete book with Id: {book.Id}";
                }


                return RedirectToAction("viewallperson");
            }
        }
        [HttpPost]
        public async Task<ActionResult> EditPerson(string id, ApplicationUser newUser)
        {
            CustomValid(newUser);
            ApplicationDbContext context = new ApplicationDbContext();
            var roleManager = new Microsoft.AspNet.Identity.RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var userManager = new Microsoft.AspNet.Identity.UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            if (!ModelState.IsValid)
            {
                return View(newUser);
            }
            else
            {
                using (var bwCtx = new ApplicationDbContext())
                {
                    bwCtx.Entry<ApplicationUser>(newUser).State
                        = System.Data.Entity.EntityState.Modified;

                    //add book to context and mark it as modified to do update, not insert
                    //var result = await userManager.ResetPasswordAsync(newUser.Id, "123", newUser.Telephone);
                    bwCtx.SaveChanges();
                }
                TempData["message"] = $"Successfully update book with Id: {newUser.Id}";

            }
            return RedirectToAction("viewallperson");
        }


        //[HttpPost]
        //public ActionResult EditTrainee(string id, ApplicationUser trainee, FormCollection fc)
        //{
        //    TraineeValidation(trainee);
        //    if (!ModelState.IsValid)
        //    {
        //        TempData["CourseIds"] = fc["courseIds[]"];
        //        PrepareViewBag();
        //        return View(trainee);
        //    }
        //    else
        //    {
        //        using (var asm = new ApplicationDbContext())
        //        {
        //            asm.Entry<ApplicationUser>(trainee).State
        //                = System.Data.Entity.EntityState.Modified;

        //            asm.Entry<ApplicationUser>(trainee).Collection(b => b.Courses).Load();

        //            trainee.Courses = LoadCourse(asm, fc["courseIds[]"]);

        //            asm.SaveChanges();
        //        }
        //        TempData["message"] = $"Successfully update Trainee with Name: {trainee.Name}";

        //        return RedirectToAction("ViewAllTrainee");
        //    }
        //}


        public ActionResult ViewAllCategories()
        {
            using (var bwctx = new ApplicationDbContext())
            {
                var books = bwctx.Categories
                                 .OrderBy(b => b.Id)
                                 .ToList();
                return View(books);
            }
        }
        // GET: Staff



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
            ApplicationDbContext context = new ApplicationDbContext();
            var roleManager = new Microsoft.AspNet.Identity.RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var userManager = new Microsoft.AspNet.Identity.UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            if (!ModelState.IsValid)
            {
                return View(newCategories);
            }
            else
            {
                using (var bwCtx = new ApplicationDbContext())
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
            using (var bwCtx = new ApplicationDbContext())
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
                using (var bwCtx = new ApplicationDbContext())
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
            using (var bwCtx = new ApplicationDbContext())
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

            using (var bwCtx = new ApplicationDbContext())
            {
                var books = bwCtx.Course
                                 .OrderBy(b => b.Id)
                                 .ToList();
                return View(books);
            }

        }
        private void PrepareViewBagS()
        {
            using (var bwCtx = new ApplicationDbContext())
            {

                ViewBag.Person = bwCtx.Course.ToList();
            }
        }
        private List<SelectListItem> GetCategoryDropDown()
        {
            using (var bwCtx = new ApplicationDbContext())
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

        private List<Course> LoadFormatsS(ApplicationDbContext bwCtx, string formatIds)
        {
            var selectedSIds = formatIds.Split(',')
                                        .Select(id => Int32.Parse(id))
                                        .ToArray();
            return bwCtx.Course.Where(f => selectedSIds.Contains(f.Id)).ToList();

        }
        [HttpGet]
        public ActionResult CreateCourse()
        {


            ViewBag.Categories = GetCategoryDropDown();
            return View();
        }
        [HttpPost]
        public ActionResult CreateCourse(Course newCourse, FormCollection fs)
        {
            ViewBag.Categories = GetCategoryDropDown();
            if (!ModelState.IsValid)
            {
                return View(newCourse);
            }
            else
            {
                using (var bwCtx = new ApplicationDbContext())
                {


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
            using (var bwCtx = new ApplicationDbContext())
            {
                ViewBag.Categories = GetCategoryDropDown();

                var a = new ApplicationDbContext();

                var user = bwCtx.Course
                    .FirstOrDefault(b => b.Id == id);

                if (user != null) // if a book is found, show edit view
                {


                    return View(user);
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
                return View(newCourse);
            }
            else
            {

                using (var bwCtx = new ApplicationDbContext())
                {

                    bwCtx.Entry<Course>(newCourse).State
                        = System.Data.Entity.EntityState.Modified;
                    //add book to context and mark it as modified to do update, not insert

                    bwCtx.SaveChanges();
                }
                TempData["message"] = $"Successfully update book with Id: {newCourse.Id}";

                return RedirectToAction("ViewAllCourse");
            }
        }

        public ActionResult DeleteCourse(int id)
        {
            using (var bwCtx = new ApplicationDbContext())
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
        public ActionResult AssignTrainerToCourse(string id)
        {

            using (var bwCtx = new ApplicationDbContext())
            {


                var Person = bwCtx.Users
                    .Include(b => b.Course)
                    .FirstOrDefault(b => b.Id == id);

                if (Person != null) // if a book is found, show edit view
                {

                    PrepareViewBagS();
                    return View(Person);
                }
                else // if no book is found, back to index
                {
                    return RedirectToAction("ViewAllPerson"); //redirect to action in the same controller
                }
            }
        }
        [HttpPost]
        public ActionResult AssignTrainerToCourse(string id, ApplicationUser newUser, FormCollection fc)
        {

            if (!ModelState.IsValid)
            {

                TempData["TrainerIds"] = fc["TrainerIds[]"];
                PrepareViewBagS();

                return View(newUser);
            }
            else
            {

                using (var bwCtx = new ApplicationDbContext())
                {


                    if (fc["TrainerIds[]"] != null)
                    {
                        bwCtx.Entry<ApplicationUser>(newUser).State
                           = System.Data.Entity.EntityState.Modified;

                        bwCtx.Entry<ApplicationUser>(newUser).Collection(b => b.Course).Load();
                        newUser.Course = LoadFormatsS(bwCtx, fc["TrainerIds[]"]);

                        bwCtx.SaveChanges();
                    }

                    //add book to context and mark it as modified to do update, not insert


                }
                TempData["message"] = $"Successfully update book with Id: {newUser.Id}";

                return RedirectToAction("ViewAllPerson");
            }
        }
        [HttpGet]
        public ActionResult AssignTraineeToCourse(string id)
        {

            using (var bwCtx = new ApplicationDbContext())
            {



                var Person = bwCtx.Users
                    .Include(b => b.Course)
                    .FirstOrDefault(b => b.Id == id);

                if (Person != null) // if a book is found, show edit view
                {

                    PrepareViewBagS();
                    return View(Person);
                }
                else // if no book is found, back to index
                {
                    return RedirectToAction("ViewAllPerson"); //redirect to action in the same controller
                }
            }
        }

        [HttpPost]
        public ActionResult AssignTraineeToCourse(string id, ApplicationUser newUser, FormCollection fc)
        {


            if (!ModelState.IsValid)
            {

                TempData["traineeIds"] = fc["traineeIds[]"];
                PrepareViewBagS();

                return View(newUser);
            }
            else
            {

                using (var bwCtx = new ApplicationDbContext())
                {




                    if (fc["traineeIds[]"] != null)
                    {
                        bwCtx.Entry<ApplicationUser>(newUser).State
                           = System.Data.Entity.EntityState.Modified;

                        bwCtx.Entry<ApplicationUser>(newUser).Collection(b => b.Course).Load();
                        newUser.Course = LoadFormatsS(bwCtx, fc["traineeIds[]"]);

                        bwCtx.SaveChanges();
                    }
                    //add book to context and mark it as modified to do update, not insert


                }
                TempData["message"] = $"Successfully update book with Id: {newUser.Id}";

                return RedirectToAction("ViewAllPerson");
            }
        }
    }

}