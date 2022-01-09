using ASPAppliFinale.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASPAppliFinale.ViewModel
{
    public class VMAnnonce
    {
        public Proprio VMProprio { get; set; }
        public Marque VMMarque { get; set; }
        public Modele VMModele { get; set; }
        public Annonce VMAnnonc { get; set; }
    }
}