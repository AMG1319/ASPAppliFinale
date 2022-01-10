using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ASPAppliFinale.Models
{
    public class Proprio
    {
        public int IDProprio { get; set; }
        public string PNom { get; set; }
        public string PPrenom { get; set; }
        public string PNumTel { get; set; }
        [Required(ErrorMessage = "Email ou Pseudo Requis !")]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "E-mail is not valid")]
        public string PMail { get; set; }
        [Required(ErrorMessage = "Mot de passe requis !")]
        public string PMdp { get; set; }
        public virtual ICollection<Annonce> Annonces { get; set; }
    }
}