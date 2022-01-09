using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASPAppliFinale.Models
{
    public class Modele
    {
        public int IDModel { get; set; }
        public virtual Marque Marque { get; set; }
        public int IDMarque { get; set; }
        public string MNom { get; set; }
        public virtual ICollection<Annonce> Annonces { get; set; }

    }
}