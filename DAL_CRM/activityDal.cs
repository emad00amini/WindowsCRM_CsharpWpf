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
  public  class activityDal
    {
        DB db = new DB();
        public string Create(activity a,customer c,user u,activityCategory ac)
        {
            a.customer = db.customers.Find(c.id);
            a.user = db.users.Find(u.id);
            a.activityCategory = db.activityCategories.Find(ac.id);
            db.activities.Add(a);
            db.SaveChanges();
            return "ثبت شد";
        }


        public DataTable read()
        {

            string cmd = @"SELECT dbo.activities.id, dbo.activities.regDate AS [تاریخ ثبت], dbo.activities.title AS [عنوان], dbo.users.userName AS [نام کاربر], dbo.customers.name AS [نام مشتری], dbo.activityCategories.categoryName AS [دسته بندی] FROM dbo.activities INNER JOIN dbo.users ON dbo.activities.user_id = dbo.users.id INNER JOIN dbo.customers ON dbo.activities.customer_id = dbo.customers.id INNER JOIN dbo.activityCategories ON dbo.activities.activityCategory_id = dbo.activityCategories.id";
            SqlConnection sqlConnection = new SqlConnection("Data Source = .; Initial Catalog = database1; Integrated Security = true");
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd, sqlConnection);
            SqlCommandBuilder sqlCommandBuilder = new SqlCommandBuilder(sqlDataAdapter);
            DataSet dataSet = new DataSet();
            sqlDataAdapter.Fill(dataSet);
            return dataSet.Tables[0];
        }

        public string delete(int id)
        {



            var q = db.activities.Where(i => i.id == id).FirstOrDefault();


            try
            {
                if (q != null)
                {
                    q.deleteStatus = true;

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
        //public bool read(activity c)
        //{
        //var q = db.activities.Where(i => c. == i.phoneNumber);
        //var w = db.activities.Where(i => c.name == i.name);



        //    if (q.Count() >= 1 || w.Count() >= 1)
        //    {
        //        return false;
        //    }
        //    else
        //    {
        //        return true;
        //    }
        //}

    }
}
