using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RestoRapido.Models
{
    public class CCmdRepas
    {
        [Key]
        public int mCmdRepID { get; set; }

        [Required]
        [DisplayName("Nombre de Repas")]
        public int mNbRep { get; set; }

        [DisplayName("Commentaire")]
        public string mCommentaire { get; set; }

        public int mEtoiles { get; set; }

        public int m_iRepasId { get; set; }
        public CRepas mRepas { get; set; }

        public int mCmdID { get; set; }
        public CCommande mCommande { get; set; }
    }
}