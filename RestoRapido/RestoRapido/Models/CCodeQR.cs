using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZXing;
using ZXing.Common;

/*
++++++++++++++++++++
+ Classe CCodeQR +
++++++++++++++++++++


+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

+ Auteur: Francis Verreault et Dave Otis  -  420-W63-JO  +

+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
*/
namespace RestoRapido.Models
{
    //Code QR d'une table
    public class CCodeQR
    {
        //Ientifiant unique du code qr
        public int i_CodeQRID { get; set; }


        //information du code QR de la table
        public string str_InfoCodeQR { get; set; }

    }



}