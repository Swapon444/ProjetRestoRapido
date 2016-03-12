using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestoRapido.ViewModels
{
    public class AssignedTableData
    {
        public int CTableID { get; set; }

        public int NumTable { get; set; }

        public bool Assigned { get; set; }
    }
}