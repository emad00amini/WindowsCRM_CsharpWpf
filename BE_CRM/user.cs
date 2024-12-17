using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE_CRM
{
   public class user
    {

        public int id { get; set; }
        public string name { get; set; }
        public bool status { get; set; }
        public string userName { get; set; }
        public string password { get; set; }
        public string pic { get; set; }
        public DateTime regDate { get; set; }
        public List<activity> activities { get; set; } = new List<activity>();
        public List<invoice> invoices { get; set; } = new List<invoice>();
        public List<reminder> reminders { get; set; } = new List<reminder>();
        public userGroup usergroup { get; set; }

        








    }
}
