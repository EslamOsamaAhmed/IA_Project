﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IA_Project.Controllers
{
    public class DataBaseFuncController : Controller
    {
        // GET: DataBaseFunc
        public ActionResult Index()
        {
            return View();
        }

        public int RemoveActor(int id)
        {
            using (IA_ProjectEntities _entities = new IA_ProjectEntities())
            {
                try
                {
                    var obj = _entities.S_ACTORS.FirstOrDefault(c => c.ACTOR_ID == id);

                    _entities.S_ACTORS.Remove(obj);
                    _entities.SaveChanges();

                    return 1;
                }
                catch
                {
                    return 0;
                }
            }
        }

        public int RemoveActorProject(int id)
        {
            using (IA_ProjectEntities _entities = new IA_ProjectEntities())
            {
                try
                {
                    var obj = _entities.ACTOR_PROJECT.FirstOrDefault(c => c.ACTOR_ID == id);

                    _entities.ACTOR_PROJECT.Remove(obj);
                    _entities.SaveChanges();

                    return 1;
                }
                catch
                {
                    return 0;
                }
            }
        }

        public int RemoveProject(int id)
        {
            using (IA_ProjectEntities _entities = new IA_ProjectEntities())
            {
                try
                {
                    var obj = _entities.PROJECTs.FirstOrDefault(c => c.PROJECT_ID == id);

                    _entities.PROJECTs.Remove(obj);
                    _entities.SaveChanges();

                    return 1;
                }
                catch
                {
                    return 0;
                }
            }
        }

        public String UpdateActor(int id, S_ACTORS act)
        {
            using (IA_ProjectEntities _entities = new IA_ProjectEntities())
            {
                try
                {
                    var obj = _entities.S_ACTORS.FirstOrDefault(c => c.ACTOR_ID == id);
                    if (obj == null)
                    {
                        return "Null Object";
                    }

                    obj.JOB_DESC = act.JOB_DESC;
                    obj.LNAME = act.LNAME;
                    obj.MOBILE = act.MOBILE;
                    obj.FNAME = act.FNAME;
                    obj.EMAIL = act.EMAIL;
                    obj.RESETTIME = act.RESETTIME;
                    obj.CODE = act.CODE;
                    obj.PASSWORD = act.PASSWORD;

                    _entities.SaveChanges();

                    return "Done, Updated";
                }
                catch (Exception ex)
                {
                    return ex.ToString();
                }
            }
        }

        public int UpdateActorProject(int id, ACTOR_PROJECT act)
        {
            using (IA_ProjectEntities _entities = new IA_ProjectEntities())
            {
                try
                {
                    var obj = _entities.ACTOR_PROJECT.FirstOrDefault(c => c.ACTOR_ID == id);
                    if (obj == null)
                    {
                        return 0;
                    }

                    obj.AssignStatus = act.AssignStatus;

                    _entities.SaveChanges();

                    return 1;
                }
                catch (Exception ex)
                {
                    return 0;
                }
            }
        }


        public String UpdateActorReset(int id, S_ACTORS act)
        {
            using (IA_ProjectEntities _entities = new IA_ProjectEntities())
            {
                try
                {
                    var obj = _entities.S_ACTORS.FirstOrDefault(c => c.ACTOR_ID == id);
                    if (obj == null)
                    {
                        return "Null Object";
                    }

                    obj.RESETTIME = act.RESETTIME;
                    obj.CODE = act.CODE;

                    _entities.SaveChanges();

                    return "Done, Updated";
                }
                catch (Exception ex)
                {
                    return ex.ToString();
                }
            }
        }

        public String UpdatePassReset(int id, S_ACTORS act)
        {
            using (IA_ProjectEntities _entities = new IA_ProjectEntities())
            {
                try
                {
                    var obj = _entities.S_ACTORS.FirstOrDefault(c => c.ACTOR_ID == id);
                    if (obj == null)
                    {
                        return "Null Object";
                    }

                    obj.PASSWORD = act.PASSWORD;

                    _entities.SaveChanges();

                    return "Done, Updated";
                }
                catch (Exception ex)
                {
                    return ex.ToString();
                }
            }
        }

        public String UpdateProject(int id, PROJECT proj)
        {
            using (IA_ProjectEntities _entities = new IA_ProjectEntities())
            {
                try
                {
                    var obj = _entities.PROJECTs.FirstOrDefault(c => c.PROJECT_ID == id);
                    if (obj == null)
                    {
                        return "Null Object";
                    }

                    obj.NAME_PROJECT = proj.NAME_PROJECT;
                    obj.DESC_PROJECT = proj.DESC_PROJECT;
                    obj.P_STATUS = proj.P_STATUS;
                    obj.START_TIME = proj.START_TIME;
                    obj.END_TIME = proj.END_TIME;
                    obj.PRICE = proj.PRICE;

                    _entities.SaveChanges();

                    return "Done, Updated";
                }
                catch (Exception ex)
                {
                    return ex.ToString();
                }
            }
        }

        public String AddProject(PROJECT proj)
        {
            using (IA_ProjectEntities _entities = new IA_ProjectEntities())
            {
                try
                {
                    _entities.PROJECTs.Add(proj);
                    _entities.SaveChanges();

                    return "Done, Updated";
                }
                catch (Exception ex)
                {
                    return ex.ToString();
                }
            }
        }

        public String AddProjectActor(ACTOR_PROJECT act_proj)
        {
            using (IA_ProjectEntities _entities = new IA_ProjectEntities())
            {
                try
                {
                    _entities.ACTOR_PROJECT.Add(act_proj);
                    _entities.SaveChanges();

                    return "Done, Updated";
                }
                catch (Exception ex)
                {
                    return ex.ToString();
                }
            }
        }

        public String page(S_PAGE proj)
        {
            using (IA_ProjectEntities _entities = new IA_ProjectEntities())
            {
                try
                {
                    _entities.S_PAGE.Add(proj);
                    _entities.SaveChanges();

                    return "Done, Updated";
                }
                catch (Exception ex)
                {
                    return ex.ToString();
                }
            }
        }

        public String AddActor(S_ACTORS act)
        {
            using (IA_ProjectEntities _entities = new IA_ProjectEntities())
            {
                try
                {
                    _entities.S_ACTORS.Add(act);
                    _entities.SaveChanges();

                    return "Done, Updated";
                }
                catch (Exception ex)
                {
                    return ex.ToString();
                }
            }
        }

        public S_ACTORS GetActorDataByID(int ID)
        {
            using (IA_ProjectEntities _entities = new IA_ProjectEntities())
            {
               var returnedVal = _entities.S_ACTORS.FirstOrDefault(aa => aa.ACTOR_ID == ID);
                return returnedVal;
            }
        }

        public ACTOR_PROJECT GetActorProject(int ID)
        {
            using (IA_ProjectEntities _entities = new IA_ProjectEntities())
            {
                var returnedVal = _entities.ACTOR_PROJECT.FirstOrDefault(aa => aa.ACTOR_ID == ID);
                return returnedVal;
            }
        }


        public PROJECT GetProjectID(int ID)
        {
            using (IA_ProjectEntities _entities = new IA_ProjectEntities())
            {
                var returnedVal = _entities.PROJECTs.FirstOrDefault(aa => aa.PROJECT_ID == ID);
                return returnedVal;
            }
        }

        public PROJECT GetProjectName(string name)
        {
            using (IA_ProjectEntities _entities = new IA_ProjectEntities())
            {
                var returnedVal = _entities.PROJECTs.FirstOrDefault(aa => aa.NAME_PROJECT == name);
                return returnedVal;
            }
        }

        public S_ACTORS GetActorDataByRole(String Role)
        {
            using (IA_ProjectEntities _entities = new IA_ProjectEntities())
            {
                var returnedVal = _entities.S_ACTORS.FirstOrDefault(aa => aa.AROLE == Role);
                return returnedVal;
            }
        }

        public S_ACTORS GetActorData(String email)
        {
            using (IA_ProjectEntities _entities = new IA_ProjectEntities())
            {
                var returnedVal = _entities.S_ACTORS.FirstOrDefault(aa => aa.EMAIL == email);
                return returnedVal;
            }
        }

        public S_ACTORS GetActorDataRole(String role)
        {
            using (IA_ProjectEntities _entities = new IA_ProjectEntities())
            {
                var returnedVal = _entities.S_ACTORS.FirstOrDefault(aa => aa.AROLE == role);
                return returnedVal;
            }
        }

        public S_ACTORS GetActorDataUsername(String username)
        {
            using (IA_ProjectEntities _entities = new IA_ProjectEntities())
            {
                var returnedVal = _entities.S_ACTORS.FirstOrDefault(aa => aa.USERNAME == username);
                return returnedVal;
            }
        }


        public IEnumerable<S_ACTORS> GetAllActors()
        {
            using (IA_ProjectEntities _entities = new IA_ProjectEntities())
            {
                return _entities.S_ACTORS.ToList();
            }
        }

        public IEnumerable<PROJECT> GetAllProjects()
        {
            using (IA_ProjectEntities _entities = new IA_ProjectEntities())
            {
                return _entities.PROJECTs.ToList();
            }
        }

        public IEnumerable<NOTIF> GetAllNotif()
        {
            using (IA_ProjectEntities _entities = new IA_ProjectEntities())
            {
                return _entities.NOTIFs.ToList();
            }
        }

        public IEnumerable<ACTOR_PROJECT> GetAllAC_Proj()
        {
            using (IA_ProjectEntities _entities = new IA_ProjectEntities())
            {
                return _entities.ACTOR_PROJECT.ToList();
            }
        }
    }
}