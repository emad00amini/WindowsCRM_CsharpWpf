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

   
  public  class userBll
    {
        userDal userDal = new userDal();
        private string enconde(string pass)
        {
            byte[] encdata_byte = new byte[pass.Length];
            encdata_byte = System.Text.Encoding.UTF8.GetBytes(pass);
            string encodedData = Convert.ToBase64String(encdata_byte);
            return encodedData;
        }
        private string DecoAndGetServerName(string Servername)
        {
            System.Text.UTF8Encoding encoder = new System.Text.UTF8Encoding();
            System.Text.Decoder strDecoder = encoder.GetDecoder();
            byte[] to_DecodeByte = Convert.FromBase64String(Servername);
            int charCount = strDecoder.GetCharCount(to_DecodeByte, 0, to_DecodeByte.Length);
            char[] decoded_char = new char[charCount];
            strDecoder.GetChars(to_DecodeByte, 0, to_DecodeByte.Length, decoded_char, 0);
            string Name = new string(decoded_char);

            return Name;
        }
        public string create(user user,userGroup userGroup)
        {
            user.password = enconde(user.password);
            return userDal.create(user,userGroup);
        }

        public DataTable read()
        {
            return userDal.read();
        }
        public user read(int id)
        {
            return userDal.read(id);
        }
        public bool read(user c)
        {
            return userDal.read(c);
        }
        public List<string> readu()
        {
            return userDal.readU();
        }
        public user readu(string s)
        {
            return userDal.readu(s);
        }
        public bool readany()
        {
            return userDal.readAny();
        }
        public string encoder(string s)
        {
            return enconde(s);
        }
        public string update(user c, int id)
        {
            c.password = enconde(c.password);
            return   userDal.Update(id, c);
        }
        public string delete(int id)
        {
            return userDal.delete(id);
        }
        public bool Access(user u,string s,int a    )
        {
            return userDal.Access(u, s, a);
        }
    }
}
