/*
+++++++++++++++++++++++++
+ Classe CRepasAssignes +
+++++++++++++++++++++++++

++++++++++++++++++++++++++++++++++++++++
+ Auteur : Marc Deslandes - 420-W63-JO +
++++++++++++++++++++++++++++++++++++++++
*/

namespace RestoRapido.ViewModels
{
    /// <summary>
    /// Classe qui permet de contenir tous les repas et de savoir si ceux-ci
    /// sont associés au menu en question
    /// </summary>
    public class CRepasAssignes
    {
        // Identifiant unique du repas
        public int m_iRepasId { get; set; }

        // Nom affiché du repas
        public string m_strNom { get; set; }

        // Indique si le repas est associé au menu en question
        public bool m_boAssigne { get; set; }
    }
}