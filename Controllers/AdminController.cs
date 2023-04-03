using eshopping.Models;
using System.Web.Mvc;


namespace eshopping.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Admin()
        {
            return View();
        }

        public ActionResult Admin(user_details ad)
        {
            using (ADbContext db = new ADbContext())
            {
                var adminUser = new user_details
                {
                    Username = "Admin",
                    Email = "admin@example.com",
                    Password = "password",
                    Isadmin = true
                };

                db.userdetails.Add(adminUser);
                db.SaveChanges();

                if (adminUser != null)
                {
                    adminUser.Isadmin = true;
                    Session["Name"] = adminUser.Name.ToString();
                    Session["Username"] = adminUser.Username.ToString();
                    Session["Password"] = adminUser.Password.ToString();

                }
                return RedirectToAction("Index");

            }

        }


    }
}