using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Web.Mvc;
using IA_Project.Models;
using System.Net.Http;
using System.Net;
using System.Data;

namespace IA_Project.Controllers
{
    public class fprofileController : Controller
    {
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

                
        }



    }
}