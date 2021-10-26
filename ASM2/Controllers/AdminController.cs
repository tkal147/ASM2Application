using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using ASM2.Models;
using ASM2.Models.FPT;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

[Authorize(Roles = "Admin")]
public class AdminController : Controller
{
    [HandleError]
    // GET: Admin
    public ActionResult Index()
    {
        using (var bwCtx = new ApplicationDbContext())
        {
            var user = bwCtx.Users
                             .OrderBy(b => b.Id)
                             .ToList();
            return View(user);
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
                Name = newUser.Name,
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
                var a = bwCtx.Users.FirstOrDefault(t => t.Email == user.Email);
                //check email null
                if (a == null)
                {
                    var result = await userManager.CreateAsync(user, "Xyz@12345");
                    if (result.Succeeded)
                    {
                        userManager.AddToRole(user.Id, newUser.Role);

                    }
                }
                else
                {
                    ModelState.AddModelError("Gmail", "This Email already exists  ");
                    return View(newUser);
                }
            }
            
           
            //        {

            
            return RedirectToAction("Index");

        }

    }
    [HttpGet]
    public ActionResult EditPersonAcc(string id)
    {
        ApplicationDbContext context = new ApplicationDbContext();
        var roleManager = new Microsoft.AspNet.Identity.RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
        var userManager = new Microsoft.AspNet.Identity.UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
        using (var bwCtx = new ApplicationDbContext())
        {
            var book = bwCtx.Users.FirstOrDefault(t => t.Id == id);
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


            return RedirectToAction("Index");
        }
    }
    [HttpPost]
    public async Task<ActionResult> EditPersonAcc(string id, ApplicationUser newUser)
    {
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
            return RedirectToAction("Index");
        }
    }


    private void CustomValidation(ApplicationUser user)
    {
        
            // pages va ngay hom nay phai cung chan hoac cung le
           
        



    }


}
