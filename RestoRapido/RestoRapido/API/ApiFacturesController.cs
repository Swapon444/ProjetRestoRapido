using RestoRapido.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Mvc;

namespace RestoRapido.API
{
    public class ApiFacturesController : ApiController
    {
        [System.Web.Http.HttpGet]
        public string CreateFacture(int _iUserId, float _fPrixTotal, [FromUri] string[] _items)
        {
            List<List<int>> lstItems = new List<List<int>>();
            try
            {
                for (int i = 0; i < _items.Length; i++)
                {
                    lstItems.Add(Array.ConvertAll(_items[i].Split(','), int.Parse).ToList());
                }
            }
            catch (Exception)
            {
                return "Erreur";
            }

            List<CCmdRepas> lstCmdRepas = new List<CCmdRepas>();

            for (int i = 0; i < lstItems.Count; i++)
            {
                lstCmdRepas.Add(
                    new CCmdRepas
                    {
                        m_iRepasId = lstItems[i][0],
                        mNbRep = lstItems[i][1],
                        mCommentaire = "",
                        mEtoiles = 0
                    }
                );
            }

            CRestoContext db = new CRestoContext();

            db.Commandes.Add(
                new CCommande
                {
                    CRestoID = 1,
                    CTableID = 1,
                    mCmdStatusCommande = 1,
                    UtilisateurID = _iUserId,
                    mCmdCommentCommandes = "",
                    mCmdPrixAvantTaxes = Convert.ToDecimal(_fPrixTotal),
                    mCmdPrixTotal = Convert.ToDecimal(_fPrixTotal + _fPrixTotal * 0.05 + _fPrixTotal * 0.09975),
                    mCmdDate = DateTime.Now,
                }
            );

            db.SaveChanges();

            CCommande TempCommande = db.Commandes.OrderByDescending(s => s.mCmdID).First();

            foreach (var CmdRepas in lstCmdRepas)
            {
                db.CommandeRepas.Add(
                    new CCmdRepas
                    {
                        mNbRep = CmdRepas.mNbRep,
                        mCommentaire = "",
                        mCmdID = TempCommande.mCmdID,
                        m_iRepasId = CmdRepas.m_iRepasId,
                    }
                );
                db.SaveChanges();
            }

            return "";
        }
    }
}
