using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE_CRM;
using DAL_CRM;

namespace BLL_CRM
{
    public class userGroupBll
    {
        userGroupDal userGroupDal = new userGroupDal();
        public string Create(userGroup ug)
        {
            return userGroupDal.Create(ug);
        }
        public userGroup readN(string title)
        {
            return userGroupDal.readN(title);
        }
        public bool read(string title)
        {
            return userGroupDal.read(title);
        }
        public List<string> readTitles()
        {
            return userGroupDal.readTitiles();
        }
    }
}
