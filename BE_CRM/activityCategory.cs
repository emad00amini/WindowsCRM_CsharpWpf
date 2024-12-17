using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE_CRM
{
  public class activityCategory
    {
        public activityCategory()
        {
            DeleteStatus = false;
        }
        public int id { get; set; }
        public string categoryName { get; set; }
        public List<activity> activities { get; set; } = new List<activity>();
        public bool DeleteStatus { get; set; }
    }
}
