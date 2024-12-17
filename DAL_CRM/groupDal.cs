using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE_CRM;
using System.Data;
using System.Data.SqlClient;

namespace DAL_CRM
{
  public  class groupDal
    {
        DB dB = new DB();
        public string Create(activityCategory g)
        {
            if (read(g))
            {
                dB.activityCategories.Add(g);
                dB.SaveChanges();
                return "ثبت شد";
            }
            else
            {
               return "تکراری";
            }

        }

        public bool read(activityCategory g)
        {
            var q = dB.activityCategories.Where(i => g.categoryName== i.categoryName);
            if (q.Count() >= 1)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public List<string> readN()
        {
            return dB.activityCategories.Select(i => i.categoryName).ToList();
        }
        public activityCategory readN(string s)
        {
            return dB.activityCategories.Where(i => i.categoryName == s).SingleOrDefault();
        }
         public List<activityCategory> read()
        {
            return dB.activityCategories.ToList();
        }
    }


}
