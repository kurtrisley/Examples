using GolfClubs.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GolfClubs.ViewModels
{
    [NotMapped]
    public class ClubViewModel : Club
    {
        public IEnumerable<SelectListItem> AllCategories { get; set; }
        //public IEnumerable<SelectListItem> AllClubTypes { get; set; }

        private IList<int> selectedCategoryIds;
        public IList<int> SelectedCategoryIds
        {
            get
            {
                if (selectedCategoryIds == null)
                {
                    selectedCategoryIds = Categories.Select(c => c.ID).ToList();
                }
                return selectedCategoryIds;
            }
            set { selectedCategoryIds = value; }
        }

        //private IList<int> selectedClubTypeIds;
        //public IList<int> SelectedClubTypeIds
        //{
        //    get
        //    {
        //        if (selectedClubTypeIds == null )
        //        {
        //            selectedClubTypeIds = ClubTypes.Select(c => c.ID).ToList();
        //            return selectedClubTypeIds;

        //        }
        //        return selectedClubTypeIds;
        //    }
        //    set { selectedClubTypeIds = value; }
        //}
    }
}