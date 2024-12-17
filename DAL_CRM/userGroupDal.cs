using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE_CRM;
using System.Data;
namespace DAL_CRM
{
   public class userGroupDal
    {
        DB dB = new DB();
        public string Create(userGroup ug)
        {
            try
            {
                dB.userGroups.Add(ug);
                dB.SaveChanges();
                return "گروه کاربری ثبت شد";

            }
            catch (Exception e)
            {

                return "مشکلی در ثبت گروه کاربری به وجود آمد" + e.Message;
            }
        }
       public userGroup readN(string title)
        {
            return dB.userGroups.Where(i => i.title == title).SingleOrDefault();
        }
        public bool read(string title)
        {
          var q=  dB.userGroups.Where(i => i.title == title);
            if (q.Count() >= 1)
            {
                return false;
            }
            else return true;
        }
        public List<string> readTitiles()
        {
            return dB.userGroups.Select(i => i.title).ToList();
        }



    }
}
