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


        public int UpdateCommandeRepas(IEnumerable<Object> _Json)
        {
            /*

               


            */


            foreach (var d in _Json)
            {
                using (SqlConnection conn = new SqlConnection("Data Source=(LocalDb)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\dbRestoRapidoV26.mdf;Initial Catalog=RestoRapido;Integrated Security=True"))
                {
                    string sql = "UPDATE CCmdRepas SET mEtoiles = @cmdEtoile WHERE mCmdRepID = @comID";

                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@cmdEtoile", 5);
                        cmd.Parameters.AddWithValue("@comID", 1);
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
