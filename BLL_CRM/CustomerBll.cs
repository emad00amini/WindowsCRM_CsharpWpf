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
    public class CustomerBll
    {
        CustomerDal customerDal = new CustomerDal();
        public string Create(customer c)
        {
            if (customerDal.read(c))
            {
               return customerDal.Create(c);
            }
            else
            {
                return "تکراری است ";
            }

        }

        public DataTable  read(string input,int condition)
        {
           return customerDal.read(input,condition);
        }
        public DataTable read()
        {
            return customerDal.read();
        }
        public customer read(int id)
        {
           return customerDal.read(id);
        }
        public bool read(customer c)
        {
            return customerDal.read(c);
        }
        public List<string> readN()
        {
            return customerDal.readN();
        }

        public List<string> readP()
        {
            return customerDal.readP();
        }
        public customer readN(string s)
        {
            return customerDal.readN(s);
        }
        public customer readP(string s)
        {
            return customerDal.readP(s);
        }
        public void update(customer c, int id)
        {
            customerDal.Update(id,c);
        }

        public string delete(int id)
        {
          return  customerDal.delete(id);
        }
    }
}
