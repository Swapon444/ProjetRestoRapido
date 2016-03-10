using RestoRapido.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.Entity;



namespace RestoRapido.API
{


    public class ApiCommandesController : ApiController
    {


        private CRestoContext db = new CRestoContext();


        public IEnumerable<Object> getCommandes(string id)
        {

            int idClient = Convert.ToInt32(id);


            var commandes = from s in db.Commandes
                            where s.mCmdStatusCommande == 1 && s.UtilisateurID == idClient
                            select new { s.mCmdID, s.mCmdStatusCommande, s.mCmdPrixAvantTaxes, s.mCmdPrixTotal, s.mCmdDate, s.mCmdColletionRepas };

            return commandes.ToList();
        }



        [System.Web.Http.HttpGet]
        public int UpdateCommandeRepas(int _tempo, string _Json)
        {
             
            /*

               


            */

            string[] tabTempo = _Json.Split('.');


            for (int i = 0; i < tabTempo.Length; i = i + 3)
            {
                using (SqlConnection conn = new SqlConnection("Data Source=(LocalDb)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\dbRestoRapidoV26.mdf;Initial Catalog=RestoRapido;Integrated Security=True"))
                {
                    string sql = "UPDATE CCmdRepas SET mEtoiles = @cmdEtoile, mCommentaire = @comment WHERE mCmdRepID = @comID";

                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@cmdEtoile", Convert.ToInt32(tabTempo[i]));
                        cmd.Parameters.AddWithValue("@comment", tabTempo[i + 1]);
                        cmd.Parameters.AddWithValue("@comID", Convert.ToInt32(tabTempo[i + 2]));
                        conn.Open();
                        cmd.ExecuteNonQuery();
                        conn.Close();
                    }
                }

            }




            return 0;

        }

    }
}
