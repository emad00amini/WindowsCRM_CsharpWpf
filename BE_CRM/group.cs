using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE_CRM
{
   public class group
    {
        public group()
        {
            DeleteStatus = false;
        }
        public int id { get; set; }
        public string name { get; set; }
        public bool DeleteStatus { get; set; }
    }
}
