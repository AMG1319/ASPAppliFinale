using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASPAppliFinale.ViewModel
{
    public class VMParamRecherche
    {
        public int IDMarque { get; set; }
        public int IDModel { get; set; }
        public string AAnnee { get; set; }
        public string AKilometrage { get; set; }
        public string ACouleur { get; set; }
        public float APrix { get; set; }
    }
}