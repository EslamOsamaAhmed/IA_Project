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
        

        public ActionResult fprofile()
        {
            return View();
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