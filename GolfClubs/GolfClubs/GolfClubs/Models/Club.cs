using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GolfClubs.Models
{
    public class Club
    {
        public Club()
        {
            this.Categories = new HashSet<Category>();
        }
        public int ID { get; set; }
        public string Brand { get; set; }
        public float Price { get; set; }

        public int ClubTypeID { get; set; }
        public virtual ClubType ClubType { get; set; }

        public virtual ICollection<Category> Categories { get; set; }
      //  public virtual ICollection<ClubType> ClubTypes { get; set; }
    }
}