using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GolfClubs.Models
{
    public class ClubType
    {
        public int ID { get; set; }
        public string ClubTypeName { get; set; }

        [Display(Name = "Last Modified Date")]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]

        public DateTime LastModified { get; set; }

        [Display(Name = "Last Modified By")]
        public string LastModifiedBy { get; set; }

        public virtual ICollection<Category> Categories { get; set; }
    }
}