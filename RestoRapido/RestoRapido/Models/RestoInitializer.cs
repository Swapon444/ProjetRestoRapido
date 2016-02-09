using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace RestoRapido.Models
{
    public class RestoInitializer : DropCreateDatabaseIfModelChanges<RestoContext>
    {
        protected override void Seed(RestoContext context)
        {
            //créé la liste d'étudiants
            var restos = new List<Resto>
            {
                new Resto { resNom = "La petite patate à Sylvain", resNoCiv = 111, resPostal = "J5Y 3X9", resRue = "Patate"},
                new Resto { resNom = "La petite patate à Sylvain2", resNoCiv = 111, resPostal = "J5Y 3X9", resRue = "Patate"}
            };

            //ajoute tous les étudiant de la liste dans la BD
            foreach (var temp in restos)
            {
                context.tabResto.Add(temp);
            }
        }
    }
}
