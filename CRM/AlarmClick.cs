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
namespace CRM
{
    public partial class AlarmClick : Form
    {
        public AlarmClick()
        {
            InitializeComponent();
        }
        ReminderBll ReminderBll = new ReminderBll();
        userBll userBll = new userBll();
        user u = new user();
        private void AlarmClick_Load(object sender, EventArgs e)
        {
            AutoCompleteStringCollection usernames = new AutoCompleteStringCollection();
            foreach(var item in userBll.readu())
            {
                usernames.Add(item);
            }

            textBoxX1.AutoCompleteCustomSource = usernames;
        }

        private void textBoxX1_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            textBoxX1.Enabled = false;
            u=userBll.readu(textBoxX1.Text);
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            reminder r = new reminder();
            
            r.title = textBoxX2.Text;
            r.reminderInfo = richTextBox1.Text;
            r.remindDate = dateTimeInput2.Value;
            r.regDate = DateTime.Now;
            MessageBox.Show(ReminderBll.Create(r,u));
        }
    }
}
