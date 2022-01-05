using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BDAutoASP.Models
{
    public class Marque
    {
        public int IDMarque { get; set; }
        public string MNom { get; set; }
        public virtual ICollection<Modele> Modeles { get; set; }
    }
}