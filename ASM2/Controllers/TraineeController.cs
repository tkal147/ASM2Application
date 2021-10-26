using ASM2.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASM2.Controllers
{
    [Authorize(Roles = "Trainee")]
    public class TraineeController : Controller
    {
        [HandleError]
        // GET: Trainee
        public ActionResult Index()
        {
            var userId = User.Identity.GetUserId();
            using (var bwCtx = new ApplicationDbContext())
            {
                var book = bwCtx.Users.FirstOrDefault(b => b.Id == userId);
                return View(book);
            }
            
        }
        
        [HttpGet]
        public ActionResult ViewInformation()
        {
            var userId = User.Identity.GetUserId();
            using (var bwCtx = new ApplicationDbContext())
            {
                var Assign = bwCtx.Users
                       .Include(b => b.Course)
                       .FirstOrDefault(b => b.Id == userId);
                if (Assign != null) // if a book is found, show edit view
                {
                    
                    
                    ViewBag.Course = Assign.Course;
                    return View();
                }
                else // if no book is found, back to index
                {
                    return RedirectToAction("Index"); //redirect to action in the same controller
                }
            }
           
                
        }
        [HttpGet]
        public ActionResult ViewInformationOfCourse(int id)
        {
            using (var bwCtx = new ApplicationDbContext())
            {
                var Assign = bwCtx.Course
                       .Include(b => b.User)
                       .FirstOrDefault(b => b.Id == id);
                if (Assign != null) // if a book is found, show edit view
                {


                    ViewBag.User = Assign.User;
                    return View();
                }
                else // if no book is found, back to index
                {
                    return RedirectToAction("Index"); //redirect to action in the same controller
                }
            }
        }
        
    }
}