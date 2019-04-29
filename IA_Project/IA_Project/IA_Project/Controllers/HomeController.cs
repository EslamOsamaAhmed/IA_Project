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
            project.PROJECT_OWNER = Session["UserName"].ToString();
            IA_ProjectEntities x = new IA_ProjectEntities();
            db.AddProject(project);
            
            
            return Json(new { result = 1 });
        }



        [HttpPost]
        public ActionResult Register(string fname, string lname, string jobdesc, HttpPostedFileBase photo, string mobile, string role, string username, string password, string email)
        {
            byte[] photos = null;

            if (photo != null)
            {
                try
                {
                    string path = Path.Combine(Server.MapPath("~/Images"), Path.GetFileName(photo.FileName));
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
                S_ACTORS act = new S_ACTORS() { FNAME = fname, LNAME = lname, JOB_DESC = jobdesc, MOBILE = Int32.Parse(mobile), AROLE = role, USERNAME = username, PASSWORD = password, EMAIL = email };
                DataBaseFuncController db = new DataBaseFuncController();

                if (db.AddActor(act) == "Done, Updated")
                {

                    return Redirect("Index");
                }
                else
                {
                    return HttpNotFound();

                }
            }
            catch (Exception ex)
            {
                return HttpNotFound();
                Console.WriteLine(ex);
            }

        }
        public ActionResult login()
        {
            return View();
        }
        // Loogin Function ...
        [HttpPost]
        public JsonResult Login(string loginEmail, string loginPass)
        {
            var result = "fail";
            Console.WriteLine(loginEmail + loginPass);
            using (IA_ProjectEntities db = new IA_ProjectEntities())
            {
                S_ACTORS act = new S_ACTORS();
                var userDetail = db.S_ACTORS.FirstOrDefault(x => x.EMAIL == loginEmail);

                if (userDetail != null)
                {
                    if (userDetail.PASSWORD == loginPass.ToString())
                    {
                        Session["ActorId"] = userDetail.ACTOR_ID.ToString();
                        Session["UserName"] = userDetail.USERNAME.ToString();
                        Session["Role"] = userDetail.AROLE.ToString();
                        Session["status"] = "done";
                        result = "suc";
                        return Json(result, JsonRequestBehavior.AllowGet);
                    }

                    else
                    {
                        result = "wrongpass";
                        return Json(result, JsonRequestBehavior.AllowGet);
                    }
                }
                else
                {
                    result = "notexist";
                    return Json(result, JsonRequestBehavior.AllowGet);
                }
            }

        }

        public ActionResult LoggedIN()
        {
            if (Session["ActorID"] != null)
                return View();
            else { return RedirectToAction("Login"); }
        }
        /*[HttpPost]
        public ActionResult Index(String project_name , String des_project , System.DateTime start_time , System.DateTime end_time , int price)
        {

            PROJECT project = new PROJECT { NAME_PROJECT = project_name , DESC_PROJECT = des_project , P_STATUS = false , START_TIME = start_time , END_TIME = end_time , PRICE = price};
            DataBaseFuncController db = new DataBaseFuncController();
            db.AddProject(project);
            return RedirectToAction("Index");
        }*/
        [HttpPost]
        public ActionResult Add_User(string fname, string lname, string jobdesc, HttpPostedFileBase photo, string mobile, string role, string username, string password, string email)
        {
            byte[] photos = null;

            if (photo != null)
            {
                try
                {
                    string path = Path.Combine(Server.MapPath("~/Images"), Path.GetFileName(photo.FileName));
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
                S_ACTORS act = new S_ACTORS() { FNAME = fname, LNAME = lname, JOB_DESC = jobdesc, MOBILE = Int32.Parse(mobile), AROLE = role, USERNAME = username, PASSWORD = password, EMAIL = email };
                DataBaseFuncController db = new DataBaseFuncController();

                if (db.AddActor(act) == "Done, Updated")
                {

                    return Json(new { result = 1 });
                }
                else
                {
                    return HttpNotFound();

                }
            }
            catch (Exception ex)
            {
                return HttpNotFound();
                Console.WriteLine(ex);
            }

        }
    }
}