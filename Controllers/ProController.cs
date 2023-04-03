using eshopping.Models;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;

namespace eshopping.Controllers
{
    public class ProController : Controller
    {
        // GET: Category
        public ActionResult productdashboard()
        {
            using (ADbContext dbb = new ADbContext())
            {
                var products = dbb.products.ToList();
                return View(products);

            }

        }

        public ActionResult Product_details()
        {
            return View();
        }


        [HttpPost] //for posting the form to server
        public ActionResult Product_details(Product dash)
        {
            int a = 0;
            if (ModelState.IsValid == true)
            {
                using (ADbContext db = new ADbContext())
                {
                    db.products.Add(dash);
                    a = db.SaveChanges(); //to insert the user data to our database table
                    if (a > 0)
                    {
                        //ViewMessage = dash.Name + "Account created successfully";
                        ModelState.Clear(); //to clear the content of all input controls 
                        //return RedirectToAction("productdashboard");

                    }
                }
            }
            return View();
        }




        //Edit or update data
        public ActionResult Edit(int id)
        {
            using (ADbContext db = new ADbContext())
            {
                var row = db.products.Where(model => model.ProductId == id).FirstOrDefault();//we use Linq query with help of lamda expression 
                return View(row);
            }

        }
        [HttpPost]
        public ActionResult Edit(Product s)
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
                    var Drow = db.products.Where(model => model.ProductId == id).FirstOrDefault();//we use Linq query with help of lamda expression 
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
                return RedirectToAction("productdashboard");


            }
        }
    }
}