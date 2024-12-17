using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE_CRM;

namespace DAL_CRM
{
  public  class invoiceDal
    {
        DB db = new DB();

        public string create(invoice i, customer c, List<product> pl)

        {
            try
            {
                Random rnd = new Random();
                string s = rnd.Next(1000000).ToString();
                var q = db.invoices.Where(z => z.invoiceNumber == s);
                while (q.Count() >0)
                {
                    s = rnd.Next(1000000).ToString();
                }
                i.invoiceNumber = s;
                i.customer = db.customers.Find(c.id);
                foreach (var item in pl)
                {
                    i.products.Add(db.products.Find(item.id));
                }
                db.invoices.Add(i);
                db.SaveChanges();



                return "فاکتور ثبت شد";
            }
            catch (Exception e)
            {

                return "با مشکلی مواجه شد" + e.Message;
            }
            
        }
        public string readInvoiceNum()
        {
            var q = db.invoices.OrderByDescending(i => i.id).FirstOrDefault();
            return q.invoiceNumber;
        }

    }
}
