using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE_CRM
{
  public  class userGroup
    {
        public int id { get; set; }
        public string title { get; set; }
        public List<userAccessRole> userAccessRoles { get; set; } = new List<userAccessRole>();
        public List<user> users { get; set; } = new List<user>();


    }
}
