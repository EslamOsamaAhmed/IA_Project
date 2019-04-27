using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;


namespace IA_Project.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        [HttpGet]
        public ActionResult Index()
        {
            PROJECT project = new PROJECT();
            return View();
        }
        [HttpPost]
        public ActionResult Index(PROJECT project)
        {
            if (!ModelState.IsValid)
            {
                return View("Index", project);

            }
            DataBaseFuncController db = new DataBaseFuncController();
            db.AddProject(project);

            return Json(new {result = 1 });
        }
        
        

        [HttpPost]
        public string Register(string fname, string lname, string jobdesc, HttpPostedFileBase photo, string mobile, string role, string username, string password, string email)
        {
            byte[] photos = null;

            if (photo != null && photo.ContentLength > 0) { 
                try
                {
                    string path = Path.Combine(Server.MapPath("~/Images"),Path.GetFileName(photo.FileName));
                    photo.SaveAs(path);

                     using (MemoryStream ms = new MemoryStream()) 
                       {
                          photo.InputStream.CopyTo(ms);
                          photos = ms.GetBuffer();
                        }

                    ViewBag.Message = "File uploaded successfully";
                }
                catch (Exception ex)
                {   
                    ViewBag.Message = "ERROR:" + ex.Message.ToString();
                }
            }

            try
            {
                S_ACTORS act = new S_ACTORS() { FNAME = fname, LNAME = lname, JOB_DESC = jobdesc, PHOTO = photos, MOBILE = Int32.Parse(mobile) , AROLE = role, USERNAME = username, PASSWORD = password, EMAIL = email};
                DataBaseFuncController db = new DataBaseFuncController();

                if (db.AddActor(act) == "Done, Updated")
                {

                    return "Done";
                }
                else
                {
                    return "Error: " + db.AddActor(act);
                }
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }

        }
        /*[HttpPost]
        public ActionResult Index(String project_name , String des_project , System.DateTime start_time , System.DateTime end_time , int price)
        {

            PROJECT project = new PROJECT { NAME_PROJECT = project_name , DESC_PROJECT = des_project , P_STATUS = false , START_TIME = start_time , END_TIME = end_time , PRICE = price};
            DataBaseFuncController db = new DataBaseFuncController();
            db.AddProject(project);
            return RedirectToAction("Index");
        }*/

    }
}