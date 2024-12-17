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
   public class ReminderBll
    {
        reminderDal reminderDal = new reminderDal();

        public string Create(reminder c,user u)
        {
           
            
                return reminderDal.Create(c,u);
          

        }

        
        public DataTable read()
        {
            return reminderDal.read();
        }
        public DataTable read(string s)
        {
            return reminderDal.read(s);
        }
       
        

        
        public void update(reminder c, int id)
        {
           reminderDal.update(id, c);
        }

        public string delete(int id)
        {
            return reminderDal.delete(id);
        }
    }
}
