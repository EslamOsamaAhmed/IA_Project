using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using System.Net.Mail;
using IA_Project.Models;

namespace IA_Project.Controllers
{
    public class HomeController : Controller
    {
        int randno;
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
        public JsonResult Register(string fname, string lname, string jobdesc, HttpPostedFileBase photo, string mobile, string role, string username, string password, string email)
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

                var allactors = db.GetAllActors();


                foreach (var element in allactors)
                    if (username == element.USERNAME)
                    {
                        return Json(11, JsonRequestBehavior.AllowGet);
                    }

                foreach (var element in allactors)
                {
                    if (email == element.EMAIL)
                    {
                        return Json(12, JsonRequestBehavior.AllowGet);
                    }
                }

                if (db.AddActor(act) == "Done, Updated")
                {

                    var result = 0;
                    return Json(result, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    var result = 1;
                    return Json(result, JsonRequestBehavior.AllowGet);

                }
            }
            catch (Exception ex)
            {
                return Json(ex.ToString(), JsonRequestBehavior.AllowGet);
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

        public JsonResult ResetPassword(string coderes, string emailf)
        {

            DataBaseFuncController db = new DataBaseFuncController();

            var actinfo = db.GetActorData(emailf);

            DateTime localDate = DateTime.Now;
            int seconds = (int)(actinfo.RESETTIME - localDate).Value.TotalSeconds;


            if (coderes == actinfo.CODE.ToString())
            {
                if(seconds >= 40)
                {
                    return Json(35, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(22, JsonRequestBehavior.AllowGet);
                }
            }
            else
            {
                return Json(25, JsonRequestBehavior.AllowGet);
            }

        }

        public JsonResult ResetNewPass(string newpass, string emailff)
        {

            DataBaseFuncController db = new DataBaseFuncController();

            var actinfo = db.GetActorData(emailff);

            S_ACTORS actcode = new S_ACTORS() { PASSWORD = newpass };
            if (db.UpdatePassReset(actinfo.ACTOR_ID, actcode) == "Done, Updated")
            {
                return Json(60, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(66, JsonRequestBehavior.AllowGet);
            }

        }

        public JsonResult Resend(string coderes, string emailf)
        {

            Random code = new Random();
            randno = code.Next(10, 5000);

            DataBaseFuncController db = new DataBaseFuncController();

            var actinfo = db.GetActorData(emailf);

            // Specify the from and to email address
            MailMessage mailMessage = new MailMessage
                ("smsmronaldo@gmail.com", emailf);
            // Specify the email body
            mailMessage.Body = "Your Code to Reset Password is: " + randno.ToString();
            // Specify the email Subject
            mailMessage.Subject = "Reset Password";

            // No need to specify the SMTP settings as these 
            // are already specified in web.config
            SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587);

            // Finall send the email message using Send() method
            smtpClient.EnableSsl = true;
            smtpClient.Send(mailMessage);

            DateTime localDate = DateTime.Now;

            S_ACTORS actcode = new S_ACTORS() { CODE = randno, RESETTIME = localDate };
            db.UpdateActorReset(actinfo.ACTOR_ID, actcode);

            return Json(90, JsonRequestBehavior.AllowGet);

        }

        public JsonResult Sendcode(string emailreset)
        {
            Random code = new Random();
            randno = code.Next(10, 5000);
            int res = 50;

            DataBaseFuncController db = new DataBaseFuncController();

            var emails = db.GetAllActors();

            foreach (var element in emails)
            {
                if (emailreset == element.EMAIL)
                {
                    res = 11;
                    break;
                }
            }

            if (res == 11)
            {
                DateTime localDate = DateTime.Now;

                var actinfo = db.GetActorData(emailreset);

                S_ACTORS actcode = new S_ACTORS() { CODE = randno , RESETTIME = localDate};
                db.UpdateActorReset(actinfo.ACTOR_ID, actcode);

                // Specify the from and to email address
                MailMessage mailMessage = new MailMessage
                    ("smsmronaldo@gmail.com", emailreset);
                // Specify the email body
                mailMessage.Body = "Your Code to Reset Password is: " + randno.ToString();
                // Specify the email Subject
                mailMessage.Subject = "Reset Password";

                // No need to specify the SMTP settings as these 
                // are already specified in web.config
                SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587);

                // Finall send the email message using Send() method
                smtpClient.EnableSsl = true;
                smtpClient.Send(mailMessage);
                return Json(res, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(res, JsonRequestBehavior.AllowGet);
            }
        }


        public ActionResult LoggedIN()
        {
            if (Session["ActorID"] != null)
                return View();
            else { return RedirectToAction("Login"); }
        }
<<<<<<< HEAD
        /*[HttpPost]
        public ActionResult Index(String project_name , String des_project , System.DateTime start_time , System.DateTime end_time , int price)
        {
            PROJECT project = new PROJECT { NAME_PROJECT = project_name , DESC_PROJECT = des_project , P_STATUS = false , START_TIME = start_time , END_TIME = end_time , PRICE = price};
            DataBaseFuncController db = new DataBaseFuncController();
            db.AddProject(project);
            return RedirectToAction("Index");
        }*/
=======
       
>>>>>>> 5f16c9f042c918d5f9c64f2a3272be63cdaf67dc
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
                return Json(ex.ToString(), JsonRequestBehavior.AllowGet);
            }

        }
    }
}