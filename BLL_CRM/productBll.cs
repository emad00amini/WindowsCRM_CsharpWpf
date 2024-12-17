using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE_CRM;
using DAL_CRM;

namespace BLL_CRM
{
   public class productBll
    {

        productDal productDal = new productDal();






        public string create(product p)
        {
         
            if (productDal.read(p))
            {

            }
         return productDal.Create(p);
        }






    public DataTable read()
        {
         return  productDal.read();
        }
    public DataTable read(string s)
        {
            return productDal.read(s);
        }

        public product read(int id)
        {
            return productDal.read(id);
        }
        public bool read(product p)
        {
            return productDal.read(p);
        }
        public product readN(string s)
        {
            return productDal.readN(s);
        }
        public List<string> readN()
        {
            return productDal.readN();
        }






        public string delete(int id)
        {
            return productDal.delete(id);
        }

        public string update(int id ,product product)
        {
            return productDal.Update(id ,product);
        
        }
       


    }

}
