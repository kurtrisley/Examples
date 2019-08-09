using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using GolfClubs.Models;
using GolfClubs.ViewModels;

namespace GolfClubs.Controllers
{
    public class ClubController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Clubs
        public ActionResult Index()
        {
            var clubs = db.Clubs.Include(c => c.ClubType);
            return View(clubs.ToList());
        }

        // GET: Clubs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Club clubs = db.Clubs.Find(id);
            if (clubs == null)
            {
                return HttpNotFound();
            }
            return View(clubs);
        }

        // GET: Clubs/Create
        public ActionResult Create()
        {
            var model = new ClubViewModel();
            ViewBag.ClubTypeId = new SelectList(db.ClubTypes, "ID", "ClubTypeName");
            model.AllCategories = db.Categories.Select(c => new SelectListItem { Text = c.CategoryName, Value = c.ID.ToString() }).ToList();
            return View(model);
        }

        // POST: Clubs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Brand,Price,ClubTypeID, SelectedCategoryIds")] ClubViewModel clubVM)
        {
            if (ModelState.IsValid)
            {
                Club m = new Club()
                {
                    ID = clubVM.ID,
                    Brand = clubVM.Brand,
                    Price = clubVM.Price,
                    ClubTypeID = clubVM.ClubTypeID,
                    ClubType = clubVM.ClubType,
                    Categories = db.Categories.Where(c => clubVM.SelectedCategoryIds.Contains(c.ID)).ToList()
                };
                db.Clubs.Add(m);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ClubTypeID = new SelectList(db.ClubTypes, "ID", "TypeName", clubVM.ClubTypeID);
            return View(clubVM);
        }

        // GET: Clubs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Club club = db.Clubs.Find(id);
            if (club == null)
            {
                return HttpNotFound();
            }
            var model = new ClubViewModel()
            {
                ID = club.ID,
                Brand = club.Brand,
                Price = club.Price,
                ClubTypeID = club.ClubTypeID,
                ClubType = club.ClubType,
                //Categories = club.Categories,

                SelectedCategoryIds = club.Categories.Select(c => c.ID).ToList()
            };

            //Allyson added the line below. Not having it was causing a runtime error.
            ViewBag.ClubTypeID = new SelectList(db.ClubTypes, "ID", "ClubTypeName", club.ClubTypeID);
            model.AllCategories = db.Categories.Select(c => new SelectListItem { Text = c.CategoryName, Value = c.ID.ToString() }).ToList();
            return View(model);
        }

        // POST: Clubs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Brand,Price,ClubTypeID, ClubType, SelectedCategoryIs")] ClubViewModel clubVM)
        {
            if (clubVM == null)
            {
                throw new ArgumentNullException(nameof(clubVM));
            }

            if (ModelState.IsValid)
            {
                Club m = new Club()
                {
                    ID = clubVM.ID,
                    Brand = clubVM.Brand,
                    Price = clubVM.Price,
                    ClubTypeID = clubVM.ClubTypeID,
                    ClubType = clubVM.ClubType,
                    Categories = db.Categories.Where(c => clubVM.SelectedCategoryIds.Contains(c.ID)).ToList()
                };
                db.Entry(m).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            //ViewBag.Categories = new SelectList(db.Categories, "CategoryName", clubVM.Categories);
            clubVM.AllCategories = db.Categories.Select(c => new SelectListItem { Text = c.CategoryName, Value = c.ID.ToString() }).ToList();
            return View(clubVM);
        }

        // GET: Clubs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Club clubs = db.Clubs.Find(id);
            if (clubs == null)
            {
                return HttpNotFound();
            }
            return View(clubs);
        }

        // POST: Clubs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Club clubs = db.Clubs.Find(id);
            db.Clubs.Remove(clubs);
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
