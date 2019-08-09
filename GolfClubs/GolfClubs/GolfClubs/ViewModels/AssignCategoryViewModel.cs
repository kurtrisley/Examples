using GolfClubs.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GolfClubs.ViewModels
{
    public class AssignCategoryViewModel
    {
        public int ClubID { get; set; }

        [Required, Range(1, int.MaxValue, ErrorMessage = "Please select a category.")]
        public int CategoryID { get; set; }
        public string ClubName { get; set; }
        public string Brand { get; set; }
        public float Price { get; set; }

        public IList<Category> AssociatedCategories { get; set; }

        public SelectList Categories { get; set; }
    }
}