using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BDAutoASP.Models
{
    public class Proprio
    {
        public int IDProprio { get; set; }
        public string PNom { get; set; }
        public string PPrenom { get; set; }
        public string PNumTel { get; set; }
        public string PMail { get; set; }
        public string PMdp { get; set; }
        public virtual ICollection<Annonce> Annonces { get; set; }
    }
}