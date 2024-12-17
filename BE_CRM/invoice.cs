using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE_CRM
{
  public  class invoice
    {
        public invoice()
        {
            deleteStatus = false;
            isCheckedOut = false;
        }
        public int id { get; set; }
        public bool deleteStatus { get; set; }
        public string invoiceNumber { get; set; }
        public DateTime regdate { get; set; }
        public bool isCheckedOut { get; set; }
        public Nullable<DateTime> checkoutDate { get; set; }
        public customer customer { get; set; }
        public user user { get; set; }
        public List<product> products { get; set; } = new List<product>();









    }
}
