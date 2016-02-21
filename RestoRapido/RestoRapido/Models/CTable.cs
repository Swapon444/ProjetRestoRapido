using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZXing;
using ZXing.Common;
/*
++++++++++++++++++++
+  Classe CTable   +
++++++++++++++++++++


+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

+ Auteur: Francis Verreault       -      420-W63-JO       +

+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
*/
namespace RestoRapido.Models
{
    //Classe représentant une table dans un restaurant
    public class CTable
    {
        //Identificateur unique de la table
        public int CTableID { get; set; }

        //Numéro de la table

        [DisplayName("Numéro de table")]
        public int i_TableNum { get; set; }

        //Code QR de la table
        public string str_TableCodeQR { get; set; }

        /*//Id de son restaurent
        public int CRestoID { get; set; }
        public virtual CResto Restorant{ get; set;}*/

        public CTable(){ }

        public CTable(int i_num, int i_restoId)
        {
            i_TableNum = i_num;
            str_TableCodeQR = Convert.ToString(i_num) + Convert.ToString(i_restoId);
        }
        
    }
    
    /*
           Permet de générer des codes QR
       */
    public static class HtmlHelperExtensions
    {
        
        public static IHtmlString GenerateQrCode(this HtmlHelper html, string url, string alt = "QR code", int height = 50, int width = 50, int margin = 0)
        {
            var qrWriter = new BarcodeWriter();
            qrWriter.Format = BarcodeFormat.QR_CODE;
            qrWriter.Options = new EncodingOptions() { Height = height, Width = width, Margin = margin };

            using (var q = qrWriter.Write(url))
            {
                using (var ms = new MemoryStream())
                {
                    q.Save(ms, ImageFormat.Png);
                    var img = new TagBuilder("img");
                    img.Attributes.Add("src", String.Format("data:image/png;base64,{0}", Convert.ToBase64String(ms.ToArray())));
                    img.Attributes.Add("alt", alt);
                    return MvcHtmlString.Create(img.ToString(TagRenderMode.SelfClosing));
                }
            }
        }
        
    }
}