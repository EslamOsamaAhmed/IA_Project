using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IA_Project.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

      

        [HttpPost]
        public string register(string Acid, string fname,string lname,string job,string mobile,
                                string email,string role,string username,string password)
        {
            try
            {
                /*DataBaseFuncController x = new DataBaseFuncController();
            x.page(obj);
            return View();*/
                S_ACTORS s = new S_ACTORS() { ACTOR_ID = Int32.Parse(Acid), FNAME = fname, LNAME = lname, JOB_DESC =job,
                    MOBILE = Int32.Parse(mobile), EMAIL =email, AROLE =role, USERNAME =username,PASSWORD=password};
                DataBaseFuncController x = new DataBaseFuncController();

                x.AddActor(s);
                return "done";
            }
            catch (Exception ex)
            {
                return "failed";
            }

        }

    }
}