using AspNetIdentity.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AspNetIdentity.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        //[Authorize]
        public ActionResult Index()
        {
            MyIdentityDbContext db = new MyIdentityDbContext();
            UserStore<MyIdentityUser> userStore = new UserStore<MyIdentityUser>(db);
            UserManager<MyIdentityUser> userManager = new UserManager<MyIdentityUser>(userStore);

            MyIdentityUser user = userManager.FindByName(HttpContext.User.Identity.Name);
            if (user != null)
            {
                if (userManager.IsInRole(user.Id, "Administrator"))
                {
                    ViewBag.Role = "Administrator";
                }

                if (userManager.IsInRole(user.Id, "Operator"))
                {
                    ViewBag.Role = "Operator";
                }
            }


            return View();
        }
    }
}