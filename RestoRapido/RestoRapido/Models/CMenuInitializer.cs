/*
+++++++++++++++++++++++++++
+ Classe CMenuInitializer +
+++++++++++++++++++++++++++

++++++++++++++++++++++++++++++++++++++++
+ Auteur : Marc Deslandes - 420-W63-JO +
++++++++++++++++++++++++++++++++++++++++
*/

#region Espace de noms utilisés

using System.Collections.Generic;
using System.Data.Entity;

#endregion

namespace RestoRapido.Models
{
    /// <summary>
    /// Classe qui permet d'initialiser la table de CMenus dans la base de
    /// données
    /// </summary>
    public class CMenuInitializer : 
        DropCreateDatabaseIfModelChanges<CMenuContext>
    {
        /// <summary>
        /// Permet de garnir la base de données de menus par défaut
        /// </summary>
        /// <param name="context">Contexte dans la base de données (classe)
        /// </param>
        protected override void Seed(CMenuContext context)
        {
            // Liste de menus initialisés
            List<CMenu> lstMenus = new List<CMenu>
            {
                new CMenu { m_strNom = "Menu1", m_strDateDebut = "2016-02-15",
                    m_strDateFin = "2016-03-15" },
                new CMenu { m_strNom = "Menu2", m_strDateDebut = "2016-03-16",
                    m_strDateFin = "2016-04-16" },
                new CMenu { m_strNom = "Menu3", m_strDateDebut = "2016-04-17",
                    m_strDateFin = "2016-05-17" },
                new CMenu { m_strNom = "Menu4", m_strDateDebut = "2016-05-18",
                    m_strDateFin = "2016-06-18" },
                new CMenu { m_strNom = "Menu5", m_strDateDebut = "2016-06-19",
                    m_strDateFin = "2016-07-19" }
            };

            /* Pour tous les menus initialisés ci-dessus, l'ajouter dans le
               contexte */
            foreach (CMenu menu in lstMenus)
            {
                context.m_Menus.Add(menu);
            }

            context.SaveChanges();
        }
    }
}