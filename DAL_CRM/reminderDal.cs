using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using BE_CRM;
using System.Data.SqlClient;

namespace DAL_CRM
{
   public class reminderDal
    {
        DB db = new DB();
        public string Create(reminder r,user u )
        {
            r.user = db.users.Find(u.id);
            db.reminders.Add(r);
            db.SaveChanges();
            return "ثبت شد";
        }
        public DataTable read()
        {

            SqlCommand sqlCommand = new SqlCommand("dbo.allreminders");
            SqlConnection sqlConnection = new SqlConnection("Data Source=DESKTOP-LIAA3AM;Initial Catalog=database1;Integrated Security=true");
            // SqlCommand sqlCommand = new SqlCommand("dbo.reads");
           
            sqlCommand.Connection = sqlConnection;
            sqlCommand.CommandType = CommandType.StoredProcedure;
            var sqlDataAdapter = new SqlDataAdapter();
            sqlDataAdapter.SelectCommand = sqlCommand;
            var sqlCommandBuilder = new SqlCommandBuilder(sqlDataAdapter);
            var dataSet = new DataSet();
            sqlDataAdapter.Fill(dataSet);
            return dataSet.Tables[0];

        }
     


        public DataTable read(string s)
        {
            //SqlCommand sqlCommand = new SqlCommand();
            SqlConnection sqlConnection = new SqlConnection("Data Source=DESKTOP-LIAA3AM;Initial Catalog=database1;Integrated Security=true");
             SqlCommand sqlCommand = new SqlCommand("dbo.readreminder_searchbyUsername");
            sqlCommand.Parameters.AddWithValue("search", s);
            sqlCommand.Connection = sqlConnection;
            sqlCommand.CommandType = CommandType.StoredProcedure;
            var sqlDataAdapter = new SqlDataAdapter();
            sqlDataAdapter.SelectCommand = sqlCommand;
            var sqlCommandBuilder = new SqlCommandBuilder(sqlDataAdapter);
            var dataSet = new DataSet();
            sqlDataAdapter.Fill(dataSet);
            return dataSet.Tables[0];
        }
      
            public String update(int id,reminder c)
        {
            var q = db.reminders.Where(i => i.id == id).FirstOrDefault();


            try
            {
                if (q != null)
                {
                    q.reminderInfo = c.reminderInfo;
                    q.remindDate = c.remindDate;
                    q.title = c.title;

                    db.SaveChanges();
                    return "تغییرات با موفقیت انجام شد";
                }
                else
                {
                    return "یادآوری مورد نظر ثبت نشده است";
                }
            }
            catch (Exception e)
            {
                return "ویرایش با مشکل مواجه شد\n" + e.Message;
            }


        }
       public string delete(int id)
        {
            var q = db.reminders.Where(i => i.id == id).FirstOrDefault();


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
        public string  done(int id)
        {
            var q = db.reminders.Where(i => i.id == id).FirstOrDefault();


            try
            {
                if (q != null)
                {
                    q.isDone = true;

                    db.SaveChanges();
                    return " با موفقیت انجام شد ";
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
    }
}
