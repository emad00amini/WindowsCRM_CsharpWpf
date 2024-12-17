using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE_CRM;

namespace DAL_CRM
{
    public class productDal
    {
        DB db = new DB();
        public string Create(product p)
        {
            try
            {
                var q = db.products.Where(i => p.name == i.name).FirstOrDefault() ;
                if (q==null)
                {
                    db.products.Add(p);
                    db.SaveChanges();
                    return "ثبت شد";
                }
                else
                {
                    q.deleteStatus = false;
                    q.price = p.price;
                    q.stock = p.stock;
                    db.SaveChanges();
                    return "دوباره ثبت شد";
                }
               
            }
            catch (Exception e)
            {
                return "ثبت مشتری با مشکل مواجه شد\n" + e.Message;
            }

        }
        public DataTable read()
        {


            string cmd = "SELECT id AS id,  name AS [نام محصول], price AS [قیمت], stock AS [موجودی] FROM dbo.products WHERE(deleteStatus = 0)";
            SqlConnection sqlConnection = new SqlConnection("Data Source = .; Initial Catalog = database1; Integrated Security = true");
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd, sqlConnection);
            SqlCommandBuilder sqlCommandBuilder = new SqlCommandBuilder(sqlDataAdapter);
            DataSet dataSet = new DataSet();
            sqlDataAdapter.Fill(dataSet);
            return dataSet.Tables[0];



        }
        public DataTable read(string input)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "dbo.read_product";
            SqlConnection sqlConnection = new SqlConnection("Data Source=DESKTOP-LIAA3AM;Initial Catalog=database1;Integrated Security=true");
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
        public string delete(int id)
        {
            var q = db.products.Where(i => i.id == id).FirstOrDefault();


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

        public product read(int id)
        {
            return db.products.Where(i => i.id == id).FirstOrDefault();
        }
        public bool read(product c)
        {
            var q = db.products.Where(i => c.name == i.name).FirstOrDefault();

            if (q != null)
            {
                if (q.deleteStatus == true)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
            else
            {
                return true;
            }
        }

        public product readN(string s)
        {
            return db.products.Where(i => i.deleteStatus == false).Where(i => i.name == s).FirstOrDefault();
        }
        public List<string> readN()
        {
            return db.products.Where(i => i.deleteStatus == false).Select(i => i.name).ToList();
        }
        
        public string Update(int id,product c)
        {
            var q = db.products.Where(i => i.id == id).FirstOrDefault();
            var w = db.products.Where(i => i.name == c.name).FirstOrDefault();

            try
            {
                if (q != null)
                {
                    q.name = c.name;
                    q.price = c.price;
                    q.stock = c.stock;
                    db.SaveChanges();
                    return "تغییرات با موفقیت انجام شد";
                }
                else if (w != null)
                {
                    
                    w.name = c.name;
                    w.price = c.price;
                    w.stock = c.stock;
                    db.SaveChanges();

                    return "تغییرات غیر محاز با موفقیت انجام شد";
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
       
    }
}