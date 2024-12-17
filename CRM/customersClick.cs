using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BE_CRM;
using BLL_CRM;


namespace CRM
{

    #region begin
    public partial class customersClick : Form
    {
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn
       (
           int nLeftRect,     // x-coordinate of upper-left corner
           int nTopRect,      // y-coordinate of upper-left corner
           int nRightRect,    // x-coordinate of lower-right corner
           int nBottomRect,   // y-coordinate of lower-right corner
           int nWidthEllipse, // width of ellipse
           int nHeightEllipse // height of ellipse
       );


        public customersClick()
        {

            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 10, 10));

        }
        #endregion








        #region variables and verbs
        CustomerBll customerBll = new CustomerBll();
        public int condition, id;
        public void EmptyTextboxes()
        {
            textBoxX1.Text = " ";
            textBoxX2.Text = " ";
        }
        public void datagridviewReload()
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = customerBll.read();
            dataGridView1.Columns["id"].Visible = false;
        }
        #endregion








        #region few usage

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBoxX2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxX1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }
        #endregion









        private void textBoxX4_TextChanged(object sender, EventArgs e)
        {


            if ((checkBox1.Checked & checkBox2.Checked) || (!checkBox2.Checked || !checkBox1.Checked))
            {
                condition = 0;
            }
            if (checkBox1.Checked && !checkBox2.Checked)
            {
                condition = 2;
            }
            if (checkBox2.Checked && !checkBox1.Checked)
            {
                condition = 1;
            }

            dataGridView1.DataSource = null;

            dataGridView1.DataSource = customerBll.read(textBoxX4.Text, condition);
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            contextMenuStrip1.Show(Cursor.Position.X, Cursor.Position.Y);
            id = Convert.ToInt32(dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells["id"].Value);
        }



        private void pictureBox1_Click(object sender, EventArgs e)
        {
            customer c = new customer();
            c.name = textBoxX1.Text;
            c.phoneNumber = textBoxX2.Text;
            if (customerBll.read(c))
            {

                c.regdate = DateTime.Now;
                MessageBox.Show(customerBll.Create(c));

            }
            else
            {
                customerBll.update(c, id);

            }
            EmptyTextboxes();
            datagridviewReload();

        }

        private void customersClick_Load(object sender, EventArgs e)
        {
            datagridviewReload();
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {

            textBoxX1.Text = customerBll.read(id).name.ToString();
            textBoxX2.Text = customerBll.read(id).phoneNumber.ToString();


        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            customerBll.delete(id);
            datagridviewReload();

        }
    }
}
