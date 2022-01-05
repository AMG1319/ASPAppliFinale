using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BDAutoASP.Models
{
    public class Annonce
    {
        public int IDAnnonce { get; set; }
        public virtual Proprio Proprio { get; set; }
        public int IDProprio { get; set; }
        public virtual Modele Modele { get; set; }
        public int IDModel { get; set; }
        public string AAnnee { get; set; }
        public string AKilometrage { get; set; }
        public string ACouleur { get; set; }
        public float APrix { get; set; }
        public string AStatut { get; set; }
    }
}