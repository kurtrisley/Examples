using GolfClubs.Models;
using GolfClubs.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GolfClubs.Controllers
{
    public class SearchController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Search
        public ActionResult Index()
        {
            var categories = new SelectList(db.Categories.ToList(), "ID", "CategoryName");
            var types = new SelectList(db.ClubTypes.ToList(), "ID", "ClubTypeName");
            SearchModel search = new SearchModel
            {
                Categories = categories,
                Types = types
            };
            
            return View(search);
        }

        public ActionResult GetCategory(int SelectedCategory) {
            var category = db.Categories.Single(x => x.ID == SelectedCategory);
            var items = db.Clubs.ToList();
            var result = new List<Club>();
            foreach(var i in items)
            {
                foreach(var c in i.Categories)
                {
                    if(c.ID == SelectedCategory)
                    {
                        result.Add(i);
                    }
                }
            }
            return View(result);
        }

        public ActionResult GetType(int SelectedType)
        {
            var SelectedClubs = db.Clubs.Where(x => x.ClubTypeID == SelectedType).ToList();

            return View(SelectedClubs);
        }
    }
}