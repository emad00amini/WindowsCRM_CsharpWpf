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
using BLL_CRM;

namespace CRM
{
    public partial class loginForm : Form
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
        public loginForm()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 10, 10));
        }
        Timer Timer1 = new Timer();
        registerAdmin r = new registerAdmin();
        userBll ubll = new userBll();
        loginUserUC l = new loginUserUC();
        private void loginForm_Load(object sender, EventArgs e)
        {
            Timer1.Enabled = true;
            Timer1.Interval = 20;
            Timer1.Tick += TTick1;
            Timer1.Start();
        }
        private void TTick1(object sender, EventArgs e)
        {
            if (progressBarX1.Value <= 80)
            {
                progressBarX1.Value++;
            }
            else
            {
                
                Timer1.Stop();
                label1.Visible = false;
                progressBarX1.Visible = false;
                if (ubll.readany())
                {
                    this.Controls.Add(l);
                    this.Controls["loginUserUC"].Location = new Point(209, 27);

                }
                else
                {
                    this.Controls.Add(r);
                    this.Controls["registerAdmin"].Location = new Point(209, 27);

                }

            }
            
        }

        private void progressBarX1_Click(object sender, EventArgs e)
        {

        }
    }
}