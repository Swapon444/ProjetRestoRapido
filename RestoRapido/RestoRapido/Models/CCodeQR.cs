using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;

/*
++++++++++++++++++++
+ Classe CCodeQR +
++++++++++++++++++++


+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

+ Auteur: Francis Verreault       -      420-W63-JO       +

+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
*/
namespace RestoRapido.Models
{
    //Code QR d'une table
    public class CCodeQR
    {
        //Ientifiant unique du code qr
        public int i_CodeQRID { get; set; }

        /*
        //L'image du code qr de la table
        public Image Img_CodeQR { get; set; }
        */

        public ICollection<CCodeQR> CodesQR { get; set; }
    }
}