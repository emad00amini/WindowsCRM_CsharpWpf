using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE_CRM;
using System.Data.SqlClient;
using System.Data;


namespace DAL_CRM
{
    public class CustomerDal
    {
        DB db = new DB();

        public string Create(customer c)
        {
            try
            {
                db.customers.Add(c);
                db.SaveChanges();
                return "ثبت شد";
            }
            catch (Exception e)
            {
                return "ثبت مشتری با مشکل مواجه شد\n" + e.Message;
            }


        }
        public bool read(customer c)
        {
            var q = db.customers.Where(i => c.phoneNumber == i.phoneNumber).Where(i => i.deleteStatus == false);
            var w = db.customers.Where(i => c.name == i.name).Where(i => i.deleteStatus == false);


            
            if (q.Count() >= 1 || w.Count()>=1)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public DataTable read()
        {


            string cmd = "SELECT id AS id,  name AS [نام مشتری], phoneNumber AS [شماره تماس], regdate AS [تاریخ ثبت نام] FROM dbo.customers WHERE(deleteStatus = 0)";
            SqlConnection sqlConnection = new SqlConnection("Data Source = .; Initial Catalog = database1; Integrated Security = true");
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd, sqlConnection);
            SqlCommandBuilder sqlCommandBuilder = new SqlCommandBuilder(sqlDataAdapter);
            DataSet dataSet = new DataSet();
            sqlDataAdapter.Fill(dataSet);
            return dataSet.Tables[0];



        }
        public DataTable read(string input, int index)
        {
            SqlCommand sqlCommand = new SqlCommand();
            if (index ==1)
            {
                sqlCommand.CommandText = "dbo.readsCustomersByName";
            }
            if (index == 2)
            {
                sqlCommand.CommandText = "dbo.readsCustomersByNumber";
            }
            if (index == 0)
            {
                sqlCommand.CommandText = "dbo.readsCustomers";
            }
            SqlConnection sqlConnection = new SqlConnection("Data Source=DESKTOP-LIAA3AM;Initial Catalog=database1;Integrated Security=true");
        // SqlCommand sqlCommand = new SqlCommand("dbo.reads");
            sqlCommand.Parameters.AddWithValue("search", input);
            sqlCommand.Connection = sqlConnection;
            sqlCommand.CommandType = CommandType.StoredProcedure;
            var sqlDataAdapter = new SqlDataAdapter();
            sqlDataAdapter.SelectCommand = sqlCommand;
            var sqlCommandBuilder = new SqlCommandBuilder(sqlDataAdapter);
            var dataSet = new DataSet();
            sqlDataAdapter.Fill(dataSet);
            return dataSet.Tables[0];

                    

        }
        public customer read(int id)
        {
            return db.customers.Where(i => i.deleteStatus == false).Where(i => i.id == id).FirstOrDefault();
        }
        public  List<string> readN()
        {
            return db.customers.Where(i => i.deleteStatus == false).Select(i => i.name).ToList() ;
        }
        public List<string> readP()
        {
            return db.customers.Where(i=>i.deleteStatus==false).Select(i => i.phoneNumber).ToList();
        }
        public customer readN(string s)
        {
            return db.customers.Where(i => i.name == s).FirstOrDefault();
        }
        public customer readP(string s)
        {
            return db.customers.Where(i => i.phoneNumber == s).FirstOrDefault();
        }

        public string Update(int id,customer c)
        {
            var q = db.customers.Where(i => i.id == id).FirstOrDefault();


            try
            {
                if (q != null)
                {
                    q.name = c.name;
                    q.phoneNumber = c.phoneNumber;
                    db.SaveChanges();
                    return "تغییرات با موفقیت انجام شد";
                }
                else
                {
                    return "مشتری مورد نظر ثبت نشده است";
                }
            }
            catch(Exception e)
            {
                return "ویرایش با مشکل مواجه شد\n" + e.Message;
            }

           

        }
        public string delete(int id)
        {
            var q = db.customers.Where(i => i.id == id).FirstOrDefault();


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






    }
}
