using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE_CRM;
using DAL_CRM;
using System.Data;


namespace BLL_CRM
{
   public class activityBll
    {
        activityDal activityDal = new activityDal();

        public string Create(activity a,customer c,user u,activityCategory ac)
        {

            return activityDal.Create(a, c, u, ac);
            
        }
        public DataTable read()
        {
            return activityDal.read();
        }

        public string delete(int id)
        {
            return activityDal.delete(id);
        }
    }
}
