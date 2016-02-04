using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CreationItem.Models
{
    public class Item
    {
        public int ItemID { get; set; }
        public string ItemNom { get; set; }
        public string ItemDescription { get; set; }
        public int ItemPrix { get; set; }
        public bool ItemAllergieArachides { get; set; }
        public bool ItemAllergieBle { get; set; }
        public bool ItemAllergieLait { get; set; }
        public bool ItemAllergieOeuf { get; set; }
        public bool ItemAllergieNoix { get; set; }
        public bool ItemAllergieSoya { get; set; }
        public bool ItemAllergieFruitsDeMer { get; set; }
    }
}