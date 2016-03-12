using RestoRapido.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace RestoRapido.Controllers
{
    public class ApiRepasController : ApiController
    {
        private CRestoContext db = new CRestoContext();
        
        public IEnumerable<CRepas> GetAllProducts()
        {
            return db.Repas.ToList();
        }

        public List<object> GetProduct(string id)
        {
            string sqlQuery = "SELECT * FROM [CREPAS] ";
            string sql = "";

            string strCon = System.Web
                      .Configuration
                      .WebConfigurationManager
                      .ConnectionStrings["CRestoContext"].ConnectionString;

            for (int i = 0; i < id.Length; i++)
            {
                if (id[i] == 1)
                {
                    switch (i)
                    {
                        case '0':
                            sql += "&& m_boBle == 0 ";
                            break;
                        case '1':
                            sql += "&& m_boLait == 0 ";
                            break;
                        case '2':
                            sql += "&& m_boOeuf == 0 ";
                            break;
                        case '3':
                            sql += "&& m_boArachide == 0 ";
                            break;
                        case '4':
                            sql += "&& m_boSoja == 0 ";
                            break;
                        case '5':
                            sql += "&& m_boFruitCoque == 0 ";
                            break;
                        case '6':
                            sql += "&& m_boPoisson == 0 ";
                            break;
                        case '7':
                            sql += "&& m_boSesame == 0 ";
                            break;
                        case '8':
                            sql += "&& m_boCrustace == 0 ";
                            break;
                        case '9':
                            sql += "&& m_boMollusque == 0 ";
                            break;
                    }
                }
            }
            if(sql.Count() > 0)
                sql = "WHERE " + sql.Remove(0, 2);
            sqlQuery += sql;

            SqlConnection conn = new SqlConnection(strCon);
            SqlCommand comm = new SqlCommand(sqlQuery, conn);
            conn.Open();

            SqlDataReader nwReader = comm.ExecuteReader();
            List<object> retour = new List<object>();
            while (nwReader.Read())
            {
                object[] row = new object [nwReader.FieldCount];
                for (int i = 0; i < nwReader.FieldCount; i++)
                {
                   row[i] = nwReader.GetValue(i);
                }
                retour.Add(row);
            }


            return retour;

        }
    }
}
