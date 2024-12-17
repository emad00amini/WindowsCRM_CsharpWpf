using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL_CRM;
using BE_CRM;
using System.Data;
namespace BLL_CRM
{
   public class groupBll
    {
      public  groupDal groupDal = new groupDal();
        public string Create(activityCategory g)
        {
            return groupDal.Create(g);
        }
        public List<activityCategory> read()
        {
            return groupDal.read();
        }
        public activityCategory readN(string s)
        {
            return groupDal.readN(s);
        }
        public List<string> readN()
        {
            return groupDal.readN();
        }
    }
}
