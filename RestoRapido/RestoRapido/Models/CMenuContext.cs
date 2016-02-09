/*
+++++++++++++++++++++++
+ Classe CMenuContext +
+++++++++++++++++++++++

++++++++++++++++++++++++++++++++++++++++
+ Auteur : Marc Deslandes - 420-W63-JO +
++++++++++++++++++++++++++++++++++++++++
*/

#region Espace de noms utilisés

using System.Data.Entity;

#endregion

namespace RestoRapido.Models
{
    /// <summary>
    /// Classe qui permet d'utiliser la base de données (une table) avec la
    /// classe CMenu
    /// </summary>
    public class CMenuContext : DbContext
    {
        // Collection dans la base de données
        public DbSet<CMenu> m_Menus { get; set; } 
    }
}