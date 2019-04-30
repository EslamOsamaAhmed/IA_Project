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
                Users = db.S_ACTORS.ToList() ,
                Projects = db.PROJECTs.ToList(),
                Project = project
            };

            return View(pum);
        }
        [HttpGet]
        public ActionResult Edit_Project(int id)
        {
            List<S_ACTORS> actor = new List<S_ACTORS>();
            List<PROJECT> projects = new List<PROJECT>();
            PROJECT project = new PROJECT();
            project = db2.GetProjectID(id);
            ProjectsUsersModel pum = new ProjectsUsersModel
            {
                Users = actor,
                Projects = projects,
                Project = project
            };

            return PartialView("../Shared/_Project_Update_Form",pum) ;
        }

        [HttpPost]
        public ActionResult Edit_Project(ProjectsUsersModel pum , int id )
        {
            var project = db.PROJECTs.Single(c => c.PROJECT_ID == id);
            project.NAME_PROJECT = pum.Project.NAME_PROJECT;
            project.DESC_PROJECT = pum.Project.DESC_PROJECT;
            project.START_TIME = pum.Project.START_TIME;
            project.END_TIME = pum.Project.END_TIME;
            project.PRICE = pum.Project.PRICE;
            project.P_STATUS = pum.Project.P_STATUS;
            db.SaveChanges();
            ProjectsUsersModel pum2 = new ProjectsUsersModel
            {
                Users = db.S_ACTORS.ToList(),
                Projects = db.PROJECTs.ToList()
            };
            return PartialView("../Shared/_Project_modle", pum2);
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
            
            var Actor_Id = Session["ActorId"].ToString();
            var Actor_Role = Session["Role"].ToString();
            var Actor_Username = Session["UserName"].ToString();
            List<PROJECT> All_Projects = new List<PROJECT>();
            List<PROJECT> Projects = new List<PROJECT>();
            List<PROJECT> Current_Projects = new List<PROJECT>();
            List<PROJECT> Completed_Projects = new List<PROJECT>();
            Projects = db.PROJECTs.ToList();
            List<ACTOR_PROJECT> act_pro = new List<ACTOR_PROJECT>();
            act_pro = db.ACTOR_PROJECT.ToList();

            if(Actor_Role == "Marketing Director" || Actor_Role == "Team Leader" || Actor_Role == "Team Trainee")
            {
                foreach (var i in act_pro.ToList())
                {
                    if (i.ACTOR_ID.ToString() != Actor_Id)
                    {
                        act_pro.Remove(i);
                    }
                }
                foreach (var x in Projects.ToList())
                {
                    foreach (var y in act_pro.ToList())
                    {
                        if (y.PROJECT_ID == x.PROJECT_ID)
                        {
                            All_Projects.Add(x);
                        }
                    }
                }
            }

            else if (Actor_Role == "Customer")
            {
                foreach(var a in Projects.ToList())
                {
                    if (a.PROJECT_OWNER == Actor_Username)
                    {
                        All_Projects.Add(a);
                    }
                }
            }

            for (var item = 0; item < All_Projects.Count; item++)
            {
                if (All_Projects[item].P_STATUS == false)
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
                    Projects = Projects
                };
                return PartialView("../Shared/_Project_modle", pum);
            }
            return HttpNotFound();

        }


        [HttpGet]
        public ActionResult Edit_Profile()
        {
            var Actor_id = Session["ActorId"];
            S_ACTORS actor = new S_ACTORS();
            actor = db2.GetActorDataByID(Convert.ToInt32(Actor_id));
            ProjectsUsersModel pum = new ProjectsUsersModel
            {
                Actor = actor
            };

            return PartialView("../Shared/_Update_Profile_Form", pum);
        }

        [HttpPost]
        public ActionResult Edit_Profile(ProjectsUsersModel pum)
        {
            var Actor_id = Session["ActorId"].ToString();
            var user = db.S_ACTORS.Single(c => c.ACTOR_ID.ToString() == Actor_id);
            user.FNAME = pum.Actor.FNAME;
            user.LNAME = pum.Actor.LNAME;
            user.MOBILE = pum.Actor.MOBILE;
            user.PASSWORD = pum.Actor.PASSWORD;
            user.PHOTO = pum.Actor.PHOTO;
            user.EMAIL = pum.Actor.EMAIL;
            user.JOB_DESC = pum.Actor.JOB_DESC;

            db.SaveChanges();
            ProjectsUsersModel pum2 = new ProjectsUsersModel
            {
                Actor = user 
            };
            return PartialView("../Shared/_FProfile_model", pum2);
        }

        [HttpGet]
        public ActionResult Show_Profile()
        {
            var Actor_Id = Session["ActorId"];
            var user = db.S_ACTORS.Single(x => x.ACTOR_ID.ToString() == Actor_Id.ToString());
            ProjectsUsersModel pum = new ProjectsUsersModel {
                Actor = user
            };
            return PartialView("../Shared/_FProfile_model",pum);
        }

    } 
}