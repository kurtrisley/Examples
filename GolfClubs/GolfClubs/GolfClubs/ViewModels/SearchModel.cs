using GolfClubs.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GolfClubs.ViewModels
{
    public class SearchModel
    {
        public SelectList Types { get; set; }
        public int SelectedType { get; set; }
        public SelectList Categories { get; set; }
        public int SelectedCategory { get; set; }
    }
}