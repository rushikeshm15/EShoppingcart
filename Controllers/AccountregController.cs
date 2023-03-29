using eshopping.Models;
using System.Linq;
using System.Web.Mvc;

namespace eshopping.Controllers
{
    public class AccountregController : Controller
    {
        // GET: Accountreg
        public ActionResult Index() // using this to show the list of registered users
        {
            using (ADbContext db = new ADbContext())
            {
                return View(db.userdetails.ToList());
            }
        }
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost] //for posting the form to server
        public ActionResult Register(user_details account)
        {
            if (ModelState.IsValid)
            {
                using (ADbContext db = new ADbContext())
                {
                    db.userdetails.Add(account);
                    db.SaveChanges(); //to insert the user data to our database table 

                }
                ModelState.Clear(); //to clear the content of all input controls 
                ViewBag.Message = account.Firstname + " " + account.Lastname + "Registration Successful";
                return RedirectToAction("Login");
            }
            return View();
        }

        //login

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(user_details user)
        {
            using (ADbContext db = new ADbContext())
            {
                var USR = db.userdetails.SingleOrDefault(u => u.Username == user.Username && u.Password == user.Password);
                if (USR != null)
                {
                    Session["UserId"] = USR.UserId.ToString();
                    Session["Username"] = USR.Username.ToString();
                    return RedirectToAction("LoggedIn");
                }
                else
                {
                    ModelState.AddModelError("", "Username or Password is Incorrect.");
                }
                return View();
            }

        }
        public ActionResult LoggedIn()
        {
            if (Session["UserId"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login");
            }
        }
    }
}