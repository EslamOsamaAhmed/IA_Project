using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Web.Mvc;
using IA_Project.Models;
using System.Net.Http;
using System.Net;
using IA_Project.ViewModels;

namespace IA_Project.Controllers
{
    public class fprofileController : Controller
    {

        private IA_ProjectEntities db = new IA_ProjectEntities();
        private DataBaseFuncController db2 = new DataBaseFuncController();

        public ActionResult fprofile()
        {
            PROJECT project = new PROJECT();
            ProjectsUsersModel pum = new ProjectsUsersModel
            {
                Users = db.S_ACTORS.ToList(),
                Projects = db.PROJECTs.ToList(),
                project = project 
            };

            return View(pum);
        }

        [HttpPost]
        public string prof(string pageid, string pageurl, string actorid)
        {
            try
            {
                S_PAGE s = new S_PAGE() { PAGE_URL = pageurl, ACTOR_ID_P = Int32.Parse(actorid), PAGE_ID = Int32.Parse(pageid) };
                DataBaseFuncController x = new DataBaseFuncController();

                x.page(s);
                return "done";
            }catch(Exception ex)
            {
                return "failed";
            }
            
        }
        [HttpGet]
        public ActionResult Delete_User(int id)
        {
            DataBaseFuncController db = new DataBaseFuncController();
            db.RemoveActor(id);
            return Json(new { result = 1 } , JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Display_All_Users()
        {
            ProjectsUsersModel pum = new ProjectsUsersModel
            {
                Users = db.S_ACTORS.ToList(),
                Projects = db.PROJECTs.ToList()
            };
            return PartialView("../Shared/_Display_All_Users", pum);

        }

        [HttpGet]
        public ActionResult Delete_Project(int id)
        {
            DataBaseFuncController db = new DataBaseFuncController();
            db.RemoveProject(id);
            return Json(new { result = 1 }, JsonRequestBehavior.AllowGet);
        }


        [HttpGet] 
        public ActionResult Display_projects_By_Type(String Project_Status)
        {
            List<PROJECT> All_Projects = new List<PROJECT>();
            List<PROJECT> Current_Projects = new List<PROJECT>();
            List<PROJECT> Completed_Projects = new List<PROJECT>();
            All_Projects = db.PROJECTs.ToList();
            for (var item = 0; item < All_Projects.Count; item++)
            {
                if(All_Projects[item].P_STATUS == false)
                {
                    Current_Projects.Add(All_Projects[item]);
                }
                else if (All_Projects[item].P_STATUS == true)
                {
                    Completed_Projects.Add(All_Projects[item]);
                }
            }

            if (Project_Status.Equals("current"))
            {
                ProjectsUsersModel pum = new ProjectsUsersModel
                {
                    Users = db.S_ACTORS.ToList(),
                    Projects = Current_Projects
                };
                return PartialView("../Shared/_Project_modle", pum);
            }
            else if (Project_Status.Equals("completed"))
            {
                ProjectsUsersModel pum = new ProjectsUsersModel
                {
                    Users = db.S_ACTORS.ToList(),
                    Projects = Completed_Projects
                };
                return PartialView("../Shared/_Project_modle", pum);
            }
            else if (Project_Status.Equals("all"))
            {
                ProjectsUsersModel pum = new ProjectsUsersModel
                {
                    Users = db.S_ACTORS.ToList(),
                    Projects = All_Projects
                };
                return PartialView("../Shared/_Project_modle", pum);
            }
            return HttpNotFound();

        }

        [HttpGet]
        public ActionResult AllUserstoAssign(int id)
        {
            
            DataBaseFuncController db = new DataBaseFuncController();

            S_ACTORS act = new S_ACTORS();
            PROJECT project = new PROJECT();

            ProjectsUsersModel pum = new ProjectsUsersModel()
            {
                Users = db.GetAllActors().ToList(),
                project = db.GetProjectID(id)
            };

            return PartialView("../Shared/_ModalAssign", pum);
        }

        [HttpPost]
        public ActionResult AllUsersReqAssign(int id1)
        {
            DataBaseFuncController db = new DataBaseFuncController();


            ACTOR_PROJECT act_proj = new ACTOR_PROJECT() { ACTOR_ID = id1, PROJECT_ID = 10};
            db.AddProjectActor(act_proj);
            return Json(12, JsonRequestBehavior.AllowGet);

        }

        [HttpGet]
        public ActionResult getNotif()
        {

            DataBaseFuncController db = new DataBaseFuncController();
            List<S_ACTORS> users = new List<S_ACTORS>();

            NOTIF act = new NOTIF();

            S_ACTORS actors = new S_ACTORS();

            var notifs = db.GetAllNotif().ToList();

            foreach(var x in notifs)
            {
                if(x.ACTOR_ID_TO.ToString() == Session["ActorId"].ToString())
                {
                    users.Add(db.GetActorDataByID(x.ACTOR_ID_FROM));
                }
            }

            Notification pum = new Notification()
            {
                Users = users,
            };

            return PartialView("../Shared/_Res", pum);
        }

        [HttpGet]
        public ActionResult getNotifreq()
        {

            DataBaseFuncController db = new DataBaseFuncController();
            List<S_ACTORS> users = new List<S_ACTORS>();

            NOTIF act = new NOTIF();

            S_ACTORS actors = new S_ACTORS();

            var notifs = db.GetAllNotif().ToList();

            foreach (var x in notifs)
            {
                if (x.ACTOR_ID_TO.ToString() == Session["ActorId"].ToString())
                {
                    users.Add(db.GetActorDataByID(x.ACTOR_ID_FROM));
                }
            }

            Notification pum = new Notification()
            {
                Users = users,
            };

            return PartialView("../Shared/_Req", pum);
        }

        [HttpPost]
        public ActionResult DeleteReq(int id)
        {

            DataBaseFuncController db = new DataBaseFuncController();

            ACTOR_PROJECT x = new ACTOR_PROJECT() { AssignStatus = false };

            

            if(db.UpdateActorProject(id, x) == 1)
            {
                return Json(12, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(13, JsonRequestBehavior.AllowGet);
            }


        }

        [HttpPost]
        public ActionResult AcceptReq(int id)
        {

            DataBaseFuncController db = new DataBaseFuncController();

            ACTOR_PROJECT x = new ACTOR_PROJECT() { AssignStatus = true };



            if (db.UpdateActorProject(id, x) == 1)
            {
                return Json(12, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(13, JsonRequestBehavior.AllowGet);
            }


        }


    }
}