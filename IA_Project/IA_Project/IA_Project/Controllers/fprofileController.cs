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

    } 
}