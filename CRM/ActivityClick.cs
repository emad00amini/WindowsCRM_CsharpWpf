using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BE_CRM;
using BLL_CRM;

namespace CRM
{
    public partial class ActivityClick : Form
    {
        public ActivityClick()
        {
            InitializeComponent();
        }

        groupBll groupBll = new groupBll();
        CustomerBll CustomerBll = new CustomerBll();
        userBll userBll = new userBll();
        activityBll activityBll = new activityBll();
        ReminderBll ReminderBll = new ReminderBll();
        public int id;
        public void datagridviewReload()
        {
            dataGridView2.DataSource = null;
            dataGridView2.DataSource = activityBll.read();
            dataGridView2.Columns["id"].Visible = false;
        }
        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void ActivityClick_Load(object sender, EventArgs e)
        {
            AutoCompleteStringCollection category = new AutoCompleteStringCollection();
            foreach (var item in groupBll.readN())
            {
               category.Add(item);
            }

            textBoxX5.AutoCompleteCustomSource = category;





            AutoCompleteStringCollection Cnames = new AutoCompleteStringCollection();
            foreach (var item in CustomerBll.readN())
            {
                Cnames.Add(item);
            }

            textBoxX1.AutoCompleteCustomSource = Cnames;


            AutoCompleteStringCollection Unames = new AutoCompleteStringCollection();
            foreach (var item in userBll.readu())
            {
                Unames.Add(item);
            }

            textBoxX2.AutoCompleteCustomSource = Unames;

        }
        customer customer = new customer();
        user user = new user();
        activityCategory activityCategory=new activityCategory();
      

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            customer = CustomerBll.readN(textBoxX1.Text);
                textBoxX1.Enabled = false;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            user = userBll.readu(textBoxX2.Text);
            textBoxX2.Enabled = false;
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            activityCategory = groupBll.readN(textBoxX5.Text);
            textBoxX5.Enabled = false;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            activity activity = new activity();
           
            activity.regDate = DateTime.Now;
            activity.title = textBoxX3.Text;
            activity.info = textBox1.Text;
            activityBll.Create(activity, customer, user, activityCategory);
            if (checkBox1.Checked)
            {
                reminder reminder = new reminder();
                reminder.title = textBoxX3.Text;
                reminder.regDate = DateTime.Now;
                reminder.reminderInfo = textBox1.Text;
                reminder.remindDate = dateTimeInput1.Value;
                ReminderBll.Create(reminder, user);
            }
            dataGridView2.DataSource = null;
            dataGridView2.DataSource= activityBll.read();

        }

        private void textBoxX1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxX2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxX3_TextChanged(object sender, EventArgs e)
        {

        }

        

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            contextMenuStrip1.Show(Cursor.Position.X, Cursor.Position.Y);
            id = Convert.ToInt32(dataGridView2.Rows[dataGridView2.CurrentRow.Index].Cells["id"].Value);
        }
        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            activityBll.delete(id);
            datagridviewReload();
        }
    }
}
