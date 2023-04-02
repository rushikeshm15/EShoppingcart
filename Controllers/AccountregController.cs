using eshopping.Models;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using System.Web.UI.WebControls;

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
            int a = 0;
            if (ModelState.IsValid == true)
            {
                using (ADbContext db = new ADbContext())
                {
                    db.userdetails.Add(account);
                    a = db.SaveChanges(); //to insert the user data to our database table
                    if (a > 0)
                    {
                        ViewBag.Message = account.Name + "Account created successfully";
                        ModelState.Clear(); //to clear the content of all input controls 
                        return RedirectToAction("Login");

                    }
                }
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

        //Edit or update data
        public ActionResult Edit(int id)
        {
            using (ADbContext db = new ADbContext())
            {
                var row = db.userdetails.Where(model => model.UserId == id).FirstOrDefault();//we use Linq query with help of lamda expression 
                return View(row);
            }

        }
        [HttpPost]
        public ActionResult Edit(user_details s)
        {
            if (ModelState.IsValid == true)
            {
                using (ADbContext db = new ADbContext())
                {
                    db.Entry(s).State = EntityState.Modified;
                    int a = db.SaveChanges();
                    if (a > 0)
                    {
                        ViewBag.Message = "Field Updated";

                    }




                }
            }
            return View();
            //return RedirectToAction("Index");
        }




        //Delete 
        public ActionResult Delete(int id)
        {
            using (ADbContext db = new ADbContext())
            {
                if (id > 0)
                {
                    var Drow = db.userdetails.Where(model => model.UserId == id).FirstOrDefault();//we use Linq query with help of lamda expression 
                    if (Drow != null)
                    {
                        db.Entry(Drow).State = EntityState.Deleted;
                        int b = db.SaveChanges();
                        if (b > 0)
                        {
                            TempData["DeleteMessage"] = "<script> alert('Filed Deleted!!')</script>";
                        }

                    }
                }
                return RedirectToAction("Index");


            }
        }
    }
}