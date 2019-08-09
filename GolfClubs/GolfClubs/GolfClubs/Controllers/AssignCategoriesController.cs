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
    public class AssignCategoriesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: AssignCategories
        public ActionResult Index(int ClubID)
        {
            AssignCategoryViewModel model = CreateAssignCategoryViewModel(ClubID);

            if (model.ClubID == 0)
            {
                return HttpNotFound();
            }
            return View(model);
        }

        [HttpPost]
        public ActionResult Index(int ClubID, int CategoryID)
        {
            if (ClubID == 0)
            {
                return HttpNotFound();
            }
            if (ModelState.IsValid && CategoryID > 0)
            {
                Club club = db.Clubs.SingleOrDefault(m => m.ID == ClubID);
                if (club == null)
                {
                    return HttpNotFound();
                }
                //Save
                Category category = db.Categories.Where(mc => mc.ID == CategoryID).SingleOrDefault();
                if (category == null)
                {
                    return HttpNotFound("Category not found");
                }
                club.Categories.Add(category);
                db.SaveChanges();
            }

            AssignCategoryViewModel model = CreateAssignCategoryViewModel(ClubID);

            return View(model);
        }

        public ActionResult Delete(int CategoryID, int ClubID)
        {
            if (CategoryID > 0)
            {
                Category category = db.Categories.Where(mc => mc.ID == CategoryID).SingleOrDefault();
                if (category == null)
                {
                    return HttpNotFound();
                }
                if (ClubID > 0)
                {
                    Club club = db.Clubs.Where(p => p.ID == ClubID).SingleOrDefault();
                    if (club == null)
                    {
                        return HttpNotFound();
                    }
                    club.Categories.Remove(category);
                    db.SaveChanges();
                }
            }
            return View("Index", CreateAssignCategoryViewModel(ClubID));
        }

        private GolfClubs.ViewModels.AssignCategoryViewModel CreateAssignCategoryViewModel(int ClubID)
        {
            GolfClubs.ViewModels.AssignCategoryViewModel model = new GolfClubs.ViewModels.AssignCategoryViewModel();

            Club club =
                db.Clubs
                .Where(m => m.ID == ClubID)
                .FirstOrDefault();

            if (club == null)
            {
                model.ClubID = 0;
            }
            else
            {
                model.ClubID = club.ID;
                model.ClubName = club.Brand;


                //Get the list of assigned category ids for this product
                IList<int> assignedCategoryIds = club.Categories.Select(c => c.ID).ToList();


                //Get a list of assigned category objects
                IList<Category> assignedCategories = db.Categories.Where(c => assignedCategoryIds.Contains(c.ID)).ToList();

                model.AssociatedCategories = assignedCategories;

                //Get a list of available category objects that could be assigned
                IList<Category> availableCategories = db.Categories.Where(c => !assignedCategoryIds.Contains(c.ID)).ToList();

                availableCategories.Insert(0, new Category() { ID = 0, CategoryName = "--- Select a Category ---" });

                //Convert to SelectList object for use with (bind to) drop down list.
                model.Categories = new SelectList(availableCategories, "ID", "CategoryName", 0);
            }

            return model;
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
