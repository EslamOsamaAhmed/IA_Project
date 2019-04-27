using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using IA_Project;

namespace IA_Project.Controllers
{
    public class PROJECTTESTController : Controller
    {
        private IA_ProjectEntities2 db = new IA_ProjectEntities2();

        // GET: PROJECTTEST
        public ActionResult Index()
        {
            return View(db.PROJECTs.ToList());
        }

        // GET: PROJECTTEST/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PROJECT pROJECT = db.PROJECTs.Find(id);
            if (pROJECT == null)
            {
                return HttpNotFound();
            }
            return View(pROJECT);
        }

        // GET: PROJECTTEST/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PROJECTTEST/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PROJECT_ID,NAME_PROJECT,DESC_PROJECT,P_STATUS,START_TIME,END_TIME,PRICE")] PROJECT pROJECT)
        {
            if (ModelState.IsValid)
            {
                db.PROJECTs.Add(pROJECT);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(pROJECT);
        }

        // GET: PROJECTTEST/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PROJECT pROJECT = db.PROJECTs.Find(id);
            if (pROJECT == null)
            {
                return HttpNotFound();
            }
            return View(pROJECT);
        }

        // POST: PROJECTTEST/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PROJECT_ID,NAME_PROJECT,DESC_PROJECT,P_STATUS,START_TIME,END_TIME,PRICE")] PROJECT pROJECT)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pROJECT).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(pROJECT);
        }

        // GET: PROJECTTEST/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PROJECT pROJECT = db.PROJECTs.Find(id);
            if (pROJECT == null)
            {
                return HttpNotFound();
            }
            return View(pROJECT);
        }

        // POST: PROJECTTEST/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PROJECT pROJECT = db.PROJECTs.Find(id);
            db.PROJECTs.Remove(pROJECT);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
