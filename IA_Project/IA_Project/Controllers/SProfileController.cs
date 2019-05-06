using IA_Project.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IA_Project.Controllers
{
    public class SProfileController : Controller
    {
        DataBaseFuncController db2 = new DataBaseFuncController();
        private IA_ProjectEntities db = new IA_ProjectEntities();
        // GET: SProfile
        public ActionResult SProfile_View()
        {
            var Actor_Id = Session["ActorId"];
            /*var user = db.S_ACTORS.Single(x => x.ACTOR_ID.ToString() == Actor_Id.ToString());
            ProjectsUsersModel pum = new ProjectsUsersModel
            {
                Actor = user
            };*/
            return View();
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
                project = project
            };

            return PartialView("../Shared/_Project_Update_Form", pum);
        }

        [HttpPost]
        public ActionResult Edit_Project(ProjectsUsersModel pum, int id)
        {
            var project = db.PROJECTs.Single(c => c.PROJECT_ID == id);
            project.NAME_PROJECT = pum.project.NAME_PROJECT;
            project.DESC_PROJECT = pum.project.DESC_PROJECT;
            project.START_TIME = pum.project.START_TIME;
            project.END_TIME = pum.project.END_TIME;
            project.PRICE = pum.project.PRICE;
            project.P_STATUS = pum.project.P_STATUS;
            db.SaveChanges();
            ProjectsUsersModel pum2 = new ProjectsUsersModel
            {
                Users = db.S_ACTORS.ToList(),
                Projects = db.PROJECTs.ToList()
            };
            return PartialView("../Shared/_Project_modle", pum2);
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

    }
}