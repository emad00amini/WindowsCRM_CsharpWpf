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
    public partial class ProductsClick : Form
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


        public ProductsClick()
        {

            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 10, 10));

        }













        productBll productBll = new productBll();
        public void EmptyTextboxes()
        {
            textBoxX1.Text = " ";
            textBoxX2.Text = " ";
            textBoxX3.Text = " ";
        }
        public void datagridviewReload()
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = productBll.read();
            dataGridView1.Columns["id"].Visible = false;
        }
        int id=0;





            public void Form1_Load(object sender, EventArgs e)
        {
            datagridviewReload();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            product product = new product();
            product.name = textBoxX1.Text;
            product.price = Convert.ToInt32(textBoxX2.Text);
            product.stock = Convert.ToInt32(textBoxX3.Text);

            if (productBll.read(product))
            {
                MessageBox.Show(productBll.create(product));
            }
            else  
            {
              MessageBox.Show(  productBll.update(id, product));
                id = 0;
               
            }
         
            EmptyTextboxes();
            datagridviewReload();


        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void textBoxX4_TextChanged(object sender, EventArgs e)
        {

           

            dataGridView1.DataSource = null;

            dataGridView1.DataSource = productBll.read(textBoxX4.Text);
        }

        private void ویرایشToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBoxX1.Text = productBll.read(id).name.ToString() ;
            textBoxX2.Text = productBll.read(id).price.ToString();
            textBoxX3.Text = productBll.read(id).stock.ToString();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
          MessageBox.Show(productBll.delete(id));
            datagridviewReload();
        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
        
        }

        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            contextMenuStrip1.Show(Cursor.Position.X, Cursor.Position.Y);
            id = Convert.ToInt32(dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells["id"].Value);
        }
    }
    }

