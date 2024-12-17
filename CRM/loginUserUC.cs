using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL_CRM;
using BE_CRM;
using System.Windows;



namespace CRM
{
    public partial class loginUserUC : UserControl
    {
        public loginUserUC()
        {
            InitializeComponent();
        }
        userBll ubll = new userBll();
        user u = new user();

        public void passverify(string s)
        {
            if (u.password ==ubll.encoder(s))
            {
                MainWindow w = (MainWindow)System.Windows.Application.Current.Windows.OfType<Window>().FirstOrDefault();
                w.u = u;
                ((loginForm)System.Windows.Forms.Application.OpenForms["loginForm"]).Close();
            }
            else
            {
                System.Windows.MessageBox.Show("اطلاعات وارد شده درست نیست");
            }
        }


        private void buttonX1_Click(object sender, EventArgs e)
        {
            u = ubll.readu(textBoxX2.Text);
            if (u != null)
            {
                passverify(textBoxX1.Text);
            }
            else
            {
                System.Windows.MessageBox.Show("کاربر یافت نشد");
            }
        }

        private void loginUserUC_Load(object sender, EventArgs e)
        {

        }
    }
}
