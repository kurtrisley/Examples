using GolfClubs.Models;
using System.Collections.Generic;
using System.Web.Mvc;

namespace GolfClubs.ViewModels
{
    public class SearchCategoryViewModel
    {
        public int CategoryID { get; set; }

        public IList<Category> CategoryList { get; set; }

        public SelectList Categories { get; set; }
    }
}