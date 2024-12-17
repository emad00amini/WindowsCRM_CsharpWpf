using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE_CRM
{
   public class activity
    {
        public activity()
        {
            deleteStatus = false;
        }
        public int id { get; set; }
        public DateTime regDate { get; set; }
        public string title { get; set; }
        public string info { get; set; }
        public customer customer { get; set; }
        public user user { get; set; }
        public activityCategory activityCategory { get; set; }
        public bool deleteStatus { get; set; }
    }
}
