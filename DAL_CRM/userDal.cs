using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL_CRM;
using BE_CRM;
using System.Data.SqlClient;
using System.Data;


namespace DAL_CRM
{
    public class userDal
    {
        DB db = new DB();
        public string create(user user,userGroup usergroup)
        {
            user.usergroup = db.userGroups.Find(usergroup.id);
            db.users.Add(user);
            db.SaveChanges();
            return "ثبت شد";
        }
        public DataTable read()
        {


            string cmd = "SELECT id AS id,  name AS [نام مشتری],userName AS [کد کاربری], regdate AS [تاریخ ثبت نام] FROM dbo.users WHERE(Status = 0)";
            SqlConnection sqlConnection = new SqlConnection("Data Source = .; Initial Catalog = database1; Integrated Security = true");
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd, sqlConnection);
            SqlCommandBuilder sqlCommandBuilder = new SqlCommandBuilder(sqlDataAdapter);
            DataSet dataSet = new DataSet();
            sqlDataAdapter.Fill(dataSet);
            return dataSet.Tables[0];
        }
        public user read(int id)
        {
            return db.users.Where(i => i.id == id).FirstOrDefault();
        }
        public bool read(user c)
        {
            var q = db.users.Where(i => c.userName == i.userName);
           



            if (q.Count() >= 1 )
            {
                return false;
            }
            else
            {
                return true;
            }

        }
        public List<string> readU()
        {
            return db.users.Select(i => i.userName).ToList();
        }
        public user readu(string s)
        {
            return db.users.Include("userGroup").Where(i => i.userName == s).SingleOrDefault();
        }
        public bool readAny()
        {
            var q = db.users.Select(i =>i).Count();
            if (q >= 1)
            {
                return true;
            }
            else return false;
        }


        public string Update(int id, user c)
        {
          


            try
            {
                var q = db.users.Where(i => i.id == id).FirstOrDefault();
                if (q != null)
                {
                    q.name = c.name;
                    q.userName = c.userName;
                    q.pic = c.pic;
                    q.password = c.password;
                    db.SaveChanges();
                    return "تغییرات با موفقیت انجام شد";
                }
                else
                {
                    return "مشتری مورد نظر ثبت نشده است";
                }
            }
            catch (Exception e)
            {
                return "ویرایش با مشکل مواجه شد\n" + e.Message;
            }



        }
        public string delete(int id)
        {
            var q = db.users.Where(i => i.id == id).FirstOrDefault();


            try
            {
                if (q != null)
                {
                    q.status = true;

                    db.SaveChanges();
                    return " حذف با موفقیت انجام شد ";
                }
                else
                {
                    return "یافت نشد";
                }
            }
            catch (Exception e)
            {
                return "حذف با مشکل مواجه شد\n" + e.Message;
            }

        }
         public bool Access(user user,string s,int a    )
        {
            userGroup userGroup = db.userGroups.Include("userAccessRole").Where(i => i.id == user.usergroup.id).FirstOrDefault();
            userAccessRole uar = userGroup.userAccessRoles.Where(z => z.section == s).FirstOrDefault();
            if (a == 1)
            {
                return uar.canEnter;
            }
            if (a == 2)
            {
                return uar.canCreate;
            }
            if (a == 3)
            {
                return uar.canUpdate;
            }
           else
            {
                return uar.canDelete;
            }
        }
    }
}
