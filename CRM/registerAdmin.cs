using FoxLearn.License;
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
using System.IO;

namespace CRM
{
    public partial class registerAdmin : UserControl
    {
        public registerAdmin()
        {
            InitializeComponent();
        }

        private void registerAdmin_Load(object sender, EventArgs e)
        {
            
            textBoxX2.Text = ComputerInfo.GetComputerId();
        }


        Timer t1 = new Timer();
        OpenFileDialog openfiledialog = new OpenFileDialog();
        Image image;
        userGroupBll ugbll = new userGroupBll();
        userBll ubll = new userBll();
        int y = 194;
       
        public void switchPanel() 
        {
            t1.Enabled = true;
            t1.Interval = 15;
            t1.Tick += tTick1;
            t1.Start();
        }
       
        public void tTick1(object sender, EventArgs e)
        {
            if (panel2.Location.Y < 800)
            {
                y = y + 15;
                panel2.Location = new Point(7, y);
            }
            else
            {
                t1.Stop();
                tTick2();
               
            }
        }
        public void tTick2()
        {
            if (ubll.readany())
            {
                //MessageBox.Show("there is");
                panel2.Visible = false;
                panel1.Visible = true;

            }
            else
            {
                panel2.Visible = false;
                panel1.Visible = true;
            }
        }
        userGroup CreateAdminUserGroup()
        {
            userGroup ug = new userGroup();
            ug.title = "مدیریت";

            //ug.userAccessRoles.Add(new userAccessRole { section ="بخش مشتری" , canEnter = true, canCreate = true, canDelete = true, canUpdate = true });
            //ug.userAccessRoles.Add(new userAccessRole { section = "بخش کالا ها", canEnter = true, canCreate = true, canDelete = true, canUpdate = true });
            //ug.userAccessRoles.Add(new userAccessRole { section = "بخش فاکتور ها", canEnter = true, canCreate = true, canDelete = true, canUpdate = true });
            //ug.userAccessRoles.Add(new userAccessRole { section = "بخش فعالیت ها", canEnter = true, canCreate = true, canDelete = true, canUpdate = true });
            //ug.userAccessRoles.Add(new userAccessRole { section = "بخش یادآور ها", canEnter = true, canCreate = true, canDelete = true, canUpdate = true });
            //ug.userAccessRoles.Add(new userAccessRole { section = "بخش کاربران", canEnter = true, canCreate = true, canDelete = true, canUpdate = true });
            //ug.userAccessRoles.Add(new userAccessRole { section = "بخش پیامکی", canEnter = true, canCreate = true, canDelete = true, canUpdate = true });
            //ug.userAccessRoles.Add(new userAccessRole { section = "بخش گزارشات", canEnter = true, canCreate = true, canDelete = true, canUpdate = true });
            //ug.userAccessRoles.Add(new userAccessRole { section = "بخش تنظیمات", canEnter = true, canCreate = true, canDelete = true, canUpdate = true });
            userAccessRole ual = new userAccessRole();
            ual.section = "بخش مشتری"; ual.canEnter = true; ual.canCreate = true; ual.canDelete = true; ual.canUpdate = true;
            ug.userAccessRoles.Add(ual);
            ual.section = "بخش کالا ها"; ual.canEnter = true; ual.canCreate = true; ual.canDelete = true; ual.canUpdate = true;
            ug.userAccessRoles.Add(ual);
            ual.section = "بخش فاکتور ها"; ual.canEnter = true; ual.canCreate = true; ual.canDelete = true; ual.canUpdate = true;
            ug.userAccessRoles.Add(ual);
            ual.section = "بخش فعالیت ها"; ual.canEnter = true; ual.canCreate = true; ual.canDelete = true; ual.canUpdate = true;
            ug.userAccessRoles.Add(ual);
            ual.section = "بخش یادآور ها"; ual.canEnter = true; ual.canCreate = true; ual.canDelete = true; ual.canUpdate = true;
            ug.userAccessRoles.Add(ual);
            ual.section = "بخش کاربران"; ual.canEnter = true; ual.canCreate = true; ual.canDelete = true; ual.canUpdate = true;
            ug.userAccessRoles.Add(ual);
            ual.section = "بخش پیامکی"; ual.canEnter = true; ual.canCreate = true; ual.canDelete = true; ual.canUpdate = true;
            ug.userAccessRoles.Add(ual);
            ual.section = "بخش گزارشات"; ual.canEnter = true; ual.canCreate = true; ual.canDelete = true; ual.canUpdate = true;
            ug.userAccessRoles.Add(ual);
            ual.section = "بخش تنظیمات"; ual.canEnter = true; ual.canCreate = true; ual.canDelete = true; ual.canUpdate = true;
            ug.userAccessRoles.Add(ual);
            return ug;


        }

        string savePath(string user)
        {
            string mainAddress = Path.GetDirectoryName(Application.ExecutablePath) + @"\UserPics\";
            if (!Directory.Exists(mainAddress))
            {
                Directory.CreateDirectory(mainAddress);
            }
            string picName = user + ".JPG";
            string picAddress = openfiledialog.FileName;
            File.Copy(picAddress, mainAddress + picName, true);
            return mainAddress + picName;
        }

        private void label1_Click(object sender, EventArgs e)
        {

            KeyManager km = new KeyManager(textBoxX2.Text);
            string productKey = textBoxX1.Text;
            if (km.ValidKey(ref productKey))
            {
                KeyValuesClass kv = new KeyValuesClass();
                if (km.DisassembleKey(productKey, ref kv))
                {
                    LicenseInfo lic = new LicenseInfo();
                    lic.ProductKey = productKey;
                    lic.FullName = "Personal accounting";
                    if (kv.Type == LicenseType.TRIAL)
                    {
                        lic.Day = kv.Expiration.Day;
                        lic.Month = kv.Expiration.Month;
                        lic.Year = kv.Expiration.Year;
                    }

                    km.SaveSuretyFile(string.Format(@"{0}\Key.lic", Application.StartupPath), lic);
                    MessageBox.Show("You have been successfully registered.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    switchPanel();
                }
            }
            else
                MessageBox.Show("Your product key is invalid.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);


        }

        private void label3_Click(object sender, EventArgs e)
        {
            userGroup ug = new userGroup();
            ug = CreateAdminUserGroup();
            ugbll.Create(ug);
            user u = new user();
            u.name = textBoxX6.Text;
            if (textBoxX5.Text == textBoxX4.Text)
            {
                u.password = textBoxX5.Text;
            }
            else
            {
                MessageBox.Show("تطابق ندارد");

            }
            u.userName = textBoxX3.Text;
            u.regDate = DateTime.Now;
            if (image != null)
            {
                u.pic = savePath(textBoxX3.Text);
            }
            
            if (u.password != null && u.pic!=null)
            {
                MessageBox.Show(new userBll().create(u,ug));
            }
            else MessageBox.Show("اول اطلاعات را کامل کنید");
           
        }

        private void label2_Click(object sender, EventArgs e)
        {

          

            openfiledialog.Filter = "JPG(*.JPG)|*.JPG";
            openfiledialog.Title = "انتخاب تصویر";
            if (openfiledialog.ShowDialog() == DialogResult.OK)
            {
                image = Image.FromFile(openfiledialog.FileName);
            }
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
