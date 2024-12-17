using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL_CRM;
using BE_CRM;

namespace BLL_CRM
{
   public class invoiceBll
    {
        invoiceDal invoiceDal = new invoiceDal();
        public string create (invoice i , customer c , List<product> pl)
        {
            return invoiceDal.create(i, c, pl);
        }
        public string readInvoiceNum()
        {
            return invoiceDal.readInvoiceNum();
        }
    }
}
