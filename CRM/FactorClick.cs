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
using Stimulsoft.Report;
using System.Windows.Forms;

namespace CRM
{
    public partial class FactorClick : Form
    {
        CustomerBll Cbll = new CustomerBll();
        productBll Pbll = new productBll();
        product p = new product();
        List<product> products = new List<product>();
        int sum = 0;
        customer c = new customer();
        invoiceBll invoiceBll = new invoiceBll();

        public FactorClick()
        {
            InitializeComponent();
        }

        private void textBoxX2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void FactorClick_Load(object sender, EventArgs e)
        {
            
           label17.Text = DateTime.Now.ToString("yyyy/MM/dd");
         

            AutoCompleteStringCollection CuNames = new AutoCompleteStringCollection();
            foreach (var item in Cbll.readP())
            {
                CuNames.Add(item);
            }
            textBoxX1.AutoCompleteCustomSource = CuNames;

            AutoCompleteStringCollection PrNames = new AutoCompleteStringCollection();
            foreach (var item in Pbll.readN())
            {
                PrNames.Add(item);
            }
            textBoxX2.AutoCompleteCustomSource = PrNames;
        }







        private void pictureBox4_Click(object sender, EventArgs e)
        {
            c = Cbll.readP(textBoxX1.Text);
            label15.Text = c.name;
            label16.Text = c.phoneNumber;
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            p=Pbll.readN(textBoxX2.Text);
            products.Add(p);
            dataGridView2.DataSource = null;
            dataGridView2.DataSource = products;
            dataGridView2.Columns["id"].Visible = false;
            dataGridView2.Columns["deleteStatus"].Visible = false;
            dataGridView2.Columns["stock"].Visible = false;
            dataGridView2.Columns["name"].HeaderText = "نام محصول";
            dataGridView2.Columns["price"].HeaderText = "قیمت محصول";
            textBoxX2.Text = "";
            string s = p.name + " به ارزش " + p.price.ToString("N0") + "اضافه شد";
            listBox1.Items.Add(s);

            sum = sum + p.price;
            label18.Text = sum.ToString("C0");
            label19.Text =(sum- Convert.ToInt64(textBoxX4.Text)).ToString("N0");
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            invoice invoice = new invoice();
            invoice.regdate = DateTime.Now;
            if (checkBox2.Checked)
            {
                invoice.isCheckedOut = true;
                invoice.checkoutDate = DateTime.Now;
            }
            else
            {
                invoice.isCheckedOut = false;
            }
            DialogResult res= MessageBox.Show( invoiceBll.create(invoice, c, products),"factor؟", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            
            if (res==DialogResult.Yes)
            {
                StiReport stiReport = new StiReport();
                stiReport.Load(@"D:\visual\CRM\stimulsoft\Report.mrt");
                stiReport.Dictionary.Variables["invoiceNum"].Value = invoiceBll.readInvoiceNum();
                stiReport.Dictionary.Variables["date"].Value = label17.Text;
                stiReport.Dictionary.Variables["custName"].Value = label9.Text;
                stiReport.RegBusinessObject("product", products);
                stiReport.Render();
                stiReport.Show();
            }
           

        }
    }
}
