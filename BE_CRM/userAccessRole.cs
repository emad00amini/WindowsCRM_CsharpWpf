using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE_CRM
{
   public class userAccessRole
    {
        public int id { get; set; }
        public bool canCreate { get; set; }
        public bool canEnter { get; set; }
        public bool canUpdate{ get; set; }
        public bool canDelete { get; set; }
        public string section { get; set; }
        public userGroup    userGroup { get; set; }




    }
}
