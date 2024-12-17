using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE_CRM
{
  public class reminder
    {
        public reminder()
        {
            isDone = false;
            deleteStatus = false;
        }
        public int id { get; set; }
        public DateTime remindDate { get; set; }
        public DateTime regDate { get; set; }
        public string title { get; set; }
        public string reminderInfo { get; set; }
        public Nullable<bool> isDone { get; set; }
        public user user { get; set; }
        public bool deleteStatus { get; set; }

    }
}
