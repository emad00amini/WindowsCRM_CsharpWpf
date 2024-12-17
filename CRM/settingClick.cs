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
    public partial class settingClick : Form
    {
        public settingClick()
        {
            InitializeComponent();
        }
        groupBll groupbll = new groupBll();
        public void EmptyTextboxes()
        {
            textBoxX1.Text = "";
           
        }
        public void datagridviewReload()
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource =groupbll.read();
            dataGridView1.Columns["id"].Visible = false;
            dataGridView1.Columns["DeleteStatus"].Visible = false;

        }
        private void setting_Load(object sender, EventArgs e)
        {
            datagridviewReload();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            activityCategory g = new activityCategory();
            g.categoryName = textBoxX1.Text;
            MessageBox.Show(groupbll.Create(g));
            EmptyTextboxes();
            datagridviewReload();
        }
    }
}
