using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using GolfClubs.Models;

namespace GolfClubs.Controllers
{
    public class ClubTypesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: ClubTypes
        public ActionResult Index()
        {
            return View(db.ClubTypes.ToList());
        }

        // GET: ClubTypes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClubType clubType = db.ClubTypes.Find(id);
            if (clubType == null)
            {
                return HttpNotFound();
            }
            return View(clubType);
        }

        // GET: ClubTypes/Create
        public ActionResult Create()
        {
            return View(new ClubType { LastModified = DateTime.Now });
        }

        // POST: ClubTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,ClubTypeName,LastModified,LastModifiedBy")] ClubType clubType)
        {
            if(ModelState.IsValid)
            {
                ClubType m = new ClubType()
                {
                    ID = clubType.ID,
                    ClubTypeName = clubType.ClubTypeName,
                    LastModified = clubType.LastModified,
                    LastModifiedBy = clubType.LastModifiedBy,
                };

                if(m.LastModified == null)
                {
                    DateTime date = DateTime.Now;
                    string formatDate = date.ToString("MM/dd/yyyy");
                    m.LastModified = Convert.ToDateTime(formatDate);
                }
                db.Entry(m).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(clubType);
        }

        // GET: ClubTypes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClubType clubType = db.ClubTypes.Find(id);
            if (clubType == null)
            {
                return HttpNotFound();
            }
            return View(clubType);
        }

        // POST: ClubTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,ClubTypeName,LastModified,LastModifiedBy")] ClubType clubType)
        {
            if (ModelState.IsValid)
            {
                ClubType m = new ClubType()
                {
                    ID = clubType.ID,
                    ClubTypeName = clubType.ClubTypeName,
                    LastModified = clubType.LastModified,
                    LastModifiedBy = clubType.LastModifiedBy,
                };

                if (m.LastModified == null)
                {
                    DateTime date = DateTime.Now;
                    string formatDate = date.ToString("MM/dd/yyyy");
                    m.LastModified = Convert.ToDateTime(formatDate);
                }
                db.Entry(m).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(clubType);
        }

        // GET: ClubTypes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClubType clubType = db.ClubTypes.Find(id);
            if (clubType == null)
            {
                return HttpNotFound();
            }
            return View(clubType);
        }

        // POST: ClubTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ClubType clubType = db.ClubTypes.Find(id);
            db.ClubTypes.Remove(clubType);
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
