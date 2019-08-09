using GolfClubs.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace GolfClubs.ViewModels
{
    public class SearchTypeViewModel
    {
        
        public int id { get; set; }

        public IList<ClubType> TypeList { get; set; }

        public SelectList Types { get; set; }
    }
}