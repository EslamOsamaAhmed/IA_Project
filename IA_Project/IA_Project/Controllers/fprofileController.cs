using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Web.Mvc;
using IA_Project.Models;
using System.Net.Http;
using System.Net;

namespace IA_Project.Controllers
{
    public class fprofileController : Controller
    {
<<<<<<< HEAD
        

        public ActionResult fprofile()
        {
            return View();
=======
        // GET: fprofile
        public ActionResult fprofile()
        {
            /*test actor = new test { id = 12 };

            ViewData["test"] = actor;

            ViewBag.myactor = actor;*/

            DataBaseFuncController x = new DataBaseFuncController();
            S_ACTORS y = new S_ACTORS { ACTOR_ID = 1000, AROLE = "Director" };

            var val = x.GetActorDataByID(1000);

            var ActorID = val.ACTOR_ID;
            var ActorName = val.FNAME + val.LNAME;

            ViewBag.ID = ActorName;

            return View();

                
>>>>>>> parent of 059f266... Select Project From Database
        }

        [HttpPost]
        public string prof(string pageid, string pageurl, string actorid)
        {
            try
            {
                /*DataBaseFuncController x = new DataBaseFuncController();
            x.page(obj);
            return View();*/
                S_PAGE s = new S_PAGE() { PAGE_URL = pageurl, ACTOR_ID_P = Int32.Parse(actorid), PAGE_ID = Int32.Parse(pageid) };
                DataBaseFuncController x = new DataBaseFuncController();

                x.page(s);
                return "done";
            }catch(Exception ex)
            {
                return "failed";
            }
            
        }
    } 
}