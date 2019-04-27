using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IA_Project.Controllers
{
    public class SProfileController : Controller
    {
        private IA_ProjectEntities2 db = new IA_ProjectEntities2();
        // GET: SProfile
        public ActionResult SProfile_View()
        {
            return View(db.PROJECTs.ToList());
        }
    }
}