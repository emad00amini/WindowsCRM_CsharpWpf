using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE_CRM
{
  public class product
    {
        public product()
        {
            deleteStatus = false;
        }
        public int id { get; set; }
        public bool deleteStatus { get; set; }
        public string name { get; set; }
        public int price { get; set; }
        public int   stock { get; set; }
        public List<invoice> invoices { get; set; } = new List<invoice>();



    }
}
