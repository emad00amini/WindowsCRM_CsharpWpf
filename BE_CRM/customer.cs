using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE_CRM
{
   public class customer
    {
        public int id { get; set; }
        public bool deleteStatus { get; set; }
        public string name { get; set; }
        public DateTime regdate{ get; set; }
        public string phoneNumber { get; set; }
        public List<invoice> invoices { get; set; } = new List<invoice>();
        public List<activity> activities { get; set; } = new List<activity>();




    }
}
